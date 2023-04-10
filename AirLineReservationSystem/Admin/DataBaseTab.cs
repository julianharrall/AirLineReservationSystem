using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
//using Microsoft.SqlServer.Management.Common;
//using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System.Data.Linq;
using System.Data;
using System.Linq;
using AirLineReservationSystem.Admin;

namespace AirLineReservationSystem
{
    public partial class DataBaseTab : Form
    {
        AirlineReservationDAL.AirlineReservation ar;
        string ConnectionString;
        Administration adf;// To allow closure of administration form
        public Table<AirlineReservationDAL.SqlLogTable> Slt { get; set; }           
        public string backUpFile { get; set; }

        public string bakFullFilePath { get; set; }
        public DataBaseTab(Administration ad)
        {
            InitializeComponent();
            adf = ad;
            //btnRestoreDB.Enabled = false;            

            this.WindowState = FormWindowState.Maximized;     
            this.FormBorderStyle = FormBorderStyle.None;
            ar = new AirlineReservationDAL.AirlineReservation();
            Slt = ar.GetTable<AirlineReservationDAL.SqlLogTable>();
            ConnectionString = ar.Connection.ConnectionString.ToString();  
            CreateMyBorderlessWindow();
            //btnBrowseRD.Enabled = false; 
            btnRestoreDB.Enabled = false;
            //BrowseEnabled(false, "both");

            
        }

