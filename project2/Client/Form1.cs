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
            BankAOpsClient proxy = new BankAOpsClient();
            InitializeComponent();
            listBox2.Items.Clear();
            foreach(Empresa e in proxy.GetEmpresas())
            {
                listBox2.Items.Add("Empresa " + e.ID + ": " + e.stockDisponivel + " Stock");
            }

            listBox2.Update();
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

            /*proxy.GetClienteOrdens(Int32.Parse(textBox1.Text));
            proxy.GetEmpresas();*/
            listBox1.Items.Clear();
            Cliente c = proxy.GetCliente(Int32.Parse(textBox1.Text));
            textBox5.Text = c.email;
            Ordem[] o = proxy.GetClienteOrdens(Int32.Parse(textBox1.Text));

            if(o.Length == 0)
            {
                listBox1.Items.Add("O cliente nao tem nenhuma ordem, de momento.");
            }

            foreach(Ordem ord in o)
            {
                if(ord.state == 1)
                {
                    listBox1.Items.Add("Ordem " + ord.id + " executada com o valor " + ord.valueStock);
                }
                else
                listBox1.Items.Add("Ordem " + ord.id + " nao executada desde " + ord.creationDate);
                
            }
            listBox1.Update();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BankAOpsClient proxy = new BankAOpsClient();
            Ordem o = new Ordem();

            
            o.clientId = Int32.Parse(textBox1.Text);
            o.email = textBox5.Text;
            o.companyId = Int32.Parse(textBox2.Text);
           

            if (comboBox1.Text == "Compra")
            {
                o.type = 0;
            }
            else
                o.type = 1;

            o.quant = Int32.Parse(textBox3.Text);
            proxy.addOrdem(o.clientId, o.companyId, o.email, o.type, o.quant);



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
