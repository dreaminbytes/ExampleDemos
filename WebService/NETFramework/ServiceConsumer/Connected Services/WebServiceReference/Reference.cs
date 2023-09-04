﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceConsumer.WebServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SumClass", Namespace="http://some-domain.com/WebServiceDemo")]
    [System.SerializableAttribute()]
    public partial class SumClass : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int FirstField;
        
        private int SecondField;
        
        private int SumField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int First {
            get {
                return this.FirstField;
            }
            set {
                if ((this.FirstField.Equals(value) != true)) {
                    this.FirstField = value;
                    this.RaisePropertyChanged("First");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int Second {
            get {
                return this.SecondField;
            }
            set {
                if ((this.SecondField.Equals(value) != true)) {
                    this.SecondField = value;
                    this.RaisePropertyChanged("Second");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int Sum {
            get {
                return this.SumField;
            }
            set {
                if ((this.SumField.Equals(value) != true)) {
                    this.SumField = value;
                    this.RaisePropertyChanged("Sum");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://some-domain.com/WebServiceDemo", ConfigurationName="WebServiceReference.WebSvcDemoSoap")]
    public interface WebSvcDemoSoap {
        
        // CODEGEN: Generating message contract since element name HelloWorldResult from namespace http://some-domain.com/WebServiceDemo is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://some-domain.com/WebServiceDemo/HelloWorld", ReplyAction="*")]
        ServiceConsumer.WebServiceReference.HelloWorldResponse HelloWorld(ServiceConsumer.WebServiceReference.HelloWorldRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://some-domain.com/WebServiceDemo/HelloWorld", ReplyAction="*")]
        System.Threading.Tasks.Task<ServiceConsumer.WebServiceReference.HelloWorldResponse> HelloWorldAsync(ServiceConsumer.WebServiceReference.HelloWorldRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://some-domain.com/WebServiceDemo/SumOfNums", ReplyAction="*")]
        int SumOfNums(int First, int Second);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://some-domain.com/WebServiceDemo/SumOfNums", ReplyAction="*")]
        System.Threading.Tasks.Task<int> SumOfNumsAsync(int First, int Second);
        
        // CODEGEN: Generating message contract since the wrapper name (GetSumThroughObject) of message GetSumThroughObject does not match the default value (SumOfNums1)
        [System.ServiceModel.OperationContractAttribute(Action="http://some-domain.com/WebServiceDemo/GetSumThroughObject", ReplyAction="*")]
        ServiceConsumer.WebServiceReference.GetSumThroughObject1 SumOfNums1(ServiceConsumer.WebServiceReference.GetSumThroughObject request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://some-domain.com/WebServiceDemo/GetSumThroughObject", ReplyAction="*")]
        System.Threading.Tasks.Task<ServiceConsumer.WebServiceReference.GetSumThroughObject1> SumOfNums1Async(ServiceConsumer.WebServiceReference.GetSumThroughObject request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorld", Namespace="http://some-domain.com/WebServiceDemo", Order=0)]
        public ServiceConsumer.WebServiceReference.HelloWorldRequestBody Body;
        
        public HelloWorldRequest() {
        }
        
        public HelloWorldRequest(ServiceConsumer.WebServiceReference.HelloWorldRequestBody Body) {
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
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorldResponse", Namespace="http://some-domain.com/WebServiceDemo", Order=0)]
        public ServiceConsumer.WebServiceReference.HelloWorldResponseBody Body;
        
        public HelloWorldResponse() {
        }
        
        public HelloWorldResponse(ServiceConsumer.WebServiceReference.HelloWorldResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://some-domain.com/WebServiceDemo")]
    public partial class HelloWorldResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string HelloWorldResult;
        
        public HelloWorldResponseBody() {
        }
        
        public HelloWorldResponseBody(string HelloWorldResult) {
            this.HelloWorldResult = HelloWorldResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetSumThroughObject", WrapperNamespace="http://some-domain.com/WebServiceDemo", IsWrapped=true)]
    public partial class GetSumThroughObject {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://some-domain.com/WebServiceDemo", Order=0)]
        public string JsonStr;
        
        public GetSumThroughObject() {
        }
        
        public GetSumThroughObject(string JsonStr) {
            this.JsonStr = JsonStr;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetSumThroughObjectResponse", WrapperNamespace="http://some-domain.com/WebServiceDemo", IsWrapped=true)]
    public partial class GetSumThroughObject1 {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://some-domain.com/WebServiceDemo", Order=0)]
        public ServiceConsumer.WebServiceReference.SumClass GetSumThroughObjectResult;
        
        public GetSumThroughObject1() {
        }
        
        public GetSumThroughObject1(ServiceConsumer.WebServiceReference.SumClass GetSumThroughObjectResult) {
            this.GetSumThroughObjectResult = GetSumThroughObjectResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WebSvcDemoSoapChannel : ServiceConsumer.WebServiceReference.WebSvcDemoSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebSvcDemoSoapClient : System.ServiceModel.ClientBase<ServiceConsumer.WebServiceReference.WebSvcDemoSoap>, ServiceConsumer.WebServiceReference.WebSvcDemoSoap {
        
        public WebSvcDemoSoapClient() {
        }
        
        public WebSvcDemoSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WebSvcDemoSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebSvcDemoSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebSvcDemoSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ServiceConsumer.WebServiceReference.HelloWorldResponse ServiceConsumer.WebServiceReference.WebSvcDemoSoap.HelloWorld(ServiceConsumer.WebServiceReference.HelloWorldRequest request) {
            return base.Channel.HelloWorld(request);
        }
        
        public string HelloWorld() {
            ServiceConsumer.WebServiceReference.HelloWorldRequest inValue = new ServiceConsumer.WebServiceReference.HelloWorldRequest();
            inValue.Body = new ServiceConsumer.WebServiceReference.HelloWorldRequestBody();
            ServiceConsumer.WebServiceReference.HelloWorldResponse retVal = ((ServiceConsumer.WebServiceReference.WebSvcDemoSoap)(this)).HelloWorld(inValue);
            return retVal.Body.HelloWorldResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceConsumer.WebServiceReference.HelloWorldResponse> ServiceConsumer.WebServiceReference.WebSvcDemoSoap.HelloWorldAsync(ServiceConsumer.WebServiceReference.HelloWorldRequest request) {
            return base.Channel.HelloWorldAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceConsumer.WebServiceReference.HelloWorldResponse> HelloWorldAsync() {
            ServiceConsumer.WebServiceReference.HelloWorldRequest inValue = new ServiceConsumer.WebServiceReference.HelloWorldRequest();
            inValue.Body = new ServiceConsumer.WebServiceReference.HelloWorldRequestBody();
            return ((ServiceConsumer.WebServiceReference.WebSvcDemoSoap)(this)).HelloWorldAsync(inValue);
        }
        
        public int SumOfNums(int First, int Second) {
            return base.Channel.SumOfNums(First, Second);
        }
        
        public System.Threading.Tasks.Task<int> SumOfNumsAsync(int First, int Second) {
            return base.Channel.SumOfNumsAsync(First, Second);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ServiceConsumer.WebServiceReference.GetSumThroughObject1 ServiceConsumer.WebServiceReference.WebSvcDemoSoap.SumOfNums1(ServiceConsumer.WebServiceReference.GetSumThroughObject request) {
            return base.Channel.SumOfNums1(request);
        }
        
        public ServiceConsumer.WebServiceReference.SumClass SumOfNums1(string JsonStr) {
            ServiceConsumer.WebServiceReference.GetSumThroughObject inValue = new ServiceConsumer.WebServiceReference.GetSumThroughObject();
            inValue.JsonStr = JsonStr;
            ServiceConsumer.WebServiceReference.GetSumThroughObject1 retVal = ((ServiceConsumer.WebServiceReference.WebSvcDemoSoap)(this)).SumOfNums1(inValue);
            return retVal.GetSumThroughObjectResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceConsumer.WebServiceReference.GetSumThroughObject1> ServiceConsumer.WebServiceReference.WebSvcDemoSoap.SumOfNums1Async(ServiceConsumer.WebServiceReference.GetSumThroughObject request) {
            return base.Channel.SumOfNums1Async(request);
        }
        
        public System.Threading.Tasks.Task<ServiceConsumer.WebServiceReference.GetSumThroughObject1> SumOfNums1Async(string JsonStr) {
            ServiceConsumer.WebServiceReference.GetSumThroughObject inValue = new ServiceConsumer.WebServiceReference.GetSumThroughObject();
            inValue.JsonStr = JsonStr;
            return ((ServiceConsumer.WebServiceReference.WebSvcDemoSoap)(this)).SumOfNums1Async(inValue);
        }
    }
}