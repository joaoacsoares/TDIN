﻿using System;
using System.Runtime.Remoting;

class Server {
  static void Main(string[] args) {
    RemotingConfiguration.Configure("Server.exe.config", false);
    Console.WriteLine("[Server]: Press Enter Key to exit.");
    Console.ReadLine();
  }
}
