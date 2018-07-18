1.启动consul 
consul agent -server -datacenter=dc1 -bootstrap -data-dir ./data -config-file ./conf -ui-dir ./dist -node=n1 -bind 172.16.3.185 -client=0.0.0.0