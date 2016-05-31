using System;
using System.ServiceModel;
using Client.BankA;
using System.Collections.Generic;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            
            BankAOpsClient bankAProxy = new BankAOpsClient();



            /*//TESTS START HERE
            //ORDERS TESTS
            Console.WriteLine("criar ordem :");
            Ordem aux = new Ordem();
            aux.id = 9;
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

           
            


            Console.WriteLine("editing empresa 1:");
            Console.WriteLine(bankAProxy.GetEmpresa(1).ID + " - " + bankAProxy.GetEmpresa(1).valorCotacao);
            bankAProxy.editEmpresaValue(1, 5000);
            Console.WriteLine("=======//=====");
            Console.WriteLine(bankAProxy.GetEmpresa(1).ID + " - " + bankAProxy.GetEmpresa(1).valorCotacao);

             //TESTS END HERE*/
            //EXECUTE ORDEM 10 TEST (if ordem 10 already exists please change this)


            /*Ordem aux1 = new Ordem();
            aux1.clientId = 2;
            aux1.companyId = 2;
            aux1.email = " 'joaosoaresacs@gmail.com' ";
            aux1.type = 0;
            aux1.quant = 4;*/
            //aux1.creationDate = "270520160000";
            //aux1.executionDate = "270520160100";
            //aux1.valueStock = 1000;
            //aux1.state = (int)0;


            Console.WriteLine("criar ordem :");
            bankAProxy.addOrdem(1, 1, "joaosoaresacs@gmail.com", 0, 4);
            bankAProxy.addOrdem(1,1,"joaosoaresacs@gmail.com",0,4);
            Console.WriteLine("=======//=====");
            Console.WriteLine("enter to print orders");
            Console.ReadLine();

            Console.WriteLine("todas as ordens:");
            Ordem[] tmp9 = bankAProxy.GetOrdens();
            foreach (Ordem t in tmp9)
            {
                Console.WriteLine(t.id + " - state - " + t.state);
            }
            Console.WriteLine("=======//=====");

            Console.WriteLine("enter to print orders");
            Console.ReadLine();
            Console.WriteLine("todas as ordens:");
            BankA.Ordem[] tmp10 = bankAProxy.GetOrdens();
            foreach (BankA.Ordem t in tmp10)
            {
                Console.WriteLine(t.id + " - state - " + t.state);
            }
            Console.WriteLine("=======//=====");
            


    
            bankAProxy.Close();
            
            Console.WriteLine("Press <Enter> to terminate.");
            Console.ReadLine();
        }
    }
}
