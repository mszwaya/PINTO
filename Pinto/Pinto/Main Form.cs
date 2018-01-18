using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Added References
using System.Data.SqlClient;
using System.IO;
using System.Windows.Controls;

using System.Collections.Specialized;
using System.Threading;

using System.Diagnostics;

namespace Pinto
{
    public partial class MainForm : Form
    {
        // Declared at the class level
        // These items will remain available while the form is open
        public string connectionString;
        private string myServerAddress = "BESDBTEST1";
        private string myDataBase = "SANDBOX";
        private string myUsername = "GIS";
        private string myPassword = "Hydr0plane";

        public string query;
        public SqlDataAdapter sqlAdapter;
        public DataTable inflowDataTable;
        public SqlCommandBuilder sqlCommandBuilder;
        public DataView inflowDataView;
        public BindingSource inflowDataBindingSource;

        private int numberOfRecords = 0;
        private int highestPercentageCompleted = 0;

        private SandboxDataContext sandboxDC = new SandboxDataContext();
        private NeptuneDataContext neptuneDC = new NeptuneDataContext();

        public MainForm()
        {
           
            InitializeComponent();

            Splash_Screen.ShowSplashScreen();
            UpdateStatusText("Initializing Main Form..........");

            // Create the connection string
            Splash_Screen.SetStatus("Creating Connection String.....");
            connectionString = "Server=" + myServerAddress + ";";
            connectionString += "Database=" + myDataBase + ";";
            connectionString += "User Id=" + myUsername + ";";
            connectionString += "Password=" + myPassword + ";";

            UpdateStatusText("Loading Main Data Grid.....");
            RefreshMainDataGridView();

            UpdateStatusText("Populating Combo Box.....");
            PopulateComboBoxWithPumpStations();


            // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            UpdateStatusText("Finishing Setup.....");
            Splash_Screen.CloseForm();

        }

        /// <summary>
        /// Classification of Pump Station Parameters used primarily for passing
        /// multiple pump station attributes to the BackgroundWorker
        /// b/c the BW can only take 1 Argument when asked to DoWork
        /// </summary>
        private class PumpStationParameters
        {
            private string _minimumPumpTime;
            private string _minimumFillTime;

            public int StationID { get; set; }
            public string Location { get; set; }

            public long MinimumPumpTime()
            {
                // Convert the string representation of minimum pump time interval to its TimeSpan equivalent.
                // Then return the # of ticks
                return TimeSpan.Parse(_minimumPumpTime).Ticks;
            }
            public long MinimumFillTime()
            {
                // Convert the string representation of minimum pump time interval to its TimeSpan equivalent.
                // Then return the # of ticks
                return TimeSpan.Parse(_minimumFillTime).Ticks;
            }

            // Constructor for just identiifcation properties
            public PumpStationParameters(int stationID, string location)
            {
                StationID = stationID;
                Location = location;
                _minimumPumpTime = "00:00";
                _minimumFillTime = "00:00";
            }

            // Constructor for the QA process that includes MinimumPumpTime
            public PumpStationParameters(int stationID, string location, string minimumPumpTime, string minimumFillTime)
            {
                StationID = stationID;
                Location = location;
                _minimumPumpTime = minimumPumpTime;
                _minimumFillTime = minimumFillTime;
            }
        }

        private void PopulateComboBoxWithPumpStations()
        {
            // Populate the ComboBox with the Pump Stations
            // Could be used to set a sort field or any other number of tasks

            var pumpStationQuery = from p in sandboxDC.PS_LocationTables where p.station_id != null select new { Name = p.Location, ID = p.station_id };
            cboPumpStationList.DataSource = pumpStationQuery.ToList();
            cboPumpStationList.DisplayMember = "Name";
            cboPumpStationList.ValueMember = "ID";

            //// ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            ////// Use this query for regular Pump Station analysis work
            //query = "SELECT * FROM PS_Location_Summary_Table";
            //// ------------------------------------------------------------------------------------------------
            //// Use this query for the CSO-CMOM Sanitary MAP (Monitoring blah blah blah Plan)
            ////query = "SELECT * FROM CSO_CMOM_Location_Summary_Table";
            //// ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    SqlCommand command = new SqlCommand(query, connection);
            //    SqlDataReader reader = command.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        this.cboPumpStationList.Items.Add(String.Format("{0}", reader[0]));
            //    }
            //    reader.Close();
            //}
        }

        private void RefreshMainDataGridView()
        {
            var psTable = from p in sandboxDC.PS_LocationTables orderby p.Location select p;

            mainDataGridView.DataSource = psTable.ToList();

           

            //// ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            ////// Use this query for regular Pump Station analysis work
            //query = "SELECT * FROM PS_LocationTable";
            //// ------------------------------------------------------------------------------------------------
            //// Use this query for the CSO-CMOM Sanitary MAP (Monitoring blah blah blah Plan)
            ////query = "SELECT * FROM CSO_CMOM_Location_Summary_Table";
            //// ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            //// SqlAdapter is the class that holds data commands and the connection used to fill the DataTable
            //sqlAdapter = new SqlDataAdapter(query, connectionString);
            //inflowDataTable = new DataTable();
            //// SqlCommandBuilder generates commands that reconciile changes that happen in a DataTable and the comnnected DB
            //sqlCommandBuilder = new SqlCommandBuilder(sqlAdapter);
            //// Sometimes the brackets [] are needed if field names have spaces.
            //// It will throw an error if spaces are there and brackets aren't specified
            //sqlCommandBuilder.QuotePrefix = "[";
            //sqlCommandBuilder.QuoteSuffix = "]";
            //inflowDataView = inflowDataTable.DefaultView;

            //// Fill the DataTable with the data in the data adapter
            //Cursor.Current = Cursors.WaitCursor;
            //sqlAdapter.Fill(inflowDataTable);
            //// Create a Binding Source for the form
            //inflowDataBindingSource = new BindingSource();
            //inflowDataBindingSource.DataSource = inflowDataTable;
            //this.mainDataGridView.DataSource = inflowDataBindingSource;
            //Cursor.Current = Cursors.Default;

            // Resize the data columns
            mainDataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void setLocationFilter_Click(object sender, EventArgs e)
        {
            string myString;

            if (cboPumpStationList.SelectedItem.ToString() != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                myString = "Location = '" + cboPumpStationList.SelectedItem.ToString() + "'";
                inflowDataView.RowFilter = myString;
                Cursor.Current = Cursors.Default;
            }
            else
            {
                MessageBox.Show("No Pump Station Selected");
            }
        }

        private void clearFilterByLocation_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            inflowDataView.RowFilter = "";
            Cursor.Current = Cursors.Default;
        }

        private void refreshData_Click(object sender, EventArgs e)
        {
            // Need to clear existing references
            query = String.Empty;
            sqlAdapter.Dispose();
            inflowDataTable.Dispose();
            sqlCommandBuilder.Dispose();
            inflowDataView.Dispose();

            // Now the table can be repopulated
            RefreshMainDataGridView();

            // Clear and then repopulate the combobox
            this.cboPumpStationList.Items.Clear();
            PopulateComboBoxWithPumpStations();
        }

        /// <summary>
        /// Determine if a string value has a specific Style Number And/OR Culture
        /// </summary>
        /// <param name="val">Numeric string value to be tested</param>
        /// <param name="NumberStyle">NumberStyles enumeration value</param>
        /// <returns>If the value is a number and meets the NumberStyles parameters</returns>
        private bool isNumeric(string val, System.Globalization.NumberStyles NumberStyle)
        {
            Double result;
            return Double.TryParse(val, NumberStyle,
                System.Globalization.CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Determines if the contents of a text box is a non-null, positve number
        /// </summary>
        /// <param name="textBox">Active Windows.Forms.TextBox User Control</param>
        /// <returns>true/false</returns>
        private bool TextBoxIsOK(System.Windows.Forms.TextBox textBox)
        {
            bool result = false;

            // First test for a Null or Empty value
            if (!String.IsNullOrEmpty(textBox.Text))
            {
                // Then test to see if the value is actually a number
                if (isNumeric(textBox.Text, System.Globalization.NumberStyles.Number))
                {
                    // TextBox contains something
                    // Next, test for 0 or negative values
                    if (Convert.ToInt32(textBox.Text) > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        // TextBox has an invalid 0 (or negative) value
                        result = false;
                    }
                }
                else
                {
                    // The TextBox has a Non-Numeric value
                    result = false;
                }
            }
            else
            {
                // The TextBox is Null or Empty
                result = false;
            }

            return result;
        }

        private void UpdateStatusText(string message)
        {
            Splash_Screen.SetStatus(message);
            statusText.AppendText(message + Environment.NewLine);
        }

        #region Inflow Volume

        private void bwCalculateInflowVolume_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            BackgroundWorker worker = sender as BackgroundWorker;

            // Extract the location from the argument. 
            string thisPumpStation = (String)e.Argument;

            // Do the work here
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

                //Create the select command
                // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                //// Use this query for regular Pump Station analysis work
                SqlCommand selectCommand = new SqlCommand("SELECT [Location],[DateTimeStamp],[Flow_gpm] FROM " +
                                                    "[SANDBOX].[GIS].[PS_ProcessedFlowData] " +
                                                    "WHERE [Location] = @Location ORDER BY [DateTimeStamp]", connection);
                // ------------------------------------------------------------------------------------------------
                // Use this query for the CSO-CMOM Sanitary MAP (Monitoring blah blah blah Plan)
                //SqlCommand selectCommand = new SqlCommand("SELECT [Location],[DateTimeStamp],[Flow_gpm] FROM " +
                //                                    "[SANDBOX].[GIS].[CSO_CMOM_ProcessedFlowData] " +
                //                                    "WHERE [Location] = @Location ORDER BY [DateTimeStamp]", connection);
                // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                // Add the parameters for the Select Command
                selectCommand.Parameters.Add("@Location", SqlDbType.NChar, 50);
                selectCommand.Parameters["@Location"].Value = thisPumpStation;

                // Set the SqlDataAdapter's SelectCommand.
                sqlDataAdapter.SelectCommand = selectCommand;

                // Fill the DataSet.
                DataSet dataSet = new DataSet("LocationFlowData");
                sqlDataAdapter.Fill(dataSet);

                long recordCounter = 0;
                double inflowVolume;
                double previousDateTime = 0;
                double previousInflow = 0;
                double currentDateTime;
                double currentInflow;

                numberOfRecords = dataSet.Tables[0].Rows.Count;

                // Loop through all flow data records for this location
                foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                {
                    if (worker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        break;
                    }
                    else
                    {
                        // This is the time consuming part

                        // Increment the record counter
                        recordCounter++;

                        // Retrieve DateTime and Q(gpm) values from the table
                        // Need to convert DateTime to Decimal in order to do _volume calculations
                        currentDateTime = dataRow.Field<DateTime>("DateTimeStamp").ToOADate();
                        currentInflow = (dataRow.Field<Double>("Flow_gpm"));

                        if (recordCounter == 1)
                        {
                            // Since there is no previous data, handle the 1st record by writing 0's and moving on to record #2
                            inflowVolume = 0;
                        }
                        else
                        {
                            // For all other records, calculate the inflow _volume.
                            // Must convert from days to minutes
                            inflowVolume = previousInflow * ((currentDateTime - previousDateTime) * 1400);
                        }

                        // Update the inflow _volume field
                        SqlCommand updateCommand = new SqlCommand();
                        updateCommand.Connection = connection;
                        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                        //// Use this query for regular Pump Station analysis work
                        updateCommand.CommandText = "UPDATE PS_ProcessedFlowData SET [InflowVolume_gal] = @inflowVolume WHERE Location = @Location AND DateTimeStamp = @dateTimeStamp";
                        // ------------------------------------------------------------------------------------------------
                        // Use this query for the CSO-CMOM Sanitary MAP (Monitoring blah blah blah Plan)
                        //updateCommand.CommandText = "UPDATE CSO_CMOM_ProcessedFlowData SET [InflowVolume_gal] = @inflowVolume WHERE Location = @Location AND DateTimeStamp = @dateTimeStamp";
                        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                        updateCommand.Parameters.Add("@inflowVolume", SqlDbType.Float);
                        updateCommand.Parameters["@inflowVolume"].Value = inflowVolume;
                        updateCommand.Parameters.Add("@Location", SqlDbType.NChar, 50);
                        updateCommand.Parameters["@Location"].Value = thisPumpStation;
                        updateCommand.Parameters.Add("@dateTimeStamp", SqlDbType.DateTime);
                        updateCommand.Parameters["@dateTimeStamp"].Value = dataRow.Field<DateTime>("DateTimeStamp");

                        try
                        {
                            updateCommand.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                        // Swap values
                        previousInflow = currentInflow;
                        previousDateTime = currentDateTime;

                        // Report progress as a percentage of the total task. 
                        int percentComplete = (int)((float)recordCounter / (float)numberOfRecords * 100);

                        if (percentComplete > highestPercentageCompleted)
                        {
                            highestPercentageCompleted = percentComplete;
                            worker.ReportProgress(percentComplete);
                        }



                    } // END if (worker.CancellationPending == true)

                } // END foreach (DataRow dataRow in dataSet.Tables[0].Rows)

            } // END using (SqlConnection connection = new SqlConnection(connectionString))

        }

        private void bwCalculateInflowVolume_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.pbarCalculateInflowVolume.Value = e.ProgressPercentage;
        }

