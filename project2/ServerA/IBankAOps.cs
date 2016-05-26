using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace BankA
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IBankAOps
    {

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void Deposit(int acct, double amount);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void Withdraw(int acct, double amount);

        [OperationContract]
        double GetBalance(int acct);
        
        [OperationContract]
        List<Ordem> GetOrdens();


    }
}
