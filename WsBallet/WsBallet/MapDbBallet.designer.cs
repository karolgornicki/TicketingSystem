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

namespace WsBallet
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="DbBallet")]
	public partial class MapDbBalletDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertEntertainment(Entertainment instance);
    partial void UpdateEntertainment(Entertainment instance);
    partial void DeleteEntertainment(Entertainment instance);
    partial void InsertSeat(Seat instance);
    partial void UpdateSeat(Seat instance);
    partial void DeleteSeat(Seat instance);
    partial void InsertShow(Show instance);
    partial void UpdateShow(Show instance);
    partial void DeleteShow(Show instance);
    #endregion
		
		public MapDbBalletDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["DbBalletConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public MapDbBalletDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MapDbBalletDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MapDbBalletDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MapDbBalletDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Entertainment> Entertainments
		{
			get
			{
				return this.GetTable<Entertainment>();
			}
		}
		
		public System.Data.Linq.Table<Seat> Seats
		{
			get
			{
				return this.GetTable<Seat>();
			}
		}
		
		public System.Data.Linq.Table<Show> Shows
		{
			get
			{
				return this.GetTable<Show>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Entertainments")]
	public partial class Entertainment : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _EntertainmentID;
		
		private int _ShowID;
		
		private System.DateTime _Date;
		
		private EntitySet<Seat> _Seats;
		
		private EntityRef<Show> _Show;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnEntertainmentIDChanging(int value);
    partial void OnEntertainmentIDChanged();
    partial void OnShowIDChanging(int value);
    partial void OnShowIDChanged();
    partial void OnDateChanging(System.DateTime value);
    partial void OnDateChanged();
    #endregion
		
		public Entertainment()
		{
			this._Seats = new EntitySet<Seat>(new Action<Seat>(this.attach_Seats), new Action<Seat>(this.detach_Seats));
			this._Show = default(EntityRef<Show>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EntertainmentID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int EntertainmentID
		{
			get
			{
				return this._EntertainmentID;
			}
			set
			{
				if ((this._EntertainmentID != value))
				{
					this.OnEntertainmentIDChanging(value);
					this.SendPropertyChanging();
					this._EntertainmentID = value;
					this.SendPropertyChanged("EntertainmentID");
					this.OnEntertainmentIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ShowID", DbType="Int NOT NULL")]
		public int ShowID
		{
			get
			{
				return this._ShowID;
			}
			set
			{
				if ((this._ShowID != value))
				{
					if (this._Show.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnShowIDChanging(value);
					this.SendPropertyChanging();
					this._ShowID = value;
					this.SendPropertyChanged("ShowID");
					this.OnShowIDChanged();
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
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Entertainment_Seat", Storage="_Seats", ThisKey="EntertainmentID", OtherKey="EntertainmentID")]
		public EntitySet<Seat> Seats
		{
			get
			{
				return this._Seats;
			}
			set
			{
				this._Seats.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Show_Entertainment", Storage="_Show", ThisKey="ShowID", OtherKey="ShowID", IsForeignKey=true)]
		public Show Show
		{
			get
			{
				return this._Show.Entity;
			}
			set
			{
				Show previousValue = this._Show.Entity;
				if (((previousValue != value) 
							|| (this._Show.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Show.Entity = null;
						previousValue.Entertainments.Remove(this);
					}
					this._Show.Entity = value;
					if ((value != null))
					{
						value.Entertainments.Add(this);
						this._ShowID = value.ShowID;
					}
					else
					{
						this._ShowID = default(int);
					}
					this.SendPropertyChanged("Show");
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
		
		private void attach_Seats(Seat entity)
		{
			this.SendPropertyChanging();
			entity.Entertainment = this;
		}
		
		private void detach_Seats(Seat entity)
		{
			this.SendPropertyChanging();
			entity.Entertainment = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Seats")]
	public partial class Seat : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _SeatID;
		
		private int _EntertainmentID;
		
		private int _Row;
		
		private int _Number;
		
		private decimal _Price;
		
		private string _CustomerName;
		
		private EntityRef<Entertainment> _Entertainment;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnSeatIDChanging(int value);
    partial void OnSeatIDChanged();
    partial void OnEntertainmentIDChanging(int value);
    partial void OnEntertainmentIDChanged();
    partial void OnRowChanging(int value);
    partial void OnRowChanged();
    partial void OnNumberChanging(int value);
    partial void OnNumberChanged();
    partial void OnPriceChanging(decimal value);
    partial void OnPriceChanged();
    partial void OnCustomerNameChanging(string value);
    partial void OnCustomerNameChanged();
    #endregion
		
		public Seat()
		{
			this._Entertainment = default(EntityRef<Entertainment>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SeatID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int SeatID
		{
			get
			{
				return this._SeatID;
			}
			set
			{
				if ((this._SeatID != value))
				{
					this.OnSeatIDChanging(value);
					this.SendPropertyChanging();
					this._SeatID = value;
					this.SendPropertyChanged("SeatID");
					this.OnSeatIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EntertainmentID", DbType="Int NOT NULL")]
		public int EntertainmentID
		{
			get
			{
				return this._EntertainmentID;
			}
			set
			{
				if ((this._EntertainmentID != value))
				{
					if (this._Entertainment.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnEntertainmentIDChanging(value);
					this.SendPropertyChanging();
					this._EntertainmentID = value;
					this.SendPropertyChanged("EntertainmentID");
					this.OnEntertainmentIDChanged();
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="Money NOT NULL")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CustomerName", DbType="VarChar(50)")]
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
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Entertainment_Seat", Storage="_Entertainment", ThisKey="EntertainmentID", OtherKey="EntertainmentID", IsForeignKey=true)]
		public Entertainment Entertainment
		{
			get
			{
				return this._Entertainment.Entity;
			}
			set
			{
				Entertainment previousValue = this._Entertainment.Entity;
				if (((previousValue != value) 
							|| (this._Entertainment.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Entertainment.Entity = null;
						previousValue.Seats.Remove(this);
					}
					this._Entertainment.Entity = value;
					if ((value != null))
					{
						value.Seats.Add(this);
						this._EntertainmentID = value.EntertainmentID;
					}
					else
					{
						this._EntertainmentID = default(int);
					}
					this.SendPropertyChanged("Entertainment");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Shows")]
	public partial class Show : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ShowID;
		
		private string _Title;
		
		private string _Conductor;
		
		private string _ChoreographyBy;
		
		private string _Cast;
		
		private string _MusicBy;
		
		private int _Runtime;
		
		private EntitySet<Entertainment> _Entertainments;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnShowIDChanging(int value);
    partial void OnShowIDChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnConductorChanging(string value);
    partial void OnConductorChanged();
    partial void OnChoreographyByChanging(string value);
    partial void OnChoreographyByChanged();
    partial void OnCastChanging(string value);
    partial void OnCastChanged();
    partial void OnMusicByChanging(string value);
    partial void OnMusicByChanged();
    partial void OnRuntimeChanging(int value);
    partial void OnRuntimeChanged();
    #endregion
		
		public Show()
		{
			this._Entertainments = new EntitySet<Entertainment>(new Action<Entertainment>(this.attach_Entertainments), new Action<Entertainment>(this.detach_Entertainments));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ShowID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ShowID
		{
			get
			{
				return this._ShowID;
			}
			set
			{
				if ((this._ShowID != value))
				{
					this.OnShowIDChanging(value);
					this.SendPropertyChanging();
					this._ShowID = value;
					this.SendPropertyChanged("ShowID");
					this.OnShowIDChanged();
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Conductor", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Conductor
		{
			get
			{
				return this._Conductor;
			}
			set
			{
				if ((this._Conductor != value))
				{
					this.OnConductorChanging(value);
					this.SendPropertyChanging();
					this._Conductor = value;
					this.SendPropertyChanged("Conductor");
					this.OnConductorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ChoreographyBy", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ChoreographyBy
		{
			get
			{
				return this._ChoreographyBy;
			}
			set
			{
				if ((this._ChoreographyBy != value))
				{
					this.OnChoreographyByChanging(value);
					this.SendPropertyChanging();
					this._ChoreographyBy = value;
					this.SendPropertyChanged("ChoreographyBy");
					this.OnChoreographyByChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cast", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Cast
		{
			get
			{
				return this._Cast;
			}
			set
			{
				if ((this._Cast != value))
				{
					this.OnCastChanging(value);
					this.SendPropertyChanging();
					this._Cast = value;
					this.SendPropertyChanged("Cast");
					this.OnCastChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MusicBy", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string MusicBy
		{
			get
			{
				return this._MusicBy;
			}
			set
			{
				if ((this._MusicBy != value))
				{
					this.OnMusicByChanging(value);
					this.SendPropertyChanging();
					this._MusicBy = value;
					this.SendPropertyChanged("MusicBy");
					this.OnMusicByChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Runtime", DbType="Int NOT NULL")]
		public int Runtime
		{
			get
			{
				return this._Runtime;
			}
			set
			{
				if ((this._Runtime != value))
				{
					this.OnRuntimeChanging(value);
					this.SendPropertyChanging();
					this._Runtime = value;
					this.SendPropertyChanged("Runtime");
					this.OnRuntimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Show_Entertainment", Storage="_Entertainments", ThisKey="ShowID", OtherKey="ShowID")]
		public EntitySet<Entertainment> Entertainments
		{
			get
			{
				return this._Entertainments;
			}
			set
			{
				this._Entertainments.Assign(value);
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
		
		private void attach_Entertainments(Entertainment entity)
		{
			this.SendPropertyChanging();
			entity.Show = this;
		}
		
		private void detach_Entertainments(Entertainment entity)
		{
			this.SendPropertyChanging();
			entity.Show = null;
		}
	}
}
#pragma warning restore 1591
