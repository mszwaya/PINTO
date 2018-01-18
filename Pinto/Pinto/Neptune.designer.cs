﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pinto
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="NEPTUNE")]
	public partial class NeptuneDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertCYCLE_DATA(CYCLE_DATA instance);
    partial void UpdateCYCLE_DATA(CYCLE_DATA instance);
    partial void DeleteCYCLE_DATA(CYCLE_DATA instance);
    #endregion
		
		public NeptuneDataContext() : 
				base(global::Pinto.Properties.Settings.Default.NEPTUNEConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public NeptuneDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public NeptuneDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public NeptuneDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public NeptuneDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<CYCLE_DATA> CYCLE_DATAs
		{
			get
			{
				return this.GetTable<CYCLE_DATA>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CYCLE_DATA")]
	public partial class CYCLE_DATA : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _cycle_data_id;
		
		private int _calendar_date_id;
		
		private int _time_of_day_id;
		
		private int _station_id;
		
		private int _pump_id;
		
		private System.DateTime _cycle_change_time;
		
		private byte _onoff_state;
		
		private System.DateTime _load_date;
		
		private string _source_filename;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Oncycle_data_idChanging(int value);
    partial void Oncycle_data_idChanged();
    partial void Oncalendar_date_idChanging(int value);
    partial void Oncalendar_date_idChanged();
    partial void Ontime_of_day_idChanging(int value);
    partial void Ontime_of_day_idChanged();
    partial void Onstation_idChanging(int value);
    partial void Onstation_idChanged();
    partial void Onpump_idChanging(int value);
    partial void Onpump_idChanged();
    partial void Oncycle_change_timeChanging(System.DateTime value);
    partial void Oncycle_change_timeChanged();
    partial void Ononoff_stateChanging(byte value);
    partial void Ononoff_stateChanged();
    partial void Onload_dateChanging(System.DateTime value);
    partial void Onload_dateChanged();
    partial void Onsource_filenameChanging(string value);
    partial void Onsource_filenameChanged();
    #endregion
		
		public CYCLE_DATA()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cycle_data_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int cycle_data_id
		{
			get
			{
				return this._cycle_data_id;
			}
			set
			{
				if ((this._cycle_data_id != value))
				{
					this.Oncycle_data_idChanging(value);
					this.SendPropertyChanging();
					this._cycle_data_id = value;
					this.SendPropertyChanged("cycle_data_id");
					this.Oncycle_data_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_calendar_date_id", DbType="Int NOT NULL")]
		public int calendar_date_id
		{
			get
			{
				return this._calendar_date_id;
			}
			set
			{
				if ((this._calendar_date_id != value))
				{
					this.Oncalendar_date_idChanging(value);
					this.SendPropertyChanging();
					this._calendar_date_id = value;
					this.SendPropertyChanged("calendar_date_id");
					this.Oncalendar_date_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_time_of_day_id", DbType="Int NOT NULL")]
		public int time_of_day_id
		{
			get
			{
				return this._time_of_day_id;
			}
			set
			{
				if ((this._time_of_day_id != value))
				{
					this.Ontime_of_day_idChanging(value);
					this.SendPropertyChanging();
					this._time_of_day_id = value;
					this.SendPropertyChanged("time_of_day_id");
					this.Ontime_of_day_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_station_id", DbType="Int NOT NULL")]
		public int station_id
		{
			get
			{
				return this._station_id;
			}
			set
			{
				if ((this._station_id != value))
				{
					this.Onstation_idChanging(value);
					this.SendPropertyChanging();
					this._station_id = value;
					this.SendPropertyChanged("station_id");
					this.Onstation_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_pump_id", DbType="Int NOT NULL")]
		public int pump_id
		{
			get
			{
				return this._pump_id;
			}
			set
			{
				if ((this._pump_id != value))
				{
					this.Onpump_idChanging(value);
					this.SendPropertyChanging();
					this._pump_id = value;
					this.SendPropertyChanged("pump_id");
					this.Onpump_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cycle_change_time", DbType="DateTime NOT NULL")]
		public System.DateTime cycle_change_time
		{
			get
			{
				return this._cycle_change_time;
			}
			set
			{
				if ((this._cycle_change_time != value))
				{
					this.Oncycle_change_timeChanging(value);
					this.SendPropertyChanging();
					this._cycle_change_time = value;
					this.SendPropertyChanged("cycle_change_time");
					this.Oncycle_change_timeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_onoff_state", DbType="TinyInt NOT NULL")]
		public byte onoff_state
		{
			get
			{
				return this._onoff_state;
			}
			set
			{
				if ((this._onoff_state != value))
				{
					this.Ononoff_stateChanging(value);
					this.SendPropertyChanging();
					this._onoff_state = value;
					this.SendPropertyChanged("onoff_state");
					this.Ononoff_stateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_load_date", DbType="DateTime NOT NULL")]
		public System.DateTime load_date
		{
			get
			{
				return this._load_date;
			}
			set
			{
				if ((this._load_date != value))
				{
					this.Onload_dateChanging(value);
					this.SendPropertyChanging();
					this._load_date = value;
					this.SendPropertyChanged("load_date");
					this.Onload_dateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_source_filename", DbType="Char(50) NOT NULL", CanBeNull=false)]
		public string source_filename
		{
			get
			{
				return this._source_filename;
			}
			set
			{
				if ((this._source_filename != value))
				{
					this.Onsource_filenameChanging(value);
					this.SendPropertyChanging();
					this._source_filename = value;
					this.SendPropertyChanged("source_filename");
					this.Onsource_filenameChanged();
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
}
#pragma warning restore 1591