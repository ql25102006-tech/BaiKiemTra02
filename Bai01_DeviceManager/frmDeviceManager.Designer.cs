namespace Bai01_DeviceManager
{
    partial class frmDeviceManager
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
            grpInput = new GroupBox();
            lblDeviceId = new Label();
            txtDeviceId = new TextBox();
            lblDeviceName = new Label();
            txtDeviceName = new TextBox();
            lblCategory = new Label();
            cboCategory = new ComboBox();
            lblPrice = new Label();
            txtPrice = new TextBox();
            lblQuantity = new Label();
            numQuantity = new NumericUpDown();
            pnlButtons = new Panel();
            btnClear = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            grpList = new GroupBox();
            dgvDevices = new DataGridView();
            errorProvider1 = new ErrorProvider(components);
            grpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            pnlButtons.SuspendLayout();
            grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDevices).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // grpInput
            // 
            grpInput.Controls.Add(numQuantity);
            grpInput.Controls.Add(lblQuantity);
            grpInput.Controls.Add(txtPrice);
            grpInput.Controls.Add(lblPrice);
            grpInput.Controls.Add(cboCategory);
            grpInput.Controls.Add(lblCategory);
            grpInput.Controls.Add(txtDeviceName);
            grpInput.Controls.Add(lblDeviceName);
            grpInput.Controls.Add(txtDeviceId);
            grpInput.Controls.Add(lblDeviceId);
            grpInput.Location = new Point(15, 15);
            grpInput.Name = "grpInput";
            grpInput.Size = new Size(320, 240);
            grpInput.TabIndex = 0;
            grpInput.TabStop = false;
            grpInput.Text = "Thông tin thiết bị";
            // 
            // lblDeviceId
            // 
            lblDeviceId.AutoSize = true;
            lblDeviceId.Location = new Point(15, 30);
            lblDeviceId.Name = "lblDeviceId";
            lblDeviceId.Size = new Size(82, 20);
            lblDeviceId.TabIndex = 0;
            lblDeviceId.Text = "Mã thiết bị:";
            // 
            // txtDeviceId
            // 
            txtDeviceId.Location = new Point(115, 27);
            txtDeviceId.Name = "txtDeviceId";
            txtDeviceId.ReadOnly = true;
            txtDeviceId.Size = new Size(185, 27);
            txtDeviceId.TabIndex = 1;
            // 
            // lblDeviceName
            // 
            lblDeviceName.AutoSize = true;
            lblDeviceName.Location = new Point(15, 70);
            lblDeviceName.Name = "lblDeviceName";
            lblDeviceName.Size = new Size(84, 20);
            lblDeviceName.TabIndex = 2;
            lblDeviceName.Text = "Tên thiết bị:";
            // 
            // txtDeviceName
            // 
            txtDeviceName.Location = new Point(115, 67);
            txtDeviceName.Name = "txtDeviceName";
            txtDeviceName.Size = new Size(185, 27);
            txtDeviceName.TabIndex = 3;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(15, 110);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(89, 20);
            lblCategory.TabIndex = 4;
            lblCategory.Text = "Loại thiết bị:";
            // 
            // cboCategory
            // 
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(115, 107);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(185, 28);
            cboCategory.TabIndex = 5;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(15, 150);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(65, 20);
            lblPrice.TabIndex = 6;
            lblPrice.Text = "Đơn giá:";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(115, 147);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(185, 27);
            txtPrice.TabIndex = 7;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(15, 190);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(99, 20);
            lblQuantity.TabIndex = 8;
            lblQuantity.Text = "Số lượng tồn:";
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(115, 188);
            numQuantity.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(185, 27);
            numQuantity.TabIndex = 9;
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(btnClear);
            pnlButtons.Controls.Add(btnDelete);
            pnlButtons.Controls.Add(btnUpdate);
            pnlButtons.Controls.Add(btnAdd);
            pnlButtons.Location = new Point(15, 265);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(320, 110);
            pnlButtons.TabIndex = 1;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(165, 60);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(135, 36);
            btnClear.TabIndex = 3;
            btnClear.Text = "Làm mới / Hủy";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(15, 60);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(135, 36);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(165, 12);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(135, 36);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(15, 12);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(135, 36);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Thêm mới";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // grpList
            // 
            grpList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpList.Controls.Add(dgvDevices);
            grpList.Location = new Point(345, 15);
            grpList.Name = "grpList";
            grpList.Size = new Size(540, 360);
            grpList.TabIndex = 2;
            grpList.TabStop = false;
            grpList.Text = "Danh sách thiết bị";
            // 
            // dgvDevices
            // 
            dgvDevices.AllowUserToAddRows = false;
            dgvDevices.AllowUserToDeleteRows = false;
            dgvDevices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDevices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDevices.Dock = DockStyle.Fill;
            dgvDevices.Location = new Point(3, 23);
            dgvDevices.MultiSelect = false;
            dgvDevices.Name = "dgvDevices";
            dgvDevices.ReadOnly = true;
            dgvDevices.RowHeadersWidth = 35;
            dgvDevices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDevices.Size = new Size(534, 334);
            dgvDevices.TabIndex = 0;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmDeviceManager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 390);
            Controls.Add(grpList);
            Controls.Add(pnlButtons);
            Controls.Add(grpInput);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmDeviceManager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bài 1 - Quản lý danh mục thiết bị điện tử";
            Load += frmDeviceManager_Load;
            grpInput.ResumeLayout(false);
            grpInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            pnlButtons.ResumeLayout(false);
            grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDevices).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpInput;
        private Label lblDeviceId;
        private TextBox txtDeviceId;
        private Label lblDeviceName;
        private TextBox txtDeviceName;
        private Label lblCategory;
        private ComboBox cboCategory;
        private Label lblPrice;
        private TextBox txtPrice;
        private Label lblQuantity;
        private NumericUpDown numQuantity;
        private Panel pnlButtons;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private GroupBox grpList;
        private DataGridView dgvDevices;
        private ErrorProvider errorProvider1;
    }
}
