using System;
using System.ServiceModel;
using Client.InterBank;
using Client.BankA;
using Client.BankB;
using System.Collections.Generic;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            InterBankOpsClient proxy = new InterBankOpsClient();
            BankAOpsClient bankAProxy = new BankAOpsClient();
            BankBOpsClient bankBProxy = new BankBOpsClient();

            /*
            //TESTS START HERE
            //ORDERS TESTS
            Console.WriteLine("criar ordem :");
            Ordem aux = new Ordem();
            aux.id = 7;
            aux.clientId = 2;
            aux.companyId = 2;
            aux.email = " 'joaosoaresacs@gmail.com' ";
            aux.type = 0;
            aux.quant = 4;
            aux.creationDate = "270520160000";
            aux.executionDate = "270520160100";
            aux.valueStock = 1000;
            aux.state = (int) 1;

            bankAProxy.addOrdem(aux);
            Console.WriteLine("=======//=====");

            Console.WriteLine("todas as ordens:");
            Ordem[] tmp = bankAProxy.GetOrdens();
            foreach(Ordem t in tmp)
            {
                Console.WriteLine(t.id);
            }
            Console.WriteLine("=======//=====");
            
            Console.WriteLine("Ordem Id = 1:");
            Ordem tmp1 = bankAProxy.GetOrdem(1);
            Console.WriteLine(tmp1.id);
            Console.WriteLine("=======//=====");

            Console.WriteLine("ordens nao executadas:");
            Ordem[] tmp2 = bankAProxy.GetNotExecutedOrdens();
            foreach (Ordem t in tmp2)
            {
                Console.WriteLine(t.id);
            }
            Console.WriteLine("=======//=====");

            Console.WriteLine("ordens executadas:");
            Ordem[] tmp3 = bankAProxy.GetExecutedOrdens();
            foreach (Ordem t in tmp3)
            {
                Console.WriteLine(t.id);
            }
            Console.WriteLine("=======//=====");

            Console.WriteLine("ordens do cliente id = 1:");
            Ordem[] tmp4 = bankAProxy.GetClienteOrdens(1);
            foreach (Ordem t in tmp4)
            {
                Console.WriteLine(t.id);
            }
            Console.WriteLine("=======//=====");

            //EMPRESAS
            Console.WriteLine("todas as empresas");
            Empresa[] tmp5 = bankAProxy.GetEmpresas();
            foreach (Empresa t in tmp5)
            {
                Console.WriteLine(t.ID);
            }
            Console.WriteLine("=======//=====");

            Console.WriteLine("empresa1:");
            Empresa tmp6 = bankAProxy.GetEmpresa(1);
            Console.WriteLine(tmp6.ID);

            Console.WriteLine("=======//=====");

            //CLIENTES
            Console.WriteLine("todas os clientes");
            Cliente[] tmp7 = bankAProxy.GetClientes();
            foreach (Cliente t in tmp7)
            {
                Console.WriteLine(t.ID);
            }
            Console.WriteLine("=======//=====");

            Console.WriteLine("Cliente 1:");
            Cliente tmp8 = bankAProxy.GetCliente(1);
            Console.WriteLine(tmp8.ID);

            Console.WriteLine("=======//=====");

            //TESTS END HERE
            */


            Console.WriteLine("editing empresa 1:");
            Console.WriteLine(bankAProxy.GetEmpresa(1).ID + " - " + bankAProxy.GetEmpresa(1).valorCotacao);
            bankAProxy.editEmpresaValue(1, 5000);
            Console.WriteLine("=======//=====");
            Console.WriteLine(bankAProxy.GetEmpresa(1).ID + " - " + bankAProxy.GetEmpresa(1).valorCotacao);

            /*
            //EXECUTE ORDEM 10 TEST (if ordem 10 already exists please change this)
            Console.WriteLine("criar ordem :");
            Ordem aux = new Ordem();
            aux.id = 10;
            aux.clientId = 2;
            aux.companyId = 2;
            aux.email = " 'joaosoaresacs@gmail.com' ";
            aux.type = 0;
            aux.quant = 4;
            aux.creationDate = "270520160000";
            aux.executionDate = "270520160100";
            aux.valueStock = 1000;
            aux.state = (int)0;

            bankAProxy.addOrdem(aux);
            Console.WriteLine("=======//=====");

            Console.WriteLine("todas as ordens:");
            Ordem[] tmp = bankAProxy.GetOrdens();
            foreach (Ordem t in tmp)
            {
                Console.WriteLine(t.id + " - state - " + t.state);
            }
            Console.WriteLine("=======//=====");

            Console.WriteLine("executar ordem 10:");
            bankAProxy.executeOrdem(10);
            Console.WriteLine("=======//=====");
            Console.WriteLine("todas as ordens:");
            Ordem[] tmp1 = bankAProxy.GetOrdens();
            foreach (Ordem t in tmp1)
            {
                Console.WriteLine(t.id + " - state - " + t.state);
            }
            Console.WriteLine("=======//=====");
            */


            bankBProxy.Close();
            bankAProxy.Close();
            if (proxy.State == CommunicationState.Opened)
             proxy.Close();
            Console.WriteLine("Press <Enter> to terminate.");
            Console.ReadLine();
        }
    }
}