        private void bwCalculateInflowVolume_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown.
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                // Next, handle the case where the user canceled the operation. 
                // Note that due to a race condition in the DoWork event handler, 
                // the Cancelled flag may not have been set, even though 
                // CancelAsync was called.
                UpdateStatusText("Calculate Inflow Volume Cancelled.....");
            }
            else
            {
                // Finally, handle the case where the operation succeeded.
                UpdateStatusText("Calculate Inflow Volume Finished.....");
            }

            // Enable the Start button
            this.buttonCalculateInflowVolume.Enabled = true;

            // Disable the stop button
            this.buttonCancelCalculateInflowVolume.Enabled = false;

            // hide the progress bar
            this.pbarCalculateInflowVolume.Visible = false;

            // Call ResetBundings to refresh the data in the datatable
            inflowDataBindingSource.ResetBindings(false);
        }

        private void buttonCalculateInflowVolume_Click(object sender, EventArgs e)
        {
            string thisPumpStation;

            // Check to see if anything was selected.
            // ToString() gets grumpy if it is empty
            if (cboPumpStationList.SelectedIndex > -1)
            {
                thisPumpStation = cboPumpStationList.SelectedItem.ToString();

                if (string.IsNullOrEmpty(thisPumpStation))
                {
                    MessageBox.Show("No Location Selected");
                    return;
                }
            }
            else
            {
                return;
            }

            // Reset the text in the status box
            statusText.Text = String.Empty;

            // Disable the task button until the asynchronous operation is done
            this.buttonCalculateInflowVolume.Enabled = false;
            // Enable the cancel button while the asynchronous operation runs
            this.buttonCancelCalculateInflowVolume.Enabled = true;
            // Enable the progress bar
            this.pbarCalculateInflowVolume.Visible = true;
            // Reset the variable for percentage tracking
            highestPercentageCompleted = 0;
            // start the asynchronous operation
            //bwCalculateInflowVolume.RunWorkerAsync(cboPumpStationList);
            bwCalculateInflowVolume.RunWorkerAsync(thisPumpStation);

        }

        private void buttonCancelCalculateInflowVolume_Click(object sender, EventArgs e)
        {
            // Cancel the asynchronous operation.
            this.bwCalculateInflowVolume.CancelAsync();
            // Disable the Cancel button
            buttonCancelCalculateInflowVolume.Enabled = false;
            // Enable the Processing Button
            buttonCalculateInflowVolume.Enabled = true;
            // hide the progress bar
            this.pbarCalculateInflowVolume.Visible = false;
        }

        #endregion

        #region Rolling Averages

        private void buttonRollingAverages_Click(object sender, EventArgs e)
        {
            string thisPumpStation;

            // Check to see if anything was selected.
            // ToString() gets grumpy if it is empty
            if (cboPumpStationList.SelectedIndex > -1)
            {
                thisPumpStation = cboPumpStationList.SelectedItem.ToString();

                if (string.IsNullOrEmpty(thisPumpStation))
                {
                    MessageBox.Show("No Pump Station Selected", "Calculate Rolling Averages", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                return;
            }

            // Reset the text in the status box
            statusText.Text = String.Empty;

            // Disable the task button until the asynchronous operation is done
            this.buttonRollingAverages.Enabled = false;
            // Enable the cancel button while the asynchronous operation runs
            this.buttonCancelRollingAverages.Enabled = true;
            // Enable the Progress Bar
            this.pbarRollingAverages.Visible = true;
            // Reset the variable for percentage tracking
            highestPercentageCompleted = 0;
            // start the asynchronous operation
            bwRollingAverages.RunWorkerAsync(thisPumpStation);

        }

        private void buttonCancelRollingAverages_Click(object sender, EventArgs e)
        {
            // Cancel the asynchronous operation.
            this.bwRollingAverages.CancelAsync();
            // Disable the Cancel button
            buttonCancelRollingAverages.Enabled = false;
            // Enable the Processing Button
            buttonRollingAverages.Enabled = true;
            // Hide the progress bar
            pbarRollingAverages.Visible = false;
        }

        private void bwRollingAverages_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            BackgroundWorker worker = sender as BackgroundWorker;

            // Extract the location from the argument. 
            string thisPumpStation = (String)e.Argument;

            // Do the work here
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

                //Create the select command
                // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                //// Use this query for regular Pump Station analysis work
                SqlCommand selectCommand = new SqlCommand("SELECT [Location],[DateTimeStamp],[Flow_gpm] FROM " +
                                                   "[SANDBOX].[GIS].[PS_ProcessedFlowData] " +
                                                   "WHERE [Location] = @Location " +
                                                   "ORDER BY [DateTimeStamp] ", connection);
                // ------------------------------------------------------------------------------------------------
                // Use this query for the CSO-CMOM Sanitary MAP (Monitoring blah blah blah Plan)
                //SqlCommand selectCommand = new SqlCommand("SELECT [Location],[DateTimeStamp],[Flow_gpm] FROM " +
                //                                   "[SANDBOX].[GIS].[CSO_CMOM_ProcessedFlowData] " +
                //                                   "WHERE [Location] = @Location " +
                //                                   "ORDER BY [DateTimeStamp] ", connection);
                // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

               

                // Add the parameters for the Select Command
                selectCommand.Parameters.Add("@Location", SqlDbType.NChar, 50);
                selectCommand.Parameters["@Location"].Value = thisPumpStation;

                // Set the SqlDataAdapter's SelectCommand.
                sqlDataAdapter.SelectCommand = selectCommand;

                // Fill the DataSet.
                DataSet dataSet = new DataSet("LocationFlowData");
                sqlDataAdapter.Fill(dataSet);

                // Define analysis variables
                long recordCounter = 0;
                DateTime startDateTime;
                DateTime endDateTime;
                double averageInflowVolume_1h = 0;
                double averageInflowVolume_1d = 0;
                double averageInflowVolume_7d = 0;
                double averageInflowVolume_30d = 0;

                // Set up the progress bar
                //InitializeProgressBar(dataSet.Tables[0].Rows.Count);
                numberOfRecords = dataSet.Tables[0].Rows.Count;

                // Loop through all flow data records for this location
                foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                {
                    if (worker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        break;
                    }
                    else
                        // This is the time-consuming part

                        // Increment the record counter
                        recordCounter++;

                    // Set the end DateTime value from the current record
                    endDateTime = dataRow.Field<DateTime>("DateTimeStamp");

                    // 1 HOUR
                    // Go back 1 hour to get the start DateTime
                    startDateTime = endDateTime.AddHours(-1);
                    // Calculate the _volume
                    averageInflowVolume_1h = CalculateAverageInflow(thisPumpStation, connection, startDateTime, endDateTime);

                    // 1 DAY
                    // Go back 1 day to get the start DateTime
                    startDateTime = endDateTime.AddDays(-1);
                    // Calculate the _volume
                    averageInflowVolume_1d = CalculateAverageInflow(thisPumpStation, connection, startDateTime, endDateTime);

                    // 7 DAY
                    // Go back 7 days to get the start DateTime
                    startDateTime = endDateTime.AddDays(-7);
                    // Calculate the _volume
                    averageInflowVolume_7d = CalculateAverageInflow(thisPumpStation, connection, startDateTime, endDateTime);

                    // 30 DAY
                    // Go back 30 Days to get the start DateTime
                    startDateTime = endDateTime.AddDays(-30);
                    // Calculate the _volume
                    averageInflowVolume_30d = CalculateAverageInflow(thisPumpStation, connection, startDateTime, endDateTime);


                    // Update the inflow _volume field
                    SqlCommand updateCommand = new SqlCommand();
                    updateCommand.Connection = connection;
                    // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    //// Use this query for regular Pump Station analysis work
                    updateCommand.CommandText = "UPDATE PS_ProcessedFlowData SET [Average_1h] = @averageInflowVolume_1h, [Average_1d] = @averageInflowVolume_1d, [Average_7d] = @averageInflowVolume_7d, [Average_30d] = @averageInflowVolume_30d WHERE Location = @Location AND DateTimeStamp = @dateTimeStamp";
                    // ------------------------------------------------------------------------------------------------
                    // Use this query for the CSO-CMOM Sanitary MAP (Monitoring blah blah blah Plan)
                    //updateCommand.CommandText = "UPDATE CSO_CMOM_ProcessedFlowData SET [Average_1h] = @averageInflowVolume_1h, [Average_1d] = @averageInflowVolume_1d, [Average_7d] = @averageInflowVolume_7d, [Average_30d] = @averageInflowVolume_30d WHERE Location = @Location AND DateTimeStamp = @dateTimeStamp";
                    // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    updateCommand.Parameters.Add("@averageInflowVolume_1h", SqlDbType.Float);
                    updateCommand.Parameters["@averageInflowVolume_1h"].Value = averageInflowVolume_1h;
                    updateCommand.Parameters.Add("@averageInflowVolume_1d", SqlDbType.Float);
                    updateCommand.Parameters["@averageInflowVolume_1d"].Value = averageInflowVolume_1d; 
                    updateCommand.Parameters.Add("@averageInflowVolume_7d", SqlDbType.Float);
                    updateCommand.Parameters["@averageInflowVolume_7d"].Value = averageInflowVolume_7d;
                    updateCommand.Parameters.Add("@averageInflowVolume_30d", SqlDbType.Float);
                    updateCommand.Parameters["@averageInflowVolume_30d"].Value = averageInflowVolume_30d;
                    updateCommand.Parameters.Add("@Location", SqlDbType.NChar, 50);
                    updateCommand.Parameters["@Location"].Value = thisPumpStation;
                    updateCommand.Parameters.Add("@dateTimeStamp", SqlDbType.DateTime);
                    updateCommand.Parameters["@dateTimeStamp"].Value = dataRow.Field<DateTime>("DateTimeStamp");

                    try
                    {
                        updateCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new ArgumentException(ex.Message);
                        //MessageBox.Show(ex.Message);
                    }

                    // Report progress as a percentage of the total task. 
                    int percentComplete = (int)((float)recordCounter / (float)numberOfRecords * 100);

                    if (percentComplete > highestPercentageCompleted)
                    {
                        highestPercentageCompleted = percentComplete;
                        worker.ReportProgress(percentComplete);
                    }

                } // END foreach (DataRow dataRow in dataSet.Tables[0].Rows)

            } // END using (SqlConnection connection = new SqlConnection(connectionString))

        }

        private void bwRollingAverages_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.pbarRollingAverages.Value = e.ProgressPercentage;
        }

        private void bwRollingAverages_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown.
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                // Next, handle the case where the user canceled the operation. 
                // Note that due to a race condition in the DoWork event handler, 
                // the Cancelled flag may not have been set, even though 
                // CancelAsync was called.
                UpdateStatusText("Calculate Rolling Averages Cancelled........");
            }
            else
            {
                // Finally, handle the case where the operation succeeded.
                UpdateStatusText("Calculate Rolling Averages Finished........");
            }

            // Enable the Start button
            this.buttonRollingAverages.Enabled = true;

            // Disable the stop button
            this.buttonCancelRollingAverages.Enabled = false;

            // hide the progress bar
            this.pbarRollingAverages.Visible = false;
        }
        
        /// <summary>
        /// Calculates the average inflow to the location between the specified start and stop date/times
        /// </summary>
        /// <param name="thisPumpStation">Location ID that will be analyzed</param>
        /// <param name="connection">SQL Connection to the database that holds the inflow data table </param>
        /// <param name="startDateTime">Start (lower) date/time</param>
        /// <param name="endDateTime">End (higher) date/time</param>
        /// <returns></returns>
        private static double CalculateAverageInflow(string thisPumpStation, SqlConnection connection, DateTime startDateTime, DateTime endDateTime)
        {
            double averageInflowVolume = 0;
            double totalInflowVolume = 0;
            double endDateTimeNumber;
            double startDateTimeNumber;

            // Set the ActualStartDateTime value as a default
            DateTime actualStartDateTime = startDateTime;

            // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            //// Use this query for regular Pump Station analysis work
            using (SqlCommand getVolumeDataCommand = new SqlCommand("PS_Get_Inflow_Volume_Statistics", connection))            
            // ------------------------------------------------------------------------------------------------
            // Use this query for the CSO-CMOM Sanitary MAP (Monitoring blah blah blah Plan)
            //using (SqlCommand getVolumeDataCommand = new SqlCommand("CSO_CMOM_Get_Inflow_Volume_Statistics", connection))
            // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++            
            {
                // Set up to execute the stored procedure
                getVolumeDataCommand.CommandType = CommandType.StoredProcedure;
                getVolumeDataCommand.CommandTimeout = 120;
                getVolumeDataCommand.Parameters.Add("@Location", SqlDbType.NChar, 50).Value = thisPumpStation;
                getVolumeDataCommand.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = startDateTime;
                getVolumeDataCommand.Parameters.Add("@EndTime", SqlDbType.DateTime).Value = endDateTime;

                // Connection is already open
                // connection.Open();

                // EXEC the stored procedure
                // Need to use Reader because there are multiple columns (but only 1 row)
                SqlDataReader volumeDataReader = getVolumeDataCommand.ExecuteReader();
                // Timeout???

                // Call Read before accessing data
                while (volumeDataReader.Read())
                {
                    try
                    {
                        // Get the values from the stored procedure
                        actualStartDateTime = volumeDataReader.GetDateTime(0);
                        //actualStartDateTime = (DateTime)volumeDataReader[1];
                        totalInflowVolume = volumeDataReader.GetDouble(2);
                        //totalInflowVolume = (float)volumeDataReader[2];
                        // Perform the AVERAGE _volume calculations
                        // The ToOADate values need to be converted from DOUBLE to FLOAT
                        endDateTimeNumber = (double)endDateTime.ToOADate();
                        startDateTimeNumber = (double)startDateTime.ToOADate();
                        averageInflowVolume = (totalInflowVolume / (endDateTimeNumber - startDateTimeNumber)) / 1000000;

                    }
                    catch (InvalidCastException ex)
                    {
                        averageInflowVolume = 0;
                        Console.WriteLine(ex.Message);
                    }
                    catch (System.Data.SqlTypes.SqlNullValueException ex)
                    {
                        averageInflowVolume = 0;
                        Console.WriteLine(ex.Message);
                    }

                } // END while (volumeDataReader.Read())

                volumeDataReader.Close();

            } // END using (SqlCommand getVolumeDataCommand = new SqlCommand("XXXXXXX_Get_Inflow_Volume_Statistics", connection))

            return averageInflowVolume;

        }

        #endregion

        #region Time To Overflow

        private void buttonTimeToOverflow_Click(object sender, EventArgs e)
        {
            string thisPumpStation;

            // Check to see if anything was selected.
            // ToString() gets grumpy if it is empty
            if (cboPumpStationList.SelectedIndex > -1)
            {
                thisPumpStation = cboPumpStationList.SelectedItem.ToString();

                if (string.IsNullOrEmpty(thisPumpStation))
                {
                    MessageBox.Show("No Location Selected", "Calculate Rolling Averages", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                return;
            }

            // Reset the text in the status box
            statusText.Text = String.Empty;

            // Disable the task button until the asynchronous operation is done
            this.buttonTimeToOverflow.Enabled = false;
            // Enable the cancel button while the asynchronous operation runs
            this.buttonCancelTTO.Enabled = true;
            // Enable the Progress Bar
            this.pbarTTO.Visible = true;
            // Reset the variable for percentage tracking
            highestPercentageCompleted = 0;
            // start the asynchronous operation
            bwTTO.RunWorkerAsync(thisPumpStation);
        }

        private void buttonCancelTTO_Click(object sender, EventArgs e)
        {
            // Cancel the asynchronous operation.
            this.bwTTO.CancelAsync();
            // Disable the Cancel button
            this.buttonCancelTTO.Enabled = false;
            // Enable the Processing Button
            this.buttonTimeToOverflow.Enabled = true;
            // Hide user controls
            pbarTTO.Visible = false;
        }

        private void bwTTO_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            BackgroundWorker worker = sender as BackgroundWorker;

            // Extract the location from the argument. 
            string thisPumpStation = (String)e.Argument;

            // Do the work here
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

                // -----------------------------------------------------------------------------------------------------------------
                // Get PS Location Information
                // Create the select command
                SqlCommand selectCommand = new SqlCommand("SELECT [GravitySystemStorage_gal] " +
                                                        "FROM [SANDBOX].[GIS].[PS_LocationTable] " +
                                                        "WHERE [Location] = @Location", connection);

                // Add the parameters for the Select Command
                selectCommand.Parameters.Add("@Location", SqlDbType.NChar, 50);
                selectCommand.Parameters["@Location"].Value = thisPumpStation;

                // Set the SqlDataAdapter's SelectCommand.
                sqlDataAdapter.SelectCommand = selectCommand;

                // Fill the DataSet.
                DataSet dataSet = new DataSet("LocationFlowData");
                sqlDataAdapter.Fill(dataSet);

                DataRow dRow = dataSet.Tables[0].Rows[0];
                int overflowVolume = dRow.Field<int>("GravitySystemStorage_gal");

                // -----------------------------------------------------------------------------------------------------------------
                // Get the full list of Inflow Data records to cycle through
                // Create the select command
                selectCommand = new SqlCommand("SELECT [Location],[DateTimeStamp] " +
                                                    "FROM [SANDBOX].[GIS].[PS_InflowData] " +
                                                    "WHERE [Location] = @Location ORDER BY [DateTimeStamp]", connection);

                // Add the parameters for the Select Command
                selectCommand.Parameters.Add("@Location", SqlDbType.NChar, 50);
                selectCommand.Parameters["@Location"].Value = thisPumpStation;

                // Set the SqlDataAdapter's SelectCommand.
                sqlDataAdapter.SelectCommand = selectCommand;

                // Fill the DataSet.
                dataSet = new DataSet("LocationFlowData");
                sqlDataAdapter.Fill(dataSet);

                // -----------------------------------------------------------------------------------------------------------------
                int recordCounter = 0;
                DateTime baseDateTime;
                double currentVolume;
                DateTime thisDateTime;
                TimeSpan timeToOverflow;

                // Set up the progress bar
                numberOfRecords = dataSet.Tables[0].Rows.Count;

                // Loop through all flow data records for this location
                foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                {
                    if (worker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        break;
                    }
                    else
                    {
                        // This is the time consuming part
                        // Increment the record counter
                        recordCounter++;
                        // Define the baseDateTime
                        baseDateTime = dataRow.Field<DateTime>("DateTimeStamp");
                        // Set/Reset currentVolume & redefine TimeToOverflow
                        currentVolume = 0;
                        timeToOverflow = new TimeSpan(23, 59, 59);

                        // Retrieve DateTime and InflowVolume values from the table
                        // where the DateTime is GREATER than the current baseDateTime
                        selectCommand = new SqlCommand("SELECT TOP 500 [DateTimeStamp],[InflowVolume_gal] " +
                                                        "FROM [SANDBOX].[GIS].[PS_InflowData] " +
                                                        "WHERE [Location] = @Location " +
                                                        "AND [DateTimeStamp] > '" + baseDateTime + "' " +
                                                        "ORDER BY [DateTimeStamp]", connection);

                        // Add the parameters for the Select Command
                        selectCommand.Parameters.Add("@Location", SqlDbType.NChar, 50);
                        selectCommand.Parameters["@Location"].Value = thisPumpStation;

                        // Set the SqlDataAdapter's SelectCommand.
                        sqlDataAdapter.SelectCommand = selectCommand;

                        // Fill the DataSet.
                        DataSet inflowDataSubSet = new DataSet("LocationFlowData");
                        sqlDataAdapter.Fill(inflowDataSubSet);

                        // Loop through the subsequent cycle records incrementally adding the _volume
                        foreach (DataRow inflowDataRow in inflowDataSubSet.Tables[0].Rows)
                        {
                            thisDateTime = inflowDataRow.Field<DateTime>("DateTimeStamp");
                            // Add the current _volume to the total _volume
                            currentVolume += inflowDataRow.Field<double>("InflowVolume_gal");
                            // Check to see if the current _volume > the overflow _volume
                            if (currentVolume > overflowVolume)
                            {
                                // Overflow...Calculate the delta time and exit the For..Next Loop
                                timeToOverflow = thisDateTime.Subtract(baseDateTime);
                                // Check if the time is greater than 24 hours.
                                // If so, bump back to a large value (23:59:59) so it will fit in SQL Server Time2 data type
                                if (timeToOverflow.Days >= 1)
                                    timeToOverflow = new TimeSpan(23, 59, 59);
                                break;
                            }
                        }

                        // Update the TimeToOverflow field
                        SqlCommand updateCommand = new SqlCommand();
                        updateCommand.Connection = connection;
                        updateCommand.CommandText = "UPDATE [SANDBOX].[GIS].[PS_InflowData] " +
                                                    "SET [TimeToOverflow] = @timeToOverflow WHERE Location = @Location AND DateTimeStamp = @dateTimeStamp";
                        updateCommand.Parameters.Add("@Location", SqlDbType.NChar, 50);
                        updateCommand.Parameters["@Location"].Value = thisPumpStation;
                        updateCommand.Parameters.Add("@timeToOverflow", SqlDbType.Time);
                        updateCommand.Parameters["@timeToOverflow"].Value = timeToOverflow;
                        updateCommand.Parameters.Add("@dateTimeStamp", SqlDbType.DateTime);
                        updateCommand.Parameters["@dateTimeStamp"].Value = dataRow.Field<DateTime>("DateTimeStamp");

                        try
                        {
                            updateCommand.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                        // Report progress as a percentage of the total task. 
                        int percentComplete = (int)((float)recordCounter / (float)numberOfRecords * 100);

                        if (percentComplete > highestPercentageCompleted)
                        {
                            highestPercentageCompleted = percentComplete;
                            worker.ReportProgress(percentComplete);
                        }
                    } // END if (worker.CancellationPending == true)
                } // END foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            } // END using (SqlConnection connection = new SqlConnection(connectionString))
        }

        private void bwTTO_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.pbarTTO.Value = e.ProgressPercentage;
        }

        private void bwTTO_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown.
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                // Next, handle the case where the user canceled the operation. 
                // Note that due to a race condition in the DoWork event handler, 
                // the Cancelled flag may not have been set, even though 
                // CancelAsync was called.
                UpdateStatusText("Calculate Time To Overflow Cancelled........");
            }
            else
            {
                // Finally, handle the case where the operation succeeded.
                UpdateStatusText("Calculate Time To Overflow Finished........");
            }

            // Disable the Cancel button
            this.buttonCancelTTO.Enabled = false;
            // Enable the Processing Button
            this.buttonTimeToOverflow.Enabled = true;
            // Hide user controls
            pbarTTO.Visible = false;
        }

        #endregion

        #region Stage Storage

        private void buttonStageStorage_Click(object sender, EventArgs e)
        {
            int? station_ID = null;

            // Check to see if anything was selected.
            // ToString() gets grumpy if it is empty
            if (cboPumpStationList.SelectedIndex > -1)
            {
                station_ID = (int)cboPumpStationList.SelectedValue;

                if (station_ID == null)
                {
                    MessageBox.Show("No Location Selected", "Calculate Stage-Storage Table", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                return;
            }

            // Reset the text in the status box
            statusText.Text = String.Empty;

            // Disable the task button until the asynchronous operation is done
            this.buttonStageStorage.Enabled = false;
            // Enable the cancel button while the asynchronous operation runs
            this.buttonCancelSS.Enabled = true;
            // Enable the Progress Bar
            this.pbarSS.Visible = true;
            // Reset the variable for percentage tracking
            highestPercentageCompleted = 0;
            // start the asynchronous operation
            bwSS.RunWorkerAsync(station_ID);
        }

        private void buttonCancelSS_Click(object sender, EventArgs e)
        {
            // Cancel the asynchronous operation.
            this.bwSS.CancelAsync();
            // Disable the Cancel button
            buttonCancelSS.Enabled = false;
            // Enable the Processing Button
            buttonStageStorage.Enabled = true;
            // Hide the progress bar
            pbarSS.Visible = false;
        }

        private void bwSS_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            BackgroundWorker worker = sender as BackgroundWorker;

            // Extract the location from the argument. 
            int station_ID = (int)e.Argument;
            string thisLocation;

            // Set up the StreamWriter to log the process
            string dateStamp = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString();
            string logFileName = @"C:\Logs\StageStorage_" + dateStamp + ".txt";
            StreamWriter sw = new StreamWriter(logFileName);

            // Do the work here
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

                // -----------------------------------------------------------------------------------------------------------------
                // Get PS Location Information
                // Create the select command
                SqlCommand selectCommand = new SqlCommand("SELECT [Location],[OverflowElevation] " +
                                                        "FROM [SANDBOX].[GIS].[PS_LocationTable] " +
                                                        "WHERE [station_id] = @station_id", connection);

                // Add the parameters for the Select Command
                selectCommand.Parameters.Add("@station_id", SqlDbType.Int);
                selectCommand.Parameters["@station_id"].Value = station_ID;

                // Set the SqlDataAdapter's SelectCommand.
                sqlDataAdapter.SelectCommand = selectCommand;

                // Fill the DataSet.
                DataSet locationDataSet = new DataSet("LocationOverflowData");
                sqlDataAdapter.Fill(locationDataSet);

                DataRow dRow = locationDataSet.Tables[0].Rows[0];
                double overflowElevation = dRow.Field<double>("OverflowElevation");
                thisLocation = dRow.Field<string>("Location");

                // -----------------------------------------------------------------------------------------------------------------
                // Get the list of gravity pipe records to work with
                // Only select gravity pipes that have the DSIE **less than** the overflow elevation
                // Create the select command
                selectCommand = new SqlCommand("SELECT [Location],[MLinkID],[USNode],[DSNode],[PipeFlowType],[DiamWidth],[USIE],[DSIE],[Length] " +
                                                    "FROM [SANDBOX].[GIS].[PS_Gravity_Pipes] " +
                                                    "WHERE [station_id] = @station_id AND [DSIE] < @OverflowElevation ", connection);

                // Add the parameters for the Select Command
                selectCommand.Parameters.Add("@station_id", SqlDbType.Int);
                selectCommand.Parameters["@station_id"].Value = station_ID;
                selectCommand.Parameters.Add("@OverflowElevation", SqlDbType.Float);
                selectCommand.Parameters["@OverflowElevation"].Value = overflowElevation;

                // Set the SqlDataAdapter's SelectCommand.
                sqlDataAdapter.SelectCommand = selectCommand;

                // Fill the DataSet.
                DataSet pipeDataSet = new DataSet("GravityPipeData");
                sqlDataAdapter.Fill(pipeDataSet);

                // -----------------------------------------------------------------------------------------------------------------
                // This is where the array of elevations to evaluate is defined
                // The elevation step will be 0.50 ft.
                // Use LINQ to query the Dataset for the smallest DSIE.  This *should* be the invert into the PS
                double lowestInvert = pipeDataSet.Tables[0].AsEnumerable().Min(r => r.Field<double>("DSIE"));
                // Now have the elevation bounds defined (lowestInvert to overflowElevation)
                // Need to create an array of elevations between the bounds at 0.50 foot intervals
                // First, find the Floor - this is the first 0.50 foot elevation at or above the lowestInvert
                double floorElevation = 0;
                if (lowestInvert % 0.50 == 0)
                {
                    // the lowestInvert is a multiple of 0.50...set the floorElevation at lowestInvert + 0.50
                    floorElevation = lowestInvert + 0.50;
                }
                else
                {
                    // The lowestInvert is NOT a multiple of 0.50...find the next 0.50 elevation using Ceiling
                    // Can't use 1 formula.  Negative elevations will get messed up!!!!!
                    if (lowestInvert < 0)
                    {
                        floorElevation = ((int)(lowestInvert / 0.50) * 0.50) - 0.50;
                        if (floorElevation < lowestInvert)
                            floorElevation += 0.50;
                    }
                    else
                        floorElevation = ((int)(lowestInvert / 0.50) * 0.50) + 0.50;
                }
                // Repeat the process with the overflowElevation to find the Ceiling
                double ceilingElevation = 0;
                if (overflowElevation % 0.50 == 0)
                {
                    // the overflowElevation is a multiple of 0.50...set the ceilingElevation at overflowElevation - 0.50
                    ceilingElevation = overflowElevation - 0.50;
                }
                else
                {
                    // The overflowElevation is NOT a multiple of 0.50...
                    ceilingElevation = ((int)(overflowElevation / 0.50) * 0.50);
                }
                // The number of elevation intervals will be the # of 0.50 intervals between the floor and ceiling + 3
                int elevationIntervals = Convert.ToInt32((ceilingElevation - floorElevation) / 0.50 + 3);
                // Initialize the array
                double[] elevationArray = new double[elevationIntervals];
                // We can assign the upper and lower bounds of the analysis to the first & last elements of the array
                // Remember arrays are zero-based
                elevationArray[0] = lowestInvert;
                elevationArray[elevationIntervals - 1] = overflowElevation;
                // The array needs to be populated with the remainder of elevations that are at 0.50 ft intervals
                for (int i = 1; i <= elevationIntervals - 2; i++)
                {
                    elevationArray[i] = floorElevation + ((i - 1) * 0.5);
                }

                // -----------------------------------------------------------------------------------------------------------------
                // This is the shitty analysis part where there is an Outer Loop of the elevations to evaluate at
                // and then an Inner Loop that consists of all the gravity system pipes.
                // Not all gravity pipes will be evaluated but they will be checked to see if they contain any water.
                // We will report progress to update the Progress Bar after each pipe, regardless of water content

                int recordCounter = 0;
                double currentVolume = 0;

                // Set up the progress bar
                // Set it as the # of intervals x the # of pipes
                numberOfRecords = pipeDataSet.Tables[0].Rows.Count * elevationIntervals;

                // Loop through all flow data records for this location
                foreach (double thisElevation in elevationArray)
                {
                    if (worker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        break;
                    }
                    else
                    {
                        // This is the time consuming part

                        // Set/Reset currentVolume for thisElevation
                        sw.WriteLine("ELEVATION: " + thisElevation.ToString());
                        currentVolume = 0;

                        // Loop through all the gravity pipes
                        foreach (DataRow pipeDataRow in pipeDataSet.Tables[0].Rows)
                        {
                            // Increment the record counter
                            recordCounter++;
                            // Create the pipe object
                            GravitySystemPipe thisPipe = new GravitySystemPipe(pipeDataRow.Field<int>("MLinkID"),
                                                                               pipeDataRow.Field<string>("USNode"),
                                                                               pipeDataRow.Field<string>("DSNode"),
                                                                               pipeDataRow.Field<double>("DiamWidth"),
                                                                               pipeDataRow.Field<double>("USIE"),
                                                                               pipeDataRow.Field<double>("DSIE"),
                                                                               pipeDataRow.Field<double>("Length"),
                                                                               thisElevation);
                            
                            // Logging
                            sw.WriteLine("MLinkID: " + thisPipe.MLinkID.ToString());
                            sw.WriteLine("USNode: " + thisPipe.USNode.ToString()); 
                            sw.WriteLine("DSNode: " + thisPipe.DSNode.ToString());
                            sw.WriteLine("Diameter: " + thisPipe.Diam_inches.ToString());
                            sw.WriteLine("Length: " + thisPipe.PipeLength.ToString());
                            sw.WriteLine("USIE: " + thisPipe.USIE.ToString());
                            sw.WriteLine("DSIE: " + thisPipe.DSIE.ToString());
                            sw.WriteLine("Slope: " + thisPipe.PipeSlope.ToString());
                            sw.WriteLine("Angle (deg.): " + thisPipe.PipeAngleInDegrees.ToString());
                            sw.WriteLine("Angle (rad): " + thisPipe.PipeAngleInRadians.ToString());
                            sw.WriteLine("USCE: " + thisPipe.USCE.ToString());
                            sw.WriteLine("US Cover: " + thisPipe.USCover.ToString());
                            sw.WriteLine("DSCE: " + thisPipe.DSCE.ToString());
                            sw.WriteLine("Pipe Case: " + thisPipe.PipeFillScenario.ToString());
                            sw.WriteLine("Measurement Tyoe: " + thisPipe.DepthMeasurementType.ToString());
                            sw.WriteLine("WSE: " + thisPipe.WSE.ToString());
                            sw.WriteLine("Volume: " + thisPipe.Volume.ToString());
                            sw.WriteLine("----------------------------------------");

                            currentVolume += thisPipe.Volume;

                            // Report progress as a percentage of the total task. 
                            int percentComplete = (int)((float)recordCounter / (float)numberOfRecords * 100);

                            if (percentComplete > highestPercentageCompleted)
                            {
                                highestPercentageCompleted = percentComplete;
                                worker.ReportProgress(percentComplete);
                            }

                        }

                        sw.WriteLine("TOTAL Volume: " + currentVolume.ToString());
                        sw.WriteLine("===================================================================");
                        sw.WriteLine();
                        
                        // insert into the PS_Stage_Storage table
                        SqlCommand insertCommand = new SqlCommand();
                        insertCommand.Connection = connection;

                        insertCommand.CommandText = "INSERT INTO [SANDBOX].[GIS].[PS_StageStorage] " +
                                                    "([Location], [station_id], [StageElev], [CumulativeVolume]) " +
                                                    "VALUES (@Location, @station_id, @StageElev, @CumulativeVolume)";
                        insertCommand.Parameters.Add("@Location", SqlDbType.NChar, 50);
                        insertCommand.Parameters["@Location"].Value = thisLocation;
                        insertCommand.Parameters.Add("@station_id", SqlDbType.Int);
                        insertCommand.Parameters["@station_id"].Value = station_ID;
                        insertCommand.Parameters.Add("@StageElev", SqlDbType.Float);
                        insertCommand.Parameters["@StageElev"].Value = thisElevation;
                        insertCommand.Parameters.Add("@CumulativeVolume", SqlDbType.Float);
                        insertCommand.Parameters["@CumulativeVolume"].Value = currentVolume;

                        int tries = 0;
                        bool completed = false;
                        while (!completed)
                        {
                            try
                            {
                                insertCommand.ExecuteNonQuery();
                                completed = true;
                            }
                            catch (SqlException ex)
                            {
                                tries++;
                                if (ex.Number == 2627) // <----------- Violation of Primary key
                                {
                                    string thisMessage = ex.Message + Environment.NewLine +
                                                        "This Pump Station already has a Stage-Storage table" + Environment.NewLine +
                                                        "Overwrite existing records?";
                                    DialogResult result = MessageBox.Show(thisMessage, "Primary Key Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (result == DialogResult.Yes)
                                    {
                                        SqlCommand deleteCommand = new SqlCommand();
                                        deleteCommand.Connection = connection;
                                        deleteCommand.CommandText = "DELETE FROM [SANDBOX].[GIS].[PS_StageStorage] WHERE " +
                                                                    "[Location] = @Location";
                                        deleteCommand.Parameters.Add("@Location", SqlDbType.NChar, 50);
                                        deleteCommand.Parameters["@Location"].Value = thisLocation;
                                        deleteCommand.ExecuteNonQuery();
                                    }
                                    
                                }
                                else
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                if (tries == 3)
                                    throw;
                            }
                        }
                    } // END if (worker.CancellationPending == true)
                } // END foreach (double thisElevation in elevationArray)
                sw.Close();
            } // END using (SqlConnection connection = new SqlConnection(connectionString))
        }

        private void bwSS_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.pbarSS.Value = e.ProgressPercentage;
        }

        private void bwSS_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown.
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                // Next, handle the case where the user canceled the operation. 
                // Note that due to a race condition in the DoWork event handler, 
                // the Cancelled flag may not have been set, even though 
                // CancelAsync was called.
                UpdateStatusText("Stage-Storage Calculations Cancelled..........");
            }
            else
            {
                // Finally, handle the case where the operation succeeded.
                UpdateStatusText("Stage-Storage Calculations Finished..........");

            }

            // Enable the Start button
            this.buttonStageStorage.Enabled = true;

            // Disable the stop button
            this.buttonCancelSS.Enabled = false;

            // hide the progress bar
            this.pbarSS.Visible = false;
        }

        #endregion

        #region #1 Get Cycle Data From NEPTUNE
        private void buttonGetCycleDataFromNeptune_Click(object sender, EventArgs e)
        {
            int? station_ID = null;
            string pumpStationName = "";

            // Check to see if anything was selected.
            // ToString() gets grumpy if it is empty
            if (cboPumpStationList.SelectedIndex > -1)
            {
                station_ID = (int)cboPumpStationList.SelectedValue;
                string selectedPumpStationName = cboPumpStationList.SelectedItem.ToString();
                pumpStationName = selectedPumpStationName.Substring(selectedPumpStationName.IndexOf("= ") + 2, selectedPumpStationName.IndexOf("  ") - selectedPumpStationName.IndexOf("= ") - 2);

                if (station_ID == null)
                {
                    MessageBox.Show("No Location Selected");
                    return;
                }
            }
            else
            {
                return;
            }

            PumpStationParameters psParameters = new PumpStationParameters((int)station_ID, pumpStationName);

            // Reset the text in the status box
            statusText.Text = String.Empty;

            // Disable the task button until the asynchronous operation is done
            this.buttonGetCycleDataFromNeptune.Enabled = false;
            // Enable the cancel button while the asynchronous operation runs
            this.buttonCancelGCDFN.Enabled = true;
            // Enable the progress bar
            this.pbarGCDFN.Visible = true;
            // Reset the variable for percentage tracking
            highestPercentageCompleted = 0;
            // start the asynchronous operation
            bwGCDFN.RunWorkerAsync(psParameters);
        }

        private void bwGCDFN_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            BackgroundWorker worker = sender as BackgroundWorker;

            // Extract the PS parameters from the argument. 
            PumpStationParameters psParameters = e.Argument as PumpStationParameters;

            //// Ask for start & stop times
            DateTime startDate = Convert.ToDateTime(Microsoft.VisualBasic.Interaction.InputBox("Start Date (MM/DD/YYYY):", "Cycle Data Translation", "", -1, -1));
            DateTime endDate = Convert.ToDateTime(Microsoft.VisualBasic.Interaction.InputBox("End Date (MM/DD/YYYY):", "Cycle Data Translation", "", -1, -1));

            // Create the query for NEPTUNE
            var query = from cycleRecord in neptuneDC.CYCLE_DATAs
                        where cycleRecord.station_id == psParameters.StationID && cycleRecord.cycle_change_time >= startDate && cycleRecord.cycle_change_time <= endDate
                        orderby cycleRecord.cycle_change_time, cycleRecord.pump_id
                        select cycleRecord;

            // Set the counter to report progress
            int numberOfRecords = query.Count();
            int index = 0;

            // Start reading & writing
            foreach (var cycleRecord in query)
            {
                // Create the new record
                // Convert.ToBoolean -> true if value is not zero; otherwise, false.
                // Other data just needs to go from 'int' to 'short'
                PS_RawCycleData_Neptune newRecord = new PS_RawCycleData_Neptune
                {
                    Location = psParameters.Location,
                    station_id = (short)psParameters.StationID,
                    pump_id = (short)cycleRecord.pump_id,
                    cycle_change_time = cycleRecord.cycle_change_time,
                    onoff_state = Convert.ToBoolean(cycleRecord.onoff_state),
                    record_status = 'o'
                };
                // Add it to Sandbox
                sandboxDC.PS_RawCycleData_Neptunes.InsertOnSubmit(newRecord);

                // Submit the change to the database
                try
                {
                    sandboxDC.SubmitChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                // Increment the counter
                index++;

                // Report progress as a percentage of the total task
                int percentComplete = (int)((float)index / (float)numberOfRecords * 100);
                if (percentComplete > highestPercentageCompleted)
                {
                    highestPercentageCompleted = percentComplete;
                    worker.ReportProgress(percentComplete);
                }
            }


            //// ##########
            //// Going to skip the FileDialog b/c it throws an exception re: threading
            //// This should be a standard workspace that I can hard-code into the program
            //// and I really shouldn't be giving users an option to select a different workspace
            //// ##########
            //string workspace = @"\\besfile1\ASM_Projects\9ESEN0000070_PSSP\Scripts\FME\PINTO\PINTO Get Cycle Data From Neptune.fmw";
            ////// ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            ////// Get Cycle Data from NEPTUNE
            ////OpenFileDialog fileDialog = new OpenFileDialog();
            ////fileDialog.Filter = "FME Workspaces (*.fmw)|*.fmw";
            ////fileDialog.Title = "Select Workspace";
            ////fileDialog.InitialDirectory = @"\\besfile1\ASM_Projects\9ESEN0000070_PSSP\Scripts\FME\PINTO";

            ////String workspace = "";
            ////if (fileDialog.ShowDialog() == DialogResult.OK)
            ////{
            ////    workspace = fileDialog.FileName;
            ////}

            ////fileDialog.Dispose();
            ////fileDialog = null;

            //fmeLogFile_.LogMessageString("Workspace selected: " + workspace, FMEOMessageLevel.Inform);

            //try
            //{
            //    RunFMEWorkspaceWithParams(workspace, thisStationID);
            //}
            //catch (FMEOException ex)
            //{
            //    // Log errors to log file
            //    fmeLogFile_.LogMessageString(ex.FmeErrorMessage, FMEOMessageLevel.Error);
            //    fmeLogFile_.LogMessageString(ex.FmeStackTrace, FMEOMessageLevel.Error);
            //    fmeLogFile_.LogMessageString(ex.FmeErrorNumber.ToString(), FMEOMessageLevel.Error);
            //}
            //// Report the progress as done
            //worker.ReportProgress(100);
        }

        private void bwGCDFN_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbarGCDFN.Value = e.ProgressPercentage;
        }

        private void bwGCDFN_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown.
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                // Next, handle the case where the user canceled the operation. 
                // Note that due to a race condition in the DoWork event handler, 
                // the Cancelled flag may not have been set, even though 
                // CancelAsync was called.
                UpdateStatusText("Get Cycle Data from NEPTUNE Cancelled..........");

            }
            else
            {
                // Finally, handle the case where the operation succeeded.
                UpdateStatusText("Finished Getting Cycle Data From NEPTUNE..........");

            }

            // Enable the Start button
            this.buttonGetCycleDataFromNeptune.Enabled = true;

            // Disable the stop button
            this.buttonCancelGCDFN.Enabled = false;

            // hide the progress bar
            this.pbarGCDFN.Visible = false;
        }

        private void RunFMEWorkspaceWithParams(string workspace, int stationID)
        {
            //IFMEOWorkspaceRunner runner = fmeSession_.CreateWorkspaceRunner();

            //// Retrieve the names of all the published parameters 
            //StringCollection paramNames = new StringCollection();

            //runner.GetPublishedParamNames(workspace, paramNames);

            //int numParams = paramNames.Count;
            //bool[] optional = new bool[numParams];
            //string[] paramType = new string[numParams];
            //string[] paramValues = new string[numParams];
            //string[] paramLabel = new string[numParams];
            //string[] paramValue = new string[numParams];

            //// Using the parameter names, we'll prompt for values.
            //for (int i = 0; i < paramNames.Count; i++)
            //{
            //    paramLabel[i] = runner.GetParamLabel(workspace, paramNames[i]);
            //    fmeLogFile_.LogMessageString("Parameter name " + i.ToString() + ": " + paramNames[i], FMEOMessageLevel.Inform);

            //    // Gather information about the workspace
            //    optional[i] = runner.GetParamOptional(workspace, paramNames[i]);
            //    paramType[i] = runner.GetParamType(workspace, paramNames[i]);
            //    paramValues[i] = runner.GetParamValues(workspace, paramNames[i]);

            //    fmeLogFile_.LogMessageString("Parameter Label: " + paramLabel[i], FMEOMessageLevel.Inform);
            //    fmeLogFile_.LogMessageString("Parameter Optional: " + optional[i].ToString(), FMEOMessageLevel.Inform);
            //    fmeLogFile_.LogMessageString("Parameter Type: " + paramType[i], FMEOMessageLevel.Inform);
            //    fmeLogFile_.LogMessageString("Possible parameter values: " + paramValues[i], FMEOMessageLevel.Inform);

            //    // If the workspace is not optional, prompt for the value
            //    // For now, jsut get the parameter value through a simple text dialog
            //    // (Not 100% sure what to do about dates and Choice With Alias yet
            //    // Should probably configure FME to handle this by using simple parameters)
            //    // IF...it is asking for somethign like the Station ID or Location, we have that already 
            //    // with the passed parameter (stationID).  Catch that and use it instead of asking
            //    // for it again via the InputBox
            //    if (paramLabel[i].Contains("location") || paramLabel[i].Contains("station") || paramLabel[i].Contains("ID"))
            //    {
            //        paramValue[i] = stationID.ToString();
            //    }
            //    else
            //    {
            //        paramValue[i] = Microsoft.VisualBasic.Interaction.InputBox(paramLabel[i], "FME Translation", "", -1, -1);
            //    }

            //    fmeLogFile_.LogMessageString("Parameter Value: " + paramValue[i], FMEOMessageLevel.Inform);
            //} // END getting parameters

            //// First build the parameters into name/value pairs
            //StringCollection parameters = new StringCollection();
            //for (int i = 0; i < numParams; i++)
            //{
            //    if (!optional[i])
            //    {
            //        parameters.Add(paramNames[i]);
            //        parameters.Add(paramValue[i]);
            //    }
            //}

            //// Run the workspace with the parameters we've gathered
            //bool success = runner.RunWithParameters(workspace, parameters);
            //runner.Dispose();

            //if (success)
            //{
            //    MessageBox.Show("The workspace was run successfully, check the log file for details.",
            //                    "FME Run Workspace",
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Information);
            //    fmeLogFile_.LogMessageString("The workspace was run successfully", FMEOMessageLevel.Inform);
            //}
            //else
            //{
            //    MessageBox.Show("The workspace run failed, check the log file for details.",
            //                    "FME Run Workspace",
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Error);
            //    fmeLogFile_.LogMessageString("The workspace run failed", FMEOMessageLevel.Error);
            //}

        }

        private void buttonCancelGCDFN_Click(object sender, EventArgs e)
        {
            // Cancel the asynchronous operation.
            this.bwGCDFN.CancelAsync();
            // Disable the Cancel button
            buttonCancelGCDFN.Enabled = false;
            // Enable the Processing Button
            buttonGetCycleDataFromNeptune.Enabled = true;
            // Hide the progress bar
            pbarGCDFN.Visible = false;
        }
        #endregion

        #region #3 Calculate Pump and Drain Times
        private void buttonCalculatePumpAndDrainTimes_Click(object sender, EventArgs e)
        {
            int? station_ID = null;

            //string thisPumpStation;

            // Check to see if anything was selected.
            // ToString() gets grumpy if it is empty
            if (cboPumpStationList.SelectedIndex > -1)
            {
                station_ID = (int)cboPumpStationList.SelectedValue;
                //station_ID = Convert.ToInt16(cboPumpStationList.SelectedItem.ToString());
                //thisPumpStation = cboPumpStationList.SelectedItem.ToString();

                if(station_ID == null)
                {
                    MessageBox.Show("No Location Selected");
                    return;
                }
                //if (string.IsNullOrEmpty(thisPumpStation))
                //{
                //    MessageBox.Show("No Location Selected");
                //    return;
                //}
            }
            else
            {
                return;
            }

            // Reset the text in the status box
            statusText.Text = String.Empty;

            // Disable the task button until the asynchronous operation is done
            this.buttonCalculatePumpAndDrainTimes.Enabled = false;
            // Enable the cancel button while the asynchronous operation runs
            this.buttonCancelPADT.Enabled = true;
            // Enable the progress bar
            this.pbarPADT.Visible = true;
            // Reset the variable for percentage tracking
            highestPercentageCompleted = 0;
            // start the asynchronous operation
            bwPADT.RunWorkerAsync(station_ID);
        }

        private void buttonCancelPADT_Click(object sender, EventArgs e)
        {
            // Cancel the asynchronous operation.
            this.bwPADT.CancelAsync();
            // Disable the Cancel button
            buttonCancelPADT.Enabled = false;
            // Enable the Processing Button
            buttonCalculatePumpAndDrainTimes.Enabled = true;
            // Hide the progress bar
            pbarPADT.Visible = false;
        }

        private void bwPADT_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            BackgroundWorker worker = sender as BackgroundWorker;

            // Extract the location from the argument. 
            int thisStationID = (int)e.Argument;

            //// Not going to deal with the log right now
            //// Set up the StreamWriter to log the process
            //string dateStamp = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString();
            //string logFileName = @"C:\Logs\StageStorage_" + dateStamp + ".txt";
            //StreamWriter sw = new StreamWriter(logFileName);

            // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            // Calculate Cycle Times (pumpdown & fill)

            // Get all cycle data records ("cycleRecord" ) from the DB
            var query = from cdr in sandboxDC.PS_RawCycleData_Neptunes
                        where cdr.station_id == thisStationID && cdr.record_status != 'd'
                        orderby cdr.cycle_change_time, cdr.pump_id
                        select cdr;

            // Get the smallest (oldest) cycle_change_time
            var PrevCycleTime = query.Min(cdr => cdr.cycle_change_time);

            // Store the Ticks here
            long delta_T;

            // Pumping state variables
            bool prevPumpState = false;
            long pumpTicks;
            long fillTicks;

            // Set up the index & # of records to process for the ProgressBar
            int index = 0;
            numberOfRecords = query.Count();

            // Loop through all records
            foreach (var cdr in query)
            {
                // Always check to see if Cancel was hit
                if(worker.CancellationPending==true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    // This is the real work

                    // Determine the delta_T between cycle records
                    // Using Ticks because I'm not sure if a cycle could span > 24h.  Otherwise I'd use Time.
                    // A single tick represents one hundred nanoseconds or one ten-millionth of a second. 
                    // There are 10,000 ticks in a millisecond, or 10 million ticks in a second.
                    delta_T = cdr.cycle_change_time.Subtract(PrevCycleTime).Ticks;

                    if (delta_T == 0)
                    {
                        delta_T = 0;
                    }

                    // Reset the pump/fill values
                    pumpTicks = 0;
                    fillTicks = 0;

                    // Define the pumping state characteristics
                    if (prevPumpState && !cdr.onoff_state)
                    {
                        // Finished pumping down
                        pumpTicks = delta_T;
                    }
                    else if (!prevPumpState && cdr.onoff_state)
                    {
                        // Finished filling wetwell
                        fillTicks = delta_T;
                    }
                    else if (prevPumpState == cdr.onoff_state)
                    {
                        // Error somewhere.  Duplicate pump states
                        // Record nothing.  It will be addressed in one of the next phases
                    }
                    else
                    {
                        // I don't know.  We shouldn't get here
                    }

                    // Write the times to the table
                    // Get the current record so it can be updated
                    //PS_RawCycleData_Neptune thisRecord = (from r in sandboxDC.PS_RawCycleData_Neptunes
                    //                                      where r.station_id == cdr.station_id
                    //                                      && r.pump_id == cdr.pump_id
                    //                                      && r.cycle_change_time == cdr.cycle_change_time
                    //                                      && r.delta_t == null
                    //                                      && r.record_status != 'd'
                    //                                      select r).SingleOrDefault();
                    PS_RawCycleData_Neptune thisRecord = (from r in sandboxDC.PS_RawCycleData_Neptunes
                                                          where r.station_id == cdr.station_id
                                                          && r.pump_id == cdr.pump_id
                                                          && r.cycle_change_time == cdr.cycle_change_time
                                                          && r.record_status != 'd'
                                                          select r).SingleOrDefault();

                    // Update values
                    thisRecord.delta_t = delta_T;
                    thisRecord.fillTime = fillTicks;
                    thisRecord.pumpTime = pumpTicks;

                    sandboxDC.SubmitChanges();

                    // Prep for the next loop
                    // Make the current timestamp the previous one for the next record.
                    PrevCycleTime = cdr.cycle_change_time;
                    // When finished, update the PumpState value
                    prevPumpState = cdr.onoff_state;

                    index++;

                    // Report progress as a percentage of the total task
                    int percentComplete = (int)((float)index / (float)numberOfRecords * 100);
                    if (percentComplete > highestPercentageCompleted)
                    {
                        highestPercentageCompleted = percentComplete;
                        worker.ReportProgress(percentComplete);
                    }

                } // end else
            } // end foreach (var cycleRecord in query)
        } // end bwPADT_DoWork

        private void bwPADT_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbarPADT.Value = e.ProgressPercentage;
        }

        private void bwPADT_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown.
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                // Next, handle the case where the user canceled the operation. 
                // Note that due to a race condition in the DoWork event handler, 
                // the Cancelled flag may not have been set, even though 
                // CancelAsync was called.
                UpdateStatusText("Calculate Pump and Drain Times Cancelled..........");

            }
            else
            {
                // Finally, handle the case where the operation succeeded.
                UpdateStatusText("Calculate Pump and Drain Times Finished..........");

            }

            // Enable the Start button
            this.buttonCalculatePumpAndDrainTimes.Enabled = true;

            // Disable the stop button
            this.buttonCancelPADT.Enabled = false;

            // hide the progress bar
            this.pbarPADT.Visible = false;
        }
        #endregion

        #region #5 Cycle Data Scrubbing
        private void buttonCycleDataScrubbing_Click(object sender, EventArgs e)
        {
            int? station_ID = null;
            string pumpStationName = "";

            // Check to see if anything was selected.
            // ToString() gets grumpy if it is empty
            if (cboPumpStationList.SelectedIndex > -1)
            {
                station_ID = (int)cboPumpStationList.SelectedValue;
                string selectedPumpStationName = cboPumpStationList.SelectedItem.ToString();
                pumpStationName = selectedPumpStationName.Substring(selectedPumpStationName.IndexOf("= ") + 2, selectedPumpStationName.IndexOf("  ") - selectedPumpStationName.IndexOf("= ") - 2);

                if (station_ID == null)
                {
                    MessageBox.Show("No Location Selected");
                    return;
                }
            }
            else
            {
                return;
            }

            // Ask user for 
            string minimumPumpTime = Microsoft.VisualBasic.Interaction.InputBox("Minimum Pumpdown Time (hh:mm:ss)", "Pump Station Parameter", "00:00:00", -1, -1);
            string minimumFillTime = Microsoft.VisualBasic.Interaction.InputBox("Minimum Wetwell Fill Time (hh:mm:ss)", "Pump Station Parameter", "00:00:00", -1, -1);

            // Create the Parameters Class to pass over to the BackgroundWorker
            PumpStationParameters psParameters = new PumpStationParameters((int)station_ID, pumpStationName, minimumPumpTime, minimumFillTime);

            // Disable the task button until the asynchronous operation is done
            this.buttonCycleDataScrubbing.Enabled = false;
            // Enable the cancel button while the asynchronous operation runs
            this.buttonCancelTCD.Enabled = true;
            // Enable the progress bar
            this.pbarTCD.Visible = true;
            // Reset the variable for percentage tracking
            highestPercentageCompleted = 0;
            // start the asynchronous operation
            bwTCD.RunWorkerAsync(psParameters);
        }

        private void buttonCancelTCD_Click(object sender, EventArgs e)
        {
            // Cancel the asynchronous operation.
            this.bwTCD.CancelAsync();
            // Disable the Cancel button
            buttonCancelTCD.Enabled = false;
            // Enable the Processing Button
            buttonCycleDataScrubbing.Enabled = true;
            // Hide the progress bar
            pbarTCD.Visible = false;
        }

        private void bwTCD_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            BackgroundWorker worker = sender as BackgroundWorker;

            // extract the station information from the 
            PumpStationParameters psParameters = e.Argument as PumpStationParameters;
            int stationID = psParameters.StationID;
            string location = psParameters.Location;
            long minimumPumpTime = psParameters.MinimumPumpTime();
            long minimumFillTime = psParameters.MinimumFillTime();

            Debug.WriteLine(System.DateTime.Now, "     Start query");

            // Create the query to retrieve all the cycle records
            var cycleRecords = from cycleRecord in sandboxDC.PS_RawCycleData_Neptunes.AsParallel()
                               where cycleRecord.station_id == stationID
                               && cycleRecord.record_status != 'd'
                               orderby cycleRecord.cycle_change_time
                               select new
                               {
                                   cycleRecord.station_id,
                                   cycleRecord.pump_id,
                                   cycleRecord.cycle_change_time,
                                   cycleRecord.onoff_state,
                                   cycleRecord.delta_t,
                                   cycleRecord.pumpTime,
                                   cycleRecord.fillTime
                               };

            Debug.WriteLine(System.DateTime.Now, "     End query");

            // Get the # of records. primarily for progress status reporting
            int numberOfRecords = cycleRecords.Count();
            int index = 0;
 
            // Variables for the QA process
            long previousFillTime = 0;
            int duplicateCycleCounter = 0;
            int addOnCycleCounter = 0;
            int addOffCycleCounter = 0;
            int deletePreviousCycleCounter = 0;
            int multiPumpCounter = 0;

            CycleRecord thisCycleRecord;
            CycleRecord previousCycleRecord = new CycleRecord();
            CycleRecord thirdbackCycleRecord = new CycleRecord();
            CycleRecord fourthbackCycleRecord = new CycleRecord();

            Debug.WriteLine(System.DateTime.Now, "     Start Loop");
            // Begin doing work
            foreach (var cycleRecord in cycleRecords)
            {
                // Create CycleRecord class
                thisCycleRecord = new CycleRecord( cycleRecord.station_id,
                                                   cycleRecord.pump_id,
                                                   cycleRecord.cycle_change_time,
                                                   cycleRecord.onoff_state,
                                                   (long)cycleRecord.delta_t,
                                                   (long)cycleRecord.pumpTime,
                                                   (long)cycleRecord.fillTime);


                // Reset Values
                thisCycleRecord.DuplicateCycle = false;
                thisCycleRecord.AddOnCycle = false;
                thisCycleRecord.AddOffCycle = false;
                thisCycleRecord.ShortCycle = false;
                thisCycleRecord.DeletePrevCycle = false;

                // ---------------------------------------------------------------------------------------
                // Duplicate Cycle Test
                if (previousCycleRecord.Station_ID != 0 && thisCycleRecord.OnOff_State == previousCycleRecord.OnOff_State)
                {
                    // The OnOff state of this record == the previous record.  Something is probably wrong or it's in multi
                    thisCycleRecord.DuplicateCycle = true;
                    duplicateCycleCounter++;
                }

                Debug.WriteLine(System.DateTime.Now + "     "+ index+ ": Duplicate Cycle Test done");

                // ---------------------------------------------------------------------------------------
                // Add ON Cycle Test
                // 2 'OFF' cycles were detected in a row so an 'ON' record needs to be added *before* this one
                // LOGIC
                // 1. Duplicate Cycle = True
                // 2. Previous State = Current State = False
                // 3. Currently OFF (not pumping)
                // 4. DeltaT is > than 2x the minimum pump time (Only add if there is enough time between the 2 'OFF' records.)
                // 5. Currently not in MultiPump
                if (thisCycleRecord.DuplicateCycle &&
                    !previousCycleRecord.OnOff_State &&
                    !thisCycleRecord.OnOff_State &&
                    thisCycleRecord.DeltaT > (2 * minimumPumpTime) &&
                    !thisCycleRecord.MultiPump)
                {
                    thisCycleRecord.AddOnCycle = true;
                    addOnCycleCounter++;
                }

                Debug.WriteLine(System.DateTime.Now + "     " + index + ": Add ON Cycle Test done");

                // ---------------------------------------------------------------------------------------
                // Add OFF Cycle Test
                // 2 "ON" cycles were detected in a row so an "OFF" records needs to be added between them (space pending)
                // LOGIC
                // 1. Duplicate Cycle = True
                // 2. Previous State = Current State = TRUE
                // 3. Currently ON (pumping)
                // 4. DeltaT is > than the minimum full cycle (pump + fill) time (Only add if there is enough time between the 2 'ON' records.)
                // 5. Currently not in MultiPump
                if (thisCycleRecord.DuplicateCycle &&
                    previousCycleRecord.OnOff_State &&
                    thisCycleRecord.OnOff_State &&
                    thisCycleRecord.DeltaT > (minimumPumpTime + minimumFillTime) &&
                    !thisCycleRecord.MultiPump)
                {
                    thisCycleRecord.AddOffCycle = true;
                    addOffCycleCounter++;
                }

                Debug.WriteLine(System.DateTime.Now + "     " + index + ": Add OFF Cycle Test done");

                // ---------------------------------------------------------------------------------------
                // Delete Previous Cycle
                // Uncommon
                // This occurs when there are 2 ON records that are too close to one another.
                // It isn't likely, or possible, to fit an OFF record between the 2.
                // Delete the first instance.
                // Invalid if station is in Multi.  That must be handled differently.
                if (!thisCycleRecord.MultiPump &&
                    thisCycleRecord.DuplicateCycle &&
                    previousCycleRecord.OnOff_State &&
                    thisCycleRecord.OnOff_State &&
                    thisCycleRecord.DeltaT <= (minimumPumpTime + minimumFillTime))
                {
                    thisCycleRecord.DeletePrevCycle = true;
                    deletePreviousCycleCounter++;
                }

                Debug.WriteLine(System.DateTime.Now + "     " + index + ": Delete Previous Cycle done");

                // ---------------------------------------------------------------------------------------
                // Add Multi-Pump Test
                // We are NOT testing to see if this is a valid multi-pump.
                // Just whether or not the station has >1 pump running at once.
                // Search for this instance
                // current ##/##/## ##:##:## ON
                // 2nd     ##/##/## ##:##:## ON
                // 3rd     ##/##/## ##:##:## OFF
                // 4th     ##/##/## ##:##:## OFF
                // LOGIC
                // 1. current cycle state must be the same as 2nd (1 pump turning on and then a second coming on)
                // 2. The FOLLOWING 2 cycles (3rd & 4th) must be the same (1 pump turning off and then the second)
                // 3. The 2nd & 3rd cycle records must be opposite.
                // 4. Current cycle must be ON (this eliminates flagging an OFF-OFF-ON-ON pattern which is rare but happens)
                // Looking for this pattern:
                // thisCycleRecord.OnOff_State      OFF
                // previousCycleRecord.OnOff_State  OFF
                // secondOnOffState                 ON
                // firstOnOffState                  ON
                if (!thisCycleRecord.OnOff_State &&
                    !previousCycleRecord.OnOff_State &&
                    thirdbackCycleRecord.OnOff_State &&
                    fourthbackCycleRecord.OnOff_State)
                {
                    // Set MultiPump to True & DuplicateCycle to False
                    thisCycleRecord.MultiPump = true;
                    thisCycleRecord.DuplicateCycle = false;
                    // Mark previous cycle as Multi & IsDirty so it gets updated
                    previousCycleRecord.MultiPump = true;
                    previousCycleRecord.IsDirty = true;
                    // 3rd Back will be flagged as a Duplicate and will have an AddOffCycle between the 1-1 values
                    // Reset these values & flag Multi only
                    thirdbackCycleRecord.MultiPump = true;
                    thirdbackCycleRecord.DuplicateCycle = false;
                    thirdbackCycleRecord.AddOffCycle = false;
                    thirdbackCycleRecord.AddOnCycle = false;
                    thirdbackCycleRecord.IsDirty = true;
                    // Mark 4th Back cycle as Multi & IsDirty so it gets updated
                    fourthbackCycleRecord.MultiPump = true;
                    fourthbackCycleRecord.IsDirty = true;

                    multiPumpCounter++;
                }

                // ---------------------------------------------------------------------------------------
                // Short Pump Cycle
                // Testing for cycle pairs where the PS pumps down the wetwell faster than 
                // what is operationally possible
                // e.g. A 100 gpm pump shouldn't empty a 100 gal wetwell in less than a minute
                // LOGIC:
                // 1. Not in multiPump (a clusterfudge situation)
                // 2. thisOnOffState != nextOnOffState (catches a future duplicate cycle)
                // 3. Not currently a duplicate cycle
                // AND
                // 4a. Pump turned off AND current pumpTime is less than minimum allowable
                // OR
                // 4b. Pump turned on AND next record pumpTime is less than minimum allowable
                if(!thisCycleRecord.MultiPump &&
                    thisCycleRecord.OnOff_State !=previousCycleRecord.OnOff_State &&
                    !thisCycleRecord.DuplicateCycle &&
                    (!thisCycleRecord.OnOff_State && thisCycleRecord.RunTime < minimumPumpTime)
                  )
                {
                    thisCycleRecord.ShortCycle = true;
                    previousCycleRecord.ShortCycle = true;
                    previousCycleRecord.IsDirty = true;
                }

                Debug.WriteLine(System.DateTime.Now + "     " + index + ": Short Cycle done");

                //    // Short Fill Cycle
                //    // Testing for cycle pairs where the Wetwell fills faster than what is reasonable
                //    // Slightly more subjective than the Short Pump Cycle.
                //    // LOGIC:
                //    // 1-3, same as Short Pump
                //    // 4a. Pump turned on AND current fillTime < minimumFillTIme
                //    // OR
                //    // 4b. Pump turned off AND previous fillTime < minimumFillTime AND previous fillTime <> 0
                //    // This catches previous cycles that may have issues, e.g. duplicate or needs an off cycle
                //    //if (!multiPump &&
                //    //    cycleRecord.onoff_state != secondCycle.onoff_state &&
                //    //    !duplicateCycle &&
                //    //        (
                //    //            (cycleRecord.onoff_state && cycleRecord.fillTime < minimumFillTime)
                //    //            ||
                //    //            (!cycleRecord.onoff_state && 0 < previousFillTime && previousFillTime < minimumFillTime)
                //    //        )
                //    //    )
                //    //{
                //    //    shortPumpCycle = true;
                //    //    shortPumpCounter++;
                //    //}

                SaveCycleRecord(thisCycleRecord);
                if (previousCycleRecord.IsDirty)
                    SaveCycleRecord(previousCycleRecord);
                if (thirdbackCycleRecord.IsDirty)
                    SaveCycleRecord(thirdbackCycleRecord);
                if (fourthbackCycleRecord.IsDirty)
                    SaveCycleRecord(fourthbackCycleRecord);

                Debug.WriteLine(System.DateTime.Now + "     " + index + ": Updating values done");

                // ---------------------------------------------------------------------------------------
                // Housekeeping Stuff
                index++;
                fourthbackCycleRecord = thirdbackCycleRecord;
                fourthbackCycleRecord.IsDirty = false;
                thirdbackCycleRecord = previousCycleRecord;
                thirdbackCycleRecord.IsDirty = false;
                previousCycleRecord = thisCycleRecord;
                previousCycleRecord.IsDirty = false;

                previousFillTime = (long)cycleRecord.fillTime;

                // Report progress as a percentage of the total task
                int percentComplete = (int)((float)index / (float)numberOfRecords * 100);

                Debug.WriteLine(System.DateTime.Now + "     " + percentComplete + "% done");

                if (percentComplete > highestPercentageCompleted)
                {
                    highestPercentageCompleted = percentComplete;
                    worker.ReportProgress(percentComplete);
                }

            }

        }

        private void SaveCycleRecord(CycleRecord aCycleRecord)
        {
            // Find/retrieve the current record so it can be updated
            PS_RawCycleData_Neptune thisRecord = (from cycles
                                                  in sandboxDC.PS_RawCycleData_Neptunes
                                                  where cycles.station_id == aCycleRecord.Station_ID
                                                  && cycles.pump_id == aCycleRecord.Pump_ID
                                                  && cycles.cycle_change_time == aCycleRecord.CycleChangeTime
                                                  select cycles).SingleOrDefault();
            // ---------------------------------------------------------------------------------------
            // Update values
            thisRecord.DuplicateCycle = aCycleRecord.DuplicateCycle;
            thisRecord.AddOnCycle = aCycleRecord.AddOnCycle;
            thisRecord.AddOffCycle = aCycleRecord.AddOffCycle;
            thisRecord.DeletePrevCycle = aCycleRecord.DeletePrevCycle;
            thisRecord.multiPump = aCycleRecord.MultiPump;
            thisRecord.shortCycle = aCycleRecord.ShortCycle;

            sandboxDC.SubmitChanges();
        }

        private void bwTCD_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbarTCD.Value = e.ProgressPercentage;
        }

        private void bwTCD_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown.
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                // Next, handle the case where the user canceled the operation. 
                // Note that due to a race condition in the DoWork event handler, 
                // the Cancelled flag may not have been set, even though 
                // CancelAsync was called.
                UpdateStatusText("Cycle Data Scrubbing Cancelled..........");

            }
            else
            {
                // Finally, handle the case where the operation succeeded.
                UpdateStatusText("Cycle Data Scrubbing From NEPTUNE..........");
            }

            // Enable the Start button
            this.buttonCycleDataScrubbing.Enabled = true;

            // Disable the stop button
            this.buttonCancelTCD.Enabled = false;

            // hide the progress bar
            this.pbarTCD.Visible = false;
        }
        #endregion

        #region #7 Fix Cycle Records
        private void buttonFixCycleRecords_Click(object sender, EventArgs e)
        {
            int? station_ID = null;
            string pumpStationName = "";

            // Check to see if anything was selected.
            // ToString() gets grumpy if it is empty
            if (cboPumpStationList.SelectedIndex > -1)
            {
                station_ID = (int)cboPumpStationList.SelectedValue;
                string selectedPumpStationName = cboPumpStationList.SelectedItem.ToString();
                pumpStationName = selectedPumpStationName.Substring(selectedPumpStationName.IndexOf("= ") + 2, selectedPumpStationName.IndexOf("  ") - selectedPumpStationName.IndexOf("= ") - 2);

                if (station_ID == null)
                {
                    MessageBox.Show("No Location Selected");
                    return;
                }
            }
            else
            {
                return;
            }

            // Create the Parameters Class to pass over to the BackgroundWorker
            PumpStationParameters psParameters = new PumpStationParameters((int)station_ID, pumpStationName);

            // Disable the task button until the asynchronous operation is done
            this.buttonFixCycleRecords.Enabled = false;
            // Enable the cancel button while the asynchronous operation runs
            this.buttonCancelFCR.Enabled = true;
            // Enable the progress bar
            this.pBarFCR.Visible = true;
            // Reset the variable for percentage tracking
            highestPercentageCompleted = 0;
            // start the asynchronous operation
            bwFCR.RunWorkerAsync(psParameters);
        }

        private void buttonCancelFCR_Click(object sender, EventArgs e)
        {
            // Cancel the asynchronous operation.
            this.bwFCR.CancelAsync();
            // Disable the Cancel button
            buttonCancelFCR.Enabled = false;
            // Enable the Processing Button
            buttonFixCycleRecords.Enabled = true;
            // Hide the progress bar
            pBarFCR.Visible = false;
        }

        private void bwFCR_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            BackgroundWorker worker = sender as BackgroundWorker;

            // extract the station information from the 
            PumpStationParameters psParameters = e.Argument as PumpStationParameters;
            int stationID = psParameters.StationID;
            string location = psParameters.Location;

            // Create the query to retrieve all valid cycle records
            var cycleRecords = from cycleRecord in sandboxDC.PS_RawCycleData_Neptunes
                               where cycleRecord.station_id == stationID
                               && cycleRecord.record_status != 'd'
                               orderby cycleRecord.cycle_change_time
                               select cycleRecord;

            // Get the # of records. primarily for progress status reporting
            int numberOfRecords = cycleRecords.Count();
            int index = 0;

            long pumpTicks = 0;

            string previousLocation = null;
            short previousStationID = 0;
            short previousPumpID = 0;
            DateTime previousCycleChangeTime = System.DateTime.Now;
            bool previousOnOffState = false;

            foreach (var cycleRecord in cycleRecords)
            {
                // pumpTicks will store the most recent valid pump time 
                // It can/will be used to create records where one is needed.
                if (cycleRecord.pumpTime != 0)
                {
                    // Any Nullable<T> is implicitly convertible to its T, 
                    // PROVIDED that the entire expression being evaluated can never result in a null assignment to a ValueType. 
                    // It returns the left-hand operand if the operand is not null; otherwise it returns the right hand operand.
                    // If pumpTime is NULL, then default(long) will be returned.
                    pumpTicks = cycleRecord.pumpTime ?? default(long);
                }

                // ADD OFF RECORD
                // ============================================================================================================
                // Need to add an OFF record *before* this one to turn the previous pump OFF
                if (cycleRecord.AddOffCycle == true)
                {
                    // See if a record does not already exist here.  Trust...but verify
                    if (sandboxDC.PS_RawCycleData_Neptunes.Count
                        (c => c.station_id == cycleRecord.station_id &&
                            c.pump_id == cycleRecord.pump_id &&
                            c.cycle_change_time == (previousCycleChangeTime.AddTicks(pumpTicks)))
                        == 0)
                    {
                        // Create a new record
                        PS_RawCycleData_Neptune insertedRecord = new PS_RawCycleData_Neptune();
                        // Update attributes
                        insertedRecord.Location = previousLocation;
                        insertedRecord.station_id = previousStationID;
                        insertedRecord.pump_id = previousPumpID;
                        // pumpTicks is positive so we're adding time/ticks
                        insertedRecord.cycle_change_time = previousCycleChangeTime.AddTicks(pumpTicks);
                        // Flip the current OnOffstate
                        insertedRecord.onoff_state = !previousOnOffState;
                        insertedRecord.record_status = 'A';
                        insertedRecord.AddOffCycle = false;
                        insertedRecord.AddOnCycle = false;
                        insertedRecord.DeletePrevCycle = false;
                        insertedRecord.DuplicateCycle = false;
                        insertedRecord.multiPump = false;
                        insertedRecord.shortCycle = false;
                        // Commit the changes
                        sandboxDC.PS_RawCycleData_Neptunes.InsertOnSubmit(insertedRecord);
                        sandboxDC.SubmitChanges();
                    }
                } // true

                // ADD ON RECORD
                // ============================================================================================================
                // Need to add an ON record *before* this one to turn this pump ON
                // Use -pumpTicks
                else if (cycleRecord.AddOnCycle == true)
                {
                    // See if a record does not already exist here.  Trust...but verify
                    // Same query as above but pumpTicks is negative to go backward
                    if (sandboxDC.PS_RawCycleData_Neptunes.Count
                        (c => c.station_id == cycleRecord.station_id &&
                            c.pump_id == cycleRecord.pump_id &&
                            c.cycle_change_time == (cycleRecord.cycle_change_time.AddTicks(-pumpTicks)))
                        == 0)
                    {
                        // Create a new record
                        PS_RawCycleData_Neptune insertedRecord = new PS_RawCycleData_Neptune();
                        // Update attributes
                        insertedRecord.Location = cycleRecord.Location;
                        insertedRecord.station_id = cycleRecord.station_id;
                        insertedRecord.pump_id = cycleRecord.pump_id;
                        // SUBTRACT most recent valid pump time from this record
                        insertedRecord.cycle_change_time = cycleRecord.cycle_change_time.AddTicks(-pumpTicks);
                        // Flip the current OnOffstate
                        insertedRecord.onoff_state = !previousOnOffState;
                        insertedRecord.record_status = 'A';
                        insertedRecord.AddOffCycle = false;
                        insertedRecord.AddOnCycle = false;
                        insertedRecord.DeletePrevCycle = false;
                        insertedRecord.DuplicateCycle = false;
                        insertedRecord.multiPump = false;
                        insertedRecord.shortCycle = false;
                        // Commit the changes
                        sandboxDC.PS_RawCycleData_Neptunes.InsertOnSubmit(insertedRecord);
                        sandboxDC.SubmitChanges();
                    }
                }

                // REMOVE SHORT CYCLES
                // ============================================================================================================
                if (cycleRecord.shortCycle == true)
                {
                    // The test version had a "&& r.delta_t == null" statement.  I can't figure out/remember why.
                    PS_RawCycleData_Neptune badRecord = (from r in sandboxDC.PS_RawCycleData_Neptunes
                                                         where r.station_id == cycleRecord.station_id &&
                                                         r.pump_id == cycleRecord.pump_id &&
                                                         r.cycle_change_time == cycleRecord.cycle_change_time
                                                         select r).SingleOrDefault();
                    badRecord.record_status = 'd';
                    sandboxDC.SubmitChanges();
                }

                // Cycle Record tests are done.
                // Prepare to move on to next record

                // Set the PreviousRecord attributes
                previousLocation = cycleRecord.Location;
                previousStationID = cycleRecord.station_id;
                previousPumpID = cycleRecord.pump_id;
                previousCycleChangeTime = cycleRecord.cycle_change_time;
                previousOnOffState = cycleRecord.onoff_state;

                // Housekeeping
                index++;

                // Report progress as a percentage of the total task
                int percentComplete = (int)((float)index / (float)numberOfRecords * 100);
                if (percentComplete > highestPercentageCompleted)
                {
                    highestPercentageCompleted = percentComplete;
                    worker.ReportProgress(percentComplete);
                }
            } // END foreach (var cycleRecord in cycleRecords)
        }

        private void bwFCR_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pBarFCR.Value = e.ProgressPercentage;
        }

        private void bwFCR_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown.
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                // Next, handle the case where the user canceled the operation. 
                // Note that due to a race condition in the DoWork event handler, 
                // the Cancelled flag may not have been set, even though 
                // CancelAsync was called.
                UpdateStatusText("Fix Cycle Data Cancelled..........");
            }
            else
            {
                // Finally, handle the case where the operation succeeded.
                UpdateStatusText("Fix Cycle Data Finished..........");
            }

            // Enable the Start button
            this.buttonFixCycleRecords.Enabled = true;

            // Disable the stop button
            this.buttonCancelFCR.Enabled = false;

            // hide the progress bar
            this.pBarFCR.Visible = false;
        }
        #endregion

        #region #8 Calculate Flow Rates
         
        private void buttonCFR_Click(object sender, EventArgs e)
        {
            int? station_ID = null;
            string pumpStationName = "";

            // Check to see if anything was selected.
            // ToString() gets grumpy if it is empty
            if (cboPumpStationList.SelectedIndex > -1)
            {
                station_ID = (int)cboPumpStationList.SelectedValue;
                string selectedPumpStationName = cboPumpStationList.SelectedItem.ToString();
                pumpStationName = selectedPumpStationName.Substring(selectedPumpStationName.IndexOf("= ") + 2, selectedPumpStationName.IndexOf("  ") - selectedPumpStationName.IndexOf("= ") - 2);

                if (station_ID == null)
                {
                    MessageBox.Show("No Location Selected");
                    return;
                }
            }
            else
            {
                return;
            }

            // Create the Parameters Class to pass over to the BackgroundWorker
            PumpStationParameters psParameters = new PumpStationParameters((int)station_ID, pumpStationName);

            // Disable the task button until the asynchronous operation is done
            this.buttonCFR.Enabled = false;
            // Enable the cancel button while the asynchronous operation runs
            this.buttonCancelCFR.Enabled = true;
            // Enable the progress bar
            this.pbarCFR.Visible = true;
            // Reset the variable for percentage tracking
            highestPercentageCompleted = 0;
            // start the asynchronous operation
            bwCFR.RunWorkerAsync(psParameters);
        }

        private void buttonCancelCFR_Click(object sender, EventArgs e)
        {
            // Cancel the asynchronous operation.
            this.bwCFR.CancelAsync();
            // Disable the Cancel button
            buttonCancelCFR.Enabled = false;
            // Enable the Processing Button
            buttonCFR.Enabled = true;
            // Hide the progress bar
            pbarCFR.Visible = false;

        }

        private void bwCFR_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            BackgroundWorker worker = sender as BackgroundWorker;

            // extract the station information from the PS Parameters
            PumpStationParameters psParameters = e.Argument as PumpStationParameters;
            int stationID = psParameters.StationID;
            string location = psParameters.Location;

            // Housekeeping variables
            int numberOfRecords = 0;
            int index = 0;
            int percentComplete = 0;
            float previousFlowRate = 0;

            // Extract the Active WW Volume from the DB
            PS_LocationTable PumpStation = (from PumpStations in sandboxDC.PS_LocationTables
                               where PumpStations.station_id == stationID
                               select PumpStations).First();

            int activeWWVol = (int)PumpStation.ActiveWWVol_gal;

            // We can clearly only use a valid non-zero wetwell volume otherwise
            // this would be a _hitshow.
            if (activeWWVol > 0)
            {

                var OnCycleRecords = from OnCycleRecord in sandboxDC.PS_RawCycleData_Neptunes
                                     where OnCycleRecord.station_id == stationID &&
                                     OnCycleRecord.onoff_state == true &&
                                     OnCycleRecord.record_status != 'd'
                                     orderby OnCycleRecord.cycle_change_time, OnCycleRecord.pump_id
                                     select new
                                     {
                                         OnCycleRecord.station_id,
                                         OnCycleRecord.pump_id,
                                         OnCycleRecord.cycle_change_time,
                                         OnCycleRecord.onoff_state,
                                         OnCycleRecord.delta_t,
                                         OnCycleRecord.pumpTime,
                                         OnCycleRecord.fillTime
                                     };

                // Get the # of records. primarily for progress status reporting
                numberOfRecords = OnCycleRecords.Count();
                index = 0;
                float flowRate = 0;

                foreach (var OnCycleRecord in OnCycleRecords)
                {
                    // CALCULATE ON RECORDS FIRST
                    // Select records where the PS just finished filling (onoff=1) and the fillTime value is NOT 0
                    if (OnCycleRecord.onoff_state == true && OnCycleRecord.fillTime != 0)
                    {
                        // fillTIme is stored in Ticks
                        // Divide by 10 million to get seconds
                        // Then divide by 60 to get to minutes
                        flowRate = (float)(activeWWVol / ((float)OnCycleRecord.fillTime / (10000000 * 60)));

                        // Write the value back to the table
                        PS_RawCycleData_Neptune thisRecord = (from CycleRecord in sandboxDC.PS_RawCycleData_Neptunes
                                                              where CycleRecord.station_id == OnCycleRecord.station_id &&
                                                              CycleRecord.pump_id == OnCycleRecord.pump_id &&
                                                              CycleRecord.cycle_change_time == OnCycleRecord.cycle_change_time
                                                              select CycleRecord).Single();
                        // update value
                        if(double.IsInfinity(flowRate))
                        {
                            thisRecord.record_status = '?';
                            thisRecord.Flow_gpm = (float)activeWWVol;
                        }
                        else
                        {
                            thisRecord.Flow_gpm = flowRate;
                        }
                        sandboxDC.SubmitChanges();
                    }

                    previousFlowRate = flowRate;
                    index++;
                    
                    percentComplete = (int)((float)index / (float)numberOfRecords * 100);
                    // Dividing percentComplete by 2 b/c this is just the first half of the 
                    // calculation process
                    if (percentComplete/2 > highestPercentageCompleted)
                    {
                        highestPercentageCompleted = percentComplete/2;
                        worker.ReportProgress(percentComplete / 2);
                    }

                } // END foreach (var OnCycleRecord in OnCycleRecords)

                // Now get all cycle data records ("CycleRecord" ) from the DB
                var CycleRecords = from CycleRecord in sandboxDC.PS_RawCycleData_Neptunes
                                   where CycleRecord.station_id == stationID &&
                                   CycleRecord.record_status != 'd'
                                   orderby CycleRecord.cycle_change_time, CycleRecord.pump_id
                                   select new
                                   {
                                       CycleRecord.station_id,
                                       CycleRecord.pump_id,
                                       CycleRecord.cycle_change_time,
                                       CycleRecord.onoff_state,
                                       CycleRecord.delta_t,
                                       CycleRecord.pumpTime,
                                       CycleRecord.fillTime,
                                       CycleRecord.Flow_gpm
                                   };
                index = 0;
                numberOfRecords = CycleRecords.Count();
                // Set percent complete at 50% b/c we're halfway through the calculation process
                // (should be there already but do it anyway)
                highestPercentageCompleted = 50;
                float nextFlowRate = 0;
                
                foreach (var CycleRecord in CycleRecords)
                {
                    // Calculate OFF records

                    // Select records where the PS just finished filling (onoff=1) and the flowrate != 0
                    // We're just gtting the previous FlowRate to be used in the calculation of the next OFF record.
                    if (CycleRecord.onoff_state == true && CycleRecord.Flow_gpm != null)
                    { previousFlowRate = (float)CycleRecord.Flow_gpm; }

                    // Select records where the PS just finished pumping (onoff = 0)
                    if (CycleRecord.onoff_state == false)
                    {
                        
                        try
                        {
                            // Get flow info from the next record
                            var nextCycleRecord = CycleRecords.Skip(index + 1).FirstOrDefault();
                            nextFlowRate = (float)nextCycleRecord.Flow_gpm;
                        }
                        catch
                        {
                            // We're here b/c we are at the end of the recordset & cannot Skip to the next record
                            // Just set the nextFLowRate = previousFlowRate;
                            nextFlowRate = previousFlowRate;
                        }
                        // FlowRate for the short durations while the PS is pumping is 
                        // calculated as teh average of the previous and next FillTime records
                        flowRate = (previousFlowRate + nextFlowRate) / 2;

                        // Update the values
                        // Write the value back to the table
                        PS_RawCycleData_Neptune thisRecord = (from r in sandboxDC.PS_RawCycleData_Neptunes
                                                              where CycleRecord.station_id == r.station_id &&
                                                              CycleRecord.pump_id == r.pump_id &&
                                                              CycleRecord.cycle_change_time == r.cycle_change_time
                                                              select r).Single();
                        // update value
                        if (double.IsInfinity(flowRate))
                        {
                            thisRecord.record_status = '?';
                            thisRecord.Flow_gpm = (float)activeWWVol;
                        }
                        else
                        {
                            thisRecord.Flow_gpm = flowRate;
                        }
                        sandboxDC.SubmitChanges(); 
                    }
                    
                    // Housekeeping
                    index++;
                    percentComplete = (int)((float)index / (float)numberOfRecords * 100);
                    if ((percentComplete/2+50) > highestPercentageCompleted)
                    {
                        highestPercentageCompleted = (percentComplete / 2 + 50);
                        worker.ReportProgress((percentComplete / 2 + 50));
                    }

                } // END foreach (var CycleRecord in CycleRecords)   
            } // This is the exit if there is no Active WW Volume specified
        }

        private void bwCFR_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            pbarCFR.Value = e.ProgressPercentage;
        }

        private void bwCFR_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown.
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                // Next, handle the case where the user canceled the operation. 
                // Note that due to a race condition in the DoWork event handler, 
                // the Cancelled flag may not have been set, even though 
                // CancelAsync was called.
                UpdateStatusText("Calculate Flow Rates Cancelled..........");

            }
            else
            {
                // Finally, handle the case where the operation succeeded.
                UpdateStatusText("Calculate Flow Rates Completed..........");
            }

            // Enable the Start button
            this.buttonCFR.Enabled = true;

            // Disable the stop button
            this.buttonCancelCFR.Enabled = false;

            // hide the progress bar
            this.pbarCFR.Visible = false;
        }
        
        #endregion

        private void resetCycleData_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("This will reset cycle data to their original state\rDo you want to continue ??",
                                     "Confirm Reset!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                int? station_ID = null;

                // Check to see if anything was selected.
                // ToString() gets grumpy if it is empty
                if (cboPumpStationList.SelectedIndex > -1)
                {
                    station_ID = (int)cboPumpStationList.SelectedValue;

                    if (station_ID == null)
                    {
                        MessageBox.Show("No Location Selected");
                        return;
                    }
                }
                else
                {
                    return;
                }
                // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                // Delete all ADD records
                var deleteRecords = from cdr in sandboxDC.PS_RawCycleData_Neptunes
                                    where cdr.station_id == station_ID && (cdr.record_status == 'a' || cdr.record_status == 'A')
                                    orderby cdr.cycle_change_time, cdr.pump_id
                                    select cdr;
                foreach (var cycleRecord in deleteRecords)
                {
                    sandboxDC.PS_RawCycleData_Neptunes.DeleteOnSubmit(cycleRecord);
                }
                try
                {
                    sandboxDC.SubmitChanges();
                }
                catch (Exception ex)
                {
                    UpdateStatusText(ex.Message);
                }
                // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                // Revert all DELETE and UPDATE records to ORIGINAL
                var updateRecords = from cdr in sandboxDC.PS_RawCycleData_Neptunes
                                    where cdr.station_id == station_ID && (cdr.record_status == 'd' || cdr.record_status == 'u')
                                    orderby cdr.cycle_change_time, cdr.pump_id
                                    select cdr;
                foreach (var cycleRecord in updateRecords)
                {
                    cycleRecord.record_status='o';
                }
                try
                {
                    sandboxDC.SubmitChanges();
                }
                catch (Exception ex)
                {
                    UpdateStatusText(ex.Message);
                }
                // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                // Reset all QA fields
                var resetRecords = from cdr in sandboxDC.PS_RawCycleData_Neptunes
                                    where cdr.station_id == station_ID 
                                    orderby cdr.cycle_change_time, cdr.pump_id
                                    select cdr;
                foreach (var cycleRecord in resetRecords)
                {
                    cycleRecord.delta_t = 0;
                    cycleRecord.pumpTime = 0;
                    cycleRecord.fillTime = 0;
                    cycleRecord.DuplicateCycle = false;
                    cycleRecord.AddOnCycle = false;
                    cycleRecord.AddOffCycle = false;
                    cycleRecord.DeletePrevCycle = false;
                    cycleRecord.multiPump = false;
                    cycleRecord.shortCycle = false;
                    cycleRecord.Flow_gpm = 0;
                }
                try
                {
                    sandboxDC.SubmitChanges();
                }
                catch (Exception ex)
                {
                    UpdateStatusText(ex.Message);
                }
            }
            else
            {
                return;
            }

        }

    }
}
