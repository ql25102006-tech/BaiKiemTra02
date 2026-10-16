using System.ComponentModel;

namespace Bai01_DeviceManager
{
    public partial class frmDeviceManager : Form
    {
        private BindingList<Device> listDevices = new BindingList<Device>();
        private BindingSource bindingSource = new BindingSource();
        private int autoIdCounter = 1;

        public frmDeviceManager()
        {
            InitializeComponent();
        }

        private void frmDeviceManager_Load(object sender, EventArgs e)
        {
            // 1. Nạp danh mục Loại thiết bị
            cboCategory.Items.AddRange(new object[] {
                "Điện thoại",
                "Laptop",
                "Máy tính bảng",
                "Phụ kiện",
                "Màn hình"
            });
            cboCategory.SelectedIndex = 0;

            // 2. Cấu hình cột thủ công cho dgvDevices hoàn toàn bằng code
            CauHinhDataGridViewBangCode();

            // 3. Ràng buộc danh sách dữ liệu qua BindingSource
            bindingSource.DataSource = listDevices;
            dgvDevices.DataSource = bindingSource;

            // Dữ liệu mẫu ban đầu
            ThemThietBiMau("TB01", "iPhone 15 Pro Max", "Điện thoại", 29500000m, 15);
            ThemThietBiMau("TB02", "Dell XPS 13 Plus", "Laptop", 34000000m, 8);
            ThemThietBiMau("TB03", "iPad Air 5 M1", "Máy tính bảng", 14500000m, 12);
            ThemThietBiMau("TB04", "Chuột Logitech MX Master 3S", "Phụ kiện", 2200000m, 25);

            autoIdCounter = 5;
            SinhMaTuDong();
        }

        private void CauHinhDataGridViewBangCode()
        {
            dgvDevices.AutoGenerateColumns = false;
            dgvDevices.Columns.Clear();

            // Cột Mã thiết bị
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.DataPropertyName = "DeviceId";
            colId.HeaderText = "Mã TB";
            colId.Name = "colDeviceId";
            colId.FillWeight = 80F;

            // Cột Tên thiết bị
            DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn();
            colName.DataPropertyName = "DeviceName";
            colName.HeaderText = "Tên thiết bị";
            colName.Name = "colDeviceName";
            colName.FillWeight = 160F;

            // Cột Loại thiết bị
            DataGridViewTextBoxColumn colCat = new DataGridViewTextBoxColumn();
            colCat.DataPropertyName = "Category";
            colCat.HeaderText = "Loại thiết bị";
            colCat.Name = "colCategory";
            colCat.FillWeight = 110F;

            // Cột Đơn giá (định dạng tiền tệ)
            DataGridViewTextBoxColumn colPrice = new DataGridViewTextBoxColumn();
            colPrice.DataPropertyName = "Price";
            colPrice.HeaderText = "Đơn giá (VNĐ)";
            colPrice.Name = "colPrice";
            colPrice.DefaultCellStyle.Format = "N0";
            colPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colPrice.FillWeight = 110F;

            // Cột Số lượng tồn
            DataGridViewTextBoxColumn colQty = new DataGridViewTextBoxColumn();
            colQty.DataPropertyName = "Quantity";
            colQty.HeaderText = "Số lượng";
            colQty.Name = "colQuantity";
            colQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colQty.FillWeight = 80F;

            dgvDevices.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colCat, colPrice, colQty });

