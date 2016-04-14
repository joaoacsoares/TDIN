﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Remotes;
using System.Runtime.Remoting;

namespace Server
{
    class Server
    {
        public static IOrders ordersList;
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure("Server.exe.config", false);
            ordersList = (IOrders)Activator.GetObject(typeof(IOrders), "tcp://localhost:9000/Server/OrdersServer");
            Console.WriteLine("[Server]: Press Enter Key to Verify if any table is ready to pay!");
            Console.ReadLine();
            List<Order> tmp = new List<Order>();
            int tab = -1;
            float auxi = 0;
            while (true) { 
            foreach(Order o in ordersList.GetAllOrders())
            {
                if(o.status == 4)
                {
                    tab = o.table;
                       // Console.WriteLine(o.name);
                    tmp.Add(o);
                }
            }
            if(tab == -1)
                {
                    Console.WriteLine("[Server]: No tables are ready to pay");
                }
                else
                {
                    Console.WriteLine("[Server]: Table " + tab + " is ready to pay");
                    foreach (Order t in tmp)
                    {
                        auxi += t.price;
                        Console.WriteLine("Ordered:" + t.name + " - " + t.price);
                    }
                    Console.WriteLine("Total of:" + auxi);
                    Console.WriteLine("[Server]: Have they payed (Y)/(N)");
                    string a = Console.ReadLine();
                    if (a.Equals("Y")) {
                        foreach(Order ord in ordersList.GetAllOrders())
                        {
                            ordersList.setOrderClosed(ord.id);
                        }
                    }
                    else if (a.Equals("N")) {
                        Console.WriteLine("[Server]: Ok!");
                        tmp.Clear();
                        auxi = 0;
                    }
                    else {
                        Console.WriteLine("[Server]: Canceling...");
                        tmp.Clear();
                        auxi = 0;
                    }
                }
                Console.WriteLine("[Server]: Today's Orders:");
                float auxiliar = 0.0F;
                foreach (Order o in ordersList.GetAllOrders())
                {
                    
                    if(o.status == 5)
                    {
                        Console.WriteLine("Order: " + o.name + " - " + "Table :" + o.table + " - " + "Price : " + o.price);
                        auxiliar = auxiliar + o.price;
                    }
                }
                Console.WriteLine("[Server]: Received a total of :" + auxiliar + " today!");
                Console.WriteLine("[Server]: Press Enter Key to Verify if any other table is ready to pay!");
            Console.ReadLine();
            }
            }
        }
    }

