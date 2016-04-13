﻿using System;
using System.Collections.Generic;

//Delegates
public delegate void AddOrderEventHandler();
public delegate void PreparingOrderEventHandler();
public delegate void ReadyOrderEventHandler();
public delegate void DeliveringOrderEventHandler();
public delegate void FinalizingOrderEventHandler();

[Serializable]
public class Client {
    public DateTime timestamp;

    public int id { get; set; }
    public string name { get; set; }

    public Client(int i, string n)
    {
        id = i;
        name = n;
    }
}


[Serializable]
public class Order
{
    public int id { get; set; }
    public int idClient { get; set; }
    public String name { get; set; }
    public String description { get; set; }
    public int quantity { get; set; }
    public float price { get; set; }
    public Client client { get; set; }

    /*
    *  0 - kitchen | 1 - bar | 2 - both
    */
    public int responsable { get; set; }
    /*
   * 0 - não atendido | 1 - em preparação | 2 - pronto
   */
    public int status { get; set; }


    public Order(int i, int idC, string n, String descript, int qt, float pr, int status, int resp)
    {
        id = i;
        idClient = idC;
        name = n;
        description = descript;
        price = pr;
        quantity = qt;
        this.status = status;
        responsable = resp;
    }
}


  public interface IOrders {
  
  event AddOrderEventHandler AddingOrder;
  event PreparingOrderEventHandler PreparingOrder;
  event ReadyOrderEventHandler ReadyOrder;
  event DeliveringOrderEventHandler DeliveringOrder;
  event FinalizingOrderEventHandler FinalizingOrder;

  void Add(string name, string add, int cc, int tp, int qt);
  List<Order> GetCostumerOrders(string name);
  List<Order> GetAllOrders();
  List<Order> GetOrdedOrders();
  List<Order> GetPreparingOrders();
  List<Order> GetReadyOrders();
  List<Order> GetDeliveringOrders();
  void setOrderPreparing(string t);
  void setOrderReady(string t);
  void setOrderDelivering(string t, string team);
  void setOrderDone(string t);


}

public class EventIntermediate : MarshalByRefObject
{
    public event AddOrderEventHandler AddingOrder;
    public event PreparingOrderEventHandler PreparingOrder;
    public event ReadyOrderEventHandler ReadyOrder;
    public event DeliveringOrderEventHandler DeliveringOrder;
    public event FinalizingOrderEventHandler FinalizingOrder;

    public void FireAddingOrder()
    {
        AddingOrder();
    }

    public void FirePreparingOrder() 
    {
        PreparingOrder();
    }

    public void FireReadyOrder()
    {
        ReadyOrder();
    }

    public void FireDeliveringOrder()
    {
        DeliveringOrder();
    }


    public override object InitializeLifetimeService()
    {
        Console.WriteLine("[EventIntermediate]: InitilizeLifetimeService");
        return null;
    }

}