            // Bắt sự kiện click chọn dòng đổ ngược dữ liệu
            dgvDevices.SelectionChanged += dgvDevices_SelectionChanged;
        }

        private void ThemThietBiMau(string id, string name, string cat, decimal price, int qty)
        {
            listDevices.Add(new Device(id, name, cat, price, qty));
        }

        private void SinhMaTuDong()
        {
            txtDeviceId.Text = $"TB{autoIdCounter:D2}";
        }

        // Đồng bộ dữ liệu đổ ngược từ Grid lên Form
        private void dgvDevices_SelectionChanged(object? sender, EventArgs e)
        {
            if (bindingSource.Current is Device currentDevice)
            {
                txtDeviceId.Text = currentDevice.DeviceId;
                txtDeviceName.Text = currentDevice.DeviceName;
                cboCategory.SelectedItem = currentDevice.Category;
                txtPrice.Text = currentDevice.Price.ToString("N0");
                numQuantity.Value = currentDevice.Quantity;

                XoaLoiValidation();
            }
        }

        // Validation kiểm tra lỗi
        private bool ValidateDuLieu(out decimal price)
        {
            bool hopLe = true;
            price = 0;
            XoaLoiValidation();

            // 1. Tên thiết bị để trống
            if (string.IsNullOrWhiteSpace(txtDeviceName.Text))
            {
                errorProvider1.SetError(txtDeviceName, "Tên thiết bị không được để trống!");
                hopLe = false;
            }

            // 2. Chưa chọn loại thiết bị
            if (cboCategory.SelectedIndex < 0)
            {
                errorProvider1.SetError(cboCategory, "Vui lòng chọn loại thiết bị!");
                hopLe = false;
            }

            // 3. Đơn giá không hợp lệ hoặc nhỏ hơn 0
            string cleanPrice = txtPrice.Text.Replace(",", "").Replace(".", "").Trim();
            if (string.IsNullOrWhiteSpace(cleanPrice) || !decimal.TryParse(cleanPrice, out price) || price < 0)
            {
                errorProvider1.SetError(txtPrice, "Đơn giá phải là số hợp lệ và không được nhỏ hơn 0!");
                hopLe = false;
            }

            return hopLe;
        }

        private void XoaLoiValidation()
        {
            errorProvider1.SetError(txtDeviceName, string.Empty);
            errorProvider1.SetError(cboCategory, string.Empty);
            errorProvider1.SetError(txtPrice, string.Empty);
        }

        // Thêm mới
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateDuLieu(out decimal price))
            {
                MessageBox.Show("Dữ liệu nhập vào chưa hợp lệ, vui lòng kiểm tra lại các ô báo lỗi!", "Cảnh báo lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = txtDeviceId.Text.Trim();
            // Nếu mã đã tồn tại thì tự động tăng
            if (listDevices.Any(d => d.DeviceId.Equals(id, StringComparison.OrdinalIgnoreCase)))
            {
                autoIdCounter++;
                SinhMaTuDong();
                id = txtDeviceId.Text.Trim();
            }

            Device newDevice = new Device(
                id,
                txtDeviceName.Text.Trim(),
                cboCategory.SelectedItem?.ToString() ?? "Khác",
                price,
                (int)numQuantity.Value
            );

            // Thêm trực tiếp vào BindingList<T> -> tự động hiển thị lên Grid
            listDevices.Add(newDevice);
            autoIdCounter++;

            // Chọn vào dòng vừa thêm
            bindingSource.Position = listDevices.IndexOf(newDevice);

            MessageBox.Show("Thêm mới thiết bị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Cập nhật
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (bindingSource.Current is Device currentDevice)
            {
                if (!ValidateDuLieu(out decimal price))
                {
                    MessageBox.Show("Dữ liệu nhập vào chưa hợp lệ, vui lòng kiểm tra lại các ô báo lỗi!", "Cảnh báo lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                currentDevice.DeviceName = txtDeviceName.Text.Trim();
                currentDevice.Category = cboCategory.SelectedItem?.ToString() ?? "Khác";
                currentDevice.Price = price;
                currentDevice.Quantity = (int)numQuantity.Value;

                // Làm mới hiển thị trên Grid
                bindingSource.ResetCurrentItem();

                MessageBox.Show("Cập nhật thông tin thiết bị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 thiết bị từ bảng để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Xóa
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (bindingSource.Current is Device currentDevice)
            {
                DialogResult dr = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa thiết bị [{currentDevice.DeviceId} - {currentDevice.DeviceName}]?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (dr == DialogResult.Yes)
                {
                    listDevices.Remove(currentDevice);
                    MessageBox.Show("Đã xóa thiết bị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (listDevices.Count == 0)
                    {
                        btnClear.PerformClick();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 thiết bị cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Làm mới / Hủy
        private void btnClear_Click(object sender, EventArgs e)
        {
            XoaLoiValidation();
            SinhMaTuDong();
            txtDeviceName.Clear();
            cboCategory.SelectedIndex = 0;
            txtPrice.Clear();
            numQuantity.Value = 0;
            txtDeviceName.Focus();
        }
    }
}
