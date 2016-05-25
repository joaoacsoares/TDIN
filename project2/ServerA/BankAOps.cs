using System;
using System.ServiceModel;
using System.Configuration;
using System.Data.SqlClient;

namespace BankA {
  public class BankAOps : IBankAOps {
    public static string connString = ConfigurationManager.ConnectionStrings["BankA"].ToString();

    [OperationBehavior(TransactionScopeRequired=true, TransactionAutoComplete=false)]
    public void Deposit(int acct, double amount) {
      SqlConnection conn = new SqlConnection(connString);
      int rows;
      try {
        conn.Open();
        string sqlcmd = "update Accounts set Balance=Balance+" + amount.ToString("F2") +
                   "where AccNr=" + acct;
        SqlCommand cmd = new SqlCommand(sqlcmd, conn);
        rows = cmd.ExecuteNonQuery();
        if (rows == 1)
          OperationContext.Current.SetTransactionComplete();
      }
      finally {
        conn.Close();
      }
    }

    [OperationBehavior(TransactionScopeRequired=true, TransactionAutoComplete=false)]
    public void Withdraw(int acct, double amount) {
      SqlConnection conn = new SqlConnection(connString);
      int rows;
      try {
        conn.Open();
        string sqlcmd = "update Accounts set Balance=Balance-" + amount.ToString("F2") +
                   "where AccNr=" + acct;
        SqlCommand cmd = new SqlCommand(sqlcmd, conn);
        rows = cmd.ExecuteNonQuery();
        if (rows == 1)
          OperationContext.Current.SetTransactionComplete();
      }
      finally {
        conn.Close();
      }
    }

    public double GetBalance(int acct) {
      SqlConnection conn = new SqlConnection(connString);
      double amount;
      try {
        conn.Open();
        string sqlcmd = "select Balance from Accounts where AccNr=" + acct;
        SqlCommand cmd = new SqlCommand(sqlcmd, conn);
        amount = Convert.ToDouble((decimal) cmd.ExecuteScalar());
      }
      catch {
        amount = -1.0;
      }
      finally {
        conn.Close();
      }
      return amount;
    }
  }
}
