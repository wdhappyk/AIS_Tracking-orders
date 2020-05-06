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
    public partial class EditEmployeeForm : Form
    {
        int StageId;
        int Id;
        dbDataSet.WorkStageStaffRow Employee;

        public EditEmployeeForm(int stageId, int id = 0)
        {
            InitializeComponent();
            StageId = stageId;
            Id = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = Data.selectedEmployee == null ? 0 : Data.selectedEmployee.Id;
            Form form = new EmployeeSelectForm(id);
            DialogResult res = form.ShowDialog();

            if (res == DialogResult.OK)
            {
                dbDataSet.StaffRow data = Data.selectedEmployee;
                fullNameInput.Text = $"{data.LastName} {data.FirstName} {data.MiddleName}";
                labelPosition.Text = data.PositionName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Data.selectedEmployee == null)
            {
                MessageBox.Show("Не выполнено!\nВсе поля со звездочкой обязательны к заполнению!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int employeeId = Data.selectedEmployee.Id;
            short days = (short)daysInput.Value;
            decimal rate = rateInput.Value;

            if (Employee == null || employeeId != Employee.EmployeeId)
            {
                try
                {
                    workStageStaffTableAdapter.Insert(StageId, employeeId, days, rate);
                }
                catch
                {
                    MessageBox.Show("Не выполнено!\nДанный специалист уже назначен!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (Id > 0)
                {
                    workStageStaffTableAdapter.Delete(StageId, Employee.EmployeeId);
                }
            } else
            {
                workStageStaffTableAdapter.UpdateData(days, rate, StageId, employeeId);
            }

            DialogResult = DialogResult.OK;
        }

        private void EditEmployeeForm_Load(object sender, EventArgs e)
        {
            if (Id > 0)
            {
                Employee = workStageStaffTableAdapter.GetDataByKey(StageId, Id).FirstOrDefault();

                if (Employee == null)
                {
                    MessageBox.Show("Запись не найдена!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.Abort;
                    return;
                }

                Data.selectedEmployee = staffTableAdapter.GetDataById(Employee.EmployeeId).FirstOrDefault();
                fullNameInput.Text = Employee.EmployeeName;
                labelPosition.Text = Employee.IsEmployeePositionNull() ? "-" : Employee.EmployeePosition;
                daysInput.Value = Employee.LaborExpenditures;
                rateInput.Value = Employee.Rate;
            } else
            {
                Data.selectedEmployee = null;
            }
        }
    }
}
