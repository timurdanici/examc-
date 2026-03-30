using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace exam
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabClients = new System.Windows.Forms.TabPage();
            this.tabCars = new System.Windows.Forms.TabPage();
            this.tabReports = new System.Windows.Forms.TabPage();

            // Clients tab controls
            this.dgvClients = new System.Windows.Forms.DataGridView();
            this.groupBoxClientDetails = new System.Windows.Forms.GroupBox();
            this.lblClientID = new System.Windows.Forms.Label();
            this.txtClientID = new System.Windows.Forms.TextBox();
            this.lblClientSurname = new System.Windows.Forms.Label();
            this.txtClientSurname = new System.Windows.Forms.TextBox();
            this.lblClientName = new System.Windows.Forms.Label();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.lblClientPhone = new System.Windows.Forms.Label();
            this.txtClientPhone = new System.Windows.Forms.TextBox();
            this.lblClientAddress = new System.Windows.Forms.Label();
            this.txtClientAddress = new System.Windows.Forms.TextBox();
            this.groupBoxClientOps = new System.Windows.Forms.GroupBox();
            this.btnClientAdd = new System.Windows.Forms.Button();
            this.btnClientUpdate = new System.Windows.Forms.Button();
            this.btnClientDelete = new System.Windows.Forms.Button();
            this.btnClientRefresh = new System.Windows.Forms.Button();
            this.btnClientClear = new System.Windows.Forms.Button();
            this.groupBoxClientSearch = new System.Windows.Forms.GroupBox();
            this.lblClientSearch = new System.Windows.Forms.Label();
            this.txtClientSearch = new System.Windows.Forms.TextBox();

            // Cars tab controls
            this.dgvCars = new System.Windows.Forms.DataGridView();
            this.groupBoxCarDetails = new System.Windows.Forms.GroupBox();
            this.lblCarID = new System.Windows.Forms.Label();
            this.txtCarID = new System.Windows.Forms.TextBox();
            this.lblCarBrand = new System.Windows.Forms.Label();
            this.txtCarBrand = new System.Windows.Forms.TextBox();
            this.lblCarModel = new System.Windows.Forms.Label();
            this.txtCarModel = new System.Windows.Forms.TextBox();
            this.lblCarYear = new System.Windows.Forms.Label();
            this.txtCarYear = new System.Windows.Forms.TextBox();
            this.lblCarGosNumber = new System.Windows.Forms.Label();
            this.txtCarGosNumber = new System.Windows.Forms.TextBox();
            this.lblCarClient = new System.Windows.Forms.Label();
            this.cmbCarClient = new System.Windows.Forms.ComboBox();
            this.groupBoxCarOps = new System.Windows.Forms.GroupBox();
            this.btnCarAdd = new System.Windows.Forms.Button();
            this.btnCarUpdate = new System.Windows.Forms.Button();
            this.btnCarDelete = new System.Windows.Forms.Button();
            this.btnCarRefresh = new System.Windows.Forms.Button();
            this.btnCarClear = new System.Windows.Forms.Button();
            this.groupBoxCarSearch = new System.Windows.Forms.GroupBox();
            this.lblCarSearch = new System.Windows.Forms.Label();
            this.txtCarSearch = new System.Windows.Forms.TextBox();

            // Reports tab controls
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBoxReportActions = new System.Windows.Forms.GroupBox();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.btnExportReport = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCars)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.tabClients.SuspendLayout();
            this.tabCars.SuspendLayout();
            this.tabReports.SuspendLayout();
            this.SuspendLayout();

            // tabControlMain
            this.tabControlMain.Controls.Add(this.tabClients);
            this.tabControlMain.Controls.Add(this.tabCars);
            this.tabControlMain.Controls.Add(this.tabReports);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1150, 680);
            this.tabControlMain.TabIndex = 0;

            // ==================== CLIENTS TAB ====================
            this.tabClients.Controls.Add(this.dgvClients);
            this.tabClients.Controls.Add(this.groupBoxClientDetails);
            this.tabClients.Controls.Add(this.groupBoxClientOps);
            this.tabClients.Controls.Add(this.groupBoxClientSearch);
            this.tabClients.Location = new System.Drawing.Point(4, 28);
            this.tabClients.Name = "tabClients";
            this.tabClients.Padding = new System.Windows.Forms.Padding(3);
            this.tabClients.Size = new System.Drawing.Size(1142, 648);
            this.tabClients.TabIndex = 0;
            this.tabClients.Text = "Клиенты";
            this.tabClients.UseVisualStyleBackColor = true;

            // groupBoxClientSearch
            this.groupBoxClientSearch.Controls.Add(this.lblClientSearch);
            this.groupBoxClientSearch.Controls.Add(this.txtClientSearch);
            this.groupBoxClientSearch.Location = new System.Drawing.Point(8, 8);
            this.groupBoxClientSearch.Name = "groupBoxClientSearch";
            this.groupBoxClientSearch.Size = new System.Drawing.Size(730, 50);
            this.groupBoxClientSearch.TabIndex = 0;
            this.groupBoxClientSearch.Text = "Поиск";

            this.lblClientSearch.AutoSize = true;
            this.lblClientSearch.Location = new System.Drawing.Point(8, 20);
            this.lblClientSearch.Name = "lblClientSearch";
            this.lblClientSearch.Text = "Поиск:";

            this.txtClientSearch.Location = new System.Drawing.Point(65, 17);
            this.txtClientSearch.Name = "txtClientSearch";
            this.txtClientSearch.Size = new System.Drawing.Size(650, 26);
            this.txtClientSearch.TabIndex = 1;
            this.txtClientSearch.TextChanged += new System.EventHandler(this.txtClientSearch_TextChanged);

            // dgvClients
            this.dgvClients.AllowUserToAddRows = false;
            this.dgvClients.AllowUserToDeleteRows = false;
            this.dgvClients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClients.Location = new System.Drawing.Point(8, 65);
            this.dgvClients.MultiSelect = false;
            this.dgvClients.Name = "dgvClients";
            this.dgvClients.ReadOnly = true;
            this.dgvClients.RowHeadersWidth = 51;
            this.dgvClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClients.Size = new System.Drawing.Size(730, 570);
            this.dgvClients.TabIndex = 1;
            this.dgvClients.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClients_CellClick);

            // groupBoxClientDetails
            this.groupBoxClientDetails.Controls.Add(this.lblClientID);
            this.groupBoxClientDetails.Controls.Add(this.txtClientID);
            this.groupBoxClientDetails.Controls.Add(this.lblClientSurname);
            this.groupBoxClientDetails.Controls.Add(this.txtClientSurname);
            this.groupBoxClientDetails.Controls.Add(this.lblClientName);
            this.groupBoxClientDetails.Controls.Add(this.txtClientName);
            this.groupBoxClientDetails.Controls.Add(this.lblClientPhone);
            this.groupBoxClientDetails.Controls.Add(this.txtClientPhone);
            this.groupBoxClientDetails.Controls.Add(this.lblClientAddress);
            this.groupBoxClientDetails.Controls.Add(this.txtClientAddress);
            this.groupBoxClientDetails.Location = new System.Drawing.Point(750, 8);
            this.groupBoxClientDetails.Name = "groupBoxClientDetails";
            this.groupBoxClientDetails.Size = new System.Drawing.Size(380, 330);
            this.groupBoxClientDetails.TabIndex = 2;
            this.groupBoxClientDetails.Text = "Данные клиента";

            this.lblClientID.AutoSize = true;
            this.lblClientID.Location = new System.Drawing.Point(10, 30);
            this.lblClientID.Name = "lblClientID";
            this.lblClientID.Text = "ID:";

            this.txtClientID.Location = new System.Drawing.Point(130, 27);
            this.txtClientID.Name = "txtClientID";
            this.txtClientID.ReadOnly = true;
            this.txtClientID.Size = new System.Drawing.Size(230, 26);
            this.txtClientID.TabIndex = 0;

            this.lblClientSurname.AutoSize = true;
            this.lblClientSurname.Location = new System.Drawing.Point(10, 70);
            this.lblClientSurname.Name = "lblClientSurname";
            this.lblClientSurname.Text = "Фамилия:";

            this.txtClientSurname.Location = new System.Drawing.Point(130, 67);
            this.txtClientSurname.Name = "txtClientSurname";
            this.txtClientSurname.Size = new System.Drawing.Size(230, 26);
            this.txtClientSurname.TabIndex = 1;

            this.lblClientName.AutoSize = true;
            this.lblClientName.Location = new System.Drawing.Point(10, 110);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Text = "Имя:";

            this.txtClientName.Location = new System.Drawing.Point(130, 107);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(230, 26);
            this.txtClientName.TabIndex = 2;

            this.lblClientPhone.AutoSize = true;
            this.lblClientPhone.Location = new System.Drawing.Point(10, 150);
            this.lblClientPhone.Name = "lblClientPhone";
            this.lblClientPhone.Text = "Телефон:";

            this.txtClientPhone.Location = new System.Drawing.Point(130, 147);
            this.txtClientPhone.Name = "txtClientPhone";
            this.txtClientPhone.Size = new System.Drawing.Size(230, 26);
            this.txtClientPhone.TabIndex = 3;

            this.lblClientAddress.AutoSize = true;
            this.lblClientAddress.Location = new System.Drawing.Point(10, 190);
            this.lblClientAddress.Name = "lblClientAddress";
            this.lblClientAddress.Text = "Адрес:";

            this.txtClientAddress.Location = new System.Drawing.Point(130, 187);
            this.txtClientAddress.Name = "txtClientAddress";
            this.txtClientAddress.Size = new System.Drawing.Size(230, 26);
            this.txtClientAddress.TabIndex = 4;

            // groupBoxClientOps
            this.groupBoxClientOps.Controls.Add(this.btnClientAdd);
            this.groupBoxClientOps.Controls.Add(this.btnClientUpdate);
            this.groupBoxClientOps.Controls.Add(this.btnClientDelete);
            this.groupBoxClientOps.Controls.Add(this.btnClientRefresh);
            this.groupBoxClientOps.Controls.Add(this.btnClientClear);
            this.groupBoxClientOps.Location = new System.Drawing.Point(750, 350);
            this.groupBoxClientOps.Name = "groupBoxClientOps";
            this.groupBoxClientOps.Size = new System.Drawing.Size(380, 285);
            this.groupBoxClientOps.TabIndex = 3;
            this.groupBoxClientOps.Text = "Операции";

            this.btnClientAdd.Location = new System.Drawing.Point(10, 30);
            this.btnClientAdd.Name = "btnClientAdd";
            this.btnClientAdd.Size = new System.Drawing.Size(355, 40);
            this.btnClientAdd.TabIndex = 0;
            this.btnClientAdd.Text = "Добавить";
            this.btnClientAdd.UseVisualStyleBackColor = true;
            this.btnClientAdd.Click += new System.EventHandler(this.btnClientAdd_Click);

            this.btnClientUpdate.Location = new System.Drawing.Point(10, 80);
            this.btnClientUpdate.Name = "btnClientUpdate";
            this.btnClientUpdate.Size = new System.Drawing.Size(355, 40);
            this.btnClientUpdate.TabIndex = 1;
            this.btnClientUpdate.Text = "Изменить";
            this.btnClientUpdate.UseVisualStyleBackColor = true;
            this.btnClientUpdate.Click += new System.EventHandler(this.btnClientUpdate_Click);

            this.btnClientDelete.Location = new System.Drawing.Point(10, 130);
            this.btnClientDelete.Name = "btnClientDelete";
            this.btnClientDelete.Size = new System.Drawing.Size(355, 40);
            this.btnClientDelete.TabIndex = 2;
            this.btnClientDelete.Text = "Удалить";
            this.btnClientDelete.UseVisualStyleBackColor = true;
            this.btnClientDelete.Click += new System.EventHandler(this.btnClientDelete_Click);

            this.btnClientRefresh.Location = new System.Drawing.Point(10, 180);
            this.btnClientRefresh.Name = "btnClientRefresh";
            this.btnClientRefresh.Size = new System.Drawing.Size(170, 40);
            this.btnClientRefresh.TabIndex = 3;
            this.btnClientRefresh.Text = "Обновить";
            this.btnClientRefresh.UseVisualStyleBackColor = true;
            this.btnClientRefresh.Click += new System.EventHandler(this.btnClientRefresh_Click);

            this.btnClientClear.Location = new System.Drawing.Point(195, 180);
            this.btnClientClear.Name = "btnClientClear";
            this.btnClientClear.Size = new System.Drawing.Size(170, 40);
            this.btnClientClear.TabIndex = 4;
            this.btnClientClear.Text = "Очистить";
            this.btnClientClear.UseVisualStyleBackColor = true;
            this.btnClientClear.Click += new System.EventHandler(this.btnClientClear_Click);

            // ==================== CARS TAB ====================
            this.tabCars.Controls.Add(this.dgvCars);
            this.tabCars.Controls.Add(this.groupBoxCarDetails);
            this.tabCars.Controls.Add(this.groupBoxCarOps);
            this.tabCars.Controls.Add(this.groupBoxCarSearch);
            this.tabCars.Location = new System.Drawing.Point(4, 28);
            this.tabCars.Name = "tabCars";
            this.tabCars.Padding = new System.Windows.Forms.Padding(3);
            this.tabCars.Size = new System.Drawing.Size(1142, 648);
            this.tabCars.TabIndex = 1;
            this.tabCars.Text = "Автомобили";
            this.tabCars.UseVisualStyleBackColor = true;

            // groupBoxCarSearch
            this.groupBoxCarSearch.Controls.Add(this.lblCarSearch);
            this.groupBoxCarSearch.Controls.Add(this.txtCarSearch);
            this.groupBoxCarSearch.Location = new System.Drawing.Point(8, 8);
            this.groupBoxCarSearch.Name = "groupBoxCarSearch";
            this.groupBoxCarSearch.Size = new System.Drawing.Size(730, 50);
            this.groupBoxCarSearch.TabIndex = 0;
            this.groupBoxCarSearch.Text = "Поиск (по марке или номеру)";

            this.lblCarSearch.AutoSize = true;
            this.lblCarSearch.Location = new System.Drawing.Point(8, 20);
            this.lblCarSearch.Name = "lblCarSearch";
            this.lblCarSearch.Text = "Поиск:";

            this.txtCarSearch.Location = new System.Drawing.Point(65, 17);
            this.txtCarSearch.Name = "txtCarSearch";
            this.txtCarSearch.Size = new System.Drawing.Size(650, 26);
            this.txtCarSearch.TabIndex = 1;
            this.txtCarSearch.TextChanged += new System.EventHandler(this.txtCarSearch_TextChanged);

            // dgvCars
            this.dgvCars.AllowUserToAddRows = false;
            this.dgvCars.AllowUserToDeleteRows = false;
            this.dgvCars.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCars.Location = new System.Drawing.Point(8, 65);
            this.dgvCars.MultiSelect = false;
            this.dgvCars.Name = "dgvCars";
            this.dgvCars.ReadOnly = true;
            this.dgvCars.RowHeadersWidth = 51;
            this.dgvCars.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCars.Size = new System.Drawing.Size(730, 570);
            this.dgvCars.TabIndex = 1;
            this.dgvCars.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCars_CellClick);

            // groupBoxCarDetails
            this.groupBoxCarDetails.Controls.Add(this.lblCarID);
            this.groupBoxCarDetails.Controls.Add(this.txtCarID);
            this.groupBoxCarDetails.Controls.Add(this.lblCarBrand);
            this.groupBoxCarDetails.Controls.Add(this.txtCarBrand);
            this.groupBoxCarDetails.Controls.Add(this.lblCarModel);
            this.groupBoxCarDetails.Controls.Add(this.txtCarModel);
            this.groupBoxCarDetails.Controls.Add(this.lblCarYear);
            this.groupBoxCarDetails.Controls.Add(this.txtCarYear);
            this.groupBoxCarDetails.Controls.Add(this.lblCarGosNumber);
            this.groupBoxCarDetails.Controls.Add(this.txtCarGosNumber);
            this.groupBoxCarDetails.Controls.Add(this.lblCarClient);
            this.groupBoxCarDetails.Controls.Add(this.cmbCarClient);
            this.groupBoxCarDetails.Location = new System.Drawing.Point(750, 8);
            this.groupBoxCarDetails.Name = "groupBoxCarDetails";
            this.groupBoxCarDetails.Size = new System.Drawing.Size(380, 370);
            this.groupBoxCarDetails.TabIndex = 2;
            this.groupBoxCarDetails.Text = "Данные автомобиля";

            this.lblCarID.AutoSize = true;
            this.lblCarID.Location = new System.Drawing.Point(10, 30);
            this.lblCarID.Name = "lblCarID";
            this.lblCarID.Text = "ID:";

            this.txtCarID.Location = new System.Drawing.Point(130, 27);
            this.txtCarID.Name = "txtCarID";
            this.txtCarID.ReadOnly = true;
            this.txtCarID.Size = new System.Drawing.Size(230, 26);
            this.txtCarID.TabIndex = 0;

            this.lblCarBrand.AutoSize = true;
            this.lblCarBrand.Location = new System.Drawing.Point(10, 70);
            this.lblCarBrand.Name = "lblCarBrand";
            this.lblCarBrand.Text = "Марка:";

            this.txtCarBrand.Location = new System.Drawing.Point(130, 67);
            this.txtCarBrand.Name = "txtCarBrand";
            this.txtCarBrand.Size = new System.Drawing.Size(230, 26);
            this.txtCarBrand.TabIndex = 1;

            this.lblCarModel.AutoSize = true;
            this.lblCarModel.Location = new System.Drawing.Point(10, 110);
            this.lblCarModel.Name = "lblCarModel";
            this.lblCarModel.Text = "Модель:";

            this.txtCarModel.Location = new System.Drawing.Point(130, 107);
            this.txtCarModel.Name = "txtCarModel";
            this.txtCarModel.Size = new System.Drawing.Size(230, 26);
            this.txtCarModel.TabIndex = 2;

            this.lblCarYear.AutoSize = true;
            this.lblCarYear.Location = new System.Drawing.Point(10, 150);
            this.lblCarYear.Name = "lblCarYear";
            this.lblCarYear.Text = "Год выпуска:";

            this.txtCarYear.Location = new System.Drawing.Point(130, 147);
            this.txtCarYear.Name = "txtCarYear";
            this.txtCarYear.Size = new System.Drawing.Size(230, 26);
            this.txtCarYear.TabIndex = 3;

            this.lblCarGosNumber.AutoSize = true;
            this.lblCarGosNumber.Location = new System.Drawing.Point(10, 190);
            this.lblCarGosNumber.Name = "lblCarGosNumber";
            this.lblCarGosNumber.Text = "Гос. номер:";

            this.txtCarGosNumber.Location = new System.Drawing.Point(130, 187);
            this.txtCarGosNumber.Name = "txtCarGosNumber";
            this.txtCarGosNumber.Size = new System.Drawing.Size(230, 26);
            this.txtCarGosNumber.TabIndex = 4;

            this.lblCarClient.AutoSize = true;
            this.lblCarClient.Location = new System.Drawing.Point(10, 230);
            this.lblCarClient.Name = "lblCarClient";
            this.lblCarClient.Text = "Клиент:";

            this.cmbCarClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCarClient.FormattingEnabled = true;
            this.cmbCarClient.Location = new System.Drawing.Point(130, 227);
            this.cmbCarClient.Name = "cmbCarClient";
            this.cmbCarClient.Size = new System.Drawing.Size(230, 28);
            this.cmbCarClient.TabIndex = 5;

            // groupBoxCarOps
            this.groupBoxCarOps.Controls.Add(this.btnCarAdd);
            this.groupBoxCarOps.Controls.Add(this.btnCarUpdate);
            this.groupBoxCarOps.Controls.Add(this.btnCarDelete);
            this.groupBoxCarOps.Controls.Add(this.btnCarRefresh);
            this.groupBoxCarOps.Controls.Add(this.btnCarClear);
            this.groupBoxCarOps.Location = new System.Drawing.Point(750, 390);
            this.groupBoxCarOps.Name = "groupBoxCarOps";
            this.groupBoxCarOps.Size = new System.Drawing.Size(380, 245);
            this.groupBoxCarOps.TabIndex = 3;
            this.groupBoxCarOps.Text = "Операции";

            this.btnCarAdd.Location = new System.Drawing.Point(10, 30);
            this.btnCarAdd.Name = "btnCarAdd";
            this.btnCarAdd.Size = new System.Drawing.Size(355, 40);
            this.btnCarAdd.TabIndex = 0;
            this.btnCarAdd.Text = "Добавить";
            this.btnCarAdd.UseVisualStyleBackColor = true;
            this.btnCarAdd.Click += new System.EventHandler(this.btnCarAdd_Click);

            this.btnCarUpdate.Location = new System.Drawing.Point(10, 80);
            this.btnCarUpdate.Name = "btnCarUpdate";
            this.btnCarUpdate.Size = new System.Drawing.Size(355, 40);
            this.btnCarUpdate.TabIndex = 1;
            this.btnCarUpdate.Text = "Изменить";
            this.btnCarUpdate.UseVisualStyleBackColor = true;
            this.btnCarUpdate.Click += new System.EventHandler(this.btnCarUpdate_Click);

            this.btnCarDelete.Location = new System.Drawing.Point(10, 130);
            this.btnCarDelete.Name = "btnCarDelete";
            this.btnCarDelete.Size = new System.Drawing.Size(355, 40);
            this.btnCarDelete.TabIndex = 2;
            this.btnCarDelete.Text = "Удалить";
            this.btnCarDelete.UseVisualStyleBackColor = true;
            this.btnCarDelete.Click += new System.EventHandler(this.btnCarDelete_Click);

            this.btnCarRefresh.Location = new System.Drawing.Point(10, 185);
            this.btnCarRefresh.Name = "btnCarRefresh";
            this.btnCarRefresh.Size = new System.Drawing.Size(170, 40);
            this.btnCarRefresh.TabIndex = 3;
            this.btnCarRefresh.Text = "Обновить";
            this.btnCarRefresh.UseVisualStyleBackColor = true;
            this.btnCarRefresh.Click += new System.EventHandler(this.btnCarRefresh_Click);

            this.btnCarClear.Location = new System.Drawing.Point(195, 185);
            this.btnCarClear.Name = "btnCarClear";
            this.btnCarClear.Size = new System.Drawing.Size(170, 40);
            this.btnCarClear.TabIndex = 4;
            this.btnCarClear.Text = "Очистить";
            this.btnCarClear.UseVisualStyleBackColor = true;
            this.btnCarClear.Click += new System.EventHandler(this.btnCarClear_Click);

            // ==================== REPORTS TAB ====================
            this.tabReports.Controls.Add(this.groupBoxReportActions);
            this.tabReports.Controls.Add(this.reportViewer);
            this.tabReports.Location = new System.Drawing.Point(4, 28);
            this.tabReports.Name = "tabReports";
            this.tabReports.Padding = new System.Windows.Forms.Padding(3);
            this.tabReports.Size = new System.Drawing.Size(1142, 648);
            this.tabReports.TabIndex = 2;
            this.tabReports.Text = "Отчёт";
            this.tabReports.UseVisualStyleBackColor = true;

            // groupBoxReportActions
            this.groupBoxReportActions.Controls.Add(this.btnGenerateReport);
            this.groupBoxReportActions.Controls.Add(this.btnExportReport);
            this.groupBoxReportActions.Location = new System.Drawing.Point(8, 8);
            this.groupBoxReportActions.Name = "groupBoxReportActions";
            this.groupBoxReportActions.Size = new System.Drawing.Size(1126, 60);
            this.groupBoxReportActions.TabIndex = 0;
            this.groupBoxReportActions.Text = "Действия";

            this.btnGenerateReport.Location = new System.Drawing.Point(10, 18);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(200, 35);
            this.btnGenerateReport.TabIndex = 0;
            this.btnGenerateReport.Text = "Сформировать отчёт";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);

            this.btnExportReport.Location = new System.Drawing.Point(220, 18);
            this.btnExportReport.Name = "btnExportReport";
            this.btnExportReport.Size = new System.Drawing.Size(200, 35);
            this.btnExportReport.TabIndex = 1;
            this.btnExportReport.Text = "Экспортировать";
            this.btnExportReport.UseVisualStyleBackColor = true;
            this.btnExportReport.Click += new System.EventHandler(this.btnExportReport_Click);

            // reportViewer
            this.reportViewer.Location = new System.Drawing.Point(8, 75);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.Size = new System.Drawing.Size(1126, 560);
            this.reportViewer.TabIndex = 1;

            // ==================== FORM ====================
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 680);
            this.Controls.Add(this.tabControlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "Form1";
            this.Text = "Автосервис";
            this.Load += new System.EventHandler(this.Form1_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCars)).EndInit();
            this.tabControlMain.ResumeLayout(false);
            this.tabClients.ResumeLayout(false);
            this.tabCars.ResumeLayout(false);
            this.tabReports.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        // TabControl
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabClients;
        private System.Windows.Forms.TabPage tabCars;
        private System.Windows.Forms.TabPage tabReports;

        // Clients
        private System.Windows.Forms.DataGridView dgvClients;
        private System.Windows.Forms.GroupBox groupBoxClientDetails;
        private System.Windows.Forms.Label lblClientID;
        private System.Windows.Forms.TextBox txtClientID;
        private System.Windows.Forms.Label lblClientSurname;
        private System.Windows.Forms.TextBox txtClientSurname;
        private System.Windows.Forms.Label lblClientName;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.Label lblClientPhone;
        private System.Windows.Forms.TextBox txtClientPhone;
        private System.Windows.Forms.Label lblClientAddress;
        private System.Windows.Forms.TextBox txtClientAddress;
        private System.Windows.Forms.GroupBox groupBoxClientOps;
        private System.Windows.Forms.Button btnClientAdd;
        private System.Windows.Forms.Button btnClientUpdate;
        private System.Windows.Forms.Button btnClientDelete;
        private System.Windows.Forms.Button btnClientRefresh;
        private System.Windows.Forms.Button btnClientClear;
        private System.Windows.Forms.GroupBox groupBoxClientSearch;
        private System.Windows.Forms.Label lblClientSearch;
        private System.Windows.Forms.TextBox txtClientSearch;

        // Cars
        private System.Windows.Forms.DataGridView dgvCars;
        private System.Windows.Forms.GroupBox groupBoxCarDetails;
        private System.Windows.Forms.Label lblCarID;
        private System.Windows.Forms.TextBox txtCarID;
        private System.Windows.Forms.Label lblCarBrand;
        private System.Windows.Forms.TextBox txtCarBrand;
        private System.Windows.Forms.Label lblCarModel;
        private System.Windows.Forms.TextBox txtCarModel;
        private System.Windows.Forms.Label lblCarYear;
        private System.Windows.Forms.TextBox txtCarYear;
        private System.Windows.Forms.Label lblCarGosNumber;
        private System.Windows.Forms.TextBox txtCarGosNumber;
        private System.Windows.Forms.Label lblCarClient;
        private System.Windows.Forms.ComboBox cmbCarClient;
        private System.Windows.Forms.GroupBox groupBoxCarOps;
        private System.Windows.Forms.Button btnCarAdd;
        private System.Windows.Forms.Button btnCarUpdate;
        private System.Windows.Forms.Button btnCarDelete;
        private System.Windows.Forms.Button btnCarRefresh;
        private System.Windows.Forms.Button btnCarClear;
        private System.Windows.Forms.GroupBox groupBoxCarSearch;
        private System.Windows.Forms.Label lblCarSearch;
        private System.Windows.Forms.TextBox txtCarSearch;

        // Reports
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.GroupBox groupBoxReportActions;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Button btnExportReport;
    }
}
