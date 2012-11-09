﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TicketingSystem
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="DbOrders")]
	public partial class MapDbOrdersDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertInvoiceLine(InvoiceLine instance);
    partial void UpdateInvoiceLine(InvoiceLine instance);
    partial void DeleteInvoiceLine(InvoiceLine instance);
    partial void InsertInvoice(Invoice instance);
    partial void UpdateInvoice(Invoice instance);
    partial void DeleteInvoice(Invoice instance);
    #endregion
		
		public MapDbOrdersDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["DbOrdersConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public MapDbOrdersDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MapDbOrdersDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MapDbOrdersDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MapDbOrdersDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<InvoiceLine> InvoiceLines
		{
			get
			{
				return this.GetTable<InvoiceLine>();
			}
		}
		
		public System.Data.Linq.Table<Invoice> Invoices
		{
			get
			{
				return this.GetTable<Invoice>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.InvoiceLines")]
	public partial class InvoiceLine : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _InvoiceLineID;
		
		private int _InvoiceID;
		
		private System.DateTime _DateOfEvent;
		
		private string _Organizer;
		
		private string _Title;
		
		private int _Row;
		
		private int _Number;
		
		private decimal _Price;
		
		private EntityRef<Invoice> _Invoice;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnInvoiceLineIDChanging(int value);
    partial void OnInvoiceLineIDChanged();
    partial void OnInvoiceIDChanging(int value);
    partial void OnInvoiceIDChanged();
    partial void OnDateOfEventChanging(System.DateTime value);
    partial void OnDateOfEventChanged();
    partial void OnOrganizerChanging(string value);
    partial void OnOrganizerChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnRowChanging(int value);
    partial void OnRowChanged();
    partial void OnNumberChanging(int value);
    partial void OnNumberChanged();
    partial void OnPriceChanging(decimal value);
    partial void OnPriceChanged();
    #endregion
		
		public InvoiceLine()
		{
			this._Invoice = default(EntityRef<Invoice>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InvoiceLineID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int InvoiceLineID
		{
			get
			{
				return this._InvoiceLineID;
			}
			set
			{
				if ((this._InvoiceLineID != value))
				{
					this.OnInvoiceLineIDChanging(value);
					this.SendPropertyChanging();
					this._InvoiceLineID = value;
					this.SendPropertyChanged("InvoiceLineID");
					this.OnInvoiceLineIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InvoiceID", DbType="Int NOT NULL")]
		public int InvoiceID
		{
			get
			{
				return this._InvoiceID;
			}
			set
			{
				if ((this._InvoiceID != value))
				{
					if (this._Invoice.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnInvoiceIDChanging(value);
					this.SendPropertyChanging();
					this._InvoiceID = value;
					this.SendPropertyChanged("InvoiceID");
					this.OnInvoiceIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateOfEvent", DbType="DateTime NOT NULL")]
		public System.DateTime DateOfEvent
		{
			get
			{
				return this._DateOfEvent;
			}
			set
			{
				if ((this._DateOfEvent != value))
				{
					this.OnDateOfEventChanging(value);
					this.SendPropertyChanging();
					this._DateOfEvent = value;
					this.SendPropertyChanged("DateOfEvent");
					this.OnDateOfEventChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Organizer", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Organizer
		{
			get
			{
				return this._Organizer;
			}
			set
			{
				if ((this._Organizer != value))
				{
					this.OnOrganizerChanging(value);
					this.SendPropertyChanging();
					this._Organizer = value;
					this.SendPropertyChanged("Organizer");
					this.OnOrganizerChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this.OnTitleChanging(value);
					this.SendPropertyChanging();
					this._Title = value;
					this.SendPropertyChanged("Title");
					this.OnTitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Row", DbType="Int NOT NULL")]
		public int Row
		{
			get
			{
				return this._Row;
			}
			set
			{
				if ((this._Row != value))
				{
					this.OnRowChanging(value);
					this.SendPropertyChanging();
					this._Row = value;
					this.SendPropertyChanged("Row");
					this.OnRowChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Number", DbType="Int NOT NULL")]
		public int Number
		{
			get
			{
				return this._Number;
			}
			set
			{
				if ((this._Number != value))
				{
					this.OnNumberChanging(value);
					this.SendPropertyChanging();
					this._Number = value;
					this.SendPropertyChanged("Number");
					this.OnNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="Decimal(18,2) NOT NULL")]
		public decimal Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this.OnPriceChanging(value);
					this.SendPropertyChanging();
					this._Price = value;
					this.SendPropertyChanged("Price");
					this.OnPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Invoice_InvoiceLine", Storage="_Invoice", ThisKey="InvoiceID", OtherKey="InvoiceID", IsForeignKey=true)]
		public Invoice Invoice
		{
			get
			{
				return this._Invoice.Entity;
			}
			set
			{
				Invoice previousValue = this._Invoice.Entity;
				if (((previousValue != value) 
							|| (this._Invoice.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Invoice.Entity = null;
						previousValue.InvoiceLines.Remove(this);
					}
					this._Invoice.Entity = value;
					if ((value != null))
					{
						value.InvoiceLines.Add(this);
						this._InvoiceID = value.InvoiceID;
					}
					else
					{
						this._InvoiceID = default(int);
					}
					this.SendPropertyChanged("Invoice");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Invoices")]
	public partial class Invoice : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _InvoiceID;
		
		private string _Code;
		
		private System.DateTime _Date;
		
		private string _CustomerName;
		
		private decimal _Subtotal;
		
		private EntitySet<InvoiceLine> _InvoiceLines;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnInvoiceIDChanging(int value);
    partial void OnInvoiceIDChanged();
    partial void OnCodeChanging(string value);
    partial void OnCodeChanged();
    partial void OnDateChanging(System.DateTime value);
    partial void OnDateChanged();
    partial void OnCustomerNameChanging(string value);
    partial void OnCustomerNameChanged();
    partial void OnSubtotalChanging(decimal value);
    partial void OnSubtotalChanged();
    #endregion
		
		public Invoice()
		{
			this._InvoiceLines = new EntitySet<InvoiceLine>(new Action<InvoiceLine>(this.attach_InvoiceLines), new Action<InvoiceLine>(this.detach_InvoiceLines));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InvoiceID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int InvoiceID
		{
			get
			{
				return this._InvoiceID;
			}
			set
			{
				if ((this._InvoiceID != value))
				{
					this.OnInvoiceIDChanging(value);
					this.SendPropertyChanging();
					this._InvoiceID = value;
					this.SendPropertyChanged("InvoiceID");
					this.OnInvoiceIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Code", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Code
		{
			get
			{
				return this._Code;
			}
			set
			{
				if ((this._Code != value))
				{
					this.OnCodeChanging(value);
					this.SendPropertyChanging();
					this._Code = value;
					this.SendPropertyChanged("Code");
					this.OnCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Date", DbType="DateTime NOT NULL")]
		public System.DateTime Date
		{
			get
			{
				return this._Date;
			}
			set
			{
				if ((this._Date != value))
				{
					this.OnDateChanging(value);
					this.SendPropertyChanging();
					this._Date = value;
					this.SendPropertyChanged("Date");
					this.OnDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CustomerName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string CustomerName
		{
			get
			{
				return this._CustomerName;
			}
			set
			{
				if ((this._CustomerName != value))
				{
					this.OnCustomerNameChanging(value);
					this.SendPropertyChanging();
					this._CustomerName = value;
					this.SendPropertyChanged("CustomerName");
					this.OnCustomerNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Subtotal", DbType="Decimal(18,2) NOT NULL")]
		public decimal Subtotal
		{
			get
			{
				return this._Subtotal;
			}
			set
			{
				if ((this._Subtotal != value))
				{
					this.OnSubtotalChanging(value);
					this.SendPropertyChanging();
					this._Subtotal = value;
					this.SendPropertyChanged("Subtotal");
					this.OnSubtotalChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Invoice_InvoiceLine", Storage="_InvoiceLines", ThisKey="InvoiceID", OtherKey="InvoiceID")]
		public EntitySet<InvoiceLine> InvoiceLines
		{
			get
			{
				return this._InvoiceLines;
			}
			set
			{
				this._InvoiceLines.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_InvoiceLines(InvoiceLine entity)
		{
			this.SendPropertyChanging();
			entity.Invoice = this;
		}
		
		private void detach_InvoiceLines(InvoiceLine entity)
		{
			this.SendPropertyChanging();
			entity.Invoice = null;
		}
	}
}
#pragma warning restore 1591
