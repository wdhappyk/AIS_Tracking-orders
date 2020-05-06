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
    public partial class SignInForm : Form
    {
        public SignInForm()
        {
            InitializeComponent();
        }

        private void ButtonSignIn_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string pass = textBoxPass.Text;
            dbDataSet.UsersRow user = null;

            try
            {
                user = usersTableAdapter.GetUser(login, pass).FirstOrDefault();
            }
            catch
            {
                MessageBox.Show("Не удалось подлючиться к базе данных!\nПожалуйста, настройте подключение.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                OpenConnectionConfig();
                return;
            }

            
            if (user == null)
            {
                MessageBox.Show("Неверные данные!", "Ошибка", MessageBoxButtons.OK);
                return;
            }
            Form mainForm = new MainForm();
            Hide();
            DialogResult res = mainForm.ShowDialog();
            if (res == DialogResult.Retry)
            {
                Show();
                ClearForm();
            }                                                          
            else
            {
                Close();
            }
            
        }

        private void ClearForm()
        {
            textBoxLogin.Clear();
            textBoxPass.Clear();
            textBoxLogin.Focus();
        }

        private void OpenConnectionConfig()
        {
            Form form = new ChangeDbConnection();
            form.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            OpenConnectionConfig();
        }
    }
}
