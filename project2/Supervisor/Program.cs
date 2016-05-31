using System;
using System.ServiceModel;
using Supervisor;
using System.Messaging;
using System.IO;

namespace Supervisor
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(Supervisor.SupervisorOps));
            host.Open();
            Console.WriteLine("Service Supervisor Active. Press <Enter> to close.");
            Console.ReadLine();
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
                    //host.Close();
                }
                messageQueue.Purge();
            }
            
            Console.ReadLine();
        }
    }
}
