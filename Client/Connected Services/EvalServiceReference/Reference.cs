﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.EvalServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EvalServiceReference.IEvalService")]
    public interface IEvalService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEvalService/SubmitEval", ReplyAction="http://tempuri.org/IEvalService/SubmitEvalResponse")]
        void SubmitEval(EvalServiceLibrary.Eval eval);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEvalService/SubmitEval", ReplyAction="http://tempuri.org/IEvalService/SubmitEvalResponse")]
        System.Threading.Tasks.Task SubmitEvalAsync(EvalServiceLibrary.Eval eval);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEvalService/GetEvals", ReplyAction="http://tempuri.org/IEvalService/GetEvalsResponse")]
        EvalServiceLibrary.Eval[] GetEvals();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEvalService/GetEvals", ReplyAction="http://tempuri.org/IEvalService/GetEvalsResponse")]
        System.Threading.Tasks.Task<EvalServiceLibrary.Eval[]> GetEvalsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IEvalServiceChannel : Client.EvalServiceReference.IEvalService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EvalServiceClient : System.ServiceModel.ClientBase<Client.EvalServiceReference.IEvalService>, Client.EvalServiceReference.IEvalService {
        
        public EvalServiceClient() {
        }
        
        public EvalServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public EvalServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EvalServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EvalServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void SubmitEval(EvalServiceLibrary.Eval eval) {
            base.Channel.SubmitEval(eval);
        }
        
        public System.Threading.Tasks.Task SubmitEvalAsync(EvalServiceLibrary.Eval eval) {
            return base.Channel.SubmitEvalAsync(eval);
        }
        
        public EvalServiceLibrary.Eval[] GetEvals() {
            return base.Channel.GetEvals();
        }
        
        public System.Threading.Tasks.Task<EvalServiceLibrary.Eval[]> GetEvalsAsync() {
            return base.Channel.GetEvalsAsync();
        }
    }
}