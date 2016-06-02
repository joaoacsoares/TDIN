using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Messaging;
using System.Web;
using WebApplication.Models;

namespace WebApplication.Services
{
    public class OrdemRepository
    {
        private const string CacheKey = "OrdemStore";
        public static string connString = "Data Source=localhost\\sqlexpress;Initial Catalog=DepInf;Integrated Security=True;MultipleActiveResultSets=True";

        public OrdemRepository()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                if (ctx.Cache[CacheKey] == null)
                {
                    var ordens = new Ordem[]
                    {
                new Ordem
                {
                    id = 1, email = "Glenn Block"
                },
                new Ordem
                {
                    id = 2, email = "Dan Roth"
                }
                    };

                    ctx.Cache[CacheKey] = ordens;
                }
            }
        }

        public List<Ordem> GetAllOrdem()
        {
            var ctx = HttpContext.Current;
            List<Ordem> ordemList = new List<Ordem>();

            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                string sqlcmd = "SELECT * FROM Ordem";
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                using (SqlDataReader results = cmd.ExecuteReader())
                {
                    while (results.Read())
                    {
                        Ordem o = new Ordem();
                        o.id = (int)results.GetValue(0);
                        //Console.WriteLine(o.id);
                        o.clientId = (int)results.GetValue(1);
                        //Console.WriteLine(o.clientId);
                        o.companyId = (int)results.GetValue(2);
                        //Console.WriteLine(o.companyId);
                        o.email = (string)results.GetValue(3);
                        //Console.WriteLine(o.email);
                        o.type = (int)results.GetValue(4);
                        //Console.WriteLine(o.type);
                        o.quant = (int)results.GetValue(5);
                        //Console.WriteLine(o.quant);
                        o.creationDate = (string)results.GetValue(6);
                        //Console.WriteLine(o.creationDate);
                        /*if(results.GetValue(7).)
                        o.executionDate = (string)results.GetValue(7);
                        // Console.WriteLine(o.executionDate);
                        if (results.GetValue(8) != System.DBNull)
                            o.valueStock = (double)results.GetValue(8); */
                        //Console.WriteLine(o.valueStock);
                        o.state = (int)results.GetValue(9);
                        //Console.WriteLine(o.state);
                        ordemList.Add(o);
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                return ordemList;
            }
            finally
            {
                conn.Close();
            }
            return ordemList;
            /*
            if (ctx != null)
            {
                return (Ordem[])ctx.Cache[CacheKey];
            }

            return new Ordem[]
                {
            new Ordem
            {
                id = 0,
                email = "Placeholder"
            }
                };*/
        }

        public void SaveOrdem(int clientId, int companyId, string email, int type, int quant)
        {
            SqlConnection conn = new SqlConnection(connString);

            int rows;
            DateTime localDate = DateTime.Now;
            string creationDate = localDate.ToString();
            creationDate = creationDate.Replace(" ", "-");
            creationDate = creationDate.Replace(":", "-");
            try
            {
                conn.Open();
                string sqlcmd = "INSERT INTO Ordem (IDCliente, IDEmpresa, emailCliente, tipo, quantidade, dataCriacao,estadoOrdem)" +
                    "VALUES (" + clientId + "," + companyId + ",'" + email + "'," + type + "," + quant + ",'" + creationDate + "',0)";
                Console.WriteLine(sqlcmd);
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                rows = cmd.ExecuteNonQuery();

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            finally
            {
                conn.Close();
            }


            int id = -1;
            try
            {
                conn.Open();
                string sqlcmd = "SELECT TOP 1 ID FROM Ordem ORDER BY ID DESC";
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                using (SqlDataReader results = cmd.ExecuteReader())
                {
                    while (results.Read())
                    {

                        id = (int)results.GetValue(0);
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            finally
            {
                conn.Close();
            }


            MessageQueue messageQueue = null;
            if (MessageQueue.Exists(@".\Private$\supervisor"))
            {
                messageQueue = new MessageQueue(@".\Private$\supervisor");
                if (messageQueue.Transactional == true)
                {
                    using (MessageQueueTransaction trans = new MessageQueueTransaction())
                    {
                        trans.Begin();
                        messageQueue.Send("+Ordem+" + id + "+" + companyId + "+" + type + "+" + quant + "+" + creationDate, trans);
                        trans.Commit();
                    }
                }
            }
            else
                messageQueue.Send("First ever Message is sent to MSMQ"/*, order_type + " " + id*/);
        }

    }
}