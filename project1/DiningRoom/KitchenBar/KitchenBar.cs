using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting;
using Common;
using Remotes;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace KitchenBar
{
    class KitchenBar
    {
        public static IOrders ordersList;
        public static List<Order> ReceivedOrders = new List<Order>();

        public object InitializeLifetimeService()
        {
            Console.WriteLine("[Kitchen/Bar]: InitilizeLifetimeService");
            return null;
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            RemotingConfiguration.Configure("KitchenBar.exe.config", false);
            
            Console.WriteLine("(0)Kitchen or (1)Bar or (2)Both!");
            string a = Console.ReadLine();
            ordersList = (IOrders)Activator.GetObject(typeof(IOrders), "tcp://localhost:9000/Server/OrdersServer");
            List<Order> ReceivedOrders = ordersList.GetAllOrders();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Int32.Parse(a) == 0)
            {
                Application.Run(new Form1(0));
            }
            else if (Int32.Parse(a) == 1)
            {
                Application.Run(new Form1(1));
            }
                else if (Int32.Parse(a) == 2)
            {
                Application.Run(new Form1(0));
                Application.Run(new Form1(1));
            }

                
           

        }

        
    }
}
