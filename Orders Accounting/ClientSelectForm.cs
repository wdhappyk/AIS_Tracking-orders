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
    public partial class ClientSelectForm : Form
    {
        new string Name;

        public ClientSelectForm(string name)
        {
            InitializeComponent();
            Name = name;
        }

        private void clientsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.clientsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dbDataSet);
        }

        private void ClientSelectForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dbDataSet.Clients". При необходимости она может быть перемещена или удалена.
            this.clientsTableAdapter.Fill(this.dbDataSet.Clients);

            clientsBindingSource.Position = clientsBindingSource.Find("Name", Name);
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
            SearchInGrid(clientsDataGridView, clientsBindingSource, toolStripTextBox1.Text);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Clear();
            SearchInGrid(clientsDataGridView, clientsBindingSource, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (clientsBindingSource.Count != 0)
            {
                Data.selectedClient = (clientsBindingSource.Current as DataRowView).Row as dbDataSet.ClientsRow;
            }
            DialogResult = DialogResult.OK;
        }
    }
}
