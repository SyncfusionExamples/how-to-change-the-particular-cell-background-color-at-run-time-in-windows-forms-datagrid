#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.DataGrid.Styles;
using System.Windows.Forms;
using Syncfusion.WinForms.DataGrid.Enums;
using System.Collections.Generic;
using Syncfusion.WinForms.GridCommon.ScrollAxis;
using System.Drawing;

namespace GettingStarted
{   
    public partial class Form1 : Form
    {
        #region Constructor

        Dictionary<RowColumnIndex, Color> colorDict = new Dictionary<RowColumnIndex, Color>();

        public Form1()
        {
            InitializeComponent();
            var data = new OrderInfoCollection();
            sfDataGrid.DataSource = data.OrdersListDetails;
            this.sfDataGrid.QueryCellStyle += sfDataGrid_QueryCellStyle;
        }

        void sfDataGrid_QueryCellStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryCellStyleEventArgs e)
        {
            var rowColumnIndex = new RowColumnIndex(e.RowIndex,e.ColumnIndex);
            if (colorDict.ContainsKey(rowColumnIndex))
                e.Style.BackColor = colorDict[rowColumnIndex];
        }

        #endregion 

        private void button1_Click(object sender, System.EventArgs e)
        {
            SetCellBackgroundColor(new RowColumnIndex(1, 0), Color.Red);
        }

        void SetCellBackgroundColor(RowColumnIndex rowColumnIndex, Color color)
        {
            if (!colorDict.ContainsKey(rowColumnIndex))
                colorDict.Add(rowColumnIndex, color);
            else
                colorDict[rowColumnIndex] = color;
            //Refresh the particular cell
            sfDataGrid.TableControl.Invalidate(this.sfDataGrid.TableControl.GetCellRectangle(rowColumnIndex.RowIndex, rowColumnIndex.ColumnIndex, false));
        }
    }
}
