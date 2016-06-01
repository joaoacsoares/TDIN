using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Client.BankA;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BankAOpsClient proxy = new BankAOpsClient();

            proxy.GetClienteOrdens(Int32.Parse(textBox1.Text));
            proxy.GetEmpresas();

            Cliente c = proxy.GetCliente(Int32.Parse(textBox1.Text));
            textBox5.Text = c.email;
            Ordem[] o = proxy.GetClienteOrdens(Int32.Parse(textBox1.Text));
            foreach(Ordem ord in o)
            {
                listBox1.Text = ord.id.ToString();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BankAOpsClient proxy = new BankAOpsClient();
            Ordem o = new Ordem();

            textBox1.Text = o.clientId.ToString();
            textBox5.Text = o.email;
            textBox2.Text = o.companyId.ToString();

            if (comboBox1.Text == "Buying")
            {
                o.type = 0;
            }
            else
                o.type = 1;

            textBox3.Text = o.quant.ToString();
            proxy.addOrdem(o);



        }
    }
}
