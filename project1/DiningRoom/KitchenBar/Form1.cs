﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Remotes;
using Common;

namespace KitchenBar
{
    public partial class Form1 : Form
    {
        public int id;
        public Form1(int id)
        {
            this.id = id;
            if (id == 0)
            {
                //KITCHEN
                Text = "Kitchen";
                InitializeComponent();
                timer1.Start();
            }
            else if (id == 1)
            {
                //BAR
                Text = "Bar";
                InitializeComponent();
                timer1.Start();
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] tmp = listBox1.Items[listBox1.SelectedIndex].ToString().Split('/');
            KitchenBar.ordersList.setOrderPreparing(Int32.Parse(tmp[0]));
            timer1.Start();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] tmp = listBox2.Items[listBox2.SelectedIndex].ToString().Split('/');
            KitchenBar.ordersList.setOrderReady(Int32.Parse(tmp[0]));
            timer1.Start();
            

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            if (id == 0)
            {
                List<Order> tmp = KitchenBar.ordersList.GetPendingOrders();
                string aux;
                foreach (Order p in tmp)
                {
                    if (p.orderType.Equals(" Kitchen "))
                    {
                        aux = p.id + " / " + p.description + " / " + p.table;
                        listBox1.Items.Add(aux);
                    }
                }

                List<Order> tmp2 = KitchenBar.ordersList.GetPreparingOrders();
                string aux2;
                foreach (Order p in tmp2)
                {
                    if (p.orderType.Equals(" Kitchen "))
                    {
                        aux2 = p.id + " / " + p.description + " / " + p.table;
                        listBox2.Items.Add(aux2);
                    }
                }
            }
            else if (id == 1)
            {
                List<Order> tmp = KitchenBar.ordersList.GetPendingOrders();
                string aux;
                foreach (Order p in tmp)
                {
                    if (p.orderType.Equals(" Bar "))
                    {
                        aux = p.id + " / " + p.description + " / " + p.table;
                        listBox1.Items.Add(aux);
                    }
                }

                List<Order> tmp2 = KitchenBar.ordersList.GetPreparingOrders();
                string aux2;
                foreach (Order p in tmp2)
                {
                    if (p.orderType.Equals(" Bar "))
                    {
                        aux2 = p.id + " / " + p.description + " / " + p.table;
                        listBox2.Items.Add(aux2);
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }
    }
}
