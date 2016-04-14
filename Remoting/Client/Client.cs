using System;
using System.Collections;
using System.Collections.Generic;

using System.Runtime.Remoting;



using System.Text;


class Client{
    
    private static EventIntermediate inter ;
    private static IOrders ordersList;
    //private Client run;

    //Client() {
    //   // Text = "Preparation Room";
    //    try
    //    {
    //        RemotingConfiguration.Configure("Client.exe.config", false);
    //        inter = new EventIntermediate();
    //        ordersList = (IOrders)Activator.GetObject(typeof(IOrders), "tcp://localhost:9000/Server/OrdersServer");
    //        ordersList.AddingOrder += inter.FireAddingOrder;
    //        //ordersList.PreparingOrder += inter.FirePreparingOrder;
    //        //ordersList.ReadyOrder += inter.FireReadyOrder;

    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine(ex.Message);
    //    }
    //}

    public object InitializeLifetimeService()
    {
        Console.WriteLine("[Kitchen]: InitilizeLifetimeService");
        return null;
    }

    static void Main(string[] args)
    {


        RemotingConfiguration.Configure("Client.exe.config", false);
        inter = new EventIntermediate();

        ordersList = (IOrders)Activator.GetObject(typeof(IOrders), "tcp://localhost:9000/Server/OrdersServer");

        List<Order> ReceivedOrders = ordersList.GetAllOrders();
        foreach(Order o in ReceivedOrders)
        {
            Console.WriteLine(o.id);
        }
        ordersList.Add("meu", "cois2", 1, 1, 1);

        ReceivedOrders.Clear();
        ReceivedOrders = ordersList.GetAllOrders();
        foreach (Order o in ReceivedOrders)
        {
            Console.WriteLine(o.id);
        }
        //ordersList.AddingOrder += inter.FireAddingOrder;
        //ordersList.PreparingOrder += inter.FirePreparingOrder;
        //ordersList.ReadyOrder += inter.FireReadyOrder;

    }
}


//  static void Main(string[] args) {
//    RemotingConfiguration.Configure("Client.exe.config", false);
//    IClient entities = (IEntity) RemoteNew.New(typeof(IEntity));
//    Intermediate inter = new Intermediate(entities);
//    inter.newClient += OnNewClient;

//    Entity myEntity = entities.GetNewEntity();
//    Console.WriteLine("[Client]: My entity is (Id=" + myEntity.Id.ToString() + ", Name=" + myEntity.Name + ")");
//    Console.ReadLine();
//    IProcessFactory factory = (IProcessFactory)RemoteNew.New(typeof(IProcessFactory));
//    IProcess processor = factory.GetNewProcessor(myEntity);
//    Console.WriteLine("[Client]: Get Processor with Value=" + processor.Value.ToString());
//    Console.ReadLine();
//    string res = processor.ProcessValue();
//    Console.WriteLine("[Client]: processing1: " + res);
//    Console.ReadLine();
//    IProcess processor2 = factory.GetNewProcessor(myEntity);
//    Console.WriteLine("[Client]: Get Processor with Value=" + processor2.Value.ToString());
//    Console.ReadLine();
//    res = processor2.ProcessValue();
//    Console.WriteLine("[Client]: processing2: " + res);
//    Console.ReadLine();

//    inter.newClient -= OnNewClient;
//    entities.newEntity -= inter.FireNewClient;
//  }

//  static void OnNewClient(Entity newClient) {
//    Console.WriteLine("[Client]: Event handler called for " + newClient.Name + " Id: " + newClient.Id.ToString());
//  }
//}

//class RemoteNew {
//  private static Hashtable types = null;

//  private static void InitTypeTable() {
//    types = new Hashtable();
//    foreach (WellKnownClientTypeEntry entry in RemotingConfiguration.GetRegisteredWellKnownClientTypes())
//      types.Add(entry.ObjectType, entry);
//  }

//  public static object New(Type type) {
//    if (types == null)
//      InitTypeTable();
//    WellKnownClientTypeEntry entry = (WellKnownClientTypeEntry)types[type];
//    if (entry == null)
//      throw new RemotingException("Type not found!");
//    return RemotingServices.Connect(type, entry.ObjectUrl);
//  }

