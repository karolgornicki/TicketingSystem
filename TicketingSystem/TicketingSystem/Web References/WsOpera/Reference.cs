﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.1.
// 
#pragma warning disable 1591

namespace TicketingSystem.WsOpera {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="Service1Soap", Namespace="http://tempuri.org/")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(object[]))]
    public partial class Service1 : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetSeatsOperationCompleted;
        
        private System.Threading.SendOrPostCallback BookSeatOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetShowDetailsOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetScheduleForDateOperationCompleted;
        
        private System.Threading.SendOrPostCallback Get3EarliestEntertainmentOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetScheduleForAMonthOperationCompleted;
        
        private System.Threading.SendOrPostCallback CancelReservationOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Service1() {
            this.Url = global::TicketingSystem.Properties.Settings.Default.TicketingSystem_WsOpera_Service1;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event GetSeatsCompletedEventHandler GetSeatsCompleted;
        
        /// <remarks/>
        public event BookSeatCompletedEventHandler BookSeatCompleted;
        
        /// <remarks/>
        public event GetShowDetailsCompletedEventHandler GetShowDetailsCompleted;
        
        /// <remarks/>
        public event GetScheduleForDateCompletedEventHandler GetScheduleForDateCompleted;
        
        /// <remarks/>
        public event Get3EarliestEntertainmentCompletedEventHandler Get3EarliestEntertainmentCompleted;
        
        /// <remarks/>
        public event GetScheduleForAMonthCompletedEventHandler GetScheduleForAMonthCompleted;
        
        /// <remarks/>
        public event CancelReservationCompletedEventHandler CancelReservationCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetSeats", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public object[] GetSeats(System.DateTime date, string showTitle) {
            object[] results = this.Invoke("GetSeats", new object[] {
                        date,
                        showTitle});
            return ((object[])(results[0]));
        }
        
        /// <remarks/>
        public void GetSeatsAsync(System.DateTime date, string showTitle) {
            this.GetSeatsAsync(date, showTitle, null);
        }
        
        /// <remarks/>
        public void GetSeatsAsync(System.DateTime date, string showTitle, object userState) {
            if ((this.GetSeatsOperationCompleted == null)) {
                this.GetSeatsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetSeatsOperationCompleted);
            }
            this.InvokeAsync("GetSeats", new object[] {
                        date,
                        showTitle}, this.GetSeatsOperationCompleted, userState);
        }
        
        private void OnGetSeatsOperationCompleted(object arg) {
            if ((this.GetSeatsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetSeatsCompleted(this, new GetSeatsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/BookSeat", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string BookSeat(System.DateTime date, string showTitle, int row, int number, string customerName) {
            object[] results = this.Invoke("BookSeat", new object[] {
                        date,
                        showTitle,
                        row,
                        number,
                        customerName});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void BookSeatAsync(System.DateTime date, string showTitle, int row, int number, string customerName) {
            this.BookSeatAsync(date, showTitle, row, number, customerName, null);
        }
        
        /// <remarks/>
        public void BookSeatAsync(System.DateTime date, string showTitle, int row, int number, string customerName, object userState) {
            if ((this.BookSeatOperationCompleted == null)) {
                this.BookSeatOperationCompleted = new System.Threading.SendOrPostCallback(this.OnBookSeatOperationCompleted);
            }
            this.InvokeAsync("BookSeat", new object[] {
                        date,
                        showTitle,
                        row,
                        number,
                        customerName}, this.BookSeatOperationCompleted, userState);
        }
        
        private void OnBookSeatOperationCompleted(object arg) {
            if ((this.BookSeatCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.BookSeatCompleted(this, new BookSeatCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetShowDetails", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public object[] GetShowDetails(string showTitle) {
            object[] results = this.Invoke("GetShowDetails", new object[] {
                        showTitle});
            return ((object[])(results[0]));
        }
        
        /// <remarks/>
        public void GetShowDetailsAsync(string showTitle) {
            this.GetShowDetailsAsync(showTitle, null);
        }
        
        /// <remarks/>
        public void GetShowDetailsAsync(string showTitle, object userState) {
            if ((this.GetShowDetailsOperationCompleted == null)) {
                this.GetShowDetailsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetShowDetailsOperationCompleted);
            }
            this.InvokeAsync("GetShowDetails", new object[] {
                        showTitle}, this.GetShowDetailsOperationCompleted, userState);
        }
        
        private void OnGetShowDetailsOperationCompleted(object arg) {
            if ((this.GetShowDetailsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetShowDetailsCompleted(this, new GetShowDetailsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetScheduleForDate", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public object[] GetScheduleForDate(System.DateTime date) {
            object[] results = this.Invoke("GetScheduleForDate", new object[] {
                        date});
            return ((object[])(results[0]));
        }
        
        /// <remarks/>
        public void GetScheduleForDateAsync(System.DateTime date) {
            this.GetScheduleForDateAsync(date, null);
        }
        
        /// <remarks/>
        public void GetScheduleForDateAsync(System.DateTime date, object userState) {
            if ((this.GetScheduleForDateOperationCompleted == null)) {
                this.GetScheduleForDateOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetScheduleForDateOperationCompleted);
            }
            this.InvokeAsync("GetScheduleForDate", new object[] {
                        date}, this.GetScheduleForDateOperationCompleted, userState);
        }
        
        private void OnGetScheduleForDateOperationCompleted(object arg) {
            if ((this.GetScheduleForDateCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetScheduleForDateCompleted(this, new GetScheduleForDateCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Get3EarliestEntertainment", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public object[] Get3EarliestEntertainment(System.DateTime sinceDate) {
            object[] results = this.Invoke("Get3EarliestEntertainment", new object[] {
                        sinceDate});
            return ((object[])(results[0]));
        }
        
        /// <remarks/>
        public void Get3EarliestEntertainmentAsync(System.DateTime sinceDate) {
            this.Get3EarliestEntertainmentAsync(sinceDate, null);
        }
        
        /// <remarks/>
        public void Get3EarliestEntertainmentAsync(System.DateTime sinceDate, object userState) {
            if ((this.Get3EarliestEntertainmentOperationCompleted == null)) {
                this.Get3EarliestEntertainmentOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGet3EarliestEntertainmentOperationCompleted);
            }
            this.InvokeAsync("Get3EarliestEntertainment", new object[] {
                        sinceDate}, this.Get3EarliestEntertainmentOperationCompleted, userState);
        }
        
        private void OnGet3EarliestEntertainmentOperationCompleted(object arg) {
            if ((this.Get3EarliestEntertainmentCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Get3EarliestEntertainmentCompleted(this, new Get3EarliestEntertainmentCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetScheduleForAMonth", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public object[] GetScheduleForAMonth(System.DateTime date) {
            object[] results = this.Invoke("GetScheduleForAMonth", new object[] {
                        date});
            return ((object[])(results[0]));
        }
        
        /// <remarks/>
        public void GetScheduleForAMonthAsync(System.DateTime date) {
            this.GetScheduleForAMonthAsync(date, null);
        }
        
        /// <remarks/>
        public void GetScheduleForAMonthAsync(System.DateTime date, object userState) {
            if ((this.GetScheduleForAMonthOperationCompleted == null)) {
                this.GetScheduleForAMonthOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetScheduleForAMonthOperationCompleted);
            }
            this.InvokeAsync("GetScheduleForAMonth", new object[] {
                        date}, this.GetScheduleForAMonthOperationCompleted, userState);
        }
        
        private void OnGetScheduleForAMonthOperationCompleted(object arg) {
            if ((this.GetScheduleForAMonthCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetScheduleForAMonthCompleted(this, new GetScheduleForAMonthCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CancelReservation", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string CancelReservation(System.DateTime date, string showTitle, int row, int number) {
            object[] results = this.Invoke("CancelReservation", new object[] {
                        date,
                        showTitle,
                        row,
                        number});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void CancelReservationAsync(System.DateTime date, string showTitle, int row, int number) {
            this.CancelReservationAsync(date, showTitle, row, number, null);
        }
        
        /// <remarks/>
        public void CancelReservationAsync(System.DateTime date, string showTitle, int row, int number, object userState) {
            if ((this.CancelReservationOperationCompleted == null)) {
                this.CancelReservationOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCancelReservationOperationCompleted);
            }
            this.InvokeAsync("CancelReservation", new object[] {
                        date,
                        showTitle,
                        row,
                        number}, this.CancelReservationOperationCompleted, userState);
        }
        
        private void OnCancelReservationOperationCompleted(object arg) {
            if ((this.CancelReservationCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CancelReservationCompleted(this, new CancelReservationCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetSeatsCompletedEventHandler(object sender, GetSeatsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetSeatsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetSeatsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public object[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((object[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void BookSeatCompletedEventHandler(object sender, BookSeatCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class BookSeatCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal BookSeatCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetShowDetailsCompletedEventHandler(object sender, GetShowDetailsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetShowDetailsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetShowDetailsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public object[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((object[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetScheduleForDateCompletedEventHandler(object sender, GetScheduleForDateCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetScheduleForDateCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetScheduleForDateCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public object[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((object[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void Get3EarliestEntertainmentCompletedEventHandler(object sender, Get3EarliestEntertainmentCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Get3EarliestEntertainmentCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Get3EarliestEntertainmentCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public object[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((object[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetScheduleForAMonthCompletedEventHandler(object sender, GetScheduleForAMonthCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetScheduleForAMonthCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetScheduleForAMonthCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public object[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((object[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void CancelReservationCompletedEventHandler(object sender, CancelReservationCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CancelReservationCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CancelReservationCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591