namespace Pinto
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainDataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPumpStationList = new System.Windows.Forms.Label();
            this.cboPumpStationList = new System.Windows.Forms.ComboBox();
            this.refreshData = new System.Windows.Forms.Button();
            this.resetCycleData = new System.Windows.Forms.Button();
            this.clearFilterByLocation = new System.Windows.Forms.Button();
            this.setLocationFilter = new System.Windows.Forms.Button();
            this.statusText = new System.Windows.Forms.TextBox();
            this.bwCalculateInflowVolume = new System.ComponentModel.BackgroundWorker();
            this.bwRollingAverages = new System.ComponentModel.BackgroundWorker();
            this.bwCycleDataAnalysis = new System.ComponentModel.BackgroundWorker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.bwCDtoQ = new System.ComponentModel.BackgroundWorker();
            this.bwTTO = new System.ComponentModel.BackgroundWorker();
            this.bwSS = new System.ComponentModel.BackgroundWorker();
            this.pbarSS = new System.Windows.Forms.ProgressBar();
            this.buttonCancelSS = new System.Windows.Forms.Button();
            this.buttonStageStorage = new System.Windows.Forms.Button();
            this.pbarTTO = new System.Windows.Forms.ProgressBar();
            this.buttonCancelTTO = new System.Windows.Forms.Button();
            this.buttonTimeToOverflow = new System.Windows.Forms.Button();
            this.panelCDtoQ = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.leadPumpRate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.activeWWVolume = new System.Windows.Forms.TextBox();
            this.buttonRunCDtoQ = new System.Windows.Forms.Button();
            this.buttonCancelCDtoQ = new System.Windows.Forms.Button();
            this.buttonConvertCDtoQ = new System.Windows.Forms.Button();
            this.pbarCDA = new System.Windows.Forms.ProgressBar();
            this.buttonCancelCDA = new System.Windows.Forms.Button();
            this.buttonCycleDataAnalysis = new System.Windows.Forms.Button();
            this.pbarRollingAverages = new System.Windows.Forms.ProgressBar();
            this.buttonCancelRollingAverages = new System.Windows.Forms.Button();
            this.buttonRollingAverages = new System.Windows.Forms.Button();
            this.pbarCalculateInflowVolume = new System.Windows.Forms.ProgressBar();
            this.buttonCancelCalculateInflowVolume = new System.Windows.Forms.Button();
            this.buttonCalculateInflowVolume = new System.Windows.Forms.Button();
            this.buttonCalculatePumpAndDrainTimes = new System.Windows.Forms.Button();
            this.buttonCancelPADT = new System.Windows.Forms.Button();
            this.pbarPADT = new System.Windows.Forms.ProgressBar();
            this.bwPADT = new System.ComponentModel.BackgroundWorker();
            this.buttonCycleDataScrubbing = new System.Windows.Forms.Button();
            this.buttonCancelTCD = new System.Windows.Forms.Button();
            this.pbarTCD = new System.Windows.Forms.ProgressBar();
            this.buttonGetCycleDataFromNeptune = new System.Windows.Forms.Button();
            this.buttonCancelGCDFN = new System.Windows.Forms.Button();
            this.pbarGCDFN = new System.Windows.Forms.ProgressBar();
            this.bwGCDFN = new System.ComponentModel.BackgroundWorker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.bwTCD = new System.ComponentModel.BackgroundWorker();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.pBarFCR = new System.Windows.Forms.ProgressBar();
            this.buttonCancelFCR = new System.Windows.Forms.Button();
            this.buttonFixCycleRecords = new System.Windows.Forms.Button();
            this.bwFCR = new System.ComponentModel.BackgroundWorker();
            this.label16 = new System.Windows.Forms.Label();
            this.pbarCFR = new System.Windows.Forms.ProgressBar();
            this.buttonCancelCFR = new System.Windows.Forms.Button();
            this.buttonCFR = new System.Windows.Forms.Button();
            this.bwCFR = new System.ComponentModel.BackgroundWorker();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).BeginInit();
            this.panelCDtoQ.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainDataGridView
            // 
            this.mainDataGridView.AllowUserToAddRows = false;
            this.mainDataGridView.AllowUserToDeleteRows = false;
            this.mainDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainDataGridView.Location = new System.Drawing.Point(13, 12);
            this.mainDataGridView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.mainDataGridView.Name = "mainDataGridView";
            this.mainDataGridView.ReadOnly = true;
            this.mainDataGridView.Size = new System.Drawing.Size(933, 430);
            this.mainDataGridView.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Garamond", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1196, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Analysis Tasks";
            // 
            // lblPumpStationList
            // 
            this.lblPumpStationList.AutoSize = true;
            this.lblPumpStationList.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPumpStationList.Location = new System.Drawing.Point(952, 32);
            this.lblPumpStationList.Name = "lblPumpStationList";
            this.lblPumpStationList.Size = new System.Drawing.Size(94, 16);
            this.lblPumpStationList.TabIndex = 34;
            this.lblPumpStationList.Text = "Pump Station";
            this.lblPumpStationList.Visible = false;
            // 
            // cboPumpStationList
            // 
            this.cboPumpStationList.FormattingEnabled = true;
            this.cboPumpStationList.Location = new System.Drawing.Point(1061, 32);
            this.cboPumpStationList.Name = "cboPumpStationList";
            this.cboPumpStationList.Size = new System.Drawing.Size(462, 22);
            this.cboPumpStationList.TabIndex = 33;
            // 
            // refreshData
            // 
            this.refreshData.Location = new System.Drawing.Point(14, 607);
            this.refreshData.Name = "refreshData";
            this.refreshData.Size = new System.Drawing.Size(123, 23);
            this.refreshData.TabIndex = 38;
            this.refreshData.Text = "Refresh Data";
            this.refreshData.UseVisualStyleBackColor = true;
            this.refreshData.Click += new System.EventHandler(this.refreshData_Click);
            // 
            // resetCycleData
            // 
            this.resetCycleData.BackColor = System.Drawing.Color.Tomato;
            this.resetCycleData.Location = new System.Drawing.Point(978, 663);
            this.resetCycleData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.resetCycleData.Name = "resetCycleData";
            this.resetCycleData.Size = new System.Drawing.Size(214, 23);
            this.resetCycleData.TabIndex = 37;
            this.resetCycleData.Text = "Reset Cycle Data";
            this.resetCycleData.UseVisualStyleBackColor = false;
            this.resetCycleData.Click += new System.EventHandler(this.resetCycleData_Click);
            // 
            // clearFilterByLocation
            // 
            this.clearFilterByLocation.Location = new System.Drawing.Point(14, 666);
            this.clearFilterByLocation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clearFilterByLocation.Name = "clearFilterByLocation";
            this.clearFilterByLocation.Size = new System.Drawing.Size(123, 25);
            this.clearFilterByLocation.TabIndex = 36;
            this.clearFilterByLocation.Text = "Clear Filter";
            this.clearFilterByLocation.UseVisualStyleBackColor = true;
            this.clearFilterByLocation.Click += new System.EventHandler(this.clearFilterByLocation_Click);
            // 
            // setLocationFilter
            // 
            this.setLocationFilter.Location = new System.Drawing.Point(14, 636);
            this.setLocationFilter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.setLocationFilter.Name = "setLocationFilter";
            this.setLocationFilter.Size = new System.Drawing.Size(123, 25);
            this.setLocationFilter.TabIndex = 35;
            this.setLocationFilter.Text = "Filter by Location";
            this.setLocationFilter.UseVisualStyleBackColor = true;
            this.setLocationFilter.Click += new System.EventHandler(this.setLocationFilter_Click);
            // 
            // statusText
            // 
            this.statusText.Location = new System.Drawing.Point(274, 580);
            this.statusText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.statusText.Multiline = true;
            this.statusText.Name = "statusText";
            this.statusText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.statusText.Size = new System.Drawing.Size(672, 106);
            this.statusText.TabIndex = 39;
            // 
            // bwCalculateInflowVolume
            // 
            this.bwCalculateInflowVolume.WorkerReportsProgress = true;
            this.bwCalculateInflowVolume.WorkerSupportsCancellation = true;
            this.bwCalculateInflowVolume.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwCalculateInflowVolume_DoWork);
            this.bwCalculateInflowVolume.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwCalculateInflowVolume_ProgressChanged);
            this.bwCalculateInflowVolume.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwCalculateInflowVolume_RunWorkerCompleted);
            // 
            // bwRollingAverages
            // 
            this.bwRollingAverages.WorkerReportsProgress = true;
            this.bwRollingAverages.WorkerSupportsCancellation = true;
            this.bwRollingAverages.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwRollingAverages_DoWork);
            this.bwRollingAverages.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwRollingAverages_ProgressChanged);
            this.bwRollingAverages.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwRollingAverages_RunWorkerCompleted);
            // 
            // bwCycleDataAnalysis
            // 
            this.bwCycleDataAnalysis.WorkerReportsProgress = true;
            this.bwCycleDataAnalysis.WorkerSupportsCancellation = true;
            // 
            // bwCDtoQ
            // 
            this.bwCDtoQ.WorkerReportsProgress = true;
            this.bwCDtoQ.WorkerSupportsCancellation = true;
            // 
            // bwTTO
            // 
            this.bwTTO.WorkerReportsProgress = true;
            this.bwTTO.WorkerSupportsCancellation = true;
            this.bwTTO.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwTTO_DoWork);
            this.bwTTO.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwTTO_ProgressChanged);
            this.bwTTO.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwTTO_RunWorkerCompleted);
            // 
            // bwSS
            // 
            this.bwSS.WorkerReportsProgress = true;
            this.bwSS.WorkerSupportsCancellation = true;
            this.bwSS.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwSS_DoWork);
            this.bwSS.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwSS_ProgressChanged);
            this.bwSS.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwSS_RunWorkerCompleted);
            // 
            // pbarSS
            // 
            this.pbarSS.Location = new System.Drawing.Point(1273, 592);
            this.pbarSS.Name = "pbarSS";
            this.pbarSS.Size = new System.Drawing.Size(248, 23);
            this.pbarSS.TabIndex = 62;
            this.pbarSS.Visible = false;
            // 
            // buttonCancelSS
            // 
            this.buttonCancelSS.Location = new System.Drawing.Point(1195, 592);
            this.buttonCancelSS.Name = "buttonCancelSS";
            this.buttonCancelSS.Size = new System.Drawing.Size(66, 23);
            this.buttonCancelSS.TabIndex = 61;
            this.buttonCancelSS.Text = "Cancel";
            this.buttonCancelSS.UseVisualStyleBackColor = true;
            this.buttonCancelSS.Click += new System.EventHandler(this.buttonCancelSS_Click);
            // 
            // buttonStageStorage
            // 
            this.buttonStageStorage.Location = new System.Drawing.Point(956, 592);
            this.buttonStageStorage.Name = "buttonStageStorage";
            this.buttonStageStorage.Size = new System.Drawing.Size(233, 25);
            this.buttonStageStorage.TabIndex = 60;
            this.buttonStageStorage.Text = "Calculate Stage-Storage Table";
            this.buttonStageStorage.UseVisualStyleBackColor = true;
            this.buttonStageStorage.Click += new System.EventHandler(this.buttonStageStorage_Click);
            // 
            // pbarTTO
            // 
            this.pbarTTO.Location = new System.Drawing.Point(1274, 563);
            this.pbarTTO.Name = "pbarTTO";
            this.pbarTTO.Size = new System.Drawing.Size(248, 23);
            this.pbarTTO.TabIndex = 58;
            this.pbarTTO.Visible = false;
            // 
            // buttonCancelTTO
            // 
            this.buttonCancelTTO.Enabled = false;
            this.buttonCancelTTO.Location = new System.Drawing.Point(1196, 562);
            this.buttonCancelTTO.Name = "buttonCancelTTO";
            this.buttonCancelTTO.Size = new System.Drawing.Size(63, 25);
            this.buttonCancelTTO.TabIndex = 57;
            this.buttonCancelTTO.Text = "Cancel";
            this.buttonCancelTTO.UseVisualStyleBackColor = true;
            this.buttonCancelTTO.Click += new System.EventHandler(this.buttonCancelTTO_Click);
            // 
            // buttonTimeToOverflow
            // 
            this.buttonTimeToOverflow.Location = new System.Drawing.Point(956, 561);
            this.buttonTimeToOverflow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonTimeToOverflow.Name = "buttonTimeToOverflow";
            this.buttonTimeToOverflow.Size = new System.Drawing.Size(233, 25);
            this.buttonTimeToOverflow.TabIndex = 56;
            this.buttonTimeToOverflow.Text = "Calculate Time To Overflow";
            this.buttonTimeToOverflow.UseVisualStyleBackColor = true;
            this.buttonTimeToOverflow.Click += new System.EventHandler(this.buttonTimeToOverflow_Click);
            // 
            // panelCDtoQ
            // 
            this.panelCDtoQ.Controls.Add(this.label5);
            this.panelCDtoQ.Controls.Add(this.label2);
            this.panelCDtoQ.Controls.Add(this.label3);
            this.panelCDtoQ.Controls.Add(this.leadPumpRate);
            this.panelCDtoQ.Controls.Add(this.label4);
            this.panelCDtoQ.Controls.Add(this.activeWWVolume);
            this.panelCDtoQ.Controls.Add(this.buttonRunCDtoQ);
            this.panelCDtoQ.Location = new System.Drawing.Point(381, 477);
            this.panelCDtoQ.Name = "panelCDtoQ";
            this.panelCDtoQ.Size = new System.Drawing.Size(259, 86);
            this.panelCDtoQ.TabIndex = 55;
            this.panelCDtoQ.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(211, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 14);
            this.label5.TabIndex = 38;
            this.label5.Text = "gal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 14);
            this.label2.TabIndex = 37;
            this.label2.Text = "gpm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 14);
            this.label3.TabIndex = 36;
            this.label3.Text = "Active Wetwell Volume";
            // 
            // leadPumpRate
            // 
            this.leadPumpRate.Location = new System.Drawing.Point(142, 3);
            this.leadPumpRate.Name = "leadPumpRate";
            this.leadPumpRate.Size = new System.Drawing.Size(63, 22);
            this.leadPumpRate.TabIndex = 33;
            this.leadPumpRate.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 14);
            this.label4.TabIndex = 35;
            this.label4.Text = "Lead Pump Rate";
            // 
            // activeWWVolume
            // 
            this.activeWWVolume.Location = new System.Drawing.Point(142, 29);
            this.activeWWVolume.Name = "activeWWVolume";
            this.activeWWVolume.Size = new System.Drawing.Size(63, 22);
            this.activeWWVolume.TabIndex = 34;
            this.activeWWVolume.Text = "0";
            // 
            // buttonRunCDtoQ
            // 
            this.buttonRunCDtoQ.Location = new System.Drawing.Point(97, 60);
            this.buttonRunCDtoQ.Name = "buttonRunCDtoQ";
            this.buttonRunCDtoQ.Size = new System.Drawing.Size(75, 23);
            this.buttonRunCDtoQ.TabIndex = 30;
            this.buttonRunCDtoQ.Text = "Run";
            this.buttonRunCDtoQ.UseVisualStyleBackColor = true;
            // 
            // buttonCancelCDtoQ
            // 
            this.buttonCancelCDtoQ.Location = new System.Drawing.Point(0, 0);
            this.buttonCancelCDtoQ.Name = "buttonCancelCDtoQ";
            this.buttonCancelCDtoQ.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelCDtoQ.TabIndex = 91;
            // 
            // buttonConvertCDtoQ
            // 
            this.buttonConvertCDtoQ.Location = new System.Drawing.Point(0, 0);
            this.buttonConvertCDtoQ.Name = "buttonConvertCDtoQ";
            this.buttonConvertCDtoQ.Size = new System.Drawing.Size(75, 23);
            this.buttonConvertCDtoQ.TabIndex = 92;
            // 
            // pbarCDA
            // 
            this.pbarCDA.Location = new System.Drawing.Point(1275, 375);
            this.pbarCDA.Name = "pbarCDA";
            this.pbarCDA.Size = new System.Drawing.Size(248, 23);
            this.pbarCDA.TabIndex = 50;
            this.pbarCDA.Visible = false;
            // 
            // buttonCancelCDA
            // 
            this.buttonCancelCDA.Location = new System.Drawing.Point(0, 0);
            this.buttonCancelCDA.Name = "buttonCancelCDA";
            this.buttonCancelCDA.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelCDA.TabIndex = 93;
            // 
            // buttonCycleDataAnalysis
            // 
            this.buttonCycleDataAnalysis.Location = new System.Drawing.Point(0, 0);
            this.buttonCycleDataAnalysis.Name = "buttonCycleDataAnalysis";
            this.buttonCycleDataAnalysis.Size = new System.Drawing.Size(75, 23);
            this.buttonCycleDataAnalysis.TabIndex = 94;
            // 
            // pbarRollingAverages
            // 
            this.pbarRollingAverages.Location = new System.Drawing.Point(1274, 531);
            this.pbarRollingAverages.Name = "pbarRollingAverages";
            this.pbarRollingAverages.Size = new System.Drawing.Size(248, 23);
            this.pbarRollingAverages.TabIndex = 47;
            this.pbarRollingAverages.Visible = false;
            // 
            // buttonCancelRollingAverages
            // 
            this.buttonCancelRollingAverages.Enabled = false;
            this.buttonCancelRollingAverages.Location = new System.Drawing.Point(1196, 531);
            this.buttonCancelRollingAverages.Name = "buttonCancelRollingAverages";
            this.buttonCancelRollingAverages.Size = new System.Drawing.Size(63, 25);
            this.buttonCancelRollingAverages.TabIndex = 46;
            this.buttonCancelRollingAverages.Text = "Cancel";
            this.buttonCancelRollingAverages.UseVisualStyleBackColor = true;
            this.buttonCancelRollingAverages.Click += new System.EventHandler(this.buttonCancelRollingAverages_Click);
            // 
            // buttonRollingAverages
            // 
            this.buttonRollingAverages.Location = new System.Drawing.Point(956, 531);
            this.buttonRollingAverages.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRollingAverages.Name = "buttonRollingAverages";
            this.buttonRollingAverages.Size = new System.Drawing.Size(233, 25);
            this.buttonRollingAverages.TabIndex = 45;
            this.buttonRollingAverages.Text = "Calculate Rolling Averages (1h/7d/30d)";
            this.buttonRollingAverages.UseVisualStyleBackColor = true;
            this.buttonRollingAverages.Click += new System.EventHandler(this.buttonRollingAverages_Click);
            // 
            // pbarCalculateInflowVolume
            // 
            this.pbarCalculateInflowVolume.Location = new System.Drawing.Point(1274, 502);
            this.pbarCalculateInflowVolume.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbarCalculateInflowVolume.Name = "pbarCalculateInflowVolume";
            this.pbarCalculateInflowVolume.Size = new System.Drawing.Size(248, 25);
            this.pbarCalculateInflowVolume.TabIndex = 44;
            this.pbarCalculateInflowVolume.Visible = false;
            // 
            // buttonCancelCalculateInflowVolume
            // 
            this.buttonCancelCalculateInflowVolume.Enabled = false;
            this.buttonCancelCalculateInflowVolume.Location = new System.Drawing.Point(1195, 502);
            this.buttonCancelCalculateInflowVolume.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCancelCalculateInflowVolume.Name = "buttonCancelCalculateInflowVolume";
            this.buttonCancelCalculateInflowVolume.Size = new System.Drawing.Size(66, 25);
            this.buttonCancelCalculateInflowVolume.TabIndex = 43;
            this.buttonCancelCalculateInflowVolume.Text = "Cancel";
            this.buttonCancelCalculateInflowVolume.UseVisualStyleBackColor = true;
            this.buttonCancelCalculateInflowVolume.Click += new System.EventHandler(this.buttonCancelCalculateInflowVolume_Click);
            // 
            // buttonCalculateInflowVolume
            // 
            this.buttonCalculateInflowVolume.Location = new System.Drawing.Point(956, 502);
            this.buttonCalculateInflowVolume.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCalculateInflowVolume.Name = "buttonCalculateInflowVolume";
            this.buttonCalculateInflowVolume.Size = new System.Drawing.Size(233, 25);
            this.buttonCalculateInflowVolume.TabIndex = 42;
            this.buttonCalculateInflowVolume.Text = "Calculate Inflow Volume";
            this.buttonCalculateInflowVolume.UseVisualStyleBackColor = true;
            this.buttonCalculateInflowVolume.Click += new System.EventHandler(this.buttonCalculateInflowVolume_Click);
            // 
            // buttonCalculatePumpAndDrainTimes
            // 
            this.buttonCalculatePumpAndDrainTimes.Location = new System.Drawing.Point(978, 128);
            this.buttonCalculatePumpAndDrainTimes.Name = "buttonCalculatePumpAndDrainTimes";
            this.buttonCalculatePumpAndDrainTimes.Size = new System.Drawing.Size(213, 23);
            this.buttonCalculatePumpAndDrainTimes.TabIndex = 63;
            this.buttonCalculatePumpAndDrainTimes.Text = "Calculate Pump and Drain Times";
            this.buttonCalculatePumpAndDrainTimes.UseVisualStyleBackColor = true;
            this.buttonCalculatePumpAndDrainTimes.Click += new System.EventHandler(this.buttonCalculatePumpAndDrainTimes_Click);
            // 
            // buttonCancelPADT
            // 
            this.buttonCancelPADT.Enabled = false;
            this.buttonCancelPADT.Location = new System.Drawing.Point(1194, 128);
            this.buttonCancelPADT.Name = "buttonCancelPADT";
            this.buttonCancelPADT.Size = new System.Drawing.Size(63, 23);
            this.buttonCancelPADT.TabIndex = 64;
            this.buttonCancelPADT.Text = "Cancel";
            this.buttonCancelPADT.UseVisualStyleBackColor = true;
            this.buttonCancelPADT.Click += new System.EventHandler(this.buttonCancelPADT_Click);
            // 
            // pbarPADT
            // 
            this.pbarPADT.Location = new System.Drawing.Point(1274, 128);
            this.pbarPADT.Name = "pbarPADT";
            this.pbarPADT.Size = new System.Drawing.Size(248, 23);
            this.pbarPADT.TabIndex = 65;
            this.pbarPADT.Visible = false;
            // 
            // bwPADT
            // 
            this.bwPADT.WorkerReportsProgress = true;
            this.bwPADT.WorkerSupportsCancellation = true;
            this.bwPADT.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwPADT_DoWork);
            this.bwPADT.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwPADT_ProgressChanged);
            this.bwPADT.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwPADT_RunWorkerCompleted);
            // 
            // buttonCycleDataScrubbing
            // 
            this.buttonCycleDataScrubbing.Location = new System.Drawing.Point(978, 192);
            this.buttonCycleDataScrubbing.Name = "buttonCycleDataScrubbing";
            this.buttonCycleDataScrubbing.Size = new System.Drawing.Size(214, 23);
            this.buttonCycleDataScrubbing.TabIndex = 66;
            this.buttonCycleDataScrubbing.Text = "Test Cycle Data";
            this.buttonCycleDataScrubbing.UseVisualStyleBackColor = true;
            this.buttonCycleDataScrubbing.Click += new System.EventHandler(this.buttonCycleDataScrubbing_Click);
            // 
            // buttonCancelTCD
            // 
            this.buttonCancelTCD.Enabled = false;
            this.buttonCancelTCD.Location = new System.Drawing.Point(1195, 192);
            this.buttonCancelTCD.Name = "buttonCancelTCD";
            this.buttonCancelTCD.Size = new System.Drawing.Size(63, 23);
            this.buttonCancelTCD.TabIndex = 67;
            this.buttonCancelTCD.Text = "Cancel";
            this.buttonCancelTCD.UseVisualStyleBackColor = true;
            this.buttonCancelTCD.Click += new System.EventHandler(this.buttonCancelTCD_Click);
            // 
            // pbarTCD
            // 
            this.pbarTCD.Location = new System.Drawing.Point(1275, 192);
            this.pbarTCD.Name = "pbarTCD";
            this.pbarTCD.Size = new System.Drawing.Size(248, 23);
            this.pbarTCD.TabIndex = 68;
            this.pbarTCD.Visible = false;
            // 
            // buttonGetCycleDataFromNeptune
            // 
            this.buttonGetCycleDataFromNeptune.Location = new System.Drawing.Point(978, 64);
            this.buttonGetCycleDataFromNeptune.Name = "buttonGetCycleDataFromNeptune";
            this.buttonGetCycleDataFromNeptune.Size = new System.Drawing.Size(213, 23);
            this.buttonGetCycleDataFromNeptune.TabIndex = 69;
            this.buttonGetCycleDataFromNeptune.Text = "Get Cycle Data from Neptune";
            this.buttonGetCycleDataFromNeptune.UseVisualStyleBackColor = true;
            this.buttonGetCycleDataFromNeptune.Click += new System.EventHandler(this.buttonGetCycleDataFromNeptune_Click);
            // 
            // buttonCancelGCDFN
            // 
            this.buttonCancelGCDFN.Enabled = false;
            this.buttonCancelGCDFN.Location = new System.Drawing.Point(1194, 64);
            this.buttonCancelGCDFN.Name = "buttonCancelGCDFN";
            this.buttonCancelGCDFN.Size = new System.Drawing.Size(63, 23);
            this.buttonCancelGCDFN.TabIndex = 70;
            this.buttonCancelGCDFN.Text = "Cancel";
            this.buttonCancelGCDFN.UseVisualStyleBackColor = true;
            this.buttonCancelGCDFN.Click += new System.EventHandler(this.buttonCancelGCDFN_Click);
            // 
            // pbarGCDFN
            // 
            this.pbarGCDFN.Location = new System.Drawing.Point(1275, 64);
            this.pbarGCDFN.Name = "pbarGCDFN";
            this.pbarGCDFN.Size = new System.Drawing.Size(248, 23);
            this.pbarGCDFN.TabIndex = 71;
            this.pbarGCDFN.Visible = false;
            // 
            // bwGCDFN
            // 
            this.bwGCDFN.WorkerReportsProgress = true;
            this.bwGCDFN.WorkerSupportsCancellation = true;
            this.bwGCDFN.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwGCDFN_DoWork);
            this.bwGCDFN.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwGCDFN_ProgressChanged);
            this.bwGCDFN.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwGCDFN_RunWorkerCompleted);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(979, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(258, 14);
            this.label6.TabIndex = 72;
            this.label6.Text = "Flag identical cycle times (SSMS or Excel/FME)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label7.Location = new System.Drawing.Point(955, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 14);
            this.label7.TabIndex = 73;
            this.label7.Text = "1.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(955, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 14);
            this.label8.TabIndex = 74;
            this.label8.Text = "2.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(955, 128);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 14);
            this.label9.TabIndex = 75;
            this.label9.Text = "3.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(955, 160);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 14);
            this.label10.TabIndex = 77;
            this.label10.Text = "4.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(979, 160);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(368, 14);
            this.label11.TabIndex = 76;
            this.label11.Text = "Review cycle times for minimum pump && fill times (SSMS -> Excel)";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(955, 192);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(18, 14);
            this.label12.TabIndex = 78;
            this.label12.Text = "5.";
            // 
            // bwTCD
            // 
            this.bwTCD.WorkerReportsProgress = true;
            this.bwTCD.WorkerSupportsCancellation = true;
            this.bwTCD.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwTCD_DoWork);
            this.bwTCD.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwTCD_ProgressChanged);
            this.bwTCD.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwTCD_RunWorkerCompleted);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(955, 224);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(18, 14);
            this.label13.TabIndex = 80;
            this.label13.Text = "6.";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(979, 224);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(293, 14);
            this.label14.TabIndex = 79;
            this.label14.Text = "Review Multi-Pump Records (SSMS -> Excel -> FME)";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(955, 256);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(18, 14);
            this.label15.TabIndex = 84;
            this.label15.Text = "7.";
            // 
            // pBarFCR
            // 
            this.pBarFCR.Location = new System.Drawing.Point(1275, 256);
            this.pBarFCR.Name = "pBarFCR";
            this.pBarFCR.Size = new System.Drawing.Size(248, 23);
            this.pBarFCR.TabIndex = 83;
            this.pBarFCR.Visible = false;
            // 
            // buttonCancelFCR
            // 
            this.buttonCancelFCR.Enabled = false;
            this.buttonCancelFCR.Location = new System.Drawing.Point(1194, 256);
            this.buttonCancelFCR.Name = "buttonCancelFCR";
            this.buttonCancelFCR.Size = new System.Drawing.Size(63, 23);
            this.buttonCancelFCR.TabIndex = 82;
            this.buttonCancelFCR.Text = "Cancel";
            this.buttonCancelFCR.UseVisualStyleBackColor = true;
            this.buttonCancelFCR.Click += new System.EventHandler(this.buttonCancelFCR_Click);
            // 
            // buttonFixCycleRecords
            // 
            this.buttonFixCycleRecords.Location = new System.Drawing.Point(978, 256);
            this.buttonFixCycleRecords.Name = "buttonFixCycleRecords";
            this.buttonFixCycleRecords.Size = new System.Drawing.Size(214, 23);
            this.buttonFixCycleRecords.TabIndex = 81;
            this.buttonFixCycleRecords.Text = "Fix Cycle Records";
            this.buttonFixCycleRecords.UseVisualStyleBackColor = true;
            this.buttonFixCycleRecords.Click += new System.EventHandler(this.buttonFixCycleRecords_Click);
            // 
            // bwFCR
            // 
            this.bwFCR.WorkerReportsProgress = true;
            this.bwFCR.WorkerSupportsCancellation = true;
            this.bwFCR.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwFCR_DoWork);
            this.bwFCR.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwFCR_ProgressChanged);
            this.bwFCR.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwFCR_RunWorkerCompleted);
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(954, 320);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(18, 14);
            this.label16.TabIndex = 88;
            this.label16.Text = "8.";
            // 
            // pbarCFR
            // 
            this.pbarCFR.Location = new System.Drawing.Point(1274, 320);
            this.pbarCFR.Name = "pbarCFR";
            this.pbarCFR.Size = new System.Drawing.Size(248, 23);
            this.pbarCFR.TabIndex = 87;
            this.pbarCFR.Visible = false;
            // 
            // buttonCancelCFR
            // 
            this.buttonCancelCFR.Enabled = false;
            this.buttonCancelCFR.Location = new System.Drawing.Point(1193, 320);
            this.buttonCancelCFR.Name = "buttonCancelCFR";
            this.buttonCancelCFR.Size = new System.Drawing.Size(63, 23);
            this.buttonCancelCFR.TabIndex = 86;
            this.buttonCancelCFR.Text = "Cancel";
            this.buttonCancelCFR.UseVisualStyleBackColor = true;
            this.buttonCancelCFR.Click += new System.EventHandler(this.buttonCancelCFR_Click);
            // 
            // buttonCFR
            // 
            this.buttonCFR.Location = new System.Drawing.Point(977, 320);
            this.buttonCFR.Name = "buttonCFR";
            this.buttonCFR.Size = new System.Drawing.Size(214, 23);
            this.buttonCFR.TabIndex = 85;
            this.buttonCFR.Text = "Calculate Flow Rates";
            this.buttonCFR.UseVisualStyleBackColor = true;
            this.buttonCFR.Click += new System.EventHandler(this.buttonCFR_Click);
            // 
            // bwCFR
            // 
            this.bwCFR.WorkerReportsProgress = true;
            this.bwCFR.WorkerSupportsCancellation = true;
            this.bwCFR.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwCFR_DoWork);
            this.bwCFR.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwCFR_ProgressChanged);
            this.bwCFR.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwCFR_RunWorkerCompleted);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(955, 288);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(11, 14);
            this.label17.TabIndex = 90;
            this.label17.Text = "-";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(979, 288);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(239, 14);
            this.label18.TabIndex = 89;
            this.label18.Text = "Re-run #3 (Calculate Pump && Drain Times)";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(1534, 697);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.pbarCFR);
            this.Controls.Add(this.buttonCancelCFR);
            this.Controls.Add(this.buttonCFR);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.pBarFCR);
            this.Controls.Add(this.buttonCancelFCR);
            this.Controls.Add(this.buttonFixCycleRecords);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pbarGCDFN);
            this.Controls.Add(this.buttonCancelGCDFN);
            this.Controls.Add(this.buttonGetCycleDataFromNeptune);
            this.Controls.Add(this.pbarTCD);
            this.Controls.Add(this.buttonCancelTCD);
            this.Controls.Add(this.buttonCycleDataScrubbing);
            this.Controls.Add(this.pbarPADT);
            this.Controls.Add(this.buttonCancelPADT);
            this.Controls.Add(this.buttonCalculatePumpAndDrainTimes);
            this.Controls.Add(this.pbarSS);
            this.Controls.Add(this.buttonCancelSS);
            this.Controls.Add(this.buttonStageStorage);
            this.Controls.Add(this.pbarTTO);
            this.Controls.Add(this.buttonCancelTTO);
            this.Controls.Add(this.buttonTimeToOverflow);
            this.Controls.Add(this.panelCDtoQ);
            this.Controls.Add(this.buttonCancelCDtoQ);
            this.Controls.Add(this.buttonConvertCDtoQ);
            this.Controls.Add(this.pbarCDA);
            this.Controls.Add(this.buttonCancelCDA);
            this.Controls.Add(this.buttonCycleDataAnalysis);
            this.Controls.Add(this.pbarRollingAverages);
            this.Controls.Add(this.buttonCancelRollingAverages);
            this.Controls.Add(this.buttonRollingAverages);
            this.Controls.Add(this.pbarCalculateInflowVolume);
            this.Controls.Add(this.buttonCancelCalculateInflowVolume);
            this.Controls.Add(this.buttonCalculateInflowVolume);
            this.Controls.Add(this.statusText);
            this.Controls.Add(this.refreshData);
            this.Controls.Add(this.resetCycleData);
            this.Controls.Add(this.clearFilterByLocation);
            this.Controls.Add(this.setLocationFilter);
            this.Controls.Add(this.lblPumpStationList);
            this.Controls.Add(this.cboPumpStationList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mainDataGridView);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "PINTO - Pump station INterpretation TOol";
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).EndInit();
            this.panelCDtoQ.ResumeLayout(false);
            this.panelCDtoQ.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView mainDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPumpStationList;
        private System.Windows.Forms.ComboBox cboPumpStationList;
        private System.Windows.Forms.Button refreshData;
        private System.Windows.Forms.Button resetCycleData;
        private System.Windows.Forms.Button clearFilterByLocation;
        private System.Windows.Forms.Button setLocationFilter;
        private System.Windows.Forms.TextBox statusText;
        private System.ComponentModel.BackgroundWorker bwCalculateInflowVolume;
        private System.ComponentModel.BackgroundWorker bwRollingAverages;
        private System.ComponentModel.BackgroundWorker bwCycleDataAnalysis;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.ComponentModel.BackgroundWorker bwCDtoQ;
        private System.ComponentModel.BackgroundWorker bwTTO;
        private System.ComponentModel.BackgroundWorker bwSS;
        private System.Windows.Forms.ProgressBar pbarSS;
        private System.Windows.Forms.Button buttonCancelSS;
        private System.Windows.Forms.Button buttonStageStorage;
        private System.Windows.Forms.ProgressBar pbarTTO;
        private System.Windows.Forms.Button buttonCancelTTO;
        private System.Windows.Forms.Button buttonTimeToOverflow;
        private System.Windows.Forms.Panel panelCDtoQ;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox leadPumpRate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox activeWWVolume;
        private System.Windows.Forms.Button buttonRunCDtoQ;
        private System.Windows.Forms.Button buttonCancelCDtoQ;
        private System.Windows.Forms.Button buttonConvertCDtoQ;
        private System.Windows.Forms.ProgressBar pbarCDA;
        private System.Windows.Forms.Button buttonCancelCDA;
        private System.Windows.Forms.Button buttonCycleDataAnalysis;
        private System.Windows.Forms.ProgressBar pbarRollingAverages;
        private System.Windows.Forms.Button buttonCancelRollingAverages;
        private System.Windows.Forms.Button buttonRollingAverages;
        private System.Windows.Forms.ProgressBar pbarCalculateInflowVolume;
        private System.Windows.Forms.Button buttonCancelCalculateInflowVolume;
        private System.Windows.Forms.Button buttonCalculateInflowVolume;
        private System.Windows.Forms.Button buttonCalculatePumpAndDrainTimes;
        private System.Windows.Forms.Button buttonCancelPADT;
        private System.Windows.Forms.ProgressBar pbarPADT;
        private System.ComponentModel.BackgroundWorker bwPADT;
        private System.Windows.Forms.Button buttonCycleDataScrubbing;
        private System.Windows.Forms.Button buttonCancelTCD;
        private System.Windows.Forms.ProgressBar pbarTCD;
        private System.Windows.Forms.Button buttonGetCycleDataFromNeptune;
        private System.Windows.Forms.Button buttonCancelGCDFN;
        private System.Windows.Forms.ProgressBar pbarGCDFN;
        private System.ComponentModel.BackgroundWorker bwGCDFN;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.ComponentModel.BackgroundWorker bwTCD;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ProgressBar pBarFCR;
        private System.Windows.Forms.Button buttonCancelFCR;
        private System.Windows.Forms.Button buttonFixCycleRecords;
        private System.ComponentModel.BackgroundWorker bwFCR;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ProgressBar pbarCFR;
        private System.Windows.Forms.Button buttonCancelCFR;
        private System.Windows.Forms.Button buttonCFR;
        private System.ComponentModel.BackgroundWorker bwCFR;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
    }
}