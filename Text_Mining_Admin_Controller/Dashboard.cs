using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Text_Mining_Admin_Controller.Models;

namespace Text_Mining_Admin_Controller
{
    public partial class Dashboard : Form
    {

        public Dashboard()
        {
            InitializeComponent();
            // Hiển thị DashboardControl mặc định khi form mở
            DashboardControl dashboardControl = new DashboardControl();
            dashboardControl.Dock = DockStyle.Fill;
            panelContent.Controls.Add(dashboardControl);
            btnDashboard.Font = new Font(btnDashboard.Font, FontStyle.Bold);
        }
        private void btn_Click(object sender, EventArgs e)
        {
            // Lấy nút được nhấn
            Button clickedButton = sender as Button;

            // Lấy container lớn mà chứa tất cả các panel nhỏ và nút
            Control parentContainer = clickedButton.Parent.Parent;

            // Duyệt qua tất cả các panel con trong container lớn
            foreach (Control panel in parentContainer.Controls)
            {
                // Duyệt qua từng control trong mỗi panel
                foreach (Control control in panel.Controls)
                {
                    if (control is Button)
                    {
                        // Đặt lại tất cả các nút thành Regular
                        control.Font = new Font(control.Font, FontStyle.Regular);
                    }
                }
            }

            // Đặt font của nút vừa được nhấn thành Bold
            clickedButton.Font = new Font(clickedButton.Font, FontStyle.Bold);

            // Xóa các controls trước đó trong panelContent
            panelContent.Controls.Clear();

            // Hiển thị nội dung tương ứng với nút được nhấn
            if (clickedButton.Name == "btnDashboard")
            {
                DashboardControl dashboardControl = new DashboardControl();
                dashboardControl.Dock = DockStyle.Fill;
                panelContent.Controls.Add(dashboardControl);
            }
            else if (clickedButton.Name == "btnProduct")
            {
                ProductControl productControl = new ProductControl();
                productControl.Dock = DockStyle.Fill;
                panelContent.Controls.Add(productControl);
            }
            else if (clickedButton.Name == "btnOrder")
            {
                OrderControl orderControl = new OrderControl();
                orderControl.Dock = DockStyle.Fill;
                panelContent.Controls.Add(orderControl);
            }
            else if (clickedButton.Name == "btnCustomer")
            {
                CustomerControl customerControl = new CustomerControl();
                customerControl.Dock = DockStyle.Fill;
                panelContent.Controls.Add(customerControl);
            }
            else if (clickedButton.Name == "btnFeedback")
            {
                FeedbackControl feedbackControl = new FeedbackControl();
                feedbackControl.Dock = DockStyle.Fill;
                panelContent.Controls.Add(feedbackControl);
            }
        }


    }
}
