using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orders_Accounting
{
    public partial class ChangeDbConnection : Form
    {
        public ChangeDbConnection()
        {
            InitializeComponent();
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            string server = textBox1.Text;
            string db = textBox2.Text;
            string[] config =
            {
                "<?xml version=\"1.0\" encoding=\"utf-8\" ?>",
                "<configuration>",
                    "<configSections>",
                    "</configSections>",
                    "<connectionStrings>",
                        "<add name=\"Orders_Accounting.Properties.Settings.dbConnectionString\"",
                            $"connectionString=\"Data Source={server};Initial Catalog={db};Integrated Security=True\"",
                            "providerName=\"System.Data.SqlClient\" />",
                    "</connectionStrings>",
                    "<startup>",
                        "<supportedRuntime version=\"v4.0\" sku=\".NETFramework,Version=v4.7.2\" />",
                    "</startup>",
                "</configuration>",
            };

            File.WriteAllLines(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Orders Accounting.exe.config"), config);
            Application.Restart();
        }
    }
}
