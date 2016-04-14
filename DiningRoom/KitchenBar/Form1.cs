using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Remotes;

namespace KitchenBar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Add(listBox1.Items[listBox1.SelectedIndex].ToString());
            TableOrders.to.setOrderPreparing(listBox1.Items[listBox1.SelectedIndex].ToString());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            TableOrders.to.setOrderReady(listBox1.Items[listBox1.SelectedIndex].ToString());
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
             
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            KitchenBar.ReceivedOrders = KitchenBar.ordersList.GetAllOrders();
            foreach (Common.Order ord in KitchenBar.ReceivedOrders)
            {
                listBox1.Items.Add(KitchenBar.ReceivedOrders.ElementAt(0).ToString());
            }
        }
    }
}
