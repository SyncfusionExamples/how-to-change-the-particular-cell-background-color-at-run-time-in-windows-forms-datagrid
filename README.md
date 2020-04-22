# How to change the particular cell background color at run time in Windows Forms DataGrid(SfDataGrid)	
## About the sample
This example illustrates to change the particular cell background color at run time in Windows Forms DataGrid(SfDataGrid)

SfDataGrid provides the support to customize the background color of a single cell at run time. You can achieve this by maintaining a Dictionary with RowColumnIndex of the cell as Key and the background color as value. Based on the value in the dictionary, QueryCellStyle event set the background color of the cell. 
```c#
 Dictionary<RowColumnIndex, Color> colorDict = new Dictionary<RowColumnIndex, Color>();

 this.sfDataGrid.QueryCellStyle += sfDataGrid_QueryCellStyle;

 void sfDataGrid_QueryCellStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryCellStyleEventArgs e)
 {
     var rowColumnIndex = new RowColumnIndex(e.RowIndex,e.ColumnIndex);
     if (colorDict.ContainsKey(rowColumnIndex))
         e.Style.BackColor = colorDict[rowColumnIndex];
 }
 

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

```
## Requirements to run the demo
Visual Studio 2015 and above versions
