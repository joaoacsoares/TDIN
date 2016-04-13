using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TDIN1
{
    class Order : MarshalByRefObject
    {
        public int id;
        public int state; //0- não atendido 1-em preparação 2- pronto
        public ArrayList itemsOrdered = new ArrayList();
        public ArrayList quantities = new ArrayList();
        public Order()
        {
            id = 1;
            state = 0;
            itemsOrdered.Add(new MenuItem());
            quantities.Add(1);
            Console.WriteLine("funcou crl");
        }
        public void addItemToOrder()
        {
            itemsOrdered.Add(new MenuItem());
            quantities.Add(1);
            foreach (MenuItem i in itemsOrdered)
            {
                Console.WriteLine(i.name);
            }
            
        }
    }

    public class MenuItem
    {
        public int id;
        public String name;
        public String description;
        public float price;
        public int responsible; //0- kitchen 1- bar 2- both

        public MenuItem()
        {
            id = 1;
            name = "Bacalhau com natas";
            description = "bom comó crl";
            price = 1.0F;
            responsible = 0;
        }
    }
}
