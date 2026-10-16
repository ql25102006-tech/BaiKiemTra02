using System;
using System.Linq;
using System.Windows.Forms;

namespace Bai03_SupermarketMDI
{
    public partial class frmMain : Form
    {
        private bool _isClosingConfirmed = false;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object? sender, EventArgs e)
        {
            sslStatus.Text = "Trạng thái: Sẵn sàng làm việc.";
        }

        /// <summary>
        /// Scenario A: Kiểm tra xem Form con đã mở hay chưa.
        /// Nếu đã mở thì Activate() mang Form đó lên trước.
        /// Nếu chưa thì tạo mới Instance, gán MdiParent = this và hiển thị (Show()).
        /// </summary>
        public T ShowOrActivateMdiChild<T>() where T : Form, new()
        {
            // Kiểm tra trong danh sách MdiChildren hiện tại
            var existingChild = MdiChildren.OfType<T>().FirstOrDefault();

            if (existingChild != null)
            {
                if (existingChild.WindowState == FormWindowState.Minimized)
                {
                    existingChild.WindowState = FormWindowState.Normal;
                }
                existingChild.Activate();
                existingChild.BringToFront();
                return existingChild;
            }
            else
            {
                var newChild = new T
                {
                    MdiParent = this,
                    StartPosition = FormStartPosition.CenterScreen
                };
                newChild.Show();
                return newChild;
            }
        }

        /// <summary>
        /// Phương thức cập nhật thanh tiến trình ProgressBar trên StatusStrip của Form Cha cho các tác vụ nặng
        /// </summary>
        public void SetProgress(int percent, bool visible = true, string statusText = "")
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => SetProgress(percent, visible, statusText)));
                return;
            }

            tspbMainProgress.Visible = visible;
            tspbMainProgress.Value = Math.Max(0, Math.Min(100, percent));

            if (!string.IsNullOrEmpty(statusText))
            {
                sslStatus.Text = statusText;
            }
        }

        public void ResetProgress(string statusText = "Trạng thái: Sẵn sàng")
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => ResetProgress(statusText)));
                return;
            }

            tspbMainProgress.Visible = false;
            tspbMainProgress.Value = 0;
            sslStatus.Text = statusText;
        }

        private void menuProductCatalog_Click(object? sender, EventArgs e)
        {
            ShowOrActivateMdiChild<frmProductCatalog>();
        }

        private void menuStockManager_Click(object? sender, EventArgs e)
        {
            MessageBox.Show(
                "Tính năng Quản lý Nhập xuất hàng hóa đang được đồng bộ cùng Danh mục sản phẩm.\nĐang mở cửa sổ Danh mục sản phẩm...",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
            ShowOrActivateMdiChild<frmProductCatalog>();
        }

        private void menuAsyncReport_Click(object? sender, EventArgs e)
        {
            ShowOrActivateMdiChild<frmAsyncReport>();
        }

        private void menuCascade_Click(object? sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void menuTileHorizontal_Click(object? sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void menuTileVertical_Click(object? sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void menuLogout_Click(object? sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Bạn có muốn đăng xuất khỏi phiên làm việc hiện tại?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // Đóng tất cả form con
                foreach (var child in MdiChildren)
                {
                    child.Close();
                }
                sslCurrentUser.Text = "Người dùng: Đã đăng xuất";
                sslStatus.Text = "Vui lòng đăng nhập lại để tiếp tục.";
                MessageBox.Show("Đã đăng xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void menuExit_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMain_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (_isClosingConfirmed)
                return;

            var result = MessageBox.Show(
                "Bạn có chắc chắn muốn đóng Hệ thống Quản lý Siêu thị?",
                "Xác nhận thoát hệ thống",
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
