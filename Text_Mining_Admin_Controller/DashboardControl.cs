using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Text_Mining_Admin_Controller.Models;

namespace Text_Mining_Admin_Controller
{
    public partial class DashboardControl : UserControl
    {
        private readonly DashboardService _dashboardService;
        public DashboardControl()
        {
            InitializeComponent();
            _dashboardService = new DashboardService(new EcommerceContext());
            Displaymetric();
            LoadRevenueChart();
            LoadCategorySalesChart();
            LoadOrderChart();
        }
        private void Displaymetric()
        {
            // Hiển thị tổng doanh thu
            decimal totalRevenue = _dashboardService.GetTotalRevenue();
            lblTotalRevenue.Text = totalRevenue.ToString("C");
            // Tổng số khách hàng
            int totalCustomers = _dashboardService.GetTotalCustomers();
            lblTotalCustomers.Text = totalCustomers.ToString();
            // Hiển thị tổng số đơn hàng
            int totalOrders = _dashboardService.GetTotalOrders();
            lblTotalOrders.Text = totalOrders.ToString();

            // Hiển thị giá trị trung bình mỗi đơn hàng
            decimal averageOrderValue = _dashboardService.GetAverageOrderValue();
            lblAverageOrderValue.Text = averageOrderValue.ToString("C"); 
        }
        private void LoadRevenueChart()
        {
            var revenueData = _dashboardService.GetRevenueByMonth();

            // Xóa dữ liệu cũ, nếu có
            var series = revenueChart.Series["Revenue"];
            series.Points.Clear();

            // Thêm dữ liệu vào series
            foreach (var data in revenueData)
            {
                series.Points.AddXY(data.Key, data.Value);
            }

            // Cấu hình ChartArea
            var chartArea = revenueChart.ChartAreas["Revenue"];
            chartArea.AxisX.LabelStyle.Format = "MMM"; 
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.IntervalType = DateTimeIntervalType.Months;
            chartArea.AxisX.Title = "Month";
            chartArea.AxisY.Title = "Revenue";

            revenueChart.Invalidate(); // Làm mới biểu đồ
        }
        private void LoadCategorySalesChart()
        {
            var data = _dashboardService.GetProductCountByCategory();
            // Xóa dữ liệu cũ, nếu có
            var series = categorySalesChart.Series["CategorySales"];
            series.Points.Clear();

            foreach (var item in data)
            {
                series.Points.AddXY(item.CategoryName, item.TotalQuantity);
            }
            // Hiển thị giá trị trên mỗi phần của biểu đồ tròn
            series.IsValueShownAsLabel = true;
            series.LabelFormat = "#,##0"; // Hiển thị số liệu dạng số nguyên
            categorySalesChart.Invalidate(); // Làm mới biểu đồ
        }
        private void LoadOrderChart()
        {
            var orderdata = _dashboardService.GetOrderCountByMonth();

            // Xóa dữ liệu cũ, nếu có
            var columnSeries = orderchart.Series["Order"];
            columnSeries.Points.Clear();

            // Thêm dữ liệu vào series
            foreach (var data in orderdata)
            {
                columnSeries.Points.AddXY(data.Key, data.Value);
            }
            // Tạo một series mới cho đường line chart
            var lineSeries = new Series("OrderTrend")
            {
                ChartType = SeriesChartType.Spline,
                XValueType = ChartValueType.DateTime,
            };

            // Thêm dữ liệu vào line series
            foreach (var data in orderdata)
            {
                lineSeries.Points.AddXY(data.Key, data.Value);
            }

            // Cấu hình ChartArea
            var chartArea = orderchart.ChartAreas["Order"];
            chartArea.AxisX.LabelStyle.Format = "MMM";
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.IntervalType = DateTimeIntervalType.Months;
            chartArea.AxisX.Title = "Month";
            chartArea.AxisY.Title = "Number of Orders";
            // Thêm cả hai series vào biểu đồ
            orderchart.Series.Clear();
            orderchart.Series.Add(columnSeries);
            orderchart.Series.Add(lineSeries);
            orderchart.Invalidate(); // Làm mới biểu đồ
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
