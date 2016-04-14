using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.Remoting;
using Common;
using Remotes;

namespace DiningRoom
{
    class DiningRoom
    {
        private static EventIntermediate inter;
        private static IOrders ordersList;
        public object InitializeLifetimeService()
        {
            Console.WriteLine("[DiningRoom]: InitilizeLifetimeService");
            return null;
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            RemotingConfiguration.Configure("DiningRoom.exe.config", false);
            inter = new EventIntermediate();
            ordersList = (IOrders)Activator.GetObject(typeof(IOrders), "tcp://localhost:9000/Server/OrdersServer");
            List<Order> ReceivedOrders = ordersList.GetAllOrders();
            Application.EnableVisualStyles(); 
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
