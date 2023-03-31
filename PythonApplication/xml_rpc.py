import sys
import xmlrpclib
import ssl
import logging

RFIDConnected = False
RFIDTagReady = False
RFIDEPCTagInfo = ''
uid = 0
password = ""
db = ""
models = 0
product_id = ""
production_id = ""
manufacture_order_list = ""




class XmlRpc:

     # Query list of open Manufacture Orders from Odoo. 
    def fetchManufactureOrders(self):
        global manufacture_order_list
        manufacture_order_list = models.execute_kw(db, uid, password, 'mrp.production', 'search_read',
                                               [[('state', 'in', ['confirmed', 'progress']), ('product_id', 'ilike', 'S2')]],
                                               {'fields': ['id', 'name', 'product_id', 'product_qty']})
        manufacture_orders = []
        
        if manufacture_order_list:
            try:
                for order in manufacture_order_list:
                    _product_id = order.get('product_id')
                    _production_id = order.get('id')
                    _production_name = order.get('name')
                    _product_qty = order.get('product_qty')

                    product_rec = models.execute_kw(db, uid, password, 'product.product', 'search_read',
                                                    [[['id', '=', _product_id[0]]]],
                                                    {'fields': ['engineering_code']})
                    eng_code = product_rec[0].get('engineering_code')

                    manufacture_orders.append([_production_id, _production_name, _product_id[0], eng_code, _product_id[1], _product_qty])
            except Exception:
                return -1 # Failed to fetch MO
        return manufacture_orders
    
    # Pass the ID of finished MO and a list of Serial Numbers used to Odoo
    def validateMO(self, mo_id, serial_list):
        try:
            models.execute_kw(db, uid, password, 'mrp.production', 'action_mass_produce_RFID', [[mo_id], serial_number_list])
        except Exception:
            return -1 # Odoo Server Error.
        return 1
    
    # Request the next RFID sequence ('PS####') from Odoo and increase the counter by one.
    def getNextSequenceNumber(self):
        sequence = models.execute_kw(db, uid, password, 'ir.sequence', 'next_by_code', [['rfid']])
        return sequence

    def getUserName(self):
        user_info = models.execute_kw(db, uid, password, 'res.users', 'search_read', [[['id', '=', uid]]], {'fields': ['name']})
        return user_info[0].get('name')

    # Log in Odoo
    def login(self, url, _db, username, _password):
        try:
            common = xmlrpclib.ServerProxy('{}/xmlrpc/common'.format(url),use_datetime=True, context=ssl._create_unverified_context())

            global uid
            uid = common.authenticate(_db, username, _password, {})

            global db
            db = _db

            global password
            password = _password

            global RFIDTagReady
            RFIDTagReady = True

            global models
            models = xmlrpclib.ServerProxy('{}/xmlrpc/2/object'.format(url),use_datetime=True,context=ssl._create_unverified_context())

        except Exception as ex:
            print('Login exception:'+str(ex))
            return -1 # Log-in Failed
                
        # Check user's access rights
        # TODO: Return a value
        try:
            can_mfg = models.execute_kw(db, uid, password, 'res.users', 'get_mfg_rights', [uid])
            can_test = models.execute_kw(db, uid, password, 'res.users', 'get_test_rights', [uid])
            can_debug = models.execute_kw(db, uid, password, 'res.users', 'get_debug_rights', [uid])
            iValue=can_mfg+can_test*2+can_debug*4
            return iValue
        except (Exception):
            return -2 # Failed to check Access Rights
        return -3 # User logged in, but he/she has no rights to perform any action