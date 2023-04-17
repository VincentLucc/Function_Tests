import xml_rpc
import ast
import datetime


x = '[["PS6179=S2-0071","PS6179=S2-0071"],["PS6180=S2-0071","PS6180=S2-0071"]]'
y = ast.literal_eval(x)

#Time
abc = datetime.datetime.today() 

Odoo = xml_rpc.XmlRpc()
sUrl = 'https://packsmart-sla-improvements-7903878.dev.odoo.com'
sDB = 'packsmart-sla-improvements-7903878'
sUser = 'smuroyan@packsmartinc.com'
sPass = 'Qwerty123'
result = Odoo.login(sUrl,sDB,sUser,sPass)

orderList = Odoo.fetchManufactureOrders()
sOrderID = orderList[0][0]
orderInfo = Odoo.getOrderDetail(sOrderID)

abc = Odoo.getNextRange(20)

sABC = '[["PS7037=S2-0058-2", "abc"],["PS7037=S2-0058-2","abc"],["PS7039=S2-0058-2","abc"]]'
abc = Odoo.validateMO(6562,sABC)
print(result,abc)




 