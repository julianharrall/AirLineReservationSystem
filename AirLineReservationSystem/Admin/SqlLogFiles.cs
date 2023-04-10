using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirLineReservationSystem.Admin
{
    public partial class SqlLogFiles : Form
    {
        public SqlLogFiles(IQueryable qry)
        {
            InitializeComponent();

            BindingSource bs = new BindingSource();

            // Set up the DataGridView.
            dgvSqlLogFileData.Dock = DockStyle.Fill;

            // Automatically generate the DataGridView columns.
            dgvSqlLogFileData.AutoGenerateColumns = true;

            // Set up the data source.
            bs.DataSource = qry;
           
            dgvSqlLogFileData.DataSource = bs;

            // Automatically resize the visible rows.
            dgvSqlLogFileData.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;

            dgvSqlLogFileData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);

            // Set the DataGridView control's border.
            dgvSqlLogFileData.BorderStyle = BorderStyle.Fixed3D;

            dgvSqlLogFileData.AutoResizeColumns();
            dgvSqlLogFileData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        public SqlLogFiles() { }

        /// <summary>
        /// This line of code loads data into the 'airlineReservationDataSet.SqlLogTable' table.
        /// You can move, or remove it, as needed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SqlLogFiles_Load(object sender, EventArgs e)
        {            
            //this.sqlLogTableTableAdapter.Fill(this.airlineReservationDataSet.SqlLogTable);

        }

        private void dgvSqlLogFileData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
