using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.Linq;

namespace AirLineReservationSystem
{
    class DataGrid : System.Windows.Forms.DataGridView
    {


        public DataGrid() :base()
        {
            //http://csharp.net-informations.com/datagridview/csharp-datagridview-formatting.htm
                                 
            this.Width = 597;
            this.Height = 283;           

            // dont want to see first column 
            this.RowHeadersVisible = false;
            this.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;       

                                  
            // allign header text
            this.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // allign row text
            this.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;

            //this.AllowUserToAddRows = false;
            //this.AllowUserToResizeRows = false;   

            //this.AllowUserToResizeRows = false;
            this.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            foreach (DataGridViewRow row in this.Rows)
            {
                row.Height = 15;
                
            }

            //this.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            //this.AllowUserToResizeRows = false;

            // set font of border text
            this.ColumnHeadersDefaultCellStyle.Font = new Font("Comic Sans MS", 10.00F, FontStyle.Regular);


            //this.RowsDefaultCellStyle.BackColor = Color.Bisque;
            this.RowsDefaultCellStyle.ForeColor = Color.White;
           // this.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.CellBorderStyle = DataGridViewCellBorderStyle.None;
            this.BorderStyle = BorderStyle.Fixed3D;

            //this.GridColor = Color.White;
            this.DefaultCellStyle.SelectionBackColor = Color.Red;
            //this.DefaultCellStyle.SelectionForeColor = Color.Yellow;

            //this.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //this.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //this.AllowUserToResizeColumns = false;

          
          
        }

        protected override void PaintBackground(Graphics graphics, Rectangle clipBounds, Rectangle gridBounds)
        {
            base.PaintBackground(graphics, clipBounds, gridBounds);
            Rectangle rectSource = new Rectangle(this.Location.X, this.Location.Y, this.Width, this.Height);
            Rectangle rectDest = new Rectangle(0, 0, rectSource.Width, rectSource.Height);

            Bitmap b = new Bitmap(Parent.ClientRectangle.Width, Parent.ClientRectangle.Height);
            Graphics.FromImage(b).DrawImage(this.Parent.BackgroundImage, Parent.ClientRectangle);


            graphics.DrawImage(b, rectDest, rectSource, GraphicsUnit.Pixel);
            SetCellsTransparent();
        }


        public void SetCellsTransparent()
        {
            this.EnableHeadersVisualStyles = false;
            this.ColumnHeadersDefaultCellStyle.BackColor = Color.Transparent;
            this.RowHeadersDefaultCellStyle.BackColor = Color.Transparent;


            foreach (DataGridViewColumn col in this.Columns)
            {
                col.DefaultCellStyle.BackColor = Color.Transparent;
                col.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            }

            int colCount = this.Columns.Count; // this returns the total number of columns (=6)
            //MessageBox.Show(colCount.ToString());
            colCount = colCount - 1; // =5

            for (int i = 0; i < colCount; i++)
            {
                this.Columns[i].Width = 165;
            }
        }

        //public void LogEmployees<T>(List<T> list) // Or IEnumerable<T> list
        //{
        //    foreach (T item in list)
        //    {

        //    }
        //}

        public void addRow(IEnumerable<dynamic> s)
        {         
            //this.AllowUserToAddRows = false;
            //this.AllowUserToResizeRows = false;          
            
            this.DataSource = s;
            
             DataGridViewColumn columnSave = new DataGridViewColumn();

             // Set column values
             columnSave.Name = "SaveButton";
   
             columnSave.HeaderText = "";
             columnSave.CellTemplate = new DataGridViewCheckBoxCell();
             columnSave.Width = 10;
            this.Columns.Insert(1, columnSave);// Add("columnname", "columntext");
          
            //columnSave.CellTemplate = new DataGridViewCheckBoxCell();

        

        }
    }
}
