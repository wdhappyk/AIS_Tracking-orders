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
    public partial class EditWorkStageForm : Form
    {
        int OrderId;
        int StageId;
        dbDataSet.WorksStagesRow Stage;

        public EditWorkStageForm(int orderId, int stageId = 0)
        {
            InitializeComponent();
            OrderId = orderId;
            StageId = stageId;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string number = textBox1.Text.Trim();
            string name = textBox2.Text.Trim();
            DateTime startDate = dateTimePicker1.Value;
            DateTime finishDate = dateTimePicker2.Value;


            if (number == String.Empty || name == String.Empty)
            {
                MessageBox.Show("Не выполнено!\nВсе поля со звездочкой обязательны к заполнению!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (startDate.CompareTo(finishDate) > 0)
            {
                MessageBox.Show("Не выполнено!\nДата начала не может быть позже даты окончания!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (StageId == 0)
            {
                worksStagesTableAdapter.Insert(OrderId, number, startDate, finishDate, name);
            }
            else
            {
                Stage.Number = number;
                Stage.Name = name;
                Stage.StartDate = startDate;
                Stage.FinishDate = finishDate;
                worksStagesTableAdapter.Update(Stage);
            }

            DialogResult = DialogResult.OK;
        }

        private void EditWorkStageForm_Load(object sender, EventArgs e)
        {
            if (StageId > 0)
            {
                Stage = worksStagesTableAdapter.GetDataById(StageId).FirstOrDefault();

                if (Stage == null)
                {
                    MessageBox.Show("Запись не найдена!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.Abort;
                    return;
                }

                textBox1.Text = Stage.Number;
                textBox2.Text = Stage.Name;
                dateTimePicker1.Value = Stage.StartDate;
                dateTimePicker2.Value = Stage.FinishDate;
            }
            else
            {
                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker2.Value = DateTime.Now;
            }
        }
    }
}
