using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace BankA
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IBankAOps
    {
        
        [OperationContract]
        void subscrever();

        [OperationContract]
        void unSubscrever();

        [OperationContract]
        List<Ordem> GetOrdens();

        [OperationContract]
        Ordem GetOrdem(int id);

        [OperationContract]
        List<Ordem> GetNotExecutedOrdens();

        [OperationContract]
        List<Ordem> GetExecutedOrdens();

        [OperationContract]
        List<Ordem> GetClienteOrdens(int idCli);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void addOrdem(int clientId, int companyId, string email, int type, int quant);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void executeOrdem(int id, double value);

        [OperationContract]
        List<Cliente> GetClientes();

        [OperationContract]
        Cliente GetCliente(int id);

        [OperationContract]
        List<Empresa> GetEmpresas();

        [OperationContract]
        Empresa GetEmpresa(int id);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void editEmpresaValue(int id, int val);

       

    }
}
