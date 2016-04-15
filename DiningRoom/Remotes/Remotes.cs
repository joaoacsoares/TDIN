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
            return AllOrders;

        }

        public List<Order> GetPendingOrders()
        {
            return AllOrders.FindAll(x => x.status == 0);
        }

        public List<Order> GetPreparingOrders()
        {
            return AllOrders.FindAll(x => x.status == 1);
        }

        public List<Order> GetReadyOrders()
        {
            return AllOrders.FindAll(x => x.status == 2);
        }



        public void setOrderPreparing(int t)
        {
            AllOrders.Find(x => x.id == t).status = 1;
        }


        public void setOrderReady(int t)
        {
            AllOrders.Find(x => x.id == t).status = 2;
        }

        public void setOrderDone(int t)
        {
            AllOrders.Find(x => x.id == t).status = 3;
        }

        public void setOrderPay(int t)
        {
            AllOrders.Find(x => x.id == t).status = 4;
        }

        public void setOrderClosed(int t)
        {
            AllOrders.Find(x => x.id == t).status = 5;
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
            
        }

    }

}
