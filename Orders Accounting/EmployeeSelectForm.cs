using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orders_Accounting
{
    public partial class EmployeeSelectForm : Form
    {
        int Id;

        public EmployeeSelectForm(int id = 0)
        {
            InitializeComponent();
            Id = id;
        }

        private void EmployeeSelectForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dbDataSet.Staff". При необходимости она может быть перемещена или удалена.
            this.staffTableAdapter.Fill(this.dbDataSet.Staff);

            staffBindingSource.Position = staffBindingSource.Find("Id", Id.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (staffBindingSource.Count != 0)
            {
                Data.selectedEmployee = (staffBindingSource.Current as DataRowView).Row as dbDataSet.StaffRow;
            }
            DialogResult = DialogResult.OK;
        }

        private void SearchInGrid(DataGridView grid, BindingSource bindingSource, string searchText)
        {
            if (searchText == null || String.IsNullOrEmpty(searchText.Trim()))
            {
                bindingSource.Filter = null;
                return;
            }
            string filter = "";

            foreach (DataGridViewColumn col in grid.Columns)
            {
                if (filter != "") filter += " OR ";
                filter += $"CONVERT([{col.DataPropertyName}], System.String) LIKE '%{searchText}%'";
            }
            bindingSource.Filter = filter;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SearchInGrid(staffDataGridView, staffBindingSource, searchInput.Text);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            searchInput.Clear();
            SearchInGrid(staffDataGridView, staffBindingSource, null);
        }
    }
}
