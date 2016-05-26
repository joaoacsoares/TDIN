using System;
using System.ServiceModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace BankA
{
    public class BankAOps : IBankAOps
    {
        public static string connString = ConfigurationManager.ConnectionStrings["DepInf"].ToString();


        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = false)]
        public void Deposit(int acct, double amount)
        {
            SqlConnection conn = new SqlConnection(connString);
            int rows;
            try
            {
                conn.Open();
                string sqlcmd = "update Accounts set Balance=Balance+" + amount.ToString("F2") +
                           "where AccNr=" + acct;
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                    OperationContext.Current.SetTransactionComplete();
            }
            finally
            {
                conn.Close();
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = false)]
        public void Withdraw(int acct, double amount)
        {
            SqlConnection conn = new SqlConnection(connString);
            int rows;
            try
            {
                conn.Open();
                string sqlcmd = "update Accounts set Balance=Balance-" + amount.ToString("F2") +
                           "where AccNr=" + acct;
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                    OperationContext.Current.SetTransactionComplete();
            }
            finally
            {
                conn.Close();
            }
        }

        public double GetBalance(int acct)
        {
            SqlConnection conn = new SqlConnection(connString);
            double amount;
            try
            {
                conn.Open();
                string sqlcmd = "select Balance from Accounts where AccNr=" + acct;
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                amount = Convert.ToDouble((decimal)cmd.ExecuteScalar());
            }
            catch
            {
                amount = -1.0;
            }
            finally
            {
                conn.Close();
            }
            return amount;
        }

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



        /*public List<Ordem> GetOrdens()
        {
            SqlConnection conn = new SqlConnection(connString);

            List<Ordem> aux = new List<Ordem>();

            try
            {
                conn.Open();
                string sqlcmd = "select * from Ordem";
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                //aux = Convert.ToString(cmd.ExecuteScalar());
                //amount = Convert.ToDouble((decimal)cmd.ExecuteScalar());



                //To Read From SQL Server
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Ordem o = new Ordem();
                    aux.Add(o.id = (Int32.Parse( dr["ID"].ToString() )),
                                       (Int32.Parse (dr["IDCliente"].ToString() )),
                                       (Int32.Parse(dr["IDEmpresa"].ToString())),
                                       dr["emailCliente"].ToString(),
                                       (Int32.Parse(dr["tipo"].ToString())),
                                       (Int32.Parse(dr["quantidade"].ToString())),
                                       dr["dataCriacao"].ToString(),
                                       dr["dataExecucao"].ToString(),
                                       (Convert.ToDouble(dr["valorCotacao"].ToString())),
                                       (Int32.Parse(dr["estadoOrdem"].ToString()))
                                ));
                };


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return aux;
        }*/



    }
}
