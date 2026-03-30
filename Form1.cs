using exam.Models;
using exam.Services;
using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace exam
{
    public partial class Form1 : Form
    {
        private ClientRepository _clientRepo;
        private CarRepository _carRepo;
        private int _selectedClientID = -1;
        private int _selectedCarID = -1;

        public Form1()
        {
            InitializeComponent();
            _clientRepo = new ClientRepository();
            _carRepo = new CarRepository();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                LoadClientsTab();
                LoadCarsTab();
                LoadReportsTab();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки формы: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region CLIENTS

        private void LoadClientsTab()
        {
            try
            {
                LoadClients();
                ClearClientForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки клиентов: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadClients()
        {
            try
            {
                DataTable dt = _clientRepo.GetAll();
                dgvClients.DataSource = dt;
                dgvClients.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearClientForm()
        {
            txtClientID.Clear();
            txtClientSurname.Clear();
            txtClientName.Clear();
            txtClientPhone.Clear();
            txtClientAddress.Clear();
            txtClientSearch.Clear();
            _selectedClientID = -1;
        }

        private bool ValidateClientInputs()
        {
            if (string.IsNullOrWhiteSpace(txtClientSurname.Text))
            {
                MessageBox.Show("Введите фамилию", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtClientName.Text))
            {
                MessageBox.Show("Введите имя", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtClientPhone.Text))
            {
                MessageBox.Show("Введите телефон", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtClientAddress.Text))
            {
                MessageBox.Show("Введите адрес", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnClientAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateClientInputs()) return;

                Client client = new Client
                {
                    Surname = txtClientSurname.Text.Trim(),
                    Name = txtClientName.Text.Trim(),
                    Phonenumber = txtClientPhone.Text.Trim(),
                    Address = txtClientAddress.Text.Trim()
                };

                if (_clientRepo.Add(client))
                {
                    MessageBox.Show("Клиент добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadClientsTab();
                    LoadCarClients();
                }
                else
                {
                    MessageBox.Show("Не удалось добавить", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClientUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedClientID == -1)
                {
                    MessageBox.Show("Выберите клиента", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!ValidateClientInputs()) return;

                Client client = new Client
                {
                    Id_client = _selectedClientID,
                    Surname = txtClientSurname.Text.Trim(),
                    Name = txtClientName.Text.Trim(),
                    Phonenumber = txtClientPhone.Text.Trim(),
                    Address = txtClientAddress.Text.Trim()
                };

                if (_clientRepo.Update(client))
                {
                    MessageBox.Show("Данные обновлены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadClientsTab();
                    LoadCarClients();
                }
                else
                {
                    MessageBox.Show("Не удалось обновить", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClientDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedClientID == -1)
                {
                    MessageBox.Show("Выберите клиента", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Удалить клиента?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_clientRepo.Delete(_selectedClientID))
                    {
                        MessageBox.Show("Клиент удалён!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadClientsTab();
                        LoadCarClients();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось удалить", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClientRefresh_Click(object sender, EventArgs e)
        {
            LoadClientsTab();
        }

        private void btnClientClear_Click(object sender, EventArgs e)
        {
            ClearClientForm();
        }

        private void dgvClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvClients.Rows[e.RowIndex];
                    _selectedClientID = Convert.ToInt32(row.Cells["Id_client"].Value);
                    txtClientID.Text = _selectedClientID.ToString();
                    txtClientSurname.Text = row.Cells["Surname"].Value?.ToString() ?? "";
                    txtClientName.Text = row.Cells["Name"].Value?.ToString() ?? "";
                    txtClientPhone.Text = row.Cells["Phonenumber"].Value?.ToString() ?? "";
                    txtClientAddress.Text = row.Cells["Address"].Value?.ToString() ?? "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtClientSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtClientSearch.Text))
                {
                    LoadClients();
                }
                else
                {
                    DataTable dt = _clientRepo.Search(txtClientSearch.Text);
                    dgvClients.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region CARS

        private void LoadCarsTab()
        {
            try
            {
                LoadCars();
                LoadCarClients();
                ClearCarForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки автомобилей: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCars()
        {
            try
            {
                DataTable dt = _carRepo.GetAll();
                dgvCars.DataSource = dt;
                dgvCars.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCarClients()
        {
            try
            {
                DataTable dt = _clientRepo.GetAll();
                cmbCarClient.DataSource = dt;
                cmbCarClient.DisplayMember = "Surname";
                cmbCarClient.ValueMember = "Id_client";
                cmbCarClient.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearCarForm()
        {
            txtCarID.Clear();
            txtCarBrand.Clear();
            txtCarModel.Clear();
            txtCarYear.Clear();
            txtCarGosNumber.Clear();
            txtCarSearch.Clear();
            cmbCarClient.SelectedIndex = -1;
            _selectedCarID = -1;
        }

        private bool ValidateCarInputs()
        {
            if (string.IsNullOrWhiteSpace(txtCarBrand.Text))
            {
                MessageBox.Show("Введите марку", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCarModel.Text))
            {
                MessageBox.Show("Введите модель", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!int.TryParse(txtCarYear.Text, out int year) || year < 1900 || year > DateTime.Now.Year)
            {
                MessageBox.Show("Введите корректный год выпуска", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCarGosNumber.Text))
            {
                MessageBox.Show("Введите государственный номер", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbCarClient.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите клиента", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnCarAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateCarInputs()) return;

                Car car = new Car
                {
                    Brand = txtCarBrand.Text.Trim(),
                    Model = txtCarModel.Text.Trim(),
                    Release_Year = new DateTime(int.Parse(txtCarYear.Text), 1, 1),
                    Gos_number = txtCarGosNumber.Text.Trim(),
                    Id_Client = (int)cmbCarClient.SelectedValue
                };

                if (_carRepo.Add(car))
                {
                    MessageBox.Show("Автомобиль добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCarsTab();
                }
                else
                {
                    MessageBox.Show("Не удалось добавить", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCarUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedCarID == -1)
                {
                    MessageBox.Show("Выберите автомобиль", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!ValidateCarInputs()) return;

                Car car = new Car
                {
                    Id_car = _selectedCarID,
                    Brand = txtCarBrand.Text.Trim(),
                    Model = txtCarModel.Text.Trim(),
                    Release_Year = new DateTime(int.Parse(txtCarYear.Text), 1, 1),
                    Gos_number = txtCarGosNumber.Text.Trim(),
                    Id_Client = (int)cmbCarClient.SelectedValue
                };

                if (_carRepo.Update(car))
                {
                    MessageBox.Show("Данные обновлены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCarsTab();
                }
                else
                {
                    MessageBox.Show("Не удалось обновить", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCarDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedCarID == -1)
                {
                    MessageBox.Show("Выберите автомобиль", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Удалить автомобиль?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_carRepo.Delete(_selectedCarID))
                    {
                        MessageBox.Show("Автомобиль удалён!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCarsTab();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось удалить", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCarRefresh_Click(object sender, EventArgs e)
        {
            LoadCarsTab();
        }

        private void btnCarClear_Click(object sender, EventArgs e)
        {
            ClearCarForm();
        }

        private void dgvCars_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvCars.Rows[e.RowIndex];
                    _selectedCarID = Convert.ToInt32(row.Cells["Id_car"].Value);
                    txtCarID.Text = _selectedCarID.ToString();
                    txtCarBrand.Text = row.Cells["Brand"].Value?.ToString() ?? "";
                    txtCarModel.Text = row.Cells["Model"].Value?.ToString() ?? "";
                    txtCarYear.Text = row.Cells["Release_Year"].Value?.ToString() ?? "";
                    txtCarGosNumber.Text = row.Cells["Gos_number"].Value?.ToString() ?? "";
                    int clientId = Convert.ToInt32(row.Cells["Id_Client"].Value);
                    cmbCarClient.SelectedValue = clientId;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCarSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCarSearch.Text))
                {
                    LoadCars();
                }
                else
                {
                    DataTable dt = _carRepo.Search(txtCarSearch.Text);
                    dgvCars.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region REPORTS

        private void LoadReportsTab()
        {
            try
            {
                reportViewer.ProcessingMode = ProcessingMode.Local;
                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.Clear();
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable reportData = _carRepo.GetReportData();

                if (reportData == null || reportData.Rows.Count == 0)
                {
                    MessageBox.Show("Нет данных для отчёта", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string reportPath = ResolveReportPath("ClientsCarsReport.rdlc");
                if (!System.IO.File.Exists(reportPath))
                {
                    MessageBox.Show("Файл отчёта не найден: " + reportPath, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                reportViewer.Reset();
                reportViewer.ProcessingMode = ProcessingMode.Local;
                reportViewer.LocalReport.ReportPath = reportPath;
                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.DataSources.Add(new ReportDataSource("ClientsCarsDataSet", reportData));
                reportViewer.LocalReport.Refresh();
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (reportViewer.LocalReport == null || reportViewer.LocalReport.DataSources.Count == 0)
                {
                    MessageBox.Show("Сначала сформируйте отчёт", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "PDF files (*.pdf)|*.pdf|Excel files (*.xlsx)|*.xlsx|Word files (*.docx)|*.docx";
                saveDialog.FileName = "Отчёт_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

                if (saveDialog.ShowDialog() != DialogResult.OK) return;

                string extension = System.IO.Path.GetExtension(saveDialog.FileName).ToLowerInvariant();
                string renderFormat = "PDF";
                if (extension == ".xlsx") renderFormat = "EXCELOPENXML";
                else if (extension == ".docx") renderFormat = "WORDOPENXML";

                string mimeType, encoding, fileNameExtension;
                string[] streamIds;
                Warning[] warnings;

                byte[] renderedBytes = reportViewer.LocalReport.Render(
                    renderFormat, null,
                    out mimeType, out encoding, out fileNameExtension, out streamIds, out warnings);

                System.IO.File.WriteAllBytes(saveDialog.FileName, renderedBytes);
                MessageBox.Show("Отчёт экспортирован!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ResolveReportPath(string reportFile)
        {
            string pathFromOutput = System.IO.Path.Combine(Application.StartupPath, "Reports", reportFile);
            if (System.IO.File.Exists(pathFromOutput)) return pathFromOutput;

            string pathFromProject = System.IO.Path.GetFullPath(
                System.IO.Path.Combine(Application.StartupPath, "..", "..", "Reports", reportFile));
            return pathFromProject;
        }

        #endregion
    }
}
