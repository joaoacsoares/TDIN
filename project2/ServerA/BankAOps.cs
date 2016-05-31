using System;
using System.ServiceModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Messaging;

namespace BankA
{
    public class BankAOps : IBankAOps
    {
        public static string connString = ConfigurationManager.ConnectionStrings["DepInf"].ToString();
        

        public List<Ordem> GetOrdens()
        {
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
                        o.executionDate = (string)results.GetValue(7);
                       // Console.WriteLine(o.executionDate);
                        o.valueStock = (double)results.GetValue(8); 
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
        }

        public Ordem GetOrdem(int id)
        {
            SqlConnection conn = new SqlConnection(connString);
            Ordem o = new Ordem();
            try
            {
                conn.Open();
                string sqlcmd = "SELECT * FROM Ordem WHERE ID = " + id;
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                
                using (SqlDataReader results = cmd.ExecuteReader())
                {
                    while (results.Read())
                    {
                        
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
                        o.executionDate = (string)results.GetValue(7);
                        // Console.WriteLine(o.executionDate);
                        o.valueStock = (double)results.GetValue(8);
                        //Console.WriteLine(o.valueStock);
                        o.state = (int)results.GetValue(9);
                        //Console.WriteLine(o.state);
                        
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                return o;
            }
            finally
            {
                conn.Close();
            }
            return o;
        }

        public List<Cliente> GetClientes()
        {
            List<Cliente> clienteList = new List<Cliente>();
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                string sqlcmd = "SELECT * FROM Cliente";
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                using (SqlDataReader results = cmd.ExecuteReader())
                {
                    while (results.Read())
                    {
                        Cliente o = new Cliente();
                        o.ID = (int)results.GetValue(0);
                        //Console.WriteLine(o.ID);
                        o.email = (string) results.GetValue(1);
                        //Console.WriteLine(o.email);
                        clienteList.Add(o);
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                return clienteList;
            }
            finally
            {
                conn.Close();
            }
            return clienteList;
        }

        public Cliente GetCliente(int id)
        {
            SqlConnection conn = new SqlConnection(connString);
            Cliente o = new Cliente();
            try
            {
                conn.Open();
                string sqlcmd = "SELECT * FROM Cliente WHERE ID = " + id;
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                using (SqlDataReader results = cmd.ExecuteReader())
                {
                    while (results.Read())
                    {
                        o.ID = (int)results.GetValue(0);
                        //Console.WriteLine(o.ID);
                        o.email = (string)results.GetValue(1);
                        //Console.WriteLine(o.email);
                        
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                return o;
            }
            finally
            {
                conn.Close();
            }
            return o;
        }

        public List<Ordem> GetNotExecutedOrdens()
        {
            List<Ordem> ordemList = new List<Ordem>();
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                string sqlcmd = "SELECT * FROM Ordem WHERE estadoOrdem = 0";
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
                        o.executionDate = (string)results.GetValue(7);
                        // Console.WriteLine(o.executionDate);
                        o.valueStock = (double)results.GetValue(8);
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
        }

        public List<Ordem> GetExecutedOrdens()
        {
            List<Ordem> ordemList = new List<Ordem>();
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                string sqlcmd = "SELECT * FROM Ordem WHERE estadoOrdem = 1";
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
                        o.executionDate = (string)results.GetValue(7);
                        // Console.WriteLine(o.executionDate);
                        o.valueStock = (double)results.GetValue(8);
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
        }

        public List<Ordem> GetClienteOrdens(int idCli)
        {
            List<Ordem> ordemList = new List<Ordem>();
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                string sqlcmd = "SELECT * FROM Ordem WHERE IDCliente = " + idCli;
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
                        o.executionDate = (string)results.GetValue(7);
                        // Console.WriteLine(o.executionDate);
                        o.valueStock = (double)results.GetValue(8);
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
        }

        public void addOrdem(Ordem od)
        {
            SqlConnection conn = new SqlConnection(connString);
            
            int rows;
            try
            {
                conn.Open();
                string sqlcmd = "INSERT INTO Ordem (ID, IDCliente, IDEmpresa, emailCliente, tipo, quantidade, dataCriacao ,dataExecucao, valorCotacao, estadoOrdem)" + 
                    "VALUES (" + od.id + "," + od.clientId+ "," + od.companyId + "," + od.email + "," + od.type + "," + od.quant + "," + od.creationDate + "," + od.executionDate + "," + od.valueStock + "," + od.state +")";

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

            MessageQueue messageQueue = null;
            if (MessageQueue.Exists(@".\Private$\supervisor"))
            {
                messageQueue = new MessageQueue(@".\Private$\supervisor");
                if (messageQueue.Transactional == true)
                {
                    using (MessageQueueTransaction trans = new MessageQueueTransaction())
                    {
                        trans.Begin();
                        messageQueue.Send(/*"insert into orders(id,quantity, request_date, company_id,order_type,client_id,execution_status, client_name) values(" + id.ToString() + "," + quantity.ToString() + "," +
            "'" + request_date_time.ToString() + "'" + "," + company_id.ToString() + "," + "'" + order_type + "'," + client_id.ToString() + ",'Request','" + username + "');", order_type + " " + id*/ "hello!", trans);
                        trans.Commit();
                    }
                }
            }
            else
                messageQueue.Send("First ever Message is sent to MSMQ"/*, order_type + " " + id*/);
        }

        public void executeOrdem(int id)
        {
            SqlConnection conn = new SqlConnection(connString);
            int rows;

            try
            {
                conn.Open();
                string sqlcmd = "update Ordem set EstadoOrdem= 1" +
                           "where ID=" + id;
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                    OperationContext.Current.SetTransactionComplete();

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Empresa> GetEmpresas()
        {
            List<Empresa> EmpresaList = new List<Empresa>();
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                string sqlcmd = "SELECT * FROM Empresa";
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                using (SqlDataReader results = cmd.ExecuteReader())
                {
                    while (results.Read())
                    {
                        Empresa o = new Empresa();
                        o.ID = (int)results.GetValue(0);
                        //Console.WriteLine(o.ID);
                        o.stockDisponivel = (int)results.GetValue(1);
                        //Console.WriteLine(o.stockDisponivel);
                        o.valorCotacao = (double)results.GetValue(2);
                        //Console.WriteLine(o.valorCotacao);
                        EmpresaList.Add(o);
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                return EmpresaList;
            }
            finally
            {
                conn.Close();
            }
            return EmpresaList;
        }

        public Empresa GetEmpresa(int id)
        {
            SqlConnection conn = new SqlConnection(connString);
            Empresa o = new Empresa();
            try
            {
                conn.Open();
                string sqlcmd = "SELECT * FROM Empresa WHERE ID = " + id;
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                using (SqlDataReader results = cmd.ExecuteReader())
                {
                    while (results.Read())
                    {
                       
                        o.ID = (int)results.GetValue(0);
                        //Console.WriteLine(o.ID);
                        o.stockDisponivel = (int)results.GetValue(1);
                        //Console.WriteLine(o.stockDisponivel);
                        o.valorCotacao = (double)results.GetValue(2);
                        //Console.WriteLine(o.valorCotacao);
                        
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                return o;
            }
            finally
            {
                conn.Close();
            }
            return o;
        }

        public void editEmpresaValue(int id, int val)
        {
            SqlConnection conn = new SqlConnection(connString);
            int rows;

            try
            {
                conn.Open();
                string sqlcmd = "update Empresa set valorCotacao = " + val +
                           "where ID=" + id;
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                    OperationContext.Current.SetTransactionComplete();

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }

      
    }
}
