﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Supervisor.BankA {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Ordem", Namespace="http://schemas.datacontract.org/2004/07/BankA")]
    [System.SerializableAttribute()]
    public partial class Ordem : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int clientIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int companyIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string creationDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string emailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string executionDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int quantField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int stateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int typeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double valueStockField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int clientId {
            get {
                return this.clientIdField;
            }
            set {
                if ((this.clientIdField.Equals(value) != true)) {
                    this.clientIdField = value;
                    this.RaisePropertyChanged("clientId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int companyId {
            get {
                return this.companyIdField;
            }
            set {
                if ((this.companyIdField.Equals(value) != true)) {
                    this.companyIdField = value;
                    this.RaisePropertyChanged("companyId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string creationDate {
            get {
                return this.creationDateField;
            }
            set {
                if ((object.ReferenceEquals(this.creationDateField, value) != true)) {
                    this.creationDateField = value;
                    this.RaisePropertyChanged("creationDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string email {
            get {
                return this.emailField;
            }
            set {
                if ((object.ReferenceEquals(this.emailField, value) != true)) {
                    this.emailField = value;
                    this.RaisePropertyChanged("email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string executionDate {
            get {
                return this.executionDateField;
            }
            set {
                if ((object.ReferenceEquals(this.executionDateField, value) != true)) {
                    this.executionDateField = value;
                    this.RaisePropertyChanged("executionDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int quant {
            get {
                return this.quantField;
            }
            set {
                if ((this.quantField.Equals(value) != true)) {
                    this.quantField = value;
                    this.RaisePropertyChanged("quant");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int state {
            get {
                return this.stateField;
            }
            set {
                if ((this.stateField.Equals(value) != true)) {
                    this.stateField = value;
                    this.RaisePropertyChanged("state");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int type {
            get {
                return this.typeField;
            }
            set {
                if ((this.typeField.Equals(value) != true)) {
                    this.typeField = value;
                    this.RaisePropertyChanged("type");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double valueStock {
            get {
                return this.valueStockField;
            }
            set {
                if ((this.valueStockField.Equals(value) != true)) {
                    this.valueStockField = value;
                    this.RaisePropertyChanged("valueStock");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Cliente", Namespace="http://schemas.datacontract.org/2004/07/BankA")]
    [System.SerializableAttribute()]
    public partial class Cliente : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string emailField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string email {
            get {
                return this.emailField;
            }
            set {
                if ((object.ReferenceEquals(this.emailField, value) != true)) {
                    this.emailField = value;
                    this.RaisePropertyChanged("email");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Empresa", Namespace="http://schemas.datacontract.org/2004/07/BankA")]
    [System.SerializableAttribute()]
    public partial class Empresa : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int stockDisponivelField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double valorCotacaoField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int stockDisponivel {
            get {
                return this.stockDisponivelField;
            }
            set {
                if ((this.stockDisponivelField.Equals(value) != true)) {
                    this.stockDisponivelField = value;
                    this.RaisePropertyChanged("stockDisponivel");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double valorCotacao {
            get {
                return this.valorCotacaoField;
            }
            set {
                if ((this.valorCotacaoField.Equals(value) != true)) {
                    this.valorCotacaoField = value;
                    this.RaisePropertyChanged("valorCotacao");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BankA.IBankAOps", SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IBankAOps {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankAOps/subscrever", ReplyAction="http://tempuri.org/IBankAOps/subscreverResponse")]
        void subscrever();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankAOps/unSubscrever", ReplyAction="http://tempuri.org/IBankAOps/unSubscreverResponse")]
        void unSubscrever();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankAOps/GetOrdens", ReplyAction="http://tempuri.org/IBankAOps/GetOrdensResponse")]
        Supervisor.BankA.Ordem[] GetOrdens();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankAOps/GetOrdem", ReplyAction="http://tempuri.org/IBankAOps/GetOrdemResponse")]
        Supervisor.BankA.Ordem GetOrdem(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankAOps/GetNotExecutedOrdens", ReplyAction="http://tempuri.org/IBankAOps/GetNotExecutedOrdensResponse")]
        Supervisor.BankA.Ordem[] GetNotExecutedOrdens();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankAOps/GetExecutedOrdens", ReplyAction="http://tempuri.org/IBankAOps/GetExecutedOrdensResponse")]
        Supervisor.BankA.Ordem[] GetExecutedOrdens();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankAOps/GetClienteOrdens", ReplyAction="http://tempuri.org/IBankAOps/GetClienteOrdensResponse")]
        Supervisor.BankA.Ordem[] GetClienteOrdens(int idCli);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankAOps/addOrdem", ReplyAction="http://tempuri.org/IBankAOps/addOrdemResponse")]
        [System.ServiceModel.TransactionFlowAttribute(System.ServiceModel.TransactionFlowOption.Allowed)]
        void addOrdem(int clientId, int companyId, string email, int type, int quant);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankAOps/executeOrdem", ReplyAction="http://tempuri.org/IBankAOps/executeOrdemResponse")]
        [System.ServiceModel.TransactionFlowAttribute(System.ServiceModel.TransactionFlowOption.Allowed)]
        void executeOrdem(int id, double value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankAOps/GetClientes", ReplyAction="http://tempuri.org/IBankAOps/GetClientesResponse")]
        Supervisor.BankA.Cliente[] GetClientes();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankAOps/GetCliente", ReplyAction="http://tempuri.org/IBankAOps/GetClienteResponse")]
        Supervisor.BankA.Cliente GetCliente(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankAOps/GetEmpresas", ReplyAction="http://tempuri.org/IBankAOps/GetEmpresasResponse")]
        Supervisor.BankA.Empresa[] GetEmpresas();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankAOps/GetEmpresa", ReplyAction="http://tempuri.org/IBankAOps/GetEmpresaResponse")]
        Supervisor.BankA.Empresa GetEmpresa(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankAOps/editEmpresaValue", ReplyAction="http://tempuri.org/IBankAOps/editEmpresaValueResponse")]
        [System.ServiceModel.TransactionFlowAttribute(System.ServiceModel.TransactionFlowOption.Allowed)]
        void editEmpresaValue(int id, int val);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBankAOpsChannel : Supervisor.BankA.IBankAOps, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BankAOpsClient : System.ServiceModel.ClientBase<Supervisor.BankA.IBankAOps>, Supervisor.BankA.IBankAOps {
        
        public BankAOpsClient() {
        }
        
        public BankAOpsClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BankAOpsClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BankAOpsClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BankAOpsClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void subscrever() {
            base.Channel.subscrever();
        }
        
        public void unSubscrever() {
            base.Channel.unSubscrever();
        }
        
        public Supervisor.BankA.Ordem[] GetOrdens() {
            return base.Channel.GetOrdens();
        }
        
        public Supervisor.BankA.Ordem GetOrdem(int id) {
            return base.Channel.GetOrdem(id);
        }
        
        public Supervisor.BankA.Ordem[] GetNotExecutedOrdens() {
            return base.Channel.GetNotExecutedOrdens();
        }
        
        public Supervisor.BankA.Ordem[] GetExecutedOrdens() {
            return base.Channel.GetExecutedOrdens();
        }
        
        public Supervisor.BankA.Ordem[] GetClienteOrdens(int idCli) {
            return base.Channel.GetClienteOrdens(idCli);
        }
        
        public void addOrdem(int clientId, int companyId, string email, int type, int quant) {
            base.Channel.addOrdem(clientId, companyId, email, type, quant);
        }
        
        public void executeOrdem(int id, double value) {
            base.Channel.executeOrdem(id, value);
        }
        
        public Supervisor.BankA.Cliente[] GetClientes() {
            return base.Channel.GetClientes();
        }
        
        public Supervisor.BankA.Cliente GetCliente(int id) {
            return base.Channel.GetCliente(id);
        }
        
        public Supervisor.BankA.Empresa[] GetEmpresas() {
            return base.Channel.GetEmpresas();
        }
        
        public Supervisor.BankA.Empresa GetEmpresa(int id) {
            return base.Channel.GetEmpresa(id);
        }
        
        public void editEmpresaValue(int id, int val) {
            base.Channel.editEmpresaValue(id, val);
        }
    }
}