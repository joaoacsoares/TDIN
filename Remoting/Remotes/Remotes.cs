using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

public class TableOrders : MarshalByRefObject
{
    private List<Order> AOrders;
    public event AddOrderEventHandler AddingOrder;
    public event PreparingOrderEventHandler PreparingOrder;
    public event ReadyOrderEventHandler ReadyOrder;
    public event DeliveringOrderEventHandler DeliveringOrder;
    public event FinalizingOrderEventHandler FinalizingOrder;

    public TableOrders()
    {
        
    }

    public override object InitializeLifetimeService()
    {
        Console.WriteLine("[Orders]: InitilizeLifetimeService");
        return null;
    }

    public void Add(int i, int idC, string name, int qt, float preco, int status, int resp)
    {
        Order nO = new Order(i, idC, name," ", qt, preco, 0, resp);
        nO.id = AOrders.Count + 1;
        AOrders.Add(nO);
        AddingOrder();
        Console.WriteLine("[Add] called.");
    }

    public List<Order> GetCostumerOrders(string name)
    {
        List<Order> result = new List<Order>();

        foreach (Order or in AOrders)
            if (or.client.name == name)
                result.Add(or);
        Console.WriteLine("[GetCostumerOrders] called.");
        return result;
    }

    public List<Order> GetAllOrders()
    {
        Console.WriteLine("[GetAllOrders] called.");
        return AOrders;

    }

    public List<Order> GetOrdedOrders()
    {
        Console.WriteLine("[GetOrdedOrders] called.");
        return AOrders.FindAll(x => x.status == 0);
           
    }

    public List<Order> GetReadyOrders()
    {
        Console.WriteLine("[GetReadyOrders] called.");
        return AOrders.FindAll(x => x.status == 1);
    }

    public List<Order> GetDeliveringOrders()
    {
        Console.WriteLine("[GetDeliveringOrders] called.");
        return AOrders.FindAll(x => x.status == 2);
    }



    public void setOrderPreparing(string t)
    {

        AOrders.Find(x => x.id == Convert.ToInt32(t)).status = 0;
        PreparingOrder();
        AOrders.Find(x => x.id == Convert.ToInt32(t)).client.timestamp = DateTime.Now;
    }

    public void setOrderReady(string t)
    {
        AOrders.Find(x => x.id == Convert.ToInt32(t)).status = 1;
        ReadyOrder();
    }


    public void setOrderDone(string t)
    {
        AOrders.Find(x => x.id == Convert.ToInt32(t)).status = 2;
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
