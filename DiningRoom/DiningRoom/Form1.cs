using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiningRoom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //List<string> tmp = new List<string>();
            //int aux = 0;
            //foreach (string o in listBox2.Items)
            //{
            //  string[] words = o.Split('/');
            //    foreach (string i in listBox2.Items)
            //    {
            //        aux = 0;
            //        if(o.Equals(i))
            //        {
            //            aux = aux + 1;
            //        }

            //    }

            //    if(!tmp.Contains(o))
            //    DiningRoom.ordersList.Add(words[0], words[0], aux, Int32.Parse(comboBox1.SelectedIndex.ToString()), float.Parse(words[2], CultureInfo.InvariantCulture.NumberFormat), words[1]);
            //    tmp.Add(o);
            //}
            foreach (string o in listBox2.Items) { 
            string[] words = o.Split('/');
            DiningRoom.ordersList.Add(words[0], words[0], 1, Int32.Parse(comboBox1.SelectedIndex.ToString()), float.Parse(words[2], CultureInfo.InvariantCulture.NumberFormat), words[1]);
        }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Add(listBox1.Items[listBox1.SelectedIndex].ToString());
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();


        }
    }
}
