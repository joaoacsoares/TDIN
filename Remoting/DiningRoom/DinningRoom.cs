using System;
using System.Collections;
using System.Collections.Generic;

using System.Runtime.Remoting;


    class DinningRoom 

    {
    private static EventIntermediate inter;
    private static IOrders ordersList; 

    static void Main(string[] args)
    {


        RemotingConfiguration.Configure("DinningRoom.exe.config", false);
        inter = new EventIntermediate();

        ordersList = (IOrders)Activator.GetObject(typeof(IOrders), "tcp://localhost:9000/Server/OrdersServer");
        Console.ReadLine();
        List<Order> ReceivedOrders = ordersList.GetAllOrders();
        foreach (Order o in ReceivedOrders)
        {
            Console.WriteLine(o.id);
            Console.WriteLine("finish");
        }
        /*List<Order> ReceivedOrders = ordersList.GetAllOrders();
        foreach (Order o in ReceivedOrders)
        {
            Console.WriteLine("start");
            Console.WriteLine(o.id);
        }
        ordersList.Add("meu", "cois2", 1, 1, 1);

        ReceivedOrders.Clear();
        ReceivedOrders = ordersList.GetAllOrders();
        foreach (Order o in ReceivedOrders)
        {
            Console.WriteLine(o.id);
            Console.WriteLine("finish");
        }*/
        //ordersList.AddingOrder += inter.FireAddingOrder;
        //ordersList.PreparingOrder += inter.FirePreparingOrder;
        //ordersList.ReadyOrder += inter.FireReadyOrder;

    }
}

