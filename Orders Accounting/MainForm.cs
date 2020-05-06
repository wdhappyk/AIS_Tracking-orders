using Orders_Accounting.Properties;
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
using Word = Microsoft.Office.Interop.Word;

namespace Orders_Accounting
{
    public partial class MainForm : Form
    {
        Dictionary<Button, TabPage> Navigation = new Dictionary<Button, TabPage>();

        public MainForm()
        {
            InitializeComponent();

            Navigation.Add(buttonOrders, tabOrders);
            Navigation.Add(buttonClients, tabClients);
            Navigation.Add(buttonStaff, tabStaff);
            Navigation.Add(buttonStaffPositions, tabStaffPositions);
            Navigation.Add(buttonOrganizationInfo, tabOrganizationInfo);

            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;
            tabControl.TabStop = false;

            Repaint();
        }

        private void ButtonUserChange_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry;
        }

        private void ButtonNavigation_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                tabControl.SelectedTab = Navigation[btn];
            }
        }


        private void Repaint()
        {
            foreach (KeyValuePair<Button, TabPage> item in Navigation)
            {
                bool isSelected = tabControl.SelectedTab == item.Value;
                item.Key.BackColor = isSelected ? Config.NavBtnBgColorActive : Config.NavBtnBgColor;
                if (isSelected)
                {
                    item.Key.Focus();
                }
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            Repaint();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dbDataSet.TechnicalSpetifications". При необходимости она может быть перемещена или удалена.
            this.technicalSpetificationsTableAdapter.Fill(this.dbDataSet.TechnicalSpetifications);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dbDataSet.WorkStageStaff". При необходимости она может быть перемещена или удалена.
            this.workStageStaffTableAdapter.Fill(this.dbDataSet.WorkStageStaff);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dbDataSet.WorksStages". При необходимости она может быть перемещена или удалена.
            this.worksStagesTableAdapter.Fill(this.dbDataSet.WorksStages);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dbDataSet.OrderStatus". При необходимости она может быть перемещена или удалена.
            this.orderStatusTableAdapter.Fill(this.dbDataSet.OrderStatus);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dbDataSet.Orders". При необходимости она может быть перемещена или удалена.
            this.ordersTableAdapter.Fill(this.dbDataSet.Orders);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dbDataSet.OrganizationInfo". При необходимости она может быть перемещена или удалена.
            this.organizationInfoTableAdapter.Fill(this.dbDataSet.OrganizationInfo);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dbDataSet.StaffPositions". При необходимости она может быть перемещена или удалена.
            this.staffPositionsTableAdapter.Fill(this.dbDataSet.StaffPositions);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dbDataSet.StaffLocal". При необходимости она может быть перемещена или удалена.
            this.staffLocalTableAdapter.Fill(this.dbDataSet.Staff);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dbDataSet.Clients". При необходимости она может быть перемещена или удалена.
            this.clientsTableAdapter.Fill(this.dbDataSet.Clients);

        }

        private void buttonCancelClientsEdit_Click(object sender, EventArgs e)
        {
            clientsBindingSource.CancelEdit();
        }

        private void ButtonAddClient_Click(object sender, EventArgs e)
        {
            clientsTableAdapter.Insert("", "", null, "", "", "", null, "", "", "", null, null);
            clientsTableAdapter.Fill(dbDataSet.Clients);
            clientsBindingSource.MoveLast();
        }

        private void ButtonDeleteClient_Click(object sender, EventArgs e)
        {
            if (clientsBindingSource.Count == 0) return;
            DialogResult res = MessageBox.Show("Вы уверены?\nОтменить данное действие будет невозможно!", "Подтвердите удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res != DialogResult.Yes) return;
            int pos = clientsBindingSource.Position;
            dbDataSet.ClientsRow client = (clientsBindingSource.Current as DataRowView).Row as dbDataSet.ClientsRow;
            clientsTableAdapter.DeleteById(client.Id);
            clientsTableAdapter.Fill(dbDataSet.Clients);
            clientsBindingSource.Position = pos;
        }

        private void buttonClientsSave_Click(object sender, EventArgs e)
        {
            string[] requiredValues =
            {
                nameClientTextBox.Text,
                addressClientTextBox.Text,
                phonesClientTextBox.Text,
                innClientTextBox.Text,
                kppClientTextBox.Text,
                bankAccountClientTextBox.Text,
                bankNameClientTextBox.Text,
                rcbicClientTextBox.Text,
            };
            bool exitEmptyField = requiredValues.Any(s => String.IsNullOrEmpty(s.Trim()));

            if (exitEmptyField)
            {
                MessageBox.Show("Не выполнено!\nВсе поля со звездочкой обязательны к заполнению!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clientsBindingSource.EndEdit();
            tableAdapterManager.UpdateAll(dbDataSet);
        }

        private void ButtonAddWorker_Click(object sender, EventArgs e)
        {
            staffLocalTableAdapter.Insert("", "", "", null, "", "");
            staffLocalTableAdapter.Fill(dbDataSet.Staff);
            staffBindingSource.MoveLast();
        }

        private void ButtonDeleteWorder_Click(object sender, EventArgs e)
        {
            if (staffBindingSource.Count == 0) return;
            DialogResult res = MessageBox.Show("Вы уверены?\nОтменить данное действие будет невозможно!", "Подтвердите удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res != DialogResult.Yes) return;
            int pos = staffBindingSource.Position;
            dbDataSet.StaffRow worker = (staffBindingSource.Current as DataRowView).Row as dbDataSet.StaffRow;
            staffLocalTableAdapter.DeleteById(worker.Id);
            staffLocalTableAdapter.Fill(dbDataSet.Staff);
            staffBindingSource.Position = pos;
        }

        private void ButtonClearSearchClients_Click(object sender, EventArgs e)
        {
            toolStripTextBoxSearchClients.Clear();
            SearchInGrid(clientsDataGridView, clientsBindingSource, null);
        }

        private void ButtonSearchClients_Click(object sender, EventArgs e)
        {
            SearchInGrid(clientsDataGridView, clientsBindingSource, toolStripTextBoxSearchClients.Text);
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

        private void clientsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (clientsDataGridView.SelectedRows.Count == 0)
            {
                panel11.Hide();
            } else
            {
                panel11.Show();
            }
        }

        private void staffDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (staffDataGridView.SelectedRows.Count == 0)
            {
                panel12.Hide();
            }
            else
            {
                panel12.Show();
                dbDataSet.StaffRow worker = (staffBindingSource.Current as DataRowView).Row as dbDataSet.StaffRow;
                staffPositionsBindingSource.Position = staffPositionsBindingSource.Find("Name", worker.PositionName);
            }
        }

        private void ButtonStaffSearch_Click(object sender, EventArgs e)
        {
            SearchInGrid(staffDataGridView, staffBindingSource, toolStripTextBoxSearchStaff.Text);
        }

        private void ButtonClearSearchStaff_Click(object sender, EventArgs e)
        {
            toolStripTextBoxSearchStaff.Clear();
            SearchInGrid(staffDataGridView, staffBindingSource, null);
        }

        private void ButtonSaveStaff_Click(object sender, EventArgs e)
        {
            string[] requiredValues =
            {
                firstNameStaffTextBox.Text,
                middleNameStaffTextBox.Text,
                lastNameStaffTextBox.Text,
                phoneStaffTextBox.Text,
            };
            bool exitEmptyField = requiredValues.Any(s => String.IsNullOrEmpty(s.Trim()));

            if (exitEmptyField)
            {
                MessageBox.Show("Не выполнено!\nВсе поля со звездочкой обязательны к заполнению!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dbDataSet.StaffRow worker = (staffBindingSource.Current as DataRowView).Row as dbDataSet.StaffRow;
            staffPositionsBindingSource.Position = staffPositionsBindingSource.Find("Name", staffPositionsComboBox.Text);
            dbDataSet.StaffPositionsRow position = (staffPositionsBindingSource.Current as DataRowView).Row as dbDataSet.StaffPositionsRow;
            worker.Position = position.Id;
            worker.PositionName = position.Name;

            staffBindingSource.EndEdit();
            tableAdapterManager.UpdateAll(dbDataSet);
            staffLocalTableAdapter.Update(worker);
        }

        private void buttonStaffReset_Click(object sender, EventArgs e)
        {
            staffBindingSource.CancelEdit();
            dbDataSet.StaffRow worker = (staffBindingSource.Current as DataRowView).Row as dbDataSet.StaffRow;
            staffPositionsBindingSource.Position = staffPositionsBindingSource.Find("Name", worker.PositionName);
        }

        private void buttonSaveOrgInfo_Click(object sender, EventArgs e)
        {
            string[] requiredValues =
            {
                nameOrgTextBox.Text,
                addressOrgTextBox.Text,
                phonesOrgTextBox.Text,
                innOrgTextBox.Text,
                kppOrgTextBox.Text,
                ogrnOrgTextBox.Text,
                bankAccountOrgTextBox.Text,
                bankOrgNameTextBox.Text,
                rcbicOrgTextBox.Text,
                corrAccOrgTextBox.Text,
                delegateOrgTextBox.Text,
            };
            bool exitEmptyField = requiredValues.Any(s => String.IsNullOrEmpty(s.Trim()));

            if (exitEmptyField)
            {
                MessageBox.Show("Не выполнено!\nВсе поля со звездочкой обязательны к заполнению!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            organizationInfoBindingSource.EndEdit();
            tableAdapterManager.UpdateAll(dbDataSet);
            dbDataSet.OrganizationInfoRow organization = (organizationInfoBindingSource.Current as DataRowView).Row as dbDataSet.OrganizationInfoRow;
            organizationInfoTableAdapter.Update(organization);
        }

        private void buttonResetOrgInfo_Click(object sender, EventArgs e)
        {
            organizationInfoBindingSource.CancelEdit();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            Validate();
            staffPositionsBindingSourceMain.EndEdit();
            tableAdapterManager.UpdateAll(dbDataSet);
            staffPositionsTableAdapter.Update(dbDataSet.StaffPositions);
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            Form exportForm = new TableToXlsForm(clientsDataGridView);
            exportForm.ShowDialog();
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            Form exportForm = new TableToXlsForm(staffDataGridView);
            exportForm.ShowDialog();
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            Form exportForm = new TableToXlsForm(ordersDataGridView);
            exportForm.ShowDialog();
        }

        private void ButtonDeleteOrder_Click(object sender, EventArgs e)
        {
            if (ordersBindingSource.Count == 0) return;
            DialogResult res = MessageBox.Show("Вы уверены?\nОтменить данное действие будет невозможно!", "Подтвердите удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res != DialogResult.Yes) return;
            int pos = ordersBindingSource.Position;
            dbDataSet.OrdersRow order = (ordersBindingSource.Current as DataRowView).Row as dbDataSet.OrdersRow;
            ordersTableAdapter.DeleteById(order.Id);
            ordersTableAdapter.Fill(dbDataSet.Orders);
            ordersBindingSource.Position = pos;
        }

        private void ButtonAddOrder_Click(object sender, EventArgs e)
        {
            ordersTableAdapter.Insert(null, 1, null, null, null);
            ordersTableAdapter.Fill(dbDataSet.Orders);
            ordersBindingSource.MoveLast();
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            SearchInGrid(ordersDataGridView, ordersBindingSource, toolStripTextBoxSearchOrders.Text);
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            toolStripTextBoxSearchOrders.Clear();
            SearchInGrid(ordersDataGridView, ordersBindingSource, null);
        }

        private void ordersDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (ordersDataGridView.SelectedRows.Count == 0)
            {
                tabControl1.Hide();
            }
            else
            {
                tabControl1.Show();
                dbDataSet.OrdersRow order = (ordersBindingSource.Current as DataRowView).Row as dbDataSet.OrdersRow;
                orderStatusBindingSource.Position = order.IsStatusNameNull() ? 0 : staffPositionsBindingSource.Find("Name", order.StatusName);
                clientNameOrderTextBox.Text = order.IsClientNameNull() ? "" : order.ClientName;

                admissionDateDateTimePicker.Value = order.IsAdmissionDateNull() ? DateTime.Now : order.AdmissionDate;
                deliveryDateDateTimePicker.Value = order.IsDeliveryDateNull() ? DateTime.Now : order.DeliveryDate;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] requiredValues =
            {
                nameOrderTextBox.Text,
                clientNameOrderTextBox.Text,
            };
            bool exitEmptyField = requiredValues.Any(s => String.IsNullOrEmpty(s.Trim()));

            if (exitEmptyField)
            {
                MessageBox.Show("Не выполнено!\nВсе поля со звездочкой обязательны к заполнению!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (admissionDateDateTimePicker.Value.CompareTo(deliveryDateDateTimePicker.Value) > 0)
            {
                MessageBox.Show("Не выполнено!\nДата приема не может быть позже даты сдачи!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dbDataSet.OrdersRow order = (ordersBindingSource.Current as DataRowView).Row as dbDataSet.OrdersRow;
            dbDataSet.OrderStatusRow status = (orderStatusBindingSource.Current as DataRowView).Row as dbDataSet.OrderStatusRow;
            clientsBindingSourceInOrders.Position = clientsBindingSourceInOrders.Find("Name", clientNameOrderTextBox.Text);
            dbDataSet.ClientsRow client = (clientsBindingSourceInOrders.Current as DataRowView).Row as dbDataSet.ClientsRow;

            order.Status = status.Id;
            order.StatusName = status.Name;
            order.ClientId = client.Id;
            order.ClientName = client.Name;
            order.AdmissionDate = admissionDateDateTimePicker.Value;
            order.DeliveryDate = deliveryDateDateTimePicker.Value;

            ordersBindingSource.EndEdit();
            tableAdapterManager.UpdateAll(dbDataSet);
            ordersTableAdapter.Update(order);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ordersBindingSource.CancelEdit();
            dbDataSet.OrdersRow order = (ordersBindingSource.Current as DataRowView).Row as dbDataSet.OrdersRow;
            orderStatusBindingSource.Position = order.IsStatusNameNull() ? 0 : staffPositionsBindingSource.Find("Name", order.StatusName);
            clientNameOrderTextBox.Text = order.IsClientNameNull() ? "" : order.ClientName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dbDataSet.OrdersRow order = (ordersBindingSource.Current as DataRowView).Row as dbDataSet.OrdersRow;
            string clientName = order.IsClientNameNull() ? "" : order.ClientName;
            Form clientSelectForm = new ClientSelectForm(clientName);
            DialogResult res = clientSelectForm.ShowDialog();
            
            if (res == DialogResult.OK)
            {
                clientNameOrderTextBox.Text = Data.selectedClient.Name;
            }
        }

        private void toolStripButton17_Click(object sender, EventArgs e)
        {
            OpenEditWorkStageForm();
        }

        private void toolStripButton19_Click(object sender, EventArgs e)
        {
            if (worksStagesBindingSource.Count == 0) return;
            dbDataSet.WorksStagesRow stage = (worksStagesBindingSource.Current as DataRowView).Row as dbDataSet.WorksStagesRow;
            OpenEditWorkStageForm(stage.Id);
        }

        private void OpenEditWorkStageForm(int stageId = 0)
        {
            dbDataSet.OrdersRow order = (ordersBindingSource.Current as DataRowView).Row as dbDataSet.OrdersRow;
            Form form = new EditWorkStageForm(order.Id, stageId);
            DialogResult res = form.ShowDialog();

            if (res == DialogResult.OK)
            {
                worksStagesTableAdapter.Fill(dbDataSet.WorksStages);
            }
        }

        private void toolStripButton18_Click(object sender, EventArgs e)
        {
            if (worksStagesBindingSource.Count == 0) return;
            DialogResult res = MessageBox.Show("Вы уверены?\nОтменить данное действие будет невозможно!", "Подтвердите удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res != DialogResult.Yes) return;
            int pos = worksStagesBindingSource.Position;
            dbDataSet.WorksStagesRow stage = (worksStagesBindingSource.Current as DataRowView).Row as dbDataSet.WorksStagesRow;
            worksStagesTableAdapter.DeleteById(stage.Id);
            worksStagesTableAdapter.Fill(dbDataSet.WorksStages);
            worksStagesBindingSource.Position = pos;
        }

        private void worksStagesDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (worksStagesBindingSource.Count == 0)
            {
                panel13.Hide();
            }
            else
            {
                panel13.Show();
            }
        }

        private void toolStripButton21_Click(object sender, EventArgs e)
        {
            if (workStageStaffBindingSource.Count == 0) return;
            DialogResult res = MessageBox.Show("Вы уверены?\nОтменить данное действие будет невозможно!", "Подтвердите удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res != DialogResult.Yes) return;
            int pos = workStageStaffBindingSource.Position;
            dbDataSet.WorkStageStaffRow data = (workStageStaffBindingSource.Current as DataRowView).Row as dbDataSet.WorkStageStaffRow;
            workStageStaffTableAdapter.Delete(data.StageId, data.EmployeeId);
            workStageStaffTableAdapter.Fill(dbDataSet.WorkStageStaff);
            workStageStaffBindingSource.Position = pos;
        }

        private void toolStripButton20_Click(object sender, EventArgs e)
        {
            OpenEditEmployeeForm();
        }

        private void toolStripButton22_Click(object sender, EventArgs e)
        {
            if (workStageStaffBindingSource.Count == 0) return;
            dbDataSet.WorkStageStaffRow employee = (workStageStaffBindingSource.Current as DataRowView).Row as dbDataSet.WorkStageStaffRow;
            OpenEditEmployeeForm(employee.EmployeeId);
        }

        private void OpenEditEmployeeForm(int employeeId = 0)
        {
            dbDataSet.WorksStagesRow stage = (worksStagesBindingSource.Current as DataRowView).Row as dbDataSet.WorksStagesRow;
            Form form = new EditEmployeeForm(stage.Id, employeeId);
            DialogResult res = form.ShowDialog();

            if (res == DialogResult.OK)
            {
                workStageStaffTableAdapter.Fill(dbDataSet.WorkStageStaff);
            }
        }

        private void OpenTsFile(object sender, EventArgs e)
        {
            openTsDialog.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            DialogResult res = openTsDialog.ShowDialog();

            if (res == DialogResult.OK)
            {
                if (technicalSpetificationsBindingSource.Count == 0)
                {
                    dbDataSet.OrdersRow order = (ordersBindingSource.Current as DataRowView).Row as dbDataSet.OrdersRow;
                    technicalSpetificationsTableAdapter.Insert(order.Id, openTsDialog.FileName);
                    technicalSpetificationsTableAdapter.Fill(dbDataSet.TechnicalSpetifications);
                } else
                {
                    dbDataSet.TechnicalSpetificationsRow ts = (technicalSpetificationsBindingSource.Current as DataRowView).Row as dbDataSet.TechnicalSpetificationsRow;
                    ts.Path = openTsDialog.FileName;
                    technicalSpetificationsTableAdapter.Update(ts);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            checkBoxContract.Checked = true;
            checkBoxTechnicalSpecification.Checked = true;
            checkBoxShedule.Checked = true;
            checkBoxCirtificateAccept.Checked = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dbDataSet.OrdersRow order = (ordersBindingSource.Current as DataRowView).Row as dbDataSet.OrdersRow;

            bool notEnoughData =
                   order.IsClientIdNull()
                || order.IsNameNull()
                || order.IsAdmissionDateNull()
                || order.IsDeliveryDateNull()
            ;


            if (notEnoughData)
            {
                MessageBox.Show("Недостаточно данных для печати.\nПожалуйста, заполните все необходимые поля.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (checkBoxContract.Checked)
            {
                PrintContract();
            }

            if (checkBoxTechnicalSpecification.Checked)
            {
                PrintTechnicalSpecification();
            }

            if (checkBoxCirtificateAccept.Checked)
            {
                PrintSertificateAccept();
            }

            if (checkBoxShedule.Checked)
            {
                PrintSheduleOfWork();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = "Техническое задание";
            DialogResult res = saveFileDialog.ShowDialog();

            if (res == DialogResult.OK)
            {
                string path = saveFileDialog.FileName;
                File.WriteAllBytes(path, Resources.TechnicalSpecificaton);

                Word.Application app = new Word.Application();
                Word.Document doc = app.Documents.Open(path);
                app.Visible = true;
            }
        }

        private void PrintContract()
        {
            saveFileDialog.FileName = "Договор";
            DialogResult res = saveFileDialog.ShowDialog();


            if (res == DialogResult.OK)
            {
                dbDataSet.OrdersRow order = (ordersBindingSource.Current as DataRowView).Row as dbDataSet.OrdersRow;
                dbDataSet.OrganizationInfoRow org = (organizationInfoBindingSource.Current as DataRowView).Row as dbDataSet.OrganizationInfoRow;
                dbDataSet.ClientsRow client = clientsTableAdapter.GetDataById(order.ClientId).FirstOrDefault();
                DataRowView[] stagesDataList = new DataRowView[worksStagesBindingSource.List.Count];
                worksStagesBindingSource.List.CopyTo(stagesDataList, 0);
                List<dbDataSet.WorksStagesRow> stages = new List<dbDataSet.WorksStagesRow>();
                foreach (DataRowView i in stagesDataList) stages.Add(i.Row as dbDataSet.WorksStagesRow);

                int stagesCount = stages.Aggregate(0, (acc, i) => i.Number.Contains(".") ? acc : acc + 1);

                Dictionary<string, decimal> stagesCosts = new Dictionary<string, decimal>();
                for (int i = 1; i <= stagesCount; ++i) stagesCosts.Add(i.ToString(), 0);
                dbDataSet.WorksStagesCostsDataTable worksStagesCostsDataTable = worksStagesCostsTableAdapter.GetData(order.Id);
                decimal stagesTotalCost = 0;
                foreach (dbDataSet.WorksStagesCostsRow item in worksStagesCostsDataTable.Rows)
                {
                    string stageN = item.Number.Split('.').First();
                    stagesCosts[stageN] += item.TotalSum;
                    stagesTotalCost += item.TotalSum;
                }

                string path = saveFileDialog.FileName;
                try
                { 
                    File.WriteAllBytes(path, Resources.Contract);
                }
                catch
                {
                    MessageBox.Show("Не выполнено!\nВыбранный файл занят другим процессом!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Word.Application app = new Word.Application();
                Word.Document doc = app.Documents.Open(path);
                Word.Bookmarks bs = doc.Bookmarks;


                Dictionary<string, string> values = new Dictionary<string, string>
                    {
                        {"Number", order.Id.ToString() },
                        {"DateDay", order.AdmissionDate.Day.ToString() },
                        {"DateMonth", order.AdmissionDate.Month.ToString() },
                        {"DateYear", order.AdmissionDate.Year.ToString() },

                        {"ProgName1", order.Name },
                        {"ProgName2", order.Name },
                        {"ProgName3", order.Name },

                        {"OrgName", org.Name },
                        {"OrgName1", org.Name },
                        {"OrgName2", org.Name },
                        {"OrgOGRN", org.OGRN },
                        {"OrgINN", org.INN },
                        {"OrgKPP", org.KPP },
                        {"OrgAddress", org.Address },
                        {"OrgBank", $"{org.BankName}, {org.BankAccount}" },
                        {"OrgDelegate", org.Delegate },
                        {"OrgDelegate1", GetShortName(org.Delegate) },

                        {"ClientAddress", client.Address },
                        {"ClientBank", $"{client.BankName}, {client.BankAccount}" },
                        {"ClientDelegate", client.IsDelegateNull() ? "" : client.Delegate },
                        {"ClientDelegate1", client.IsDelegateNull() ? "": GetShortName(client.Delegate) },
                        {"ClientINN", client.INN },
                        {"ClientKPP", client.KPP },
                        {"ClientName", client.Name },
                        {"ClientName1", client.Name },
                        {"ClientName2", client.Name },
                        {"ClientOGRN", client.IsOGRNNull() ? "" : client.OGRN },

                        {"StagesCount", stagesCount.ToString() },
                        {"StagesCount1", stagesCount.ToString() },

                        {"StagesTotalCost", stagesTotalCost.ToString() },
                    };

                if (!client.IsPassportNull())
                {
                    values.Add("Fiz", "");
                }


                foreach (KeyValuePair<string, string> pair in values)
                {
                    try
                    {
                        bs[pair.Key].Range.Text = pair.Value;
                    }
                    catch { }
                }

                List<string> stagesCostsText = new List<string>();
                List<string> stagesCostsSecondText = new List<string>();

                foreach (KeyValuePair<string, decimal> i in stagesCosts)
                {
                    stagesCostsText.Add($"стоимость {i.Key}-го этапа работ по Разработке Системы в размере {i.Value} рублей;");
                    stagesCostsSecondText.Add($"Аванс 50% от стоимости работ по Разработке Системы по этапу №{i.Key} выплачивается в течении 5 (пяти) рабочих дней после начала работ по этому этапу в соответствии со сроками начала работ, указанными в Приложении № 2 в размере {i.Value / 2} рублей;");
                    stagesCostsSecondText.Add($"В течение 5 (пяти) рабочих дней после подписания обеими Сторонами Акта сдачи-приемки {i.Key}-го этапа работ по Разработке Системы (Приложение № 3) Заказчик выплачивает Исполнителю сумму в размере {i.Value / 2} рублей;");
                }

                try
                {
                    bs["CostsStages"].Range.Text = String.Join("\n", stagesCostsText);
                    bs["CostsStages2"].Range.Text = String.Join("\n", stagesCostsSecondText);
                }
                catch { }

                doc.Save();
                app.Visible = true;
            }
        }

        private void PrintTechnicalSpecification()
        {
            if (technicalSpetificationsBindingSource.Count == 0)
            {
                MessageBox.Show("Техническое задание не может быть распечатано, т.к. не указан файл.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dbDataSet.TechnicalSpetificationsRow ts = (technicalSpetificationsBindingSource.Current as DataRowView).Row as dbDataSet.TechnicalSpetificationsRow;
            string path = ts.Path;
            if (!File.Exists(path))
            {
                MessageBox.Show("Техническое задание не может быть распечатано, т.к. не найден указанный файл!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Word.Application app = new Word.Application();
            Word.Document doc = app.Documents.Open(path);
            app.Visible = true;
        }

        private void PrintSertificateAccept()
        {
            saveFileDialog.FileName = "Акт сдачи-приемки работ";
            DialogResult res = saveFileDialog.ShowDialog();


            if (res == DialogResult.OK)
            {
                dbDataSet.OrdersRow order = (ordersBindingSource.Current as DataRowView).Row as dbDataSet.OrdersRow;
                dbDataSet.OrganizationInfoRow org = (organizationInfoBindingSource.Current as DataRowView).Row as dbDataSet.OrganizationInfoRow;
                dbDataSet.ClientsRow client = clientsTableAdapter.GetDataById(order.ClientId).FirstOrDefault();
                DataRowView[] stagesDataList = new DataRowView[worksStagesBindingSource.List.Count];
                worksStagesBindingSource.List.CopyTo(stagesDataList, 0);
                List<dbDataSet.WorksStagesRow> stages = new List<dbDataSet.WorksStagesRow>();
                foreach (DataRowView i in stagesDataList) stages.Add(i.Row as dbDataSet.WorksStagesRow);

                int stagesCount = stages.Aggregate(0, (acc, i) => i.Number.Contains(".") ? acc : acc + 1);

                Dictionary<string, decimal> stagesCosts = new Dictionary<string, decimal>();
                for (int i = 1; i <= stagesCount; ++i) stagesCosts.Add(i.ToString(), 0);
                dbDataSet.WorksStagesCostsDataTable worksStagesCostsDataTable = worksStagesCostsTableAdapter.GetData(order.Id);
                decimal stagesTotalCost = 0;
                foreach (dbDataSet.WorksStagesCostsRow item in worksStagesCostsDataTable.Rows)
                {
                    string stageN = item.Number.Split('.').First();
                    stagesCosts[stageN] += item.TotalSum;
                    stagesTotalCost += item.TotalSum;
                }

                string path = saveFileDialog.FileName;
                try 
                { 
                    File.WriteAllBytes(path, Resources.SertificateAccept);
                }
                catch
                {
                    MessageBox.Show("Не выполнено!\nВыбранный файл занят другим процессом!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Word.Application app = new Word.Application();
                Word.Document doc = app.Documents.Open(path);
                Word.Bookmarks bs = doc.Bookmarks;


                Dictionary<string, string> values = new Dictionary<string, string>
                    {
                        {"DocN1", order.Id.ToString() },
                        {"DocN2", order.Id.ToString() },
                        {"AdmissionDay1", order.AdmissionDate.Day.ToString() },
                        {"AdmissionMonth1", order.AdmissionDate.Month.ToString() },
                        {"AdmissionYear1", order.AdmissionDate.Year.ToString() },
                        {"AdmissionDay2", order.AdmissionDate.Day.ToString() },
                        {"AdmissionMonth2", order.AdmissionDate.Month.ToString() },
                        {"AdmissionYear2", order.AdmissionDate.Year.ToString() },
                        {"DeliveryDay1", order.DeliveryDate.Day.ToString() },
                        {"DeliveryMonth1", order.DeliveryDate.Month.ToString() },
                        {"DeliveryYear1", order.DeliveryDate.Year.ToString() },


                        {"ProgName", order.Name },
                        {"ProgName2", order.Name },

                        {"OrgName1", org.Name },
                        {"OrgName2", org.Name },
                        {"OrgDelegate", GetShortName(org.Delegate) },

                        {"ClientName1", client.Name },
                        {"ClientName2", client.Name },
                        {"ClientDelegate", client.IsDelegateNull() ? "": GetShortName(client.Delegate) },

                        {"TotalCost", stagesTotalCost.ToString() },
                        {"TotalCost1", stagesTotalCost.ToString() },
                    };

                //if (!client.IsPassportNull())
                //{
                //    values.Add("Fiz", "");
                //}


                foreach (KeyValuePair<string, string> pair in values)
                {
                    try
                    {
                        bs[pair.Key].Range.Text = pair.Value;
                    }
                    catch { }
                }


                Word.Table tbl = doc.Tables[3];
                for (int i = 1; i < stagesCount; ++i) tbl.Rows.Add(tbl.Rows[2]);

                int row = 2;

                foreach (KeyValuePair<string, decimal> i in stagesCosts)
                {
                    tbl.Rows[row].Cells[1].Range.Text = i.Key;
                    tbl.Rows[row].Cells[2].Range.Text = stages.Find(x => x.Number == i.Key).Name;
                    tbl.Rows[row].Cells[3].Range.Text = i.Value.ToString();

                    ++row;
                }


                doc.Save();
                app.Visible = true;
            }
        }

        private void PrintSheduleOfWork()
        {
            saveFileDialog.FileName = "План-график работ";
            DialogResult res = saveFileDialog.ShowDialog();


            if (res == DialogResult.OK)
            {
                dbDataSet.OrdersRow order = (ordersBindingSource.Current as DataRowView).Row as dbDataSet.OrdersRow;
                dbDataSet.OrganizationInfoRow org = (organizationInfoBindingSource.Current as DataRowView).Row as dbDataSet.OrganizationInfoRow;
                dbDataSet.ClientsRow client = clientsTableAdapter.GetDataById(order.ClientId).FirstOrDefault();
                DataRowView[] stagesDataList = new DataRowView[worksStagesBindingSource.List.Count];
                worksStagesBindingSource.List.CopyTo(stagesDataList, 0);
                List<dbDataSet.WorksStagesRow> stages = new List<dbDataSet.WorksStagesRow>();
                foreach (DataRowView i in stagesDataList) stages.Add(i.Row as dbDataSet.WorksStagesRow);

                int stagesCount = stages.Aggregate(0, (acc, i) => i.Number.Contains(".") ? acc : acc + 1);

                Dictionary<string, decimal> stagesCosts = new Dictionary<string, decimal>();
                for (int i = 1; i <= stagesCount; ++i) stagesCosts.Add(i.ToString(), 0);
                dbDataSet.WorksStagesCostsDataTable worksStagesCostsDataTable = worksStagesCostsTableAdapter.GetData(order.Id);
                decimal stagesTotalCost = 0;
                foreach (dbDataSet.WorksStagesCostsRow item in worksStagesCostsDataTable.Rows)
                {
                    string stageN = item.Number.Split('.').First();
                    stagesCosts[stageN] += item.TotalSum;
                    stagesTotalCost += item.TotalSum;
                }

                string path = saveFileDialog.FileName;

                try
                {
                    File.WriteAllBytes(path, Resources.SheduleOfWork);
                } catch
                {
                    MessageBox.Show("Не выполнено!\nВыбранный файл занят другим процессом!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                

                Word.Application app = new Word.Application();
                Word.Document doc = app.Documents.Open(path);
                Word.Bookmarks bs = doc.Bookmarks;


                Dictionary<string, string> values = new Dictionary<string, string>
                    {
                        {"DocN", order.Id.ToString() },
                        {"Day", order.AdmissionDate.Day.ToString() },
                        {"Month", order.AdmissionDate.Month.ToString() },
                        {"Year", order.AdmissionDate.Year.ToString() },

                        {"ProgName", order.Name },

                        {"OrgName", org.Name },
                        {"OrgDelegate", GetShortName(org.Delegate) },

                        {"ClientName", client.Name },
                        {"ClientDelegate", client.IsDelegateNull() ? "": GetShortName(client.Delegate) },
                    };

                foreach (KeyValuePair<string, string> pair in values)
                {
                    try
                    {
                        bs[pair.Key].Range.Text = pair.Value;
                    }
                    catch { }
                }

                Word.Table tbl = doc.Tables[2];
                Word.Row tplRow = tbl.Rows[2];
                List<Word.Range> rls = new List<Word.Range>();

                int pos = worksStagesBindingSource.Position;
                worksStagesBindingSource.MoveFirst();
                workStageStaffBindingSource.MoveFirst();

                for (int i = 0; i < worksStagesBindingSource.Count; ++i)
                {
                    dbDataSet.WorksStagesRow stage = (worksStagesBindingSource.Current as DataRowView).Row as dbDataSet.WorksStagesRow;
                    Word.Row row = tbl.Rows.Add(tplRow);
                    row.Cells[1].Range.Text = stage.Number;
                    row.Cells[2].Range.Text = stage.Name;
                    row.Cells[4].Range.Text = stage.StartDate.ToShortDateString();
                    row.Cells[5].Range.Text = stage.FinishDate.ToShortDateString();

                    Word.Row rowEmp = null;

                    decimal totalCost = 0;

                    workStageStaffBindingSource.MoveFirst();
                    foreach (DataRowView empRow in workStageStaffBindingSource.List)
                    {
                        dbDataSet.WorkStageStaffRow emp = empRow.Row as dbDataSet.WorkStageStaffRow;

                        if (emp.IsEmployeeNameNull()) continue;

                        string posPrefix = emp.IsEmployeePositionNull() ? "" : $"{emp.EmployeePosition} ";
                        decimal cost = emp.LaborExpenditures * 8 * emp.Rate;
                        totalCost += cost;

                        rowEmp = tbl.Rows.Add(tplRow);
                        rowEmp.Cells[3].Range.Text = posPrefix + GetShortName(emp.EmployeeName);
                        rowEmp.Cells[6].Range.Text = emp.LaborExpenditures.ToString();
                        rowEmp.Cells[7].Range.Text = emp.Rate.ToString();
                        rowEmp.Cells[8].Range.Text = cost.ToString();
                    }

                    row.Cells[9].Range.Text = totalCost.ToString();

                    if (rowEmp != null)
                    {
                        rls.Add(doc.Range(row.Cells[9].Range.Start, rowEmp.Cells[9].Range.End));
                    }


                    worksStagesBindingSource.MoveNext();
                }

                tbl.Columns.AutoFit();

                worksStagesBindingSource.Position = pos;

                doc.Range(tplRow.Cells[1].Range.Start, tplRow.Cells[5].Range.End).Cells.Merge();
                doc.Range(tplRow.Cells[2].Range.Start, tplRow.Cells[5].Range.End).Cells.Merge();
                tplRow.Cells[1].Range.Text = "ИТОГО";
                tplRow.Range.Font.Bold = 1;
                tplRow.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                tplRow.Cells[2].Range.Text = stagesTotalCost.ToString();

                foreach (Word.Range r in rls) 
                {
                    r.Cells.Merge();
                }
                

                doc.Save();
                app.Visible = true;
            }
        }

        private string GetShortName(string name)
        {
            try
            {
                string[] ls = name.Split(' ');
                return $"{ls[0]} {ls[1][0]}.{ls[2][0]}.";
            }
            catch
            {
                return name;
            }
        }
    }
}
