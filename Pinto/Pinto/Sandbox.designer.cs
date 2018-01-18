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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="SANDBOX")]
	public partial class SandboxDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertPS_LocationTable(PS_LocationTable instance);
    partial void UpdatePS_LocationTable(PS_LocationTable instance);
    partial void DeletePS_LocationTable(PS_LocationTable instance);
    partial void InsertPS_Gravity_Pipe(PS_Gravity_Pipe instance);
    partial void UpdatePS_Gravity_Pipe(PS_Gravity_Pipe instance);
    partial void DeletePS_Gravity_Pipe(PS_Gravity_Pipe instance);
    partial void InsertPS_RawCycleData_Neptune(PS_RawCycleData_Neptune instance);
    partial void UpdatePS_RawCycleData_Neptune(PS_RawCycleData_Neptune instance);
    partial void DeletePS_RawCycleData_Neptune(PS_RawCycleData_Neptune instance);
    partial void InsertPS_StageStorage(PS_StageStorage instance);
    partial void UpdatePS_StageStorage(PS_StageStorage instance);
    partial void DeletePS_StageStorage(PS_StageStorage instance);
    #endregion
		
		public SandboxDataContext() : 
				base(global::Pinto.Properties.Settings.Default.SANDBOXConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public SandboxDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SandboxDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SandboxDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SandboxDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<PS_LocationTable> PS_LocationTables
		{
			get
			{
				return this.GetTable<PS_LocationTable>();
			}
		}
		
		public System.Data.Linq.Table<PS_Gravity_Pipe> PS_Gravity_Pipes
		{
			get
			{
				return this.GetTable<PS_Gravity_Pipe>();
			}
		}
		
		public System.Data.Linq.Table<PS_RawCycleData_Neptune> PS_RawCycleData_Neptunes
		{
			get
			{
				return this.GetTable<PS_RawCycleData_Neptune>();
			}
		}
		
		public System.Data.Linq.Table<PS_StageStorage> PS_StageStorages
		{
			get
			{
				return this.GetTable<PS_StageStorage>();
			}
		}
		
		public System.Data.Linq.Table<PS_Location_Summary_Table> PS_Location_Summary_Tables
		{
			get
			{
				return this.GetTable<PS_Location_Summary_Table>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="GIS.PS_LocationTable")]
	public partial class PS_LocationTable : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Location;
		
		private System.Nullable<int> _LeadPump_gpm;
		
		private System.Nullable<int> _ActiveWWVol_gal;
		
		private System.Nullable<int> _GravitySystemStorage_gal;
		
		private System.Nullable<double> _OverflowElevation;
		
		private System.Nullable<int> _station_id;
		
		private System.Nullable<int> _Asset_ID;
		
		private EntitySet<PS_Gravity_Pipe> _PS_Gravity_Pipes;
		
		private EntitySet<PS_RawCycleData_Neptune> _PS_RawCycleData_Neptunes;
		
		private EntitySet<PS_StageStorage> _PS_StageStorages;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnLocationChanging(string value);
    partial void OnLocationChanged();
    partial void OnLeadPump_gpmChanging(System.Nullable<int> value);
    partial void OnLeadPump_gpmChanged();
    partial void OnActiveWWVol_galChanging(System.Nullable<int> value);
    partial void OnActiveWWVol_galChanged();
    partial void OnGravitySystemStorage_galChanging(System.Nullable<int> value);
    partial void OnGravitySystemStorage_galChanged();
    partial void OnOverflowElevationChanging(System.Nullable<double> value);
    partial void OnOverflowElevationChanged();
    partial void Onstation_idChanging(System.Nullable<int> value);
    partial void Onstation_idChanged();
    partial void OnAsset_IDChanging(System.Nullable<int> value);
    partial void OnAsset_IDChanged();
    #endregion
		
		public PS_LocationTable()
		{
			this._PS_Gravity_Pipes = new EntitySet<PS_Gravity_Pipe>(new Action<PS_Gravity_Pipe>(this.attach_PS_Gravity_Pipes), new Action<PS_Gravity_Pipe>(this.detach_PS_Gravity_Pipes));
			this._PS_RawCycleData_Neptunes = new EntitySet<PS_RawCycleData_Neptune>(new Action<PS_RawCycleData_Neptune>(this.attach_PS_RawCycleData_Neptunes), new Action<PS_RawCycleData_Neptune>(this.detach_PS_RawCycleData_Neptunes));
			this._PS_StageStorages = new EntitySet<PS_StageStorage>(new Action<PS_StageStorage>(this.attach_PS_StageStorages), new Action<PS_StageStorage>(this.detach_PS_StageStorages));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Location", DbType="NChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Location
		{
			get
			{
				return this._Location;
			}
			set
			{
				if ((this._Location != value))
				{
					this.OnLocationChanging(value);
					this.SendPropertyChanging();
					this._Location = value;
					this.SendPropertyChanged("Location");
					this.OnLocationChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LeadPump_gpm", DbType="Int")]
		public System.Nullable<int> LeadPump_gpm
		{
			get
			{
				return this._LeadPump_gpm;
			}
			set
			{
				if ((this._LeadPump_gpm != value))
				{
					this.OnLeadPump_gpmChanging(value);
					this.SendPropertyChanging();
					this._LeadPump_gpm = value;
					this.SendPropertyChanged("LeadPump_gpm");
					this.OnLeadPump_gpmChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActiveWWVol_gal", DbType="Int")]
		public System.Nullable<int> ActiveWWVol_gal
		{
			get
			{
				return this._ActiveWWVol_gal;
			}
			set
			{
				if ((this._ActiveWWVol_gal != value))
				{
					this.OnActiveWWVol_galChanging(value);
					this.SendPropertyChanging();
					this._ActiveWWVol_gal = value;
					this.SendPropertyChanged("ActiveWWVol_gal");
					this.OnActiveWWVol_galChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GravitySystemStorage_gal", DbType="Int")]
		public System.Nullable<int> GravitySystemStorage_gal
		{
			get
			{
				return this._GravitySystemStorage_gal;
			}
			set
			{
				if ((this._GravitySystemStorage_gal != value))
				{
					this.OnGravitySystemStorage_galChanging(value);
					this.SendPropertyChanging();
					this._GravitySystemStorage_gal = value;
					this.SendPropertyChanged("GravitySystemStorage_gal");
					this.OnGravitySystemStorage_galChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OverflowElevation", DbType="Float")]
		public System.Nullable<double> OverflowElevation
		{
			get
			{
				return this._OverflowElevation;
			}
			set
			{
				if ((this._OverflowElevation != value))
				{
					this.OnOverflowElevationChanging(value);
					this.SendPropertyChanging();
					this._OverflowElevation = value;
					this.SendPropertyChanged("OverflowElevation");
					this.OnOverflowElevationChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_station_id", DbType="Int")]
		public System.Nullable<int> station_id
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Asset ID]", Storage="_Asset_ID", DbType="Int")]
		public System.Nullable<int> Asset_ID
		{
			get
			{
				return this._Asset_ID;
			}
			set
			{
				if ((this._Asset_ID != value))
				{
					this.OnAsset_IDChanging(value);
					this.SendPropertyChanging();
					this._Asset_ID = value;
					this.SendPropertyChanged("Asset_ID");
					this.OnAsset_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="PS_LocationTable_PS_Gravity_Pipe", Storage="_PS_Gravity_Pipes", ThisKey="Location", OtherKey="Location")]
		public EntitySet<PS_Gravity_Pipe> PS_Gravity_Pipes
		{
			get
			{
				return this._PS_Gravity_Pipes;
			}
			set
			{
				this._PS_Gravity_Pipes.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="PS_LocationTable_PS_RawCycleData_Neptune", Storage="_PS_RawCycleData_Neptunes", ThisKey="Location", OtherKey="Location")]
		public EntitySet<PS_RawCycleData_Neptune> PS_RawCycleData_Neptunes
		{
			get
			{
				return this._PS_RawCycleData_Neptunes;
			}
			set
			{
				this._PS_RawCycleData_Neptunes.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="PS_LocationTable_PS_StageStorage", Storage="_PS_StageStorages", ThisKey="Location", OtherKey="Location")]
		public EntitySet<PS_StageStorage> PS_StageStorages
		{
			get
			{
				return this._PS_StageStorages;
			}
			set
			{
				this._PS_StageStorages.Assign(value);
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
		
		private void attach_PS_Gravity_Pipes(PS_Gravity_Pipe entity)
		{
			this.SendPropertyChanging();
			entity.PS_LocationTable = this;
		}
		
		private void detach_PS_Gravity_Pipes(PS_Gravity_Pipe entity)
		{
			this.SendPropertyChanging();
			entity.PS_LocationTable = null;
		}
		
		private void attach_PS_RawCycleData_Neptunes(PS_RawCycleData_Neptune entity)
		{
			this.SendPropertyChanging();
			entity.PS_LocationTable = this;
		}
		
		private void detach_PS_RawCycleData_Neptunes(PS_RawCycleData_Neptune entity)
		{
			this.SendPropertyChanging();
			entity.PS_LocationTable = null;
		}
		
		private void attach_PS_StageStorages(PS_StageStorage entity)
		{
			this.SendPropertyChanging();
			entity.PS_LocationTable = this;
		}
		
		private void detach_PS_StageStorages(PS_StageStorage entity)
		{
			this.SendPropertyChanging();
			entity.PS_LocationTable = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="GIS.PS_Gravity_Pipes")]
	public partial class PS_Gravity_Pipe : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Location;
		
		private int _MLinkID;
		
		private string _USNode;
		
		private string _DSNode;
		
		private System.Nullable<char> _PipeFlowType;
		
		private System.Nullable<double> _DiamWidth;
		
		private System.Nullable<double> _USIE;
		
		private System.Nullable<double> _DSIE;
		
		private System.Nullable<double> _Length;
		
		private EntityRef<PS_LocationTable> _PS_LocationTable;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnLocationChanging(string value);
    partial void OnLocationChanged();
    partial void OnMLinkIDChanging(int value);
    partial void OnMLinkIDChanged();
    partial void OnUSNodeChanging(string value);
    partial void OnUSNodeChanged();
    partial void OnDSNodeChanging(string value);
    partial void OnDSNodeChanged();
    partial void OnPipeFlowTypeChanging(System.Nullable<char> value);
    partial void OnPipeFlowTypeChanged();
    partial void OnDiamWidthChanging(System.Nullable<double> value);
    partial void OnDiamWidthChanged();
    partial void OnUSIEChanging(System.Nullable<double> value);
    partial void OnUSIEChanged();
    partial void OnDSIEChanging(System.Nullable<double> value);
    partial void OnDSIEChanged();
    partial void OnLengthChanging(System.Nullable<double> value);
    partial void OnLengthChanged();
    #endregion
		
		public PS_Gravity_Pipe()
		{
			this._PS_LocationTable = default(EntityRef<PS_LocationTable>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Location", DbType="NChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Location
		{
			get
			{
				return this._Location;
			}
			set
			{
				if ((this._Location != value))
				{
					if (this._PS_LocationTable.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnLocationChanging(value);
					this.SendPropertyChanging();
					this._Location = value;
					this.SendPropertyChanged("Location");
					this.OnLocationChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MLinkID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int MLinkID
		{
			get
			{
				return this._MLinkID;
			}
			set
			{
				if ((this._MLinkID != value))
				{
					this.OnMLinkIDChanging(value);
					this.SendPropertyChanging();
					this._MLinkID = value;
					this.SendPropertyChanged("MLinkID");
					this.OnMLinkIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_USNode", DbType="Char(6)")]
		public string USNode
		{
			get
			{
				return this._USNode;
			}
			set
			{
				if ((this._USNode != value))
				{
					this.OnUSNodeChanging(value);
					this.SendPropertyChanging();
					this._USNode = value;
					this.SendPropertyChanged("USNode");
					this.OnUSNodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DSNode", DbType="Char(6)")]
		public string DSNode
		{
			get
			{
				return this._DSNode;
			}
			set
			{
				if ((this._DSNode != value))
				{
					this.OnDSNodeChanging(value);
					this.SendPropertyChanging();
					this._DSNode = value;
					this.SendPropertyChanged("DSNode");
					this.OnDSNodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PipeFlowType", DbType="Char(1)")]
		public System.Nullable<char> PipeFlowType
		{
			get
			{
				return this._PipeFlowType;
			}
			set
			{
				if ((this._PipeFlowType != value))
				{
					this.OnPipeFlowTypeChanging(value);
					this.SendPropertyChanging();
					this._PipeFlowType = value;
					this.SendPropertyChanged("PipeFlowType");
					this.OnPipeFlowTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DiamWidth", DbType="Float")]
		public System.Nullable<double> DiamWidth
		{
			get
			{
				return this._DiamWidth;
			}
			set
			{
				if ((this._DiamWidth != value))
				{
					this.OnDiamWidthChanging(value);
					this.SendPropertyChanging();
					this._DiamWidth = value;
					this.SendPropertyChanged("DiamWidth");
					this.OnDiamWidthChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_USIE", DbType="Float")]
		public System.Nullable<double> USIE
		{
			get
			{
				return this._USIE;
			}
			set
			{
				if ((this._USIE != value))
				{
					this.OnUSIEChanging(value);
					this.SendPropertyChanging();
					this._USIE = value;
					this.SendPropertyChanged("USIE");
					this.OnUSIEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DSIE", DbType="Float")]
		public System.Nullable<double> DSIE
		{
			get
			{
				return this._DSIE;
			}
			set
			{
				if ((this._DSIE != value))
				{
					this.OnDSIEChanging(value);
					this.SendPropertyChanging();
					this._DSIE = value;
					this.SendPropertyChanged("DSIE");
					this.OnDSIEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Length", DbType="Float")]
		public System.Nullable<double> Length
		{
			get
			{
				return this._Length;
			}
			set
			{
				if ((this._Length != value))
				{
					this.OnLengthChanging(value);
					this.SendPropertyChanging();
					this._Length = value;
					this.SendPropertyChanged("Length");
					this.OnLengthChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="PS_LocationTable_PS_Gravity_Pipe", Storage="_PS_LocationTable", ThisKey="Location", OtherKey="Location", IsForeignKey=true)]
		public PS_LocationTable PS_LocationTable
		{
			get
			{
				return this._PS_LocationTable.Entity;
			}
			set
			{
				PS_LocationTable previousValue = this._PS_LocationTable.Entity;
				if (((previousValue != value) 
							|| (this._PS_LocationTable.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._PS_LocationTable.Entity = null;
						previousValue.PS_Gravity_Pipes.Remove(this);
					}
					this._PS_LocationTable.Entity = value;
					if ((value != null))
					{
						value.PS_Gravity_Pipes.Add(this);
						this._Location = value.Location;
					}
					else
					{
						this._Location = default(string);
					}
					this.SendPropertyChanged("PS_LocationTable");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="GIS.PS_RawCycleData_Neptune")]
	public partial class PS_RawCycleData_Neptune : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Location;
		
		private short _station_id;
		
		private short _pump_id;
		
		private System.DateTime _cycle_change_time;
		
		private bool _onoff_state;
		
		private System.Nullable<char> _record_status;
		
		private System.Nullable<long> _delta_t;
		
		private System.Nullable<long> _pumpTime;
		
		private System.Nullable<long> _fillTime;
		
		private System.Nullable<bool> _DuplicateCycle;
		
		private System.Nullable<bool> _AddOnCycle;
		
		private System.Nullable<bool> _AddOffCycle;
		
		private System.Nullable<bool> _DeletePrevCycle;
		
		private System.Nullable<bool> _multiPump;
		
		private System.Nullable<bool> _shortCycle;
		
		private System.Nullable<double> _Flow_gpm;
		
		private EntityRef<PS_LocationTable> _PS_LocationTable;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnLocationChanging(string value);
    partial void OnLocationChanged();
    partial void Onstation_idChanging(short value);
    partial void Onstation_idChanged();
    partial void Onpump_idChanging(short value);
    partial void Onpump_idChanged();
    partial void Oncycle_change_timeChanging(System.DateTime value);
    partial void Oncycle_change_timeChanged();
    partial void Ononoff_stateChanging(bool value);
    partial void Ononoff_stateChanged();
    partial void Onrecord_statusChanging(System.Nullable<char> value);
    partial void Onrecord_statusChanged();
    partial void Ondelta_tChanging(System.Nullable<long> value);
    partial void Ondelta_tChanged();
    partial void OnpumpTimeChanging(System.Nullable<long> value);
    partial void OnpumpTimeChanged();
    partial void OnfillTimeChanging(System.Nullable<long> value);
    partial void OnfillTimeChanged();
    partial void OnDuplicateCycleChanging(System.Nullable<bool> value);
    partial void OnDuplicateCycleChanged();
    partial void OnAddOnCycleChanging(System.Nullable<bool> value);
    partial void OnAddOnCycleChanged();
    partial void OnAddOffCycleChanging(System.Nullable<bool> value);
    partial void OnAddOffCycleChanged();
    partial void OnDeletePrevCycleChanging(System.Nullable<bool> value);
    partial void OnDeletePrevCycleChanged();
    partial void OnmultiPumpChanging(System.Nullable<bool> value);
    partial void OnmultiPumpChanged();
    partial void OnshortCycleChanging(System.Nullable<bool> value);
    partial void OnshortCycleChanged();
    partial void OnFlow_gpmChanging(System.Nullable<double> value);
    partial void OnFlow_gpmChanged();
    #endregion
		
		public PS_RawCycleData_Neptune()
		{
			this._PS_LocationTable = default(EntityRef<PS_LocationTable>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Location", DbType="NChar(50) NOT NULL", CanBeNull=false)]
		public string Location
		{
			get
			{
				return this._Location;
			}
			set
			{
				if ((this._Location != value))
				{
					if (this._PS_LocationTable.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnLocationChanging(value);
					this.SendPropertyChanging();
					this._Location = value;
					this.SendPropertyChanged("Location");
					this.OnLocationChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_station_id", DbType="SmallInt NOT NULL", IsPrimaryKey=true)]
		public short station_id
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_pump_id", DbType="SmallInt NOT NULL", IsPrimaryKey=true)]
		public short pump_id
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cycle_change_time", DbType="DateTime NOT NULL", IsPrimaryKey=true)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_onoff_state", DbType="Bit NOT NULL")]
		public bool onoff_state
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_record_status", DbType="Char(1)")]
		public System.Nullable<char> record_status
		{
			get
			{
				return this._record_status;
			}
			set
			{
				if ((this._record_status != value))
				{
					this.Onrecord_statusChanging(value);
					this.SendPropertyChanging();
					this._record_status = value;
					this.SendPropertyChanged("record_status");
					this.Onrecord_statusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_delta_t", DbType="BigInt")]
		public System.Nullable<long> delta_t
		{
			get
			{
				return this._delta_t;
			}
			set
			{
				if ((this._delta_t != value))
				{
					this.Ondelta_tChanging(value);
					this.SendPropertyChanging();
					this._delta_t = value;
					this.SendPropertyChanged("delta_t");
					this.Ondelta_tChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_pumpTime", DbType="BigInt")]
		public System.Nullable<long> pumpTime
		{
			get
			{
				return this._pumpTime;
			}
			set
			{
				if ((this._pumpTime != value))
				{
					this.OnpumpTimeChanging(value);
					this.SendPropertyChanging();
					this._pumpTime = value;
					this.SendPropertyChanged("pumpTime");
					this.OnpumpTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fillTime", DbType="BigInt")]
		public System.Nullable<long> fillTime
		{
			get
			{
				return this._fillTime;
			}
			set
			{
				if ((this._fillTime != value))
				{
					this.OnfillTimeChanging(value);
					this.SendPropertyChanging();
					this._fillTime = value;
					this.SendPropertyChanged("fillTime");
					this.OnfillTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DuplicateCycle", DbType="Bit")]
		public System.Nullable<bool> DuplicateCycle
		{
			get
			{
				return this._DuplicateCycle;
			}
			set
			{
				if ((this._DuplicateCycle != value))
				{
					this.OnDuplicateCycleChanging(value);
					this.SendPropertyChanging();
					this._DuplicateCycle = value;
					this.SendPropertyChanged("DuplicateCycle");
					this.OnDuplicateCycleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AddOnCycle", DbType="Bit")]
		public System.Nullable<bool> AddOnCycle
		{
			get
			{
				return this._AddOnCycle;
			}
			set
			{
				if ((this._AddOnCycle != value))
				{
					this.OnAddOnCycleChanging(value);
					this.SendPropertyChanging();
					this._AddOnCycle = value;
					this.SendPropertyChanged("AddOnCycle");
					this.OnAddOnCycleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AddOffCycle", DbType="Bit")]
		public System.Nullable<bool> AddOffCycle
		{
			get
			{
				return this._AddOffCycle;
			}
			set
			{
				if ((this._AddOffCycle != value))
				{
					this.OnAddOffCycleChanging(value);
					this.SendPropertyChanging();
					this._AddOffCycle = value;
					this.SendPropertyChanged("AddOffCycle");
					this.OnAddOffCycleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DeletePrevCycle", DbType="Bit")]
		public System.Nullable<bool> DeletePrevCycle
		{
			get
			{
				return this._DeletePrevCycle;
			}
			set
			{
				if ((this._DeletePrevCycle != value))
				{
					this.OnDeletePrevCycleChanging(value);
					this.SendPropertyChanging();
					this._DeletePrevCycle = value;
					this.SendPropertyChanged("DeletePrevCycle");
					this.OnDeletePrevCycleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_multiPump", DbType="Bit")]
		public System.Nullable<bool> multiPump
		{
			get
			{
				return this._multiPump;
			}
			set
			{
				if ((this._multiPump != value))
				{
					this.OnmultiPumpChanging(value);
					this.SendPropertyChanging();
					this._multiPump = value;
					this.SendPropertyChanged("multiPump");
					this.OnmultiPumpChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_shortCycle", DbType="Bit")]
		public System.Nullable<bool> shortCycle
		{
			get
			{
				return this._shortCycle;
			}
			set
			{
				if ((this._shortCycle != value))
				{
					this.OnshortCycleChanging(value);
					this.SendPropertyChanging();
					this._shortCycle = value;
					this.SendPropertyChanged("shortCycle");
					this.OnshortCycleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Flow_gpm", DbType="Float")]
		public System.Nullable<double> Flow_gpm
		{
			get
			{
				return this._Flow_gpm;
			}
			set
			{
				if ((this._Flow_gpm != value))
				{
					this.OnFlow_gpmChanging(value);
					this.SendPropertyChanging();
					this._Flow_gpm = value;
					this.SendPropertyChanged("Flow_gpm");
					this.OnFlow_gpmChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="PS_LocationTable_PS_RawCycleData_Neptune", Storage="_PS_LocationTable", ThisKey="Location", OtherKey="Location", IsForeignKey=true)]
		public PS_LocationTable PS_LocationTable
		{
			get
			{
				return this._PS_LocationTable.Entity;
			}
			set
			{
				PS_LocationTable previousValue = this._PS_LocationTable.Entity;
				if (((previousValue != value) 
							|| (this._PS_LocationTable.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._PS_LocationTable.Entity = null;
						previousValue.PS_RawCycleData_Neptunes.Remove(this);
					}
					this._PS_LocationTable.Entity = value;
					if ((value != null))
					{
						value.PS_RawCycleData_Neptunes.Add(this);
						this._Location = value.Location;
					}
					else
					{
						this._Location = default(string);
					}
					this.SendPropertyChanged("PS_LocationTable");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="GIS.PS_StageStorage")]
	public partial class PS_StageStorage : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Location;
		
		private double _StageElev;
		
		private double _CumulativeVolume;
		
		private System.Nullable<int> _AssetID;
		
		private EntityRef<PS_LocationTable> _PS_LocationTable;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnLocationChanging(string value);
    partial void OnLocationChanged();
    partial void OnStageElevChanging(double value);
    partial void OnStageElevChanged();
    partial void OnCumulativeVolumeChanging(double value);
    partial void OnCumulativeVolumeChanged();
    partial void OnAssetIDChanging(System.Nullable<int> value);
    partial void OnAssetIDChanged();
    #endregion
		
		public PS_StageStorage()
		{
			this._PS_LocationTable = default(EntityRef<PS_LocationTable>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Location", DbType="NChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Location
		{
			get
			{
				return this._Location;
			}
			set
			{
				if ((this._Location != value))
				{
					if (this._PS_LocationTable.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnLocationChanging(value);
					this.SendPropertyChanging();
					this._Location = value;
					this.SendPropertyChanged("Location");
					this.OnLocationChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StageElev", DbType="Float NOT NULL", IsPrimaryKey=true)]
		public double StageElev
		{
			get
			{
				return this._StageElev;
			}
			set
			{
				if ((this._StageElev != value))
				{
					this.OnStageElevChanging(value);
					this.SendPropertyChanging();
					this._StageElev = value;
					this.SendPropertyChanged("StageElev");
					this.OnStageElevChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CumulativeVolume", DbType="Float NOT NULL")]
		public double CumulativeVolume
		{
			get
			{
				return this._CumulativeVolume;
			}
			set
			{
				if ((this._CumulativeVolume != value))
				{
					this.OnCumulativeVolumeChanging(value);
					this.SendPropertyChanging();
					this._CumulativeVolume = value;
					this.SendPropertyChanged("CumulativeVolume");
					this.OnCumulativeVolumeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AssetID", DbType="Int")]
		public System.Nullable<int> AssetID
		{
			get
			{
				return this._AssetID;
			}
			set
			{
				if ((this._AssetID != value))
				{
					this.OnAssetIDChanging(value);
					this.SendPropertyChanging();
					this._AssetID = value;
					this.SendPropertyChanged("AssetID");
					this.OnAssetIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="PS_LocationTable_PS_StageStorage", Storage="_PS_LocationTable", ThisKey="Location", OtherKey="Location", IsForeignKey=true)]
		public PS_LocationTable PS_LocationTable
		{
			get
			{
				return this._PS_LocationTable.Entity;
			}
			set
			{
				PS_LocationTable previousValue = this._PS_LocationTable.Entity;
				if (((previousValue != value) 
							|| (this._PS_LocationTable.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._PS_LocationTable.Entity = null;
						previousValue.PS_StageStorages.Remove(this);
					}
					this._PS_LocationTable.Entity = value;
					if ((value != null))
					{
						value.PS_StageStorages.Add(this);
						this._Location = value.Location;
					}
					else
					{
						this._Location = default(string);
					}
					this.SendPropertyChanged("PS_LocationTable");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="GIS.PS_Location_Summary_Table")]
	public partial class PS_Location_Summary_Table
	{
		
		private string _Location;
		
		private System.Nullable<int> _Asset_ID;
		
		private string _Lead_Pump__gpm_;
		
		private string _Wetwell_Vol___gal_;
		
		private string _Gravity_Storage__gal_;
		
		private string _Overflow_Elev___ft_;
		
		public PS_Location_Summary_Table()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Location", DbType="NChar(50) NOT NULL", CanBeNull=false)]
		public string Location
		{
			get
			{
				return this._Location;
			}
			set
			{
				if ((this._Location != value))
				{
					this._Location = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Asset ID]", Storage="_Asset_ID", DbType="Int")]
		public System.Nullable<int> Asset_ID
		{
			get
			{
				return this._Asset_ID;
			}
			set
			{
				if ((this._Asset_ID != value))
				{
					this._Asset_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Lead Pump (gpm)]", Storage="_Lead_Pump__gpm_", DbType="NVarChar(4000)")]
		public string Lead_Pump__gpm_
		{
			get
			{
				return this._Lead_Pump__gpm_;
			}
			set
			{
				if ((this._Lead_Pump__gpm_ != value))
				{
					this._Lead_Pump__gpm_ = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Wetwell Vol. (gal)]", Storage="_Wetwell_Vol___gal_", DbType="NVarChar(4000)")]
		public string Wetwell_Vol___gal_
		{
			get
			{
				return this._Wetwell_Vol___gal_;
			}
			set
			{
				if ((this._Wetwell_Vol___gal_ != value))
				{
					this._Wetwell_Vol___gal_ = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Gravity Storage (gal)]", Storage="_Gravity_Storage__gal_", DbType="NVarChar(4000)")]
		public string Gravity_Storage__gal_
		{
			get
			{
				return this._Gravity_Storage__gal_;
			}
			set
			{
				if ((this._Gravity_Storage__gal_ != value))
				{
					this._Gravity_Storage__gal_ = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Overflow Elev. (ft)]", Storage="_Overflow_Elev___ft_", DbType="NVarChar(4000)")]
		public string Overflow_Elev___ft_
		{
			get
			{
				return this._Overflow_Elev___ft_;
			}
			set
			{
				if ((this._Overflow_Elev___ft_ != value))
				{
					this._Overflow_Elev___ft_ = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
