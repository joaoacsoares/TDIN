﻿using System;
using System.Collections.Generic;

namespace Common
{
    [Serializable]
    public class Order
    {
        public int id { get; set; }
        public int table { get; set; }
        public String name { get; set; }
        public String description { get; set; }
        public int quantity { get; set; }
        public float price { get; set; }
        /*
        *  0 - kitchen | 1 - bar | 2 - both
        */
        public string orderType { get; set; }
        /*
       * 0 - não atendido | 1 - em preparação | 2 - pronto
       */
        public int status { get; set; }


        public Order(int i, int idC, string n, String descript, int qt, float pr, int status, string resp)
        {
            id = i;
            table = idC;
            name = n;
            description = descript;
            price = pr;
            quantity = qt;
            this.status = status;
            orderType = resp;
        }

        
    }


    public interface IOrders
    {

        void Add(string name, string description, int quant, int table, float price, string resp);
        List<Order> GetAllOrders();
        List<Order> GetPendingOrders();
        List<Order> GetPreparingOrders();
        List<Order> GetReadyOrders();
        void setOrderPreparing(int t);
        void setOrderReady(int t);
        void setOrderPay(int t);
        void setOrderClosed(int t);


    }
}
