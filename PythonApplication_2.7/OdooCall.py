import xml_rpc
Odoo = xml_rpc.XmlRpc()
sUrl = 'https://packsmart-sla-7785082.dev.odoo.com'
sDB = 'packsmart-sla-7785082'
sUser = 'smuroyan@packsmartinc.com'
sPass = 'Qwerty123'
result = Odoo.login(sUrl,sDB,sUser,sPass)
abc = Odoo.getNextRange(20)
print(result,abc)




 