# TDIN
Tecnologias de Distribuição e Integração 
Trabalho nr. 1 Aplicação Distribuída em Intranet (.NET Remoting) 
Sistema de pedidos em restauração 
2015-2016


COMPILING AND EXECUTING INSTRUCTIONS 
1.
\Remoting\Common
csc /noconfig /t:library Common.cs
copy Common.dll into \Remoting\Client, \Remoting\Server, \Remoting\DiningRoom and \Remoting\Remotes

2.
\Remoting\Remotes
csc /noconfig /r:Common.dll /t:library Remotes.cs
copy Remotes.dll into \Remoting\Client, \Remoting\Server and \Remoting\DiningRoom

3.
\Remoting\Server
csc /noconfig /r:Common.dll /r:Remotes.dll Server.cs
type Server+Enter to run

3.1
\Remoting\Client
csc /noconfig /r:Common.dll /r:Remotes.dll Client.cs
type Client+Enter to run

3.2 (NOT WORKING YET)
\Remoting\DiningRoom
csc /noconfig /r:Common.dll /r:Remotes.dll DiningRoom.cs
type DiningRoom+Enter to run
