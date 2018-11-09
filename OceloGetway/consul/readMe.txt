1.启动consul 
consul agent -server -datacenter=dc1 -bootstrap -data-dir ./data -config-file ./conf -ui -node=n1 -bind 172.16.3.248 -client=0.0.0.0