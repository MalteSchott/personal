﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleClient.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ArrayOfString", Namespace="http://stableGeniuses.com/", ItemName="string")]
    [System.SerializableAttribute()]
    public class ArrayOfString : System.Collections.Generic.List<string> {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://stableGeniuses.com/", ConfigurationName="ServiceReference1.WebService1Soap")]
    public interface WebService1Soap {
        
        // CODEGEN: Generating message contract since element name file from namespace http://stableGeniuses.com/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://stableGeniuses.com/GetFileContents", ReplyAction="*")]
        ConsoleClient.ServiceReference1.GetFileContentsResponse GetFileContents(ConsoleClient.ServiceReference1.GetFileContentsRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://stableGeniuses.com/GetFileContents", ReplyAction="*")]
        System.Threading.Tasks.Task<ConsoleClient.ServiceReference1.GetFileContentsResponse> GetFileContentsAsync(ConsoleClient.ServiceReference1.GetFileContentsRequest request);
        
        // CODEGEN: Generating message contract since element name HelloWorldResult from namespace http://stableGeniuses.com/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://stableGeniuses.com/HelloWorld", ReplyAction="*")]
        ConsoleClient.ServiceReference1.HelloWorldResponse HelloWorld(ConsoleClient.ServiceReference1.HelloWorldRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://stableGeniuses.com/HelloWorld", ReplyAction="*")]
        System.Threading.Tasks.Task<ConsoleClient.ServiceReference1.HelloWorldResponse> HelloWorldAsync(ConsoleClient.ServiceReference1.HelloWorldRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetFileContentsRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetFileContents", Namespace="http://stableGeniuses.com/", Order=0)]
        public ConsoleClient.ServiceReference1.GetFileContentsRequestBody Body;
        
        public GetFileContentsRequest() {
        }
        
        public GetFileContentsRequest(ConsoleClient.ServiceReference1.GetFileContentsRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://stableGeniuses.com/")]
    public partial class GetFileContentsRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string file;
        
        public GetFileContentsRequestBody() {
        }
        
        public GetFileContentsRequestBody(string file) {
            this.file = file;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetFileContentsResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetFileContentsResponse", Namespace="http://stableGeniuses.com/", Order=0)]
        public ConsoleClient.ServiceReference1.GetFileContentsResponseBody Body;
        
        public GetFileContentsResponse() {
        }
        
        public GetFileContentsResponse(ConsoleClient.ServiceReference1.GetFileContentsResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://stableGeniuses.com/")]
    public partial class GetFileContentsResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public ConsoleClient.ServiceReference1.ArrayOfString GetFileContentsResult;
        
        public GetFileContentsResponseBody() {
        }
        
        public GetFileContentsResponseBody(ConsoleClient.ServiceReference1.ArrayOfString GetFileContentsResult) {
            this.GetFileContentsResult = GetFileContentsResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorld", Namespace="http://stableGeniuses.com/", Order=0)]
        public ConsoleClient.ServiceReference1.HelloWorldRequestBody Body;
        
        public HelloWorldRequest() {
        }
        
        public HelloWorldRequest(ConsoleClient.ServiceReference1.HelloWorldRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class HelloWorldRequestBody {
        
        public HelloWorldRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorldResponse", Namespace="http://stableGeniuses.com/", Order=0)]
        public ConsoleClient.ServiceReference1.HelloWorldResponseBody Body;
        
        public HelloWorldResponse() {
        }
        
        public HelloWorldResponse(ConsoleClient.ServiceReference1.HelloWorldResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://stableGeniuses.com/")]
    public partial class HelloWorldResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string HelloWorldResult;
        
        public HelloWorldResponseBody() {
        }
        
        public HelloWorldResponseBody(string HelloWorldResult) {
            this.HelloWorldResult = HelloWorldResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WebService1SoapChannel : ConsoleClient.ServiceReference1.WebService1Soap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebService1SoapClient : System.ServiceModel.ClientBase<ConsoleClient.ServiceReference1.WebService1Soap>, ConsoleClient.ServiceReference1.WebService1Soap {
        
        public WebService1SoapClient() {
        }
        
        public WebService1SoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WebService1SoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebService1SoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebService1SoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ConsoleClient.ServiceReference1.GetFileContentsResponse ConsoleClient.ServiceReference1.WebService1Soap.GetFileContents(ConsoleClient.ServiceReference1.GetFileContentsRequest request) {
            return base.Channel.GetFileContents(request);
        }
        
        public ConsoleClient.ServiceReference1.ArrayOfString GetFileContents(string file) {
            ConsoleClient.ServiceReference1.GetFileContentsRequest inValue = new ConsoleClient.ServiceReference1.GetFileContentsRequest();
            inValue.Body = new ConsoleClient.ServiceReference1.GetFileContentsRequestBody();
            inValue.Body.file = file;
            ConsoleClient.ServiceReference1.GetFileContentsResponse retVal = ((ConsoleClient.ServiceReference1.WebService1Soap)(this)).GetFileContents(inValue);
            return retVal.Body.GetFileContentsResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ConsoleClient.ServiceReference1.GetFileContentsResponse> ConsoleClient.ServiceReference1.WebService1Soap.GetFileContentsAsync(ConsoleClient.ServiceReference1.GetFileContentsRequest request) {
            return base.Channel.GetFileContentsAsync(request);
        }
        
        public System.Threading.Tasks.Task<ConsoleClient.ServiceReference1.GetFileContentsResponse> GetFileContentsAsync(string file) {
            ConsoleClient.ServiceReference1.GetFileContentsRequest inValue = new ConsoleClient.ServiceReference1.GetFileContentsRequest();
            inValue.Body = new ConsoleClient.ServiceReference1.GetFileContentsRequestBody();
            inValue.Body.file = file;
            return ((ConsoleClient.ServiceReference1.WebService1Soap)(this)).GetFileContentsAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ConsoleClient.ServiceReference1.HelloWorldResponse ConsoleClient.ServiceReference1.WebService1Soap.HelloWorld(ConsoleClient.ServiceReference1.HelloWorldRequest request) {
            return base.Channel.HelloWorld(request);
        }
        
        public string HelloWorld() {
            ConsoleClient.ServiceReference1.HelloWorldRequest inValue = new ConsoleClient.ServiceReference1.HelloWorldRequest();
            inValue.Body = new ConsoleClient.ServiceReference1.HelloWorldRequestBody();
            ConsoleClient.ServiceReference1.HelloWorldResponse retVal = ((ConsoleClient.ServiceReference1.WebService1Soap)(this)).HelloWorld(inValue);
            return retVal.Body.HelloWorldResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ConsoleClient.ServiceReference1.HelloWorldResponse> ConsoleClient.ServiceReference1.WebService1Soap.HelloWorldAsync(ConsoleClient.ServiceReference1.HelloWorldRequest request) {
            return base.Channel.HelloWorldAsync(request);
        }
        
        public System.Threading.Tasks.Task<ConsoleClient.ServiceReference1.HelloWorldResponse> HelloWorldAsync() {
            ConsoleClient.ServiceReference1.HelloWorldRequest inValue = new ConsoleClient.ServiceReference1.HelloWorldRequest();
            inValue.Body = new ConsoleClient.ServiceReference1.HelloWorldRequestBody();
            return ((ConsoleClient.ServiceReference1.WebService1Soap)(this)).HelloWorldAsync(inValue);
        }
    }
}