using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Remoting;

  class DiningRoom
    {
        private static EventIntermediate inter;  
        private static IOrders ordersList;
        static void Main()
        {
            RemotingConfiguration.Configure("Room.exe.config", false);
            inter = new EventIntermediate();

            ordersList = (IOrders)Activator.GetObject(typeof(IOrders), "tcp://localhost:9000/Server/OrdersServer");
            ordersList.AddingOrder += inter.FireAddingOrder;
        }
    }

