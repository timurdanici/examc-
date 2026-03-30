using System.Drawing;
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
            if (disposing)
            {
                FontTitle?.Dispose();
                FontSub?.Dispose();
                FontLabel?.Dispose();
                FontInput?.Dispose();
                FontTab?.Dispose();
                FontBtn?.Dispose();
                FontGroup?.Dispose();
            }
            base.Dispose(disposing);
        }

        // ── Colour palette ────────────────────────────────────────────────────
        private static readonly Color ClrNavy      = Color.FromArgb(15, 32, 65);   // header / tab strip
        private static readonly Color ClrDarkBlue  = Color.FromArgb(22, 50, 100);  // sidebar panels
        private static readonly Color ClrOrange    = Color.FromArgb(230, 100, 20); // primary accent
        private static readonly Color ClrGreen     = Color.FromArgb(39, 174, 96);
        private static readonly Color ClrBlue      = Color.FromArgb(41, 128, 185);
        private static readonly Color ClrRed       = Color.FromArgb(192, 57, 43);
        private static readonly Color ClrSlate     = Color.FromArgb(100, 116, 139);
        private static readonly Color ClrPageBg    = Color.FromArgb(240, 244, 248);
        private static readonly Color ClrCardBg    = Color.White;
        private static readonly Color ClrTextDark  = Color.FromArgb(30, 40, 55);
        private static readonly Color ClrTextLight = Color.White;
        private static readonly Color ClrBorder    = Color.FromArgb(200, 210, 225);
        private static readonly Color ClrGridHdr   = Color.FromArgb(22, 50, 100);
        private static readonly Color ClrGridSel   = Color.FromArgb(230, 100, 20);

        // ── Fonts ─────────────────────────────────────────────────────────────
        private readonly Font FontTitle  = new Font("Segoe UI", 18F, FontStyle.Bold);
        private readonly Font FontSub    = new Font("Segoe UI", 9F, FontStyle.Regular);
        private readonly Font FontLabel  = new Font("Segoe UI", 9F, FontStyle.Bold);
        private readonly Font FontInput  = new Font("Segoe UI", 9.5F);
        private readonly Font FontTab    = new Font("Segoe UI", 10F, FontStyle.Bold);
        private readonly Font FontBtn    = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        private readonly Font FontGroup  = new Font("Segoe UI", 9F, FontStyle.Bold);

        // ── Helpers ───────────────────────────────────────────────────────────
        private Button MakeBtn(string text, Color back, int x, int y, int w = 355, int h = 40)
        {
            var b = new Button
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(w, h),
                BackColor = back,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = FontBtn,
                Cursor = Cursors.Hand
            };
            b.FlatAppearance.BorderSize = 0;
            return b;
        }

        private GroupBox MakeGroup(string text, int x, int y, int w, int h)
        {
            return new GroupBox
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(w, h),
                BackColor = ClrCardBg,
                ForeColor = ClrDarkBlue,
                Font = FontGroup
            };
        }

        private Label MakeLbl(string text, int x, int y)
        {
            return new Label
            {
                Text = text,
                Location = new Point(x, y),
                AutoSize = true,
                Font = FontLabel,
                ForeColor = ClrTextDark
            };
        }

        private TextBox MakeTxt(int x, int y, int w, bool ro = false)
        {
            return new TextBox
            {
                Location = new Point(x, y),
                Size = new Size(w, 28),
                Font = FontInput,
                BackColor = ro ? Color.FromArgb(235, 240, 248) : Color.White,
                ForeColor = ClrTextDark,
                BorderStyle = BorderStyle.FixedSingle,
                ReadOnly = ro
            };
        }

        private void StyleDgv(DataGridView dgv)
        {
            dgv.BackgroundColor = ClrCardBg;
            dgv.BorderStyle = BorderStyle.None;
            dgv.GridColor = ClrBorder;
            dgv.RowsDefaultCellStyle.BackColor = Color.White;
            dgv.RowsDefaultCellStyle.ForeColor = ClrTextDark;
            dgv.RowsDefaultCellStyle.Font = FontSub;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 252);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = ClrGridHdr;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = FontLabel;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(4, 0, 0, 0);
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersHeight = 34;
            dgv.DefaultCellStyle.SelectionBackColor = ClrGridSel;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.RowTemplate.Height = 28;
        }

        private void InitializeComponent()
        {
            // ── Instantiate all controls ──────────────────────────────────────
            this.panelHeader        = new Panel();
            this.lblAppTitle        = new Label();
            this.lblAppSubtitle     = new Label();
            this.panelAccentLine    = new Panel();

            this.tabControlMain = new TabControl();
            this.tabClients     = new TabPage();
            this.tabCars        = new TabPage();
            this.tabReports     = new TabPage();

            // Clients
            this.dgvClients            = new DataGridView();
            this.groupBoxClientDetails = MakeGroup("Данные клиента", 750, 10, 385, 335);
            this.lblClientID           = MakeLbl("ID:", 12, 32);
            this.txtClientID           = MakeTxt(140, 29, 225, ro: true);
            this.lblClientSurname      = MakeLbl("Фамилия:", 12, 72);
            this.txtClientSurname      = MakeTxt(140, 69, 225);
            this.lblClientName         = MakeLbl("Имя:", 12, 112);
            this.txtClientName         = MakeTxt(140, 109, 225);
            this.lblClientPhone        = MakeLbl("Телефон:", 12, 152);
            this.txtClientPhone        = MakeTxt(140, 149, 225);
            this.lblClientAddress      = MakeLbl("Адрес:", 12, 192);
            this.txtClientAddress      = MakeTxt(140, 189, 225);
            this.groupBoxClientOps     = MakeGroup("Операции", 750, 355, 385, 285);
            this.btnClientAdd          = MakeBtn("＋  Добавить клиента", ClrGreen,  10, 30);
            this.btnClientUpdate       = MakeBtn("✎  Изменить",          ClrBlue,   10, 80);
            this.btnClientDelete       = MakeBtn("✕  Удалить",           ClrRed,    10, 130);
            this.btnClientRefresh      = MakeBtn("↻  Обновить",          ClrSlate,  10, 185, 175);
            this.btnClientClear        = MakeBtn("⊘  Очистить",          ClrSlate,  198, 185, 175);
            this.groupBoxClientSearch  = MakeGroup("🔍  Поиск клиентов", 8, 10, 730, 52);
            this.lblClientSearch       = MakeLbl("Поиск:", 10, 20);
            this.txtClientSearch       = MakeTxt(68, 17, 645);

            // Cars
            this.dgvCars            = new DataGridView();
            this.groupBoxCarDetails = MakeGroup("Данные автомобиля", 750, 10, 385, 380);
            this.lblCarID           = MakeLbl("ID:", 12, 32);
            this.txtCarID           = MakeTxt(140, 29, 225, ro: true);
            this.lblCarBrand        = MakeLbl("Марка:", 12, 72);
            this.txtCarBrand        = MakeTxt(140, 69, 225);
            this.lblCarModel        = MakeLbl("Модель:", 12, 112);
            this.txtCarModel        = MakeTxt(140, 109, 225);
            this.lblCarYear         = MakeLbl("Год выпуска:", 12, 152);
            this.txtCarYear         = MakeTxt(140, 149, 225);
            this.lblCarGosNumber    = MakeLbl("Гос. номер:", 12, 192);
            this.txtCarGosNumber    = MakeTxt(140, 189, 225);
            this.lblCarClient       = MakeLbl("Клиент:", 12, 232);
            this.cmbCarClient       = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                FormattingEnabled = true,
                Location = new Point(140, 229),
                Size = new Size(225, 28),
                Font = FontInput,
                FlatStyle = FlatStyle.Flat
            };
            this.groupBoxCarOps     = MakeGroup("Операции", 750, 400, 385, 250);
            this.btnCarAdd          = MakeBtn("＋  Добавить автомобиль", ClrGreen,  10, 30);
            this.btnCarUpdate       = MakeBtn("✎  Изменить",             ClrBlue,   10, 80);
            this.btnCarDelete       = MakeBtn("✕  Удалить",              ClrRed,    10, 130);
            this.btnCarRefresh      = MakeBtn("↻  Обновить",             ClrSlate,  10, 185, 175);
            this.btnCarClear        = MakeBtn("⊘  Очистить",             ClrSlate,  198, 185, 175);
            this.groupBoxCarSearch  = MakeGroup("🔍  Поиск (марка / гос. номер)", 8, 10, 730, 52);
            this.lblCarSearch       = MakeLbl("Поиск:", 10, 20);
            this.txtCarSearch       = MakeTxt(68, 17, 645);

            // Reports
            this.reportViewer         = new ReportViewer();
            this.groupBoxReportActions = MakeGroup("Действия", 8, 8, 1126, 60);
            this.btnGenerateReport    = MakeBtn("📄  Сформировать отчёт", ClrOrange, 10, 16, 210, 36);
            this.btnExportReport      = MakeBtn("⬇  Экспортировать",     ClrSlate,  230, 16, 210, 36);

            // ── Begin init ────────────────────────────────────────────────────
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCars)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.tabClients.SuspendLayout();
            this.tabCars.SuspendLayout();
            this.tabReports.SuspendLayout();
            this.SuspendLayout();

            // ── Header panel ──────────────────────────────────────────────────
            this.panelHeader.BackColor = ClrNavy;
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Height = 70;
            this.panelHeader.Name = "panelHeader";

            this.lblAppTitle.Text = "🔧  АВТОСЕРВИС";
            this.lblAppTitle.Font = FontTitle;
            this.lblAppTitle.ForeColor = ClrOrange;
            this.lblAppTitle.AutoSize = true;
            this.lblAppTitle.Location = new Point(16, 10);
            this.lblAppTitle.BackColor = Color.Transparent;

            this.lblAppSubtitle.Text = "Система управления клиентами и автомобилями";
            this.lblAppSubtitle.Font = FontSub;
            this.lblAppSubtitle.ForeColor = Color.FromArgb(180, 200, 230);
            this.lblAppSubtitle.AutoSize = true;
            this.lblAppSubtitle.Location = new Point(18, 46);
            this.lblAppSubtitle.BackColor = Color.Transparent;

            this.panelAccentLine.BackColor = ClrOrange;
            this.panelAccentLine.Dock = DockStyle.Bottom;
            this.panelAccentLine.Height = 3;

            this.panelHeader.Controls.Add(this.lblAppTitle);
            this.panelHeader.Controls.Add(this.lblAppSubtitle);
            this.panelHeader.Controls.Add(this.panelAccentLine);

            // ── TabControl ────────────────────────────────────────────────────
            this.tabControlMain.Controls.Add(this.tabClients);
            this.tabControlMain.Controls.Add(this.tabCars);
            this.tabControlMain.Controls.Add(this.tabReports);
            this.tabControlMain.Dock = DockStyle.Fill;
            this.tabControlMain.Font = FontTab;
            this.tabControlMain.Padding = new Point(14, 6);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;

            // ── Clients tab ───────────────────────────────────────────────────
            this.tabClients.BackColor = ClrPageBg;
            this.tabClients.Controls.Add(this.dgvClients);
            this.tabClients.Controls.Add(this.groupBoxClientDetails);
            this.tabClients.Controls.Add(this.groupBoxClientOps);
            this.tabClients.Controls.Add(this.groupBoxClientSearch);
            this.tabClients.Name = "tabClients";
            this.tabClients.Padding = new Padding(4);
            this.tabClients.Text = "  👤 Клиенты  ";
            this.tabClients.TabIndex = 0;

            this.txtClientSearch.TextChanged += new System.EventHandler(this.txtClientSearch_TextChanged);

            StyleDgv(this.dgvClients);
            this.dgvClients.AllowUserToAddRows = false;
            this.dgvClients.AllowUserToDeleteRows = false;
            this.dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvClients.Location = new Point(8, 70);
            this.dgvClients.MultiSelect = false;
            this.dgvClients.Name = "dgvClients";
            this.dgvClients.ReadOnly = true;
            this.dgvClients.RowHeadersVisible = false;
            this.dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvClients.Size = new Size(730, 568);
            this.dgvClients.TabIndex = 1;
            this.dgvClients.CellClick += new DataGridViewCellEventHandler(this.dgvClients_CellClick);

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
            this.groupBoxClientDetails.TabIndex = 2;

            this.groupBoxClientOps.Controls.Add(this.btnClientAdd);
            this.groupBoxClientOps.Controls.Add(this.btnClientUpdate);
            this.groupBoxClientOps.Controls.Add(this.btnClientDelete);
            this.groupBoxClientOps.Controls.Add(this.btnClientRefresh);
            this.groupBoxClientOps.Controls.Add(this.btnClientClear);
            this.groupBoxClientOps.TabIndex = 3;

            this.btnClientAdd.TabIndex    = 0;
            this.btnClientUpdate.TabIndex = 1;
            this.btnClientDelete.TabIndex = 2;
            this.btnClientRefresh.TabIndex = 3;
            this.btnClientClear.TabIndex  = 4;
            this.btnClientAdd.Click    += new System.EventHandler(this.btnClientAdd_Click);
            this.btnClientUpdate.Click += new System.EventHandler(this.btnClientUpdate_Click);
            this.btnClientDelete.Click += new System.EventHandler(this.btnClientDelete_Click);
            this.btnClientRefresh.Click += new System.EventHandler(this.btnClientRefresh_Click);
            this.btnClientClear.Click  += new System.EventHandler(this.btnClientClear_Click);

            this.groupBoxClientSearch.Controls.Add(this.lblClientSearch);
            this.groupBoxClientSearch.Controls.Add(this.txtClientSearch);
            this.groupBoxClientSearch.TabIndex = 0;
            this.txtClientSearch.TabIndex = 1;

            this.txtClientID.TabIndex      = 0;
            this.txtClientSurname.TabIndex = 1;
            this.txtClientName.TabIndex    = 2;
            this.txtClientPhone.TabIndex   = 3;
            this.txtClientAddress.TabIndex = 4;

            // ── Cars tab ──────────────────────────────────────────────────────
            this.tabCars.BackColor = ClrPageBg;
            this.tabCars.Controls.Add(this.dgvCars);
            this.tabCars.Controls.Add(this.groupBoxCarDetails);
            this.tabCars.Controls.Add(this.groupBoxCarOps);
            this.tabCars.Controls.Add(this.groupBoxCarSearch);
            this.tabCars.Name = "tabCars";
            this.tabCars.Padding = new Padding(4);
            this.tabCars.Text = "  🚗 Автомобили  ";
            this.tabCars.TabIndex = 1;

            this.txtCarSearch.TextChanged += new System.EventHandler(this.txtCarSearch_TextChanged);

            StyleDgv(this.dgvCars);
            this.dgvCars.AllowUserToAddRows = false;
            this.dgvCars.AllowUserToDeleteRows = false;
            this.dgvCars.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCars.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCars.Location = new Point(8, 70);
            this.dgvCars.MultiSelect = false;
            this.dgvCars.Name = "dgvCars";
            this.dgvCars.ReadOnly = true;
            this.dgvCars.RowHeadersVisible = false;
            this.dgvCars.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvCars.Size = new Size(730, 568);
            this.dgvCars.TabIndex = 1;
            this.dgvCars.CellClick += new DataGridViewCellEventHandler(this.dgvCars_CellClick);

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
            this.groupBoxCarDetails.TabIndex = 2;

            this.groupBoxCarOps.Controls.Add(this.btnCarAdd);
            this.groupBoxCarOps.Controls.Add(this.btnCarUpdate);
            this.groupBoxCarOps.Controls.Add(this.btnCarDelete);
            this.groupBoxCarOps.Controls.Add(this.btnCarRefresh);
            this.groupBoxCarOps.Controls.Add(this.btnCarClear);
            this.groupBoxCarOps.TabIndex = 3;

            this.btnCarAdd.TabIndex    = 0;
            this.btnCarUpdate.TabIndex = 1;
            this.btnCarDelete.TabIndex = 2;
            this.btnCarRefresh.TabIndex = 3;
            this.btnCarClear.TabIndex  = 4;
            this.btnCarAdd.Click    += new System.EventHandler(this.btnCarAdd_Click);
            this.btnCarUpdate.Click += new System.EventHandler(this.btnCarUpdate_Click);
            this.btnCarDelete.Click += new System.EventHandler(this.btnCarDelete_Click);
            this.btnCarRefresh.Click += new System.EventHandler(this.btnCarRefresh_Click);
            this.btnCarClear.Click  += new System.EventHandler(this.btnCarClear_Click);

            this.groupBoxCarSearch.Controls.Add(this.lblCarSearch);
            this.groupBoxCarSearch.Controls.Add(this.txtCarSearch);
            this.groupBoxCarSearch.TabIndex = 0;
            this.txtCarSearch.TabIndex = 1;

            this.txtCarID.TabIndex      = 0;
            this.txtCarBrand.TabIndex   = 1;
            this.txtCarModel.TabIndex   = 2;
            this.txtCarYear.TabIndex    = 3;
            this.txtCarGosNumber.TabIndex = 4;
            this.cmbCarClient.TabIndex  = 5;

            // ── Reports tab ───────────────────────────────────────────────────
            this.tabReports.BackColor = ClrPageBg;
            this.tabReports.Controls.Add(this.groupBoxReportActions);
            this.tabReports.Controls.Add(this.reportViewer);
            this.tabReports.Name = "tabReports";
            this.tabReports.Padding = new Padding(4);
            this.tabReports.Text = "  📊 Отчёты  ";
            this.tabReports.TabIndex = 2;

            this.groupBoxReportActions.Controls.Add(this.btnGenerateReport);
            this.groupBoxReportActions.Controls.Add(this.btnExportReport);
            this.groupBoxReportActions.TabIndex = 0;

            this.btnGenerateReport.TabIndex = 0;
            this.btnExportReport.TabIndex   = 1;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            this.btnExportReport.Click   += new System.EventHandler(this.btnExportReport_Click);

            this.reportViewer.Location = new Point(8, 76);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.Size = new Size(1126, 560);
            this.reportViewer.TabIndex = 1;

            // ── Form ──────────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = ClrNavy;
            this.ClientSize = new Size(1150, 750);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.panelHeader);
            this.Font = FontSub;
            this.MinimumSize = new Size(950, 650);
            this.Name = "Form1";
            this.Text = "АвтоСервис — Система управления";
            this.Load += new System.EventHandler(this.Form1_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCars)).EndInit();
            this.tabControlMain.ResumeLayout(false);
            this.tabClients.ResumeLayout(false);
            this.tabCars.ResumeLayout(false);
            this.tabReports.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        // ── Header ────────────────────────────────────────────────────────────
        private Panel  panelHeader;
        private Label  lblAppTitle;
        private Label  lblAppSubtitle;
        private Panel  panelAccentLine;

        // ── TabControl ────────────────────────────────────────────────────────
        private TabControl tabControlMain;
        private TabPage    tabClients;
        private TabPage    tabCars;
        private TabPage    tabReports;

        // ── Clients ───────────────────────────────────────────────────────────
        private DataGridView dgvClients;
        private GroupBox     groupBoxClientDetails;
        private Label        lblClientID;
        private TextBox      txtClientID;
        private Label        lblClientSurname;
        private TextBox      txtClientSurname;
        private Label        lblClientName;
        private TextBox      txtClientName;
        private Label        lblClientPhone;
        private TextBox      txtClientPhone;
        private Label        lblClientAddress;
        private TextBox      txtClientAddress;
        private GroupBox     groupBoxClientOps;
        private Button       btnClientAdd;
        private Button       btnClientUpdate;
        private Button       btnClientDelete;
        private Button       btnClientRefresh;
        private Button       btnClientClear;
        private GroupBox     groupBoxClientSearch;
        private Label        lblClientSearch;
        private TextBox      txtClientSearch;

        // ── Cars ──────────────────────────────────────────────────────────────
        private DataGridView dgvCars;
        private GroupBox     groupBoxCarDetails;
        private Label        lblCarID;
        private TextBox      txtCarID;
        private Label        lblCarBrand;
        private TextBox      txtCarBrand;
        private Label        lblCarModel;
        private TextBox      txtCarModel;
        private Label        lblCarYear;
        private TextBox      txtCarYear;
        private Label        lblCarGosNumber;
        private TextBox      txtCarGosNumber;
        private Label        lblCarClient;
        private ComboBox     cmbCarClient;
        private GroupBox     groupBoxCarOps;
        private Button       btnCarAdd;
        private Button       btnCarUpdate;
        private Button       btnCarDelete;
        private Button       btnCarRefresh;
        private Button       btnCarClear;
        private GroupBox     groupBoxCarSearch;
        private Label        lblCarSearch;
        private TextBox      txtCarSearch;

        // ── Reports ───────────────────────────────────────────────────────────
        private ReportViewer reportViewer;
        private GroupBox     groupBoxReportActions;
        private Button       btnGenerateReport;
        private Button       btnExportReport;
    }
}
