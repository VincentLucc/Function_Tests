#import xmlrpclib
import sys
import os

# In c# this part need to be coded in ironpython
sys.path
path = sys.argv[0]
path=os.path.dirname(path)+"\\Lib\\"
sys.path.append(path)


#import xmlrpc.client
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

class XmlRpc1:

    #def __init__(self):
    #    path = sys.argv[0]
    #    sys.path.append(path)
      
     # Query list of open Manufacture Orders from Odoo. 
    def fetchManufactureOrders(self):
        global manufacture_order_list
        manufacture_order_list = models.execute_kw(db, uid, password, 'mrp.production', 'search_read',
                                       [[('state', 'in', ['confirmed', 'progress'])]],
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

    # Query list of open Manufacture Orders from Odoo. 
    def fetchManufactureOrdersOld(self):
        global manufacture_order_list
        manufacture_order_list = models.execute_kw(db, uid, password, 'mrp.production', 'search_read',
                                       [[('state', 'in', ['ready', 'progress'])]],
                                       {'fields': ['id', 'name', 'product_id', 'product_qty']})
        manufacture_orders = []
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


    # NOTE TO VINCENT: I am not sure what this is for. The old code seems like it is only adding the ID and Part Number.
    def getProductInfo(self, product_id):
        productInfo = []
        try:
            product_rec = models.execute_kw(db, uid, password, 'product.product', 'search_read',
                                                [[['id', '=', product_id]]],
                                                {'fields': ['engineering_code']})
            product_code = product_rec[0].get('engineering_code')
            productInfo.append(product_id)
            productInfo.append(product_code)
            return productInfo
        except Exception:
            return ''        
        return ''
     
    # Create (register) an activated tag's info in Odoo
    def registerTag(self, RFIDEPCTagInfo, RFIDTIDInfo,ProductID):
        try:
            serial_number_id = models.execute_kw(db, uid, password, 'stock.production.lot', 'create',
                                                 [{'name': RFIDEPCTagInfo, 'product_id': ProductID,
                                                   'company_id': 1, 'ref': RFIDTIDInfo}])
        except Exception:
            return -3 # Duplicate Tag
        return serial_number_id   
    
    # Apply Activated Tag to MO, validate, and return ID of next MO
    def validateMO(self, mo_id, serial_number_id):
        try:
            new_mo_id = models.execute_kw(db, uid, password, 'mrp.production', 'proceed', [[mo_id], serial_number_id])
        except Exception:
            return -1 # Odoo Server Error
        return new_mo_id
    
    def checkOdooStatus(self,serial_number_name):
        regID = models.execute_kw(db, uid, password, 'stock.production.lot', 'search',
                                         [[['name', 'like', serial_number_name]]], {'limit':1})
        if not regID:
            return -1  # Serial Number not registered in Odoo.
        else:
            mo_id = models.execute_kw(db, uid, password, 'mrp.production', 'search',
                                  [[['lot_producing_id', '=', regID]]])
        if not mo_id:
            return regID[0]  # Serial Number register in Odoo but MO not validated
        return 0  # Tag is fully activated


    # Request the next RFID sequence ('PS####') from Odoo and increase the counter by one.
    # NOTE TO VINCENT: This is the combined version of getRFIDNumber() and getNextRFIDNumber(). 
    # However, if the writing to tag fails, one number is skipped so you might have to consider that.
    def getNextSequenceNumber(self):
        sequence = models.execute_kw(db, uid, password, 'ir.sequence', 'next_by_code', [['rfid']])
        return sequence

    def getUserName(self):
        user_info = models.execute_kw(db, uid, password, 'res.users', 'search_read', [[['id', '=', uid]]], {'fields': ['name']})
        return user_info[0].get('name')

    def login(self, url, _db, username, _password):
        # Log in Odoo
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

        except (Exception):
            return -1 # Log-in Failed
                
        # Check if User should see the "Serialize Tag" Section
        try:
            has_serialize_rights = models.execute_kw(db, uid, password, 'res.groups', 'search',
                              [[['name', '=', 'Serialize RFID Tags'], ['users', 'in', uid]]])
            if has_serialize_rights:
                return 1 # Internal User (Can Serialize)
        except (Exception):
            return -2

        return 0 # External User (Cannot Serialize)



call=XmlRpc1()
sName="smuroyan@packsmartinc.com"
sPass="Qwerty123"
sUrl="https://packsmart-staging-4142084.dev.odoo.com"
sDB="packsmart-staging-4142084"
loginResult=call.login(sUrl,sDB,sName,sPass);
print(loginResult)


