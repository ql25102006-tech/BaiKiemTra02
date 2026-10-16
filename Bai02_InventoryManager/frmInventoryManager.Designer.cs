namespace Bai02_InventoryManager
{
    partial class frmInventoryManager
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            menuSystem = new ToolStripMenuItem();
            menuOpenFile = new ToolStripMenuItem();
            menuSaveReport = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            menuExit = new ToolStripMenuItem();
            menuTools = new ToolStripMenuItem();
            menuImportCsv = new ToolStripMenuItem();
            menuExportCsv = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            btnToolOpen = new ToolStripButton();
            btnToolSave = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            btnToolImport = new ToolStripButton();
            btnToolExport = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            btnToolExit = new ToolStripButton();
            statusStrip1 = new StatusStrip();
            sslTotalQuantity = new ToolStripStatusLabel();
            sslTotalValue = new ToolStripStatusLabel();
            sslCurrentTime = new ToolStripStatusLabel();
            timerClock = new System.Windows.Forms.Timer(components);
            grpInput = new GroupBox();
            btnChooseImage = new Button();
            picProductImage = new PictureBox();
            lblImage = new Label();
            numQuantity = new NumericUpDown();
            lblQuantity = new Label();
            txtPrice = new TextBox();
            lblPrice = new Label();
            cboCategory = new ComboBox();
            lblCategory = new Label();
            txtProductName = new TextBox();
            lblProductName = new Label();
            txtProductId = new TextBox();
            lblProductId = new Label();
            pnlButtons = new Panel();
            btnClear = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            grpList = new GroupBox();
            dgvProducts = new DataGridView();
            errorProvider1 = new ErrorProvider(components);
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            grpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picProductImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            pnlButtons.SuspendLayout();
            grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuSystem, menuTools });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(980, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuSystem
            // 
            menuSystem.DropDownItems.AddRange(new ToolStripItem[] { menuOpenFile, menuSaveReport, toolStripSeparator1, menuExit });
            menuSystem.Name = "menuSystem";
            menuSystem.Size = new Size(70, 24);
            menuSystem.Text = "System";
            // 
            // menuOpenFile
            // 
            menuOpenFile.Name = "menuOpenFile";
            menuOpenFile.ShortcutKeys = Keys.Control | Keys.O;
            menuOpenFile.Size = new Size(224, 26);
            menuOpenFile.Text = "Open File";
            menuOpenFile.Click += menuOpenFile_Click;
            // 
            // menuSaveReport
            // 
            menuSaveReport.Name = "menuSaveReport";
            menuSaveReport.ShortcutKeys = Keys.Control | Keys.S;
            menuSaveReport.Size = new Size(224, 26);
            menuSaveReport.Text = "Save Report";
            menuSaveReport.Click += menuSaveReport_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(221, 6);
            // 
            // menuExit
            // 
            menuExit.Name = "menuExit";
            menuExit.ShortcutKeys = Keys.Alt | Keys.F4;
            menuExit.Size = new Size(224, 26);
            menuExit.Text = "Exit";
            menuExit.Click += menuExit_Click;
            // 
            // menuTools
            // 
            menuTools.DropDownItems.AddRange(new ToolStripItem[] { menuImportCsv, menuExportCsv });
            menuTools.Name = "menuTools";
            menuTools.Size = new Size(58, 24);
            menuTools.Text = "Tools";
            // 
            // menuImportCsv
            // 
            menuImportCsv.Name = "menuImportCsv";
            menuImportCsv.Size = new Size(165, 26);
            menuImportCsv.Text = "Import CSV";
            menuImportCsv.Click += menuImportCsv_Click;
            // 
            // menuExportCsv
            // 
            menuExportCsv.Name = "menuExportCsv";
            menuExportCsv.Size = new Size(165, 26);
            menuExportCsv.Text = "Export CSV";
            menuExportCsv.Click += menuExportCsv_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnToolOpen, btnToolSave, toolStripSeparator2, btnToolImport, btnToolExport, toolStripSeparator3, btnToolExit });
            toolStrip1.Location = new Point(0, 28);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(980, 27);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnToolOpen
            // 
            btnToolOpen.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnToolOpen.Name = "btnToolOpen";
            btnToolOpen.Size = new Size(49, 24);
            btnToolOpen.Text = "Open";
            btnToolOpen.Click += menuOpenFile_Click;
            // 
            // btnToolSave
            // 
            btnToolSave.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnToolSave.Name = "btnToolSave";
            btnToolSave.Size = new Size(44, 24);
            btnToolSave.Text = "Save";
            btnToolSave.Click += menuSaveReport_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 27);
            // 
            // btnToolImport
            // 
            btnToolImport.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnToolImport.Name = "btnToolImport";
            btnToolImport.Size = new Size(87, 24);
            btnToolImport.Text = "Import CSV";
            btnToolImport.Click += menuImportCsv_Click;
            // 
            // btnToolExport
            // 
            btnToolExport.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnToolExport.Name = "btnToolExport";
            btnToolExport.Size = new Size(84, 24);
            btnToolExport.Text = "Export CSV";
            btnToolExport.Click += menuExportCsv_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 27);
            // 
            // btnToolExit
            // 
            btnToolExit.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnToolExit.Name = "btnToolExit";
            btnToolExit.Size = new Size(37, 24);
            btnToolExit.Text = "Exit";
            btnToolExit.Click += menuExit_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { sslTotalQuantity, sslTotalValue, sslCurrentTime });
            statusStrip1.Location = new Point(0, 504);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(980, 26);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // sslTotalQuantity
            // 
            sslTotalQuantity.BorderSides = ToolStripStatusLabelBorderSides.Right;
            sslTotalQuantity.Name = "sslTotalQuantity";
            sslTotalQuantity.Size = new Size(160, 20);
            sslTotalQuantity.Text = "Tổng số lượng SP: 0";
            // 
            // sslTotalValue
            // 
            sslTotalValue.BorderSides = ToolStripStatusLabelBorderSides.Right;
            sslTotalValue.Name = "sslTotalValue";
            sslTotalValue.Size = new Size(180, 20);
            sslTotalValue.Text = "Tổng giá trị kho: 0 VNĐ";
            // 
            // sslCurrentTime
            // 
            sslCurrentTime.Name = "sslCurrentTime";
            sslCurrentTime.Size = new Size(146, 20);
            sslCurrentTime.Text = "Thời gian: 00:00:00";
            // 
            // timerClock
            // 
            timerClock.Enabled = true;
            timerClock.Interval = 1000;
            timerClock.Tick += timerClock_Tick;
            // 
            // grpInput
            // 
            grpInput.Controls.Add(btnChooseImage);
            grpInput.Controls.Add(picProductImage);
            grpInput.Controls.Add(lblImage);
            grpInput.Controls.Add(numQuantity);
            grpInput.Controls.Add(lblQuantity);
            grpInput.Controls.Add(txtPrice);
            grpInput.Controls.Add(lblPrice);
            grpInput.Controls.Add(cboCategory);
            grpInput.Controls.Add(lblCategory);
            grpInput.Controls.Add(txtProductName);
            grpInput.Controls.Add(lblProductName);
            grpInput.Controls.Add(txtProductId);
            grpInput.Controls.Add(lblProductId);
            grpInput.Location = new Point(15, 65);
            grpInput.Name = "grpInput";
            grpInput.Size = new Size(330, 320);
            grpInput.TabIndex = 3;
            grpInput.TabStop = false;
            grpInput.Text = "Thông tin sản phẩm kho";
            // 
            // btnChooseImage
            // 
            btnChooseImage.Location = new Point(220, 265);
            btnChooseImage.Name = "btnChooseImage";
            btnChooseImage.Size = new Size(95, 32);
            btnChooseImage.TabIndex = 12;
            btnChooseImage.Text = "Chọn ảnh";
            btnChooseImage.UseVisualStyleBackColor = true;
            btnChooseImage.Click += btnChooseImage_Click;
            // 
            // picProductImage
            // 
            picProductImage.BorderStyle = BorderStyle.FixedSingle;
            picProductImage.Location = new Point(115, 225);
            picProductImage.Name = "picProductImage";
            picProductImage.Size = new Size(95, 80);
            picProductImage.SizeMode = PictureBoxSizeMode.Zoom;
            picProductImage.TabIndex = 11;
            picProductImage.TabStop = false;
            // 
            // lblImage
            // 
            lblImage.AutoSize = true;
            lblImage.Location = new Point(15, 230);
            lblImage.Name = "lblImage";
            lblImage.Size = new Size(71, 20);
            lblImage.TabIndex = 10;
            lblImage.Text = "Hình ảnh:";
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(115, 185);
            numQuantity.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(200, 27);
            numQuantity.TabIndex = 9;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(15, 187);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(99, 20);
            lblQuantity.TabIndex = 8;
            lblQuantity.Text = "Số lượng tồn:";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(115, 145);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(200, 27);
            txtPrice.TabIndex = 7;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(15, 148);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(65, 20);
            lblPrice.TabIndex = 6;
            lblPrice.Text = "Đơn giá:";
            // 
            // cboCategory
            // 
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(115, 105);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(200, 28);
            cboCategory.TabIndex = 5;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(15, 108);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(79, 20);
            lblCategory.TabIndex = 4;
            lblCategory.Text = "Danh mục:";
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(115, 65);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(200, 27);
            txtProductName.TabIndex = 3;
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(15, 68);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(103, 20);
            lblProductName.TabIndex = 2;
            lblProductName.Text = "Tên sản phẩm:";
            // 
            // txtProductId
            // 
            txtProductId.Location = new Point(115, 25);
            txtProductId.Name = "txtProductId";
            txtProductId.ReadOnly = true;
            txtProductId.Size = new Size(200, 27);
            txtProductId.TabIndex = 1;
            // 
            // lblProductId
            // 
            lblProductId.AutoSize = true;
            lblProductId.Location = new Point(15, 28);
            lblProductId.Name = "lblProductId";
            lblProductId.Size = new Size(101, 20);
            lblProductId.TabIndex = 0;
            lblProductId.Text = "Mã sản phẩm:";
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(btnClear);
            pnlButtons.Controls.Add(btnDelete);
            pnlButtons.Controls.Add(btnUpdate);
            pnlButtons.Controls.Add(btnAdd);
            pnlButtons.Location = new Point(15, 395);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(330, 95);
            pnlButtons.TabIndex = 4;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(170, 50);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(145, 34);
            btnClear.TabIndex = 3;
            btnClear.Text = "Làm mới";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(15, 50);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(145, 34);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(170, 8);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(145, 34);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(15, 8);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(145, 34);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Thêm mới";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // grpList
            // 
            grpList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpList.Controls.Add(dgvProducts);
            grpList.Location = new Point(360, 65);
            grpList.Name = "grpList";
            grpList.Size = new Size(605, 425);
            grpList.TabIndex = 5;
            grpList.TabStop = false;
            grpList.Text = "Danh sách sản phẩm trong kho (DataGridView)";
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Dock = DockStyle.Fill;
            dgvProducts.Location = new Point(3, 23);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersWidth = 35;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(599, 399);
            dgvProducts.TabIndex = 0;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmInventoryManager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 530);
            Controls.Add(grpList);
            Controls.Add(pnlButtons);
            Controls.Add(grpInput);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(900, 500);
            Name = "frmInventoryManager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bài 2 - Quản lý kho và xuất báo cáo tổng hợp";
            FormClosing += frmInventoryManager_FormClosing;
            Load += frmInventoryManager_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            grpInput.ResumeLayout(false);
            grpInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picProductImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            pnlButtons.ResumeLayout(false);
            grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuSystem;
        private ToolStripMenuItem menuOpenFile;
        private ToolStripMenuItem menuSaveReport;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem menuExit;
        private ToolStripMenuItem menuTools;
        private ToolStripMenuItem menuImportCsv;
        private ToolStripMenuItem menuExportCsv;
        private ToolStrip toolStrip1;
        private ToolStripButton btnToolOpen;
        private ToolStripButton btnToolSave;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton btnToolImport;
        private ToolStripButton btnToolExport;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton btnToolExit;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel sslTotalQuantity;
        private ToolStripStatusLabel sslTotalValue;
        private ToolStripStatusLabel sslCurrentTime;
        private System.Windows.Forms.Timer timerClock;
        private GroupBox grpInput;
        private Label lblProductId;
        private TextBox txtProductId;
        private Label lblProductName;
        private TextBox txtProductName;
        private Label lblCategory;
        private ComboBox cboCategory;
        private Label lblPrice;
        private TextBox txtPrice;
        private Label lblQuantity;
        private NumericUpDown numQuantity;
        private Label lblImage;
        private PictureBox picProductImage;
        private Button btnChooseImage;
        private Panel pnlButtons;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private GroupBox grpList;
        private DataGridView dgvProducts;
        private ErrorProvider errorProvider1;
    }
}
