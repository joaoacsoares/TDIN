using System;
using System.ServiceModel;
using Supervisor;
using System.Messaging;
using System.IO;
using System.Collections.Generic;
using Supervisor.BankA;
using System.Text;
using System.Windows.Forms;

namespace Supervisor
{
    class Program
    {
        public List<Ordem> ordensNaoExecutadas = new List<Ordem>();

        static void Main(string[] args)
        {
            Program p = new Program();
            BankAOpsClient bankAProxy = new BankAOpsClient();
            bankAProxy.subscrever();
            Form1 form = new Form1(); 
            Application.Run(form);
            bankAProxy.unSubscrever();
            /*p.unstashMessages();

            ServiceHost host = new ServiceHost(typeof(Supervisor.SupervisorOps));
            host.Open();
            Console.WriteLine("=== Serviço Bolsista Activo. O Dep.Informático será notificado da sua conecção. ===");
            Console.WriteLine("1 - Listar Ordens não executadas;");
            Console.WriteLine("2 - Executar uma Ordem");
            Console.WriteLine("3 - Sair.");
            string line = Console.ReadLine();
            while (!line.Equals("3"))
            {
                if (line.Equals("1"))
                {
                    foreach (Ordem i in p.receiveMessages())
                        p.ordensNaoExecutadas.Add(i);
                    foreach (Ordem i in p.ordensNaoExecutadas)
                    {
                        Console.WriteLine("Ordem " + i.id);
                    }


                }
                if (line.Equals("2"))
                {
                    foreach (Ordem i in p.receiveMessages())
                        p.ordensNaoExecutadas.Add(i);
                    foreach (Ordem i in p.ordensNaoExecutadas)
                    {
                        Console.WriteLine("Ordem " + i.id);
                    }
                    Console.WriteLine("Executar Ordem numero? (numero + <Enter>");
                    int odid = Int32.Parse(Console.ReadLine());

                    Console.WriteLine("Valor das acções? (numero + <Enter>");
                    double vs = Double.Parse(Console.ReadLine());
                    bool checker = false;
                    foreach (Ordem i in p.ordensNaoExecutadas)
                    {
                        if (i.id.Equals(odid))
                        {
                            checker = true;
                            p.ordensNaoExecutadas.Remove(i);
                            bankAProxy.executeOrdem(odid, vs);
                            
                            break;
                        }
                        else
                            checker = false;
                    }
                    if (checker)
                        Console.WriteLine("Order Executed Successfully!");
                    

                }
                else
                {
                    Console.WriteLine("Something went wrong, please re-enter input :/");
                }
                line = Console.ReadLine();
            }
            Console.WriteLine("Exiting...");
            foreach (Ordem i in p.receiveMessages())
                p.ordensNaoExecutadas.Add(i);
            p.stashMessages();
            bankAProxy.unSubscrever();
            Console.WriteLine("Exit Successfully.");
            //Console.ReadLine();*/
        }


        public void stashMessages()
        {
            BankAOpsClient bankAProxy = new BankAOpsClient();
            Ordem[] tmp = bankAProxy.GetNotExecutedOrdens();
            bool checker = false;
            foreach (Ordem i in tmp)
            {
                checker = false;
                foreach(Ordem o in ordensNaoExecutadas)
                {
                    if(i.id == o.id)
                    {
                        checker = true;
                    }
                }
                if(!checker)
                    ordensNaoExecutadas.Add(i);
            }


            var csv = new StringBuilder();
            foreach (Ordem o in ordensNaoExecutadas)
            {
                var newLine = string.Format("{0},{1},{2},{3},{4},{5}", o.id, o.companyId, o.email, o.creationDate, o.quant, o.type);
                csv.AppendLine(newLine);
            }
            

            ordensNaoExecutadas.Clear();
            File.WriteAllText(@"C:\Users\Joao\Documents\MIEIC\4º Ano\2S\TDIN\TDIN\project2\Supervisor\persistentOrders.csv", csv.ToString());
            //ader.Close();
        }

        public void unstashMessages()
        {
            List<Ordem> tmp = new List<Ordem>();
            var reader = new StreamReader(File.OpenRead(@"C:\Users\Joao\Documents\MIEIC\4º Ano\2S\TDIN\TDIN\project2\Supervisor\persistentOrders.csv"));

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                Ordem o = new Ordem();
                o.id = Int32.Parse(values[0]);
                o.companyId = Int32.Parse(values[1]);
                o.email = values[2];
                o.creationDate = values[3];
                o.quant = Int32.Parse(values[4]);
                o.type = Int32.Parse(values[5]);
                ordensNaoExecutadas.Add(o);
            }
            reader.Close();


        }

        public List<Ordem> receiveMessages()
        {
            List<Ordem> tmp = new List<Ordem>();

            if (MessageQueue.Exists(@".\Private$\supervisor"))
            {

                MessageQueue messageQueue = new MessageQueue(@".\Private$\supervisor");
                


                System.Messaging.Message[] messages = messageQueue.GetAllMessages();

                string rec = "";
                //string sqlcmd;
                foreach (System.Messaging.Message message in messages)
                {
                    //string line;
                    message.Formatter = new System.Messaging.XmlMessageFormatter(new String[] { });
                    StreamReader sr = new StreamReader(message.BodyStream);
                    
                    while (sr.Peek() >= 0)
                    {
                        //Ordem o = new Ordem();
                        rec += sr.ReadLine();

                    }
                    string[] words = rec.Split('+');

                    Ordem o = new Ordem();
                    o.id = Int32.Parse(words[2]);
                    o.companyId = Int32.Parse(words[3]);
                    o.type = Int32.Parse(words[4]);
                    o.quant = Int32.Parse(words[5]);
                    o.creationDate = words[6];
                    ordensNaoExecutadas.Add(o);
                    rec = "";
                    /*
                    string[] splitter1 = new string[] { "<string>" }, splitter2 = new string[] { "</string>" };
                    rec = rec.Split(splitter1, StringSplitOptions.None)[1];
                    sqlcmd = rec.Split(splitter2, StringSplitOptions.None)[0];
                    */
                    /*conn = new SQLiteConnection("data source=eBanking.db");
                    try
                    {
                        conn.Open();
                        SQLiteCommand cmd = new SQLiteCommand(sqlcmd, conn);
                        cmd.ExecuteNonQuery();


                    }
                    finally
                    {
                        conn.Close();
                    }*/

                }
                messageQueue.Purge();
            }


            return tmp;
        }

        
    }
}

