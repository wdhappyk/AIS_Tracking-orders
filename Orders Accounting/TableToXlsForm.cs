using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Orders_Accounting
{
    public partial class TableToXlsForm : Form
    {
        DataGridView DataGrid;

        public TableToXlsForm(DataGridView dataGrid)
        {
            InitializeComponent();
            DataGrid = dataGrid;

            listBox.Items.Clear();

            for (int i = 0; i < dataGrid.Columns.Count; ++i)
            {
                DataGridViewColumn col = dataGrid.Columns[i];
                listBox.Items.Add(col.HeaderText);
                listBox.SetItemChecked(i, true);
            }
        }

        private void buttonClientsSave_Click(object sender, EventArgs e)
        {
            if (listBox.CheckedItems.Count == 0)
            {
                MessageBox.Show("Выберите поля!", "Не выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Excel.Application app = new Excel.Application();
            Excel.Workbook book = app.Workbooks.Add();
            Excel.Worksheet sheet = book.Worksheets.Add();

            for (int i = 0, col = 0; i < listBox.Items.Count; ++i)
            {
                if (!listBox.GetItemChecked(i)) continue;
                ++col;
                sheet.Cells[1, col] = listBox.Items[i];

                for (int j = 0; j < DataGrid.Rows.Count; ++j)
                {
                    object value = DataGrid.Rows[j].Cells[i].Value;
                    if (value is DateTime val)
                    {
                        sheet.Cells[j + 2, col].Value = val.Date;
                    }
                    else
                    {
                        sheet.Cells[j + 2, col].Value = $"'{Convert.ToString(value)}";
                    }
                }

                sheet.Columns[col].AutoFit();
            }

            app.Visible = true;
            Close();
        }
    }
}
