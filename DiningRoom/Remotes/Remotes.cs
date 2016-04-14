using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Common;

namespace Remotes
{
    public class TableOrders : MarshalByRefObject, IOrders 
    {
        private List<Order> AllOrders = new List<Order>();
        private List<Order> AllOrders1 = new List<Order>();
        private List<Order> AllOrders2 = new List<Order>();
        /*public event AddOrderEventHandler AddingOrder;
        public event PreparingOrderEventHandler PreparingOrder;
        public event ReadyOrderEventHandler ReadyOrder;
        public event FinalizingOrderEventHandler FinalizingOrder;*/


        public static TableOrders to;

        public TableOrders()
        {

        }

        public override object InitializeLifetimeService()
        {
            Console.WriteLine("[Orders]: InitilizeLifetimeService");
            return null;
        }

        public List<Order> GetAllOrders()
        {
            Console.WriteLine("[GetAllOrders] called.");
            return AllOrders;

        }

        public List<Order> GetPendingOrders()
        {
            Console.WriteLine("[GetPendingOrders] called.");
            return AllOrders.FindAll(x => x.status == 0);
        }

        public List<Order> GetPreparingOrders()
        {
            Console.WriteLine("[GetPreparingOrders] called.");
            return AllOrders.FindAll(x => x.status == 1);
        }

        public List<Order> GetReadyOrders()
        {
            Console.WriteLine("[GetReadyOrders] called.");
            return AllOrders.FindAll(x => x.status == 2);
        }



        public void setOrderPreparing(string t)
        {
            string[] words = t.Split('/');
            AllOrders.Find(x => x.name == words[0]).status = 1;
            //PreparingOrder();
        }


        public void setOrderReady(string t)
        {
            string[] words = t.Split('/');
            AllOrders.Find(x => x.name == words[0]).status = 2;
            //ReadyOrder();
        }

        public void setOrderDone(string t)
        {
            string[] words = t.Split('/');
            AllOrders.Find(x => x.name == words[0]).status = 3;
            //FinalizingOrder();
        }


        public void Add(string name, string description, int quant, int table, float price, string resp) 
        {
            int i = 0;
            foreach (Order o in AllOrders)
            {
                if (i != o.id)
                    break;
                else i++;
            }
            Order nO = new Order(i, table, name, description, quant, price, 0, resp);
            AllOrders.Add(nO);
            //AddingOrder();
            Console.WriteLine("[Add] called.");
            
        }

    }

    /*public class Entities : MarshalByRefObject, IEntity {
      private int nr = 1;
      string[] names = { "Peter", "John", "George", "Mary", "Michael", "Anthony" };
      public event HandlerNotify newEntity;
      public override object InitializeLifetimeService() {
        Console.WriteLine("[Entities]: InitilizeLifetimeService");
        return null;
      }
      public Entity GetNewEntity() {
        Entity ent = new Entity(nr, names[(nr-1)%names.Length]);
        Console.WriteLine("[Entities]: New entity created (" + nr.ToString() + ")");
        nr += 1;
        if (newEntity != null) {
          Delegate[] invkList = newEntity.GetInvocationList();
          foreach (HandlerNotify handler in invkList) {
            Console.WriteLine("[Entities]: Event triggered: invoking handler");
            new Thread(() => {
              try {
                handler(ent);
              }
              catch (Exception) {
                Console.WriteLine("[TriggerEvent]: Exception");
                newEntity -= handler;
              }
            }).Start();
          }
        }
        return ent;
      }
    }
    public class ProcessorFactory : MarshalByRefObject, IProcessFactory {
      ProcessorFactory() {
        Console.WriteLine("[Factory]: Constructed");
      }
      public IProcess GetNewProcessor(Entity client) {
        Console.WriteLine("[Factory]: New processor created for (" + client.Id.ToString() + ")");
        return new Processor(client);
      }
    }
    public class Processor : MarshalByRefObject, IProcess {
      Entity client;
      public double Value { get; set; }
      public Processor(Entity entity) {
        Random r = new Random();
        Value = 10.0 * r.NextDouble();
        client = entity;
        Console.WriteLine("[Processor]: Constructed");
      }
      public override object InitializeLifetimeService() {
        Console.WriteLine("[Processor]: InitilizeLifetimeService");
        return null;
      }
      public string ProcessValue() {
        Console.WriteLine("[Processor]: process called with " + Value.ToString());
        string result = "Value: " + Value.ToString() + " by ID: " + client.Id.ToString() + " Name: " + client.Name;
        return result;
      }
    }*/
}
