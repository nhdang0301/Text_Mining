using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Text_Mining_Admin_Controller
{
    public partial class load : Form
    {
        private System.Windows.Forms.Timer timer; // Sử dụng System.Windows.Forms.Timer
        private int progress = 0;  // Biến lưu trữ % tiến trình
        public load()
        {
            InitializeComponent();
            pictureBox1.Location = new Point(progressBar3.Location.X, progressBar3.Location.Y + progressBar3.Height / 2 - pictureBox1.Height / 2);
            // Tạo Timer để cập nhật tiến độ mỗi 100ms
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 200;
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Tăng giá trị thanh tiến trình
            progress += 5;
            progressBar3.Value = progress;
            labelProgress.Text = progress + "%"; // Hiển thị % tiến trình
            // Tính toán vị trí mới cho PictureBox dựa trên giá trị của ProgressBar
            int maxPositionX = progressBar3.Location.X + progressBar3.Width - pictureBox1.Width; // Giới hạn di chuyển
            int newX = progressBar3.Location.X + (progressBar3.Width - pictureBox1.Width) * progress / progressBar3.Maximum;

            // Di chuyển PictureBox theo trục X (hoặc Y nếu cần chạy dọc)
            pictureBox1.Location = new Point(newX, pictureBox1.Location.Y);

            // Khi thanh tiến trình đạt 100%, mở Form chính và đóng Loading Form
            if (progress >= 100)
            {
                // Mở form chính (MainForm)
                timer.Stop();
                timer.Dispose();
                this.Hide();
                Login mainForm = new Login();
                mainForm.Show();
            }
        }
        private void frmLoading_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

    }
}