        public DataBaseTab()
        {
            
        }
        // remove the entire system menu:
        private const int WS_SYSMENU = 0x80000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style &= ~WS_SYSMENU;
                return cp;
            }
        }

        public void CreateMyBorderlessWindow()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            // Remove the control box so the form will only display client area.
            this.ControlBox = false;
        }

        private void btnBackupDB_Click(object sender, EventArgs e)
        {
            var command = "sp_BackupDatabase \"AirlineReservation\" ";
            string x = "sp_BackupDatabase \"AirlineReservation\" ";

            AdminRestoreDBLogin restoreDialog = new AdminRestoreDBLogin();

            restoreDialog.Text = "Admin Database Backup";
            restoreDialog.ShowDialog(this);

            if (!restoreDialog.AdminRestoreDBAccess)
            {
                return;
            }

            bool goahead = WarningMessage("Please Confirm you wish to back up the Database!", "Confirm DataBase BackUp");
            if (goahead)
            {
                try
                {
                    ar.ExecuteCommand(command);

                    ar.SubmitChanges();

                    MessageBox.Show("Database backed up Succesfully");

                    lblBackupDB.Text = "Succesfull Database Backup \n    " + DateTimeOffset.UtcNow.UtcDateTime.ToString() +
                                                 "\n        Username: " + System.Environment.UserName.ToString();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString() + " " + ex.StackTrace.ToString());
                }
            }
            else
            {
                lblBackupDB.Text = "Database Backup Cancelled \n    " + DateTimeOffset.UtcNow.UtcDateTime.ToString() +
                                            "\n        Username: " + System.Environment.UserName.ToString();
            }
        }
       
        private void btnRestoreDB_Click(object sender, EventArgs e)
        {
            //string strtxtRestore = txtRestore.Text + ".bak";            
            //var restoreFilePath = @"C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\Backup\" + strtxtRestore;
            RestoreDatabase(bakFullFilePath);

            //RestoreDatabase(@"C:\Users\julia\source\repos\Projects\C#\AirLineReservationSystemEntityFramework\AirLineReservationSystem\Backups\backup.bak");
        }

        public void RestoreDatabase(string backUpFile)
        {
            lblRestoreResult.Text = "";
            //if (chbxRDL.Checked == false & txtRestore.Text.Trim().Length == 0)
            if (txtRestore.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please Browse to the location of your restore \n  \t\tOR \n    Select the Restore Default Loaction", "Restore Location!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                bool goahead = WarningMessage("Restoring Database will cancel all Database Connections!!!!!!", "Confirm DataBase Restore");
                if (goahead)
                {
                    try
                    {
                        // this will kick everyone out of database - temporarily everytime the restore is run
                        ar.setDBtoSingleUser();

                        // To restore database - have to initially set to Master
                        ConnectionString = ConnectionString.Replace("AirlineReservation", "Master");
                        SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                        ServerConnection con = new ServerConnection(sqlConnection);
                        Server server = new Server(con);
                        Restore destination = new Restore();
                        destination.Action = RestoreActionType.Database;
                        destination.Database = "AirlineReservation";
                        BackupDeviceItem source = new BackupDeviceItem(backUpFile, DeviceType.File);
                        destination.Devices.Add(source);
                        destination.ReplaceDatabase = true;

                        // stop all processes running against the database whilst restoring
                        // effectiveley will kick everyone out
                        //server.KillAllProcesses(destination.Database);

                        destination.SqlRestore(server);
                        con.Disconnect();

                        txtRestore.Text = "";
                        btnRestoreDB.Enabled = false;

                        lblRestoreResult.Text = "Succesfull Database Restore \n    " + DateTimeOffset.UtcNow.UtcDateTime.ToString() +
                                                 "\n        Username: " + System.Environment.UserName.ToString();
                    }
                    catch (Exception ex)
                    {
                        lblRestoreResult.Text = ex.Message;
                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    txtRestore.Text = "";
                    btnRestoreDB.Enabled = false;   
                    lblRestoreResult.Text = "Database Restore Cancelled \n    " + DateTimeOffset.UtcNow.UtcDateTime.ToString() +
                                                "\n        Username: " + System.Environment.UserName.ToString();
                }
            }
        }

        public bool WarningMessage(string message1, string message2)
        {
            if (MessageBox.Show(message1, message2, MessageBoxButtons.YesNo) == DialogResult.Yes)
                return true;
            else return false;
        }        

        private void btnBrowseRD_Click(object sender, EventArgs e)
        {
            //BrowseRDClick();

            AdminRestoreDBLogin restoreDialog = new AdminRestoreDBLogin();

            restoreDialog.ShowDialog(this);

            if (restoreDialog.AdminRestoreDBAccess)
            {
                OpenFileDialog fldg = new OpenFileDialog();
                fldg.Title = "Select file to Restore from";
                fldg.Filter = "(Backup Files)|AirlineReservation*.bak";
                if (fldg.ShowDialog() == DialogResult.OK)
                {
                    bakFullFilePath = fldg.FileName;
                    txtRestore.Text = fldg.SafeFileName.Remove(fldg.SafeFileName.Length - 4);
                    btnRestoreDB.Enabled = true;
                }
                //btnRestoreDB.Enabled = true;
                //BrowseRDClick(); 
            }
            //else return false;



            
        }       

        //private void BrowseRDClick()
        //{
        //    OpenFileDialog fldg = new OpenFileDialog();
        //    fldg.Title = "Select file to Restore from";
        //    fldg.Filter = "(Backup Files)|*.bak*";
        //    if (fldg.ShowDialog() == DialogResult.OK && fldg.FileName.StartsWith("AirlineReservation"))
        //    {
        //        txtRestore.Text = fldg.SafeFileName;
        //        btnRestoreDB.Enabled = true;
        //    }
        //    else
        //    {
                
        //    }
        //}

        private void chbxBUDL_CheckedChanged(object sender, EventArgs e)
        {
            //if (chbxBUDL.Checked == true)
            //    BrowseEnabled(false, "Browse");
            //else
            //    BrowseEnabled(true, "Browse");

            //lblBackupFolderPath.Text = "";
        }

        private void btDbLogs_Click(object sender, EventArgs e)
        {

        }

        private void chbxRDL_CheckedChanged(object sender, EventArgs e)
        {
            //if (chbxRDL.Checked == true)
            //    BrowseEnabled(false, "Restore");
            //else
            //    BrowseEnabled(true, "Restore");

            //txtRestore.Text = "";
        }

        /*
        public void BrowseEnabled(bool val, string but)
        {
            switch (but)
            {
                case "both":
                    btnBrowseBUD.Enabled = val;
                    btnBrowseRD.Enabled = val;
                    txtRestore.Enabled = val;
                    break;
                case "Browse":
                    btnBrowseBUD.Enabled = val;
                    break;
                case "Restore":
                    btnBrowseRD.Enabled = val;
                    txtRestore.Enabled = val;
                    break;
            }
        }
        */

        private void DatabaseE_Click_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DatabaseB_Click_Click(object sender, EventArgs e)
        {
            adf.lblBookFlightBack_Click(sender, e);
            adf = null;
            this.Close();         
        }

        private Image getThumbnail(string aircrftImage)
        {
            //String aircrftImage = @"C:\Users\jules\Documents\Visual Studio 2010\Projects\C#\AirLineReservationSystemEntityFramework\AirLineReservationSystem\Resources\aircraftImages\";
            //string thumbplaneimage = @"C:\Users\jules\Documents\Visual Studio 2010\Projects\C#\AirLineReservationSystemEntityFramework\AirLineReservationSystem\Resources\aircraftImages\thumbA319.jpg";

            //http://www.dotnetperls.com/getthumbnailimage
            Image ai = Image.FromFile(aircrftImage);
            Image thumbnail = ai.GetThumbnailImage(ai.Width / 10, ai.Height / 10, null, IntPtr.Zero);
            return thumbnail;
            //thumbnail.Save(thumbplaneimage);
        }

        private void Database_FMF_Click_Click(object sender, EventArgs e)
        {
            adf.lblBookFlightBack_Click(sender, e);
            adf.showFindFlight();
            adf = null;
            this.Close();
        }

        private void btDbLogs_Click_1(object sender, EventArgs e)
        {

            Table<AirlineReservationDAL.SqlLogTable> sqLgs = ar.GetTable<AirlineReservationDAL.SqlLogTable>();

            var SqlLogs = new Admin.SqlLogFiles();

            var qry = from s in sqLgs
                      select new { s.LogDate, s.LogText };
            
            var command = $"sp_SearchAllLogs";
          
            var affectedDatas = ar.ExecuteCommand(command);

            try
            {
                ar.SubmitChanges();           

                Admin.SqlLogFiles sqlLogFiles = new Admin.SqlLogFiles(qry);           

                sqlLogFiles.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + " " + ex.StackTrace.ToString());
            }
        }

        

        private void DataBaseTab_Leave(object sender, EventArgs e)
        {
            btnRestoreDB.Enabled = false;
            txtRestore.Text = "";
        }

        private void DataBaseTab_Paint(object sender, PaintEventArgs e)
        {
            AirportTab.boolEnterAirports = false;
        }

        private void btnClearDB_Click(object sender, EventArgs e)
        {
            AdminLogin testDialog = new AdminLogin();

            testDialog.Text = "Clear Database";
            testDialog.ShowDialog(this);

            if (!testDialog.AdminDBAccess)
                return;

            var command  = $"sp_ClearDataBase";

            bool goahead = WarningMessage("Please Confirm you wish to Clear the Database!", "Confirm Clear Database");
            if (goahead)
            { 
                try
                {
                    var affectedDatas = ar.ExecuteCommand(command);
                    ar.SubmitChanges();
                    lblClear.Text = "Database Clear Successful \n    " + DateTimeOffset.UtcNow.UtcDateTime.ToString() +
                                            "\n        Username: " + System.Environment.UserName.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString() + " " + ex.StackTrace.ToString()); 
                }
            }
            else
            {
                lblClear.Text = "Database Clear Cancelled \n    " + DateTimeOffset.UtcNow.UtcDateTime.ToString() +
                                            "\n        Username: " + System.Environment.UserName.ToString();
            }




        }

        private void DataBaseTab_Load(object sender, EventArgs e)
        {

        }
    }
}
