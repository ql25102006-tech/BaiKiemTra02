using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bai02_InventoryManager
{
    public partial class frmInventoryManager : Form
    {
        private BindingList<Product> _productList = new BindingList<Product>();
        private BindingSource _bindingSource = new BindingSource();
        private int _autoIdCounter = 1;
        private string _selectedImagePath = string.Empty;
        private bool _isClosingConfirmed = false;

        public frmInventoryManager()
        {
            InitializeComponent();
        }

        private void frmInventoryManager_Load(object sender, EventArgs e)
        {
            // Cấu hình ComboBox danh mục
            cboCategory.Items.AddRange(new object[] {
                "Điện thoại",
                "Laptop",
                "Máy tính bảng",
                "Phụ kiện",
                "Thiết bị mạng",
                "Linh kiện PC"
            });
            cboCategory.SelectedIndex = 0;

            // Cấu hình DataGridView thủ công qua code
            ConfigureDataGridView();

            // Ràng buộc dữ liệu qua BindingSource
            _bindingSource.DataSource = _productList;
            dgvProducts.DataSource = _bindingSource;

            // Đăng ký sự kiện thay đổi dữ liệu trong danh sách
            _productList.ListChanged += (s, ev) => UpdateStatusBarSummary();

            // Nạp một số dữ liệu ban đầu
            SeedInitialData();

            // Bắt sự kiện chọn dòng trên DataGridView
            dgvProducts.SelectionChanged += dgvProducts_SelectionChanged;

            // Cập nhật đồng hồ thời gian thực và thống kê
            UpdateClock();
            UpdateStatusBarSummary();
            ClearForm();
        }

        private void ConfigureDataGridView()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.Columns.Clear();

            var colId = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Product.ProductId),
                HeaderText = "Mã SP",
                Name = "colProductId",
                Width = 90
            };

            var colName = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Product.ProductName),
                HeaderText = "Tên sản phẩm",
                Name = "colProductName",
                Width = 180
            };

            var colCategory = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Product.Category),
                HeaderText = "Danh mục",
                Name = "colCategory",
                Width = 110
            };

            var colPrice = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Product.Price),
                HeaderText = "Đơn giá (VNĐ)",
                Name = "colPrice",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "#,##0 VNĐ",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            };

            var colQty = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Product.Quantity),
                HeaderText = "Số lượng",
                Name = "colQuantity",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            };

            var colTotal = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Product.TotalValue),
                HeaderText = "Thành tiền",
                Name = "colTotalValue",
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "#,##0 VNĐ",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            };

            var colImage = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Product.ImagePath),
                HeaderText = "Đường dẫn hình ảnh",
                Name = "colImagePath",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            dgvProducts.Columns.AddRange(new DataGridViewColumn[] {
                colId, colName, colCategory, colPrice, colQty, colTotal, colImage
            });
        }

        private void SeedInitialData()
        {
            _productList.Add(new Product("SP001", "iPhone 15 Pro Max", "Điện thoại", 29990000m, 15, ""));
            _productList.Add(new Product("SP002", "Dell XPS 13 Plus", "Laptop", 35500000m, 8, ""));
            _productList.Add(new Product("SP003", "iPad Pro 11 M2", "Máy tính bảng", 21500000m, 12, ""));
            _productList.Add(new Product("SP004", "Chuột Logitech MX Master 3S", "Phụ kiện", 2390000m, 30, ""));
            _autoIdCounter = 5;
        }

        private void UpdateStatusBarSummary()
        {
            int totalQty = _productList.Sum(p => p.Quantity);
            decimal totalVal = _productList.Sum(p => p.TotalValue);

            sslTotalQuantity.Text = $"Tổng số lượng SP: {totalQty:#,##0}";
            sslTotalValue.Text = $"Tổng giá trị kho: {totalVal:#,##0} VNĐ";
        }

        private void UpdateClock()
        {
            sslCurrentTime.Text = $"Thời gian: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
        }

        private void timerClock_Tick(object? sender, EventArgs e)
        {
            UpdateClock();
        }

        private void dgvProducts_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow?.DataBoundItem is Product selectedProduct)
            {
                txtProductId.Text = selectedProduct.ProductId;
                txtProductName.Text = selectedProduct.ProductName;
                cboCategory.SelectedItem = selectedProduct.Category;
                txtPrice.Text = selectedProduct.Price.ToString("G29", CultureInfo.InvariantCulture);
                numQuantity.Value = Math.Min(numQuantity.Maximum, Math.Max(numQuantity.Minimum, selectedProduct.Quantity));

                _selectedImagePath = selectedProduct.ImagePath;
                LoadImageToPictureBox(_selectedImagePath);

                errorProvider1.Clear();
            }
        }

        private void LoadImageToPictureBox(string path)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
                {
                    // Tránh lock file bằng cách đọc stream hoặc tạo Bitmap mới
                    using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        using (var img = Image.FromStream(fs))
                        {
                            picProductImage.Image?.Dispose();
                            picProductImage.Image = new Bitmap(img);
                        }
                    }
                }
                else
                {
                    picProductImage.Image?.Dispose();
                    picProductImage.Image = null;
                }
            }
            catch
            {
                picProductImage.Image?.Dispose();
                picProductImage.Image = null;
            }
        }

        private bool ValidateInput(out decimal price)
        {
            bool isValid = true;
            errorProvider1.Clear();
            price = 0;

            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                errorProvider1.SetError(txtProductName, "Tên sản phẩm không được để trống!");
                isValid = false;
            }

            if (cboCategory.SelectedItem == null)
            {
                errorProvider1.SetError(cboCategory, "Vui lòng chọn danh mục sản phẩm!");
                isValid = false;
            }

            string rawPrice = txtPrice.Text.Trim().Replace(",", "");
            if (!decimal.TryParse(rawPrice, NumberStyles.Any, CultureInfo.InvariantCulture, out price) || price < 0)
            {
                if (!decimal.TryParse(txtPrice.Text.Trim(), out price) || price < 0)
                {
                    errorProvider1.SetError(txtPrice, "Đơn giá phải là số hợp lệ và lớn hơn hoặc bằng 0!");
                    isValid = false;
                }
            }

            return isValid;
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Chọn hình ảnh sản phẩm";
                openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All Files (*.*)|*.*";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    _selectedImagePath = openFileDialog.FileName;
                    LoadImageToPictureBox(_selectedImagePath);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(out decimal price))
                return;

            string newId = $"SP{_autoIdCounter:D3}";
            _autoIdCounter++;

            var newProduct = new Product
            {
                ProductId = newId,
                ProductName = txtProductName.Text.Trim(),
                Category = cboCategory.SelectedItem?.ToString() ?? "",
                Price = price,
                Quantity = (int)numQuantity.Value,
                ImagePath = _selectedImagePath
            };

            _productList.Add(newProduct);

            // Chọn dòng mới thêm
            _bindingSource.Position = _productList.Count - 1;
            MessageBox.Show($"Thêm sản phẩm '{newProduct.ProductName}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow?.DataBoundItem is Product selectedProduct)
            {
                if (!ValidateInput(out decimal price))
                    return;

                selectedProduct.ProductName = txtProductName.Text.Trim();
                selectedProduct.Category = cboCategory.SelectedItem?.ToString() ?? "";
                selectedProduct.Price = price;
                selectedProduct.Quantity = (int)numQuantity.Value;
                selectedProduct.ImagePath = _selectedImagePath;

                _bindingSource.ResetBindings(false);
                UpdateStatusBarSummary();

                MessageBox.Show($"Cập nhật sản phẩm '{selectedProduct.ProductId}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần cập nhật từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow?.DataBoundItem is Product selectedProduct)
            {
                var result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa sản phẩm [{selectedProduct.ProductId}] - {selectedProduct.ProductName} khỏi kho?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    _productList.Remove(selectedProduct);
                    ClearForm();
                    MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            dgvProducts.ClearSelection();
            txtProductId.Text = $"SP{_autoIdCounter:D3} (Tự động)";
            txtProductName.Clear();
            if (cboCategory.Items.Count > 0)
                cboCategory.SelectedIndex = 0;
            txtPrice.Clear();
            numQuantity.Value = 0;
            _selectedImagePath = string.Empty;
            picProductImage.Image?.Dispose();
            picProductImage.Image = null;
            errorProvider1.Clear();
        }

        private void menuImportCsv_Click(object sender, EventArgs e)
        {
            ImportFromCsv();
        }

        private void menuExportCsv_Click(object sender, EventArgs e)
        {
            ExportToCsv();
        }

        private void menuOpenFile_Click(object sender, EventArgs e)
        {
            ImportFromCsv();
        }

        private void menuSaveReport_Click(object sender, EventArgs e)
        {
            ExportToCsv();
        }

        private void ExportToCsv()
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Title = "Xuất danh sách sản phẩm ra tệp CSV";
                sfd.Filter = "CSV Files (*.csv)|*.csv|Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                sfd.FileName = $"BaoCaoKho_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                sfd.DefaultExt = "csv";

                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        var sb = new StringBuilder();
                        // Header
                        sb.AppendLine("Mã sản phẩm,Tên sản phẩm,Danh mục,Đơn giá,Số lượng tồn,Thành tiền,Đường dẫn ảnh");

                        foreach (var prod in _productList)
                        {
                            // Escape dấu phẩy hoặc ngoặc kép nếu có
                            string name = prod.ProductName.Contains(",") ? $"\"{prod.ProductName}\"" : prod.ProductName;
                            string cat = prod.Category.Contains(",") ? $"\"{prod.Category}\"" : prod.Category;
                            string img = prod.ImagePath.Contains(",") ? $"\"{prod.ImagePath}\"" : prod.ImagePath;

                            sb.AppendLine($"{prod.ProductId},{name},{cat},{prod.Price},{prod.Quantity},{prod.TotalValue},{img}");
                        }

                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);

                        MessageBox.Show(
                            $"Xuất dữ liệu thành công ra tệp:\n{sfd.FileName}\n\nTổng số sản phẩm: {_productList.Count}",
                            "Xuất dữ liệu thành công",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xuất tệp CSV:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ImportFromCsv()
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn tệp CSV dữ liệu kho cần nhập";
                ofd.Filter = "CSV Files (*.csv)|*.csv|Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        var lines = File.ReadAllLines(ofd.FileName, Encoding.UTF8);
                        if (lines.Length <= 1)
                        {
                            MessageBox.Show("Tệp CSV không có dữ liệu để nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        int importedCount = 0;
                        int skippedCount = 0;

                        // Bỏ qua dòng header đầu tiên
                        for (int i = 1; i < lines.Length; i++)
                        {
                            string line = lines[i].Trim();
                            if (string.IsNullOrWhiteSpace(line)) continue;

                            // Phân tách dấu phẩy
                            var parts = line.Split(',');
                            if (parts.Length >= 5)
                            {
                                string id = parts[0].Trim().Trim('"');
                                string name = parts[1].Trim().Trim('"');
                                string category = parts[2].Trim().Trim('"');

                                if (!decimal.TryParse(parts[3].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal price))
                                    decimal.TryParse(parts[3].Trim(), out price);

                                if (!int.TryParse(parts[4].Trim(), out int qty))
                                    qty = 0;

                                string imagePath = parts.Length >= 7 ? parts[6].Trim().Trim('"') : (parts.Length >= 6 ? parts[5].Trim().Trim('"') : "");

                                // Cập nhật ID tự tăng lớn nhất để không bị trùng
                                if (id.StartsWith("SP", StringComparison.OrdinalIgnoreCase) && int.TryParse(id.Substring(2), out int numId))
                                {
                                    if (numId >= _autoIdCounter)
                                        _autoIdCounter = numId + 1;
                                }

                                // Kiểm tra xem đã có mã chưa, nếu có thì cập nhật, nếu chưa thì thêm mới
                                var existing = _productList.FirstOrDefault(p => p.ProductId.Equals(id, StringComparison.OrdinalIgnoreCase));
                                if (existing != null)
                                {
                                    existing.ProductName = name;
                                    existing.Category = category;
                                    existing.Price = price;
                                    existing.Quantity = qty;
                                    existing.ImagePath = imagePath;
                                }
                                else
                                {
                                    _productList.Add(new Product(id, name, category, price, qty, imagePath));
                                }

                                importedCount++;
                            }
                            else
                            {
                                skippedCount++;
                            }
                        }

                        _bindingSource.ResetBindings(false);
                        UpdateStatusBarSummary();
                        ClearForm();

                        MessageBox.Show(
                            $"Nhập dữ liệu hoàn tất từ tệp:\n{Path.GetFileName(ofd.FileName)}\n\nĐã xử lý: {importedCount} sản phẩm.\nBỏ qua dòng lỗi: {skippedCount}.",
                            "Nhập CSV thành công",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi đọc tệp CSV:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInventoryManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isClosingConfirmed)
                return;

            var result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát khỏi chương trình?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                _isClosingConfirmed = true;
            }
        }
    }
}
