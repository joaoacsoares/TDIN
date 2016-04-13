using System;
using System.Runtime.Remoting;

class Server
{
   
  static void Main(string[] args)
  {
    RemotingConfiguration.Configure("Server.exe.config");
    Console.WriteLine("Press return to exit");
    Console.ReadLine();
  }
}
