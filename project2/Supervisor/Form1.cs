using Supervisor.BankA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Supervisor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Program p = new Program();
            InitializeComponent();
            listBox1.Items.Clear();

            p.unstashMessages();
            foreach (Ordem o in p.receiveMessages())
                listBox1.Items.Add("Ordem " + o.id);
            foreach (Ordem o in p.ordensNaoExecutadas)
                listBox1.Items.Add("Ordem " + o.id);

            listBox1.Update();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program p = new Program();
            p.stashMessages();
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BankAOpsClient proxy = new BankAOpsClient();
            int id;
            double value;

            id = Int32.Parse(textBox1.Text);
            value = Double.Parse(textBox2.Text);
            //Console.WriteLine(id + value);
            proxy.executeOrdem(id, value);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program p = new Program ();
            p.receiveMessages();
            listBox1.Items.Clear();

            foreach (Ordem o in p.receiveMessages())
                listBox1.Items.Add("Ordem " + o.id);
            foreach (Ordem o in p.ordensNaoExecutadas)
                listBox1.Items.Add("Ordem " + o.id);

            listBox1.Update();

        }
    }
}
