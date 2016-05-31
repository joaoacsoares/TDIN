using System;
using System.IO;
using System.Messaging;
using System.ServiceModel;

namespace Supervisor
{
    public class SupervisorOps : ISupervisorOps
    {
        public void ReceiveMessages()
        {
            if (MessageQueue.Exists(@".\Private$\supervisor"))
            {

                MessageQueue messageQueue = new MessageQueue(@".\Private$\supervisor");
                System.Messaging.Message[] messages = messageQueue.GetAllMessages();

                string rec = "";
                string sqlcmd;
                foreach (System.Messaging.Message message in messages)
                {
                    string line;
                    message.Formatter = new System.Messaging.XmlMessageFormatter(new String[] { });
                    StreamReader sr = new StreamReader(message.BodyStream);

                    while (sr.Peek() >= 0)
                    {
                        rec += sr.ReadLine();
                        
                    }
                    Console.WriteLine(rec);
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

                    messageQueue.Purge();
                }
            }
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void ReportToSupervisor(string message)
        {
            Console.WriteLine(message);
        }
    }
}
