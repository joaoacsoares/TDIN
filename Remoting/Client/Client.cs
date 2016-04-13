using System;
using System.Runtime.Remoting;

class Client
{ 
  static void Main(string[] args)
  {
    RemotingConfiguration.Configure("Client.exe.config");
    Order obj = new Order(); 
    obj.addItemToOrder(); 
  }
}
