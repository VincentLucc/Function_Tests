import xml_rpc
import ast


x = '[["PS6179=S2-0071","PS6179=S2-0071"],["PS6180=S2-0071","PS6180=S2-0071"]]'
y= ast.literal_eval(x)

Odoo = xml_rpc.XmlRpc()
sUrl = 'https://packsmart-commission-7825415.dev.odoo.com'
sDB = 'packsmart-commission-7825415'
sUser = 'smuroyan@packsmartinc.com'
sPass = 'Qwerty123'
result = Odoo.login(sUrl,sDB,sUser,sPass)
abc = Odoo.getNextRange(20)
sABC='[["PS7037=S2-0058-2", "abc"],["PS7037=S2-0058-2","abc"],["PS7039=S2-0058-2","abc"]]'
abc = Odoo.validateMO(6562,sABC)
print(result,abc)




 