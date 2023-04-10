namespace AirLineReservationSystem.Admin
{
    partial class SqlLogFiles
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
            this.sqlLogTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.airlineReservationDataSet = new AirLineReservationSystem.AirlineReservationDataSet();
            this.sqlLogTableTableAdapter = new AirLineReservationSystem.AirlineReservationDataSetTableAdapters.SqlLogTableTableAdapter();
            this.dgvSqlLogFileData = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.sqlLogTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.airlineReservationDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSqlLogFileData)).BeginInit();
            this.SuspendLayout();
            // 
            // sqlLogTableBindingSource
            // 
            this.sqlLogTableBindingSource.DataMember = "SqlLogTable";
            this.sqlLogTableBindingSource.DataSource = this.airlineReservationDataSet;
            // 
            // airlineReservationDataSet
            // 
            this.airlineReservationDataSet.DataSetName = "AirlineReservationDataSet";
            this.airlineReservationDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sqlLogTableTableAdapter
            // 
            this.sqlLogTableTableAdapter.ClearBeforeFill = true;
            // 
            // dgvSqlLogFileData
            // 
            this.dgvSqlLogFileData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSqlLogFileData.Location = new System.Drawing.Point(12, 12);
            this.dgvSqlLogFileData.Name = "dgvSqlLogFileData";
            this.dgvSqlLogFileData.RowHeadersWidth = 51;
            this.dgvSqlLogFileData.RowTemplate.Height = 24;
            this.dgvSqlLogFileData.Size = new System.Drawing.Size(1006, 668);
            this.dgvSqlLogFileData.TabIndex = 0;
            // 
            // SqlLogFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 692);
            this.Controls.Add(this.dgvSqlLogFileData);
            this.Name = "SqlLogFiles";
            this.Text = "SQL Server Logs";
            this.Load += new System.EventHandler(this.SqlLogFiles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sqlLogTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.airlineReservationDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSqlLogFileData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private AirlineReservationDataSet airlineReservationDataSet;
        private System.Windows.Forms.BindingSource sqlLogTableBindingSource;
        private AirlineReservationDataSetTableAdapters.SqlLogTableTableAdapter sqlLogTableTableAdapter;
        private System.Windows.Forms.DataGridView dgvSqlLogFileData;
    }
}