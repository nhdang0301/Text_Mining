namespace Text_Mining_Admin_Controller
{
    partial class DashboardControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardControl));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            lblTotalRevenue = new Label();
            panel2 = new Panel();
            pictureBox2 = new PictureBox();
            lblTotalCustomers = new Label();
            label2 = new Label();
            panel3 = new Panel();
            pictureBox3 = new PictureBox();
            lblTotalOrders = new Label();
            label4 = new Label();
            panel4 = new Panel();
            pictureBox4 = new PictureBox();
            lblAverageOrderValue = new Label();
            label6 = new Label();
            panel5 = new Panel();
            revenueChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            panel6 = new Panel();
            orderchart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            categorySalesChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            panel7 = new Panel();
            panel9 = new Panel();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)revenueChart).BeginInit();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)orderchart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)categorySalesChart).BeginInit();
            panel7.SuspendLayout();
            panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(43, 45, 85);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblTotalRevenue);
            panel1.Location = new Point(29, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(230, 57);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(165, 8);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(52, 41);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(126, 135, 169);
            label1.Location = new Point(2, 42);
            label1.Name = "label1";
            label1.Size = new Size(80, 13);
            label1.TabIndex = 0;
            label1.Text = "Total Revenue";
            label1.Click += label1_Click;
            // 
            // lblTotalRevenue
            // 
            lblTotalRevenue.AutoSize = true;
            lblTotalRevenue.BackColor = Color.Transparent;
            lblTotalRevenue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTotalRevenue.ForeColor = Color.White;
            lblTotalRevenue.Location = new Point(2, 2);
            lblTotalRevenue.Name = "lblTotalRevenue";
            lblTotalRevenue.Size = new Size(96, 30);
            lblTotalRevenue.TabIndex = 1;
            lblTotalRevenue.Text = "revenue";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(43, 45, 85);
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(lblTotalCustomers);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(279, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(230, 57);
            panel2.TabIndex = 1;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(167, 8);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(52, 41);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // lblTotalCustomers
            // 
            lblTotalCustomers.AutoSize = true;
            lblTotalCustomers.BackColor = Color.Transparent;
            lblTotalCustomers.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTotalCustomers.ForeColor = Color.White;
            lblTotalCustomers.Location = new Point(2, 2);
            lblTotalCustomers.Name = "lblTotalCustomers";
            lblTotalCustomers.Size = new Size(110, 30);
            lblTotalCustomers.TabIndex = 1;
            lblTotalCustomers.Text = "customer";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(126, 135, 169);
            label2.Location = new Point(2, 42);
            label2.Name = "label2";
            label2.Size = new Size(85, 13);
            label2.TabIndex = 0;
            label2.Text = "Total Customer";
            label2.Click += label1_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(43, 45, 85);
            panel3.Controls.Add(pictureBox3);
            panel3.Controls.Add(lblTotalOrders);
            panel3.Controls.Add(label4);
            panel3.Location = new Point(529, 12);
            panel3.Name = "panel3";
            panel3.Size = new Size(230, 57);
            panel3.TabIndex = 1;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(167, 8);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(52, 41);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 9;
            pictureBox3.TabStop = false;
            // 
            // lblTotalOrders
            // 
            lblTotalOrders.AutoSize = true;
            lblTotalOrders.BackColor = Color.Transparent;
            lblTotalOrders.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTotalOrders.ForeColor = Color.White;
            lblTotalOrders.Location = new Point(2, 2);
            lblTotalOrders.Name = "lblTotalOrders";
            lblTotalOrders.Size = new Size(70, 30);
            lblTotalOrders.TabIndex = 1;
            lblTotalOrders.Text = "order";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(126, 135, 169);
            label4.Location = new Point(2, 42);
            label4.Name = "label4";
            label4.Size = new Size(101, 13);
            label4.TabIndex = 0;
            label4.Text = "Number of Orders";
            label4.Click += label1_Click;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(43, 45, 85);
            panel4.Controls.Add(pictureBox4);
            panel4.Controls.Add(lblAverageOrderValue);
            panel4.Controls.Add(label6);
            panel4.Location = new Point(779, 12);
            panel4.Name = "panel4";
            panel4.Size = new Size(230, 57);
            panel4.TabIndex = 1;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(167, 8);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(52, 41);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 10;
            pictureBox4.TabStop = false;
            // 
            // lblAverageOrderValue
            // 
            lblAverageOrderValue.AutoSize = true;
            lblAverageOrderValue.BackColor = Color.Transparent;
            lblAverageOrderValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblAverageOrderValue.ForeColor = Color.White;
            lblAverageOrderValue.Location = new Point(2, 2);
            lblAverageOrderValue.Name = "lblAverageOrderValue";
            lblAverageOrderValue.Size = new Size(50, 30);
            lblAverageOrderValue.TabIndex = 1;
            lblAverageOrderValue.Text = "aov";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(126, 135, 169);
            label6.Location = new Point(2, 42);
            label6.Name = "label6";
            label6.Size = new Size(113, 13);
            label6.TabIndex = 0;
            label6.Text = "Average Order Value";
            label6.Click += label1_Click;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(43, 45, 85);
            panel5.Controls.Add(revenueChart);
            panel5.Location = new Point(29, 86);
            panel5.Name = "panel5";
            panel5.Size = new Size(480, 238);
            panel5.TabIndex = 0;
            // 
            // revenueChart
            // 
            revenueChart.BackColor = Color.Transparent;
            revenueChart.BorderlineColor = Color.Transparent;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.IsMarginVisible = false;
            chartArea1.AxisX.LabelStyle.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chartArea1.AxisX.LabelStyle.ForeColor = Color.White;
            chartArea1.AxisX.LineColor = Color.Transparent;
            chartArea1.AxisX.LineWidth = 0;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea1.AxisX.MajorGrid.LineWidth = 0;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisX.TitleFont = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chartArea1.AxisX.TitleForeColor = Color.White;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelStyle.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chartArea1.AxisY.LabelStyle.ForeColor = Color.White;
            chartArea1.AxisY.LabelStyle.Format = "${0:0,}K";
            chartArea1.AxisY.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.AxisY.TitleFont = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chartArea1.AxisY.TitleForeColor = Color.White;
            chartArea1.BackColor = Color.Transparent;
            chartArea1.Name = "Revenue";
            revenueChart.ChartAreas.Add(chartArea1);
            legend1.BackColor = Color.Transparent;
            legend1.Enabled = false;
            legend1.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            legend1.ForeColor = Color.White;
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            revenueChart.Legends.Add(legend1);
            revenueChart.Location = new Point(3, 3);
            revenueChart.Name = "revenueChart";
            series1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalLeft;
            series1.BorderColor = Color.FromArgb(128, 128, 255);
            series1.ChartArea = "Revenue";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            series1.Color = Color.FromArgb(128, 128, 255);
            series1.LabelForeColor = Color.White;
            series1.Legend = "Legend1";
            series1.Name = "Revenue";
            revenueChart.Series.Add(series1);
            revenueChart.Size = new Size(474, 232);
            revenueChart.TabIndex = 0;
            revenueChart.Text = "chart1";
            title1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            title1.ForeColor = Color.White;
            title1.Name = "c1";
            title1.Text = "Total Revenue By Month";
            revenueChart.Titles.Add(title1);
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(43, 45, 85);
            panel6.Controls.Add(orderchart);
            panel6.Location = new Point(29, 341);
            panel6.Name = "panel6";
            panel6.Size = new Size(480, 238);
            panel6.TabIndex = 0;
            // 
            // orderchart
            // 
            orderchart.BackColor = Color.Transparent;
            orderchart.BorderlineColor = Color.Transparent;
            chartArea2.AxisX.IsLabelAutoFit = false;
            chartArea2.AxisX.IsMarginVisible = false;
            chartArea2.AxisX.LabelStyle.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chartArea2.AxisX.LabelStyle.ForeColor = Color.White;
            chartArea2.AxisX.LineColor = Color.Transparent;
            chartArea2.AxisX.LineWidth = 0;
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea2.AxisX.MajorGrid.LineWidth = 0;
            chartArea2.AxisX.MajorTickMark.Enabled = false;
            chartArea2.AxisX.TitleFont = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chartArea2.AxisX.TitleForeColor = Color.White;
            chartArea2.AxisY.IsLabelAutoFit = false;
            chartArea2.AxisY.LabelStyle.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chartArea2.AxisY.LabelStyle.ForeColor = Color.White;
            chartArea2.AxisY.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea2.AxisY.MajorTickMark.Enabled = false;
            chartArea2.AxisY.TitleFont = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chartArea2.AxisY.TitleForeColor = Color.White;
            chartArea2.BackColor = Color.Transparent;
            chartArea2.Name = "Order";
            orderchart.ChartAreas.Add(chartArea2);
            legend2.BackColor = Color.Transparent;
            legend2.Enabled = false;
            legend2.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            legend2.ForeColor = Color.White;
            legend2.IsTextAutoFit = false;
            legend2.Name = "Legend1";
            orderchart.Legends.Add(legend2);
            orderchart.Location = new Point(3, 3);
            orderchart.Name = "orderchart";
            series2.BorderColor = Color.FromArgb(128, 128, 255);
            series2.BorderWidth = 0;
            series2.ChartArea = "Order";
            series2.Color = Color.FromArgb(255, 192, 255);
            series2.LabelForeColor = Color.White;
            series2.Legend = "Legend1";
            series2.Name = "Order";
            series3.ChartArea = "Order";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Legend = "Legend1";
            series3.Name = "OrderTrend";
            orderchart.Series.Add(series2);
            orderchart.Series.Add(series3);
            orderchart.Size = new Size(474, 232);
            orderchart.TabIndex = 1;
            orderchart.Text = "chart1";
            title2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            title2.ForeColor = Color.White;
            title2.Name = "c2";
            title2.Text = "Monthly Orders and Trend";
            orderchart.Titles.Add(title2);
            // 
            // categorySalesChart
            // 
            categorySalesChart.BackColor = Color.Transparent;
            categorySalesChart.BorderlineColor = Color.Transparent;
            chartArea3.AxisX.IsLabelAutoFit = false;
            chartArea3.AxisX.IsMarginVisible = false;
            chartArea3.AxisX.LabelStyle.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chartArea3.AxisX.LabelStyle.ForeColor = Color.White;
            chartArea3.AxisX.LineColor = Color.Transparent;
            chartArea3.AxisX.LineWidth = 0;
            chartArea3.AxisX.MajorGrid.Enabled = false;
            chartArea3.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea3.AxisX.MajorGrid.LineWidth = 0;
            chartArea3.AxisX.MajorTickMark.Enabled = false;
            chartArea3.AxisX.TitleFont = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            chartArea3.AxisX.TitleForeColor = Color.White;
            chartArea3.AxisY.IsLabelAutoFit = false;
            chartArea3.AxisY.LabelStyle.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chartArea3.AxisY.LabelStyle.ForeColor = Color.White;
            chartArea3.AxisY.LabelStyle.Format = "${0:0,}K";
            chartArea3.AxisY.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea3.AxisY.MajorTickMark.Enabled = false;
            chartArea3.AxisY.TitleFont = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            chartArea3.AxisY.TitleForeColor = Color.White;
            chartArea3.BackColor = Color.Transparent;
            chartArea3.Name = "CategorySales";
            categorySalesChart.ChartAreas.Add(chartArea3);
            legend3.BackColor = Color.Transparent;
            legend3.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            legend3.ForeColor = Color.White;
            legend3.IsTextAutoFit = false;
            legend3.Name = "Legend1";
            categorySalesChart.Legends.Add(legend3);
            categorySalesChart.Location = new Point(3, 3);
            categorySalesChart.Name = "categorySalesChart";
            categorySalesChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            categorySalesChart.PaletteCustomColors = new Color[]
    {
    Color.FromArgb(239, 188, 0),
    Color.FromArgb(241, 160, 139),
    Color.FromArgb(241, 88, 127),
    Color.FromArgb(1, 220, 205),
    Color.FromArgb(107, 83, 255),
    Color.FromArgb(66, 65, 65),
    Color.FromArgb(94, 219, 148),
    Color.FromArgb(56, 182, 255),
    Color.FromArgb(240, 88, 88),
    Color.FromArgb(165, 165, 251),
    Color.FromArgb(224, 216, 141),
    Color.Empty
    };
            series4.BackSecondaryColor = Color.DarkOliveGreen;
            series4.BorderColor = Color.FromArgb(43, 45, 85);
            series4.BorderWidth = 8;
            series4.ChartArea = "CategorySales";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series4.Color = Color.FromArgb(128, 128, 255);
            series4.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            series4.LabelForeColor = Color.White;
            series4.Legend = "Legend1";
            series4.Name = "CategorySales";
            categorySalesChart.Series.Add(series4);
            categorySalesChart.Size = new Size(474, 232);
            categorySalesChart.TabIndex = 1;
            categorySalesChart.Text = "chart1";
            title3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            title3.ForeColor = Color.White;
            title3.Name = "Title1";
            title3.Text = "Total Order by Category";
            categorySalesChart.Titles.Add(title3);
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(43, 45, 85);
            panel7.Controls.Add(categorySalesChart);
            panel7.Location = new Point(529, 86);
            panel7.Name = "panel7";
            panel7.Size = new Size(480, 238);
            panel7.TabIndex = 0;
            // 
            // panel9
            // 
            panel9.BackColor = Color.FromArgb(43, 45, 85);
            panel9.Controls.Add(chart1);
            panel9.Location = new Point(529, 341);
            panel9.Name = "panel9";
            panel9.Size = new Size(480, 238);
            panel9.TabIndex = 0;
            // 
            // chart1
            // 
            chart1.BackColor = Color.Transparent;
            chart1.BorderlineColor = Color.Transparent;
            chartArea4.AxisX.IsLabelAutoFit = false;
            chartArea4.AxisX.IsMarginVisible = false;
            chartArea4.AxisX.LabelStyle.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chartArea4.AxisX.LabelStyle.ForeColor = Color.White;
            chartArea4.AxisX.LineColor = Color.Transparent;
            chartArea4.AxisX.LineWidth = 0;
            chartArea4.AxisX.MajorGrid.Enabled = false;
            chartArea4.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea4.AxisX.MajorGrid.LineWidth = 0;
            chartArea4.AxisX.MajorTickMark.Enabled = false;
            chartArea4.AxisX.TitleFont = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chartArea4.AxisX.TitleForeColor = Color.White;
            chartArea4.AxisY.IsLabelAutoFit = false;
            chartArea4.AxisY.LabelStyle.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chartArea4.AxisY.LabelStyle.ForeColor = Color.White;
            chartArea4.AxisY.LabelStyle.Format = "${0:0,}K";
            chartArea4.AxisY.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea4.AxisY.MajorTickMark.Enabled = false;
            chartArea4.AxisY.TitleFont = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chartArea4.AxisY.TitleForeColor = Color.White;
            chartArea4.BackColor = Color.Transparent;
            chartArea4.Name = "Revenue";
            chart1.ChartAreas.Add(chartArea4);
            legend4.BackColor = Color.Transparent;
            legend4.Enabled = false;
            legend4.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            legend4.ForeColor = Color.White;
            legend4.IsTextAutoFit = false;
            legend4.Name = "Legend1";
            chart1.Legends.Add(legend4);
            chart1.Location = new Point(3, 3);
            chart1.Name = "chart1";
            series5.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalLeft;
            series5.BorderColor = Color.FromArgb(128, 128, 255);
            series5.ChartArea = "Revenue";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bubble;
            series5.Color = Color.FromArgb(128, 128, 255);
            series5.LabelForeColor = Color.White;
            series5.Legend = "Legend1";
            series5.Name = "Revenue";
            series5.YValuesPerPoint = 2;
            chart1.Series.Add(series5);
            chart1.Size = new Size(474, 232);
            chart1.TabIndex = 1;
            chart1.Text = "chart1";
            title4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            title4.ForeColor = Color.White;
            title4.Name = "c1";
            title4.Text = "Total Revenue By Month";
            chart1.Titles.Add(title4);
            // 
            // DashboardControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(27, 27, 66);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel7);
            Controls.Add(panel9);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel1);
            Name = "DashboardControl";
            Size = new Size(1028, 595);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)revenueChart).EndInit();
            panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)orderchart).EndInit();
            ((System.ComponentModel.ISupportInitialize)categorySalesChart).EndInit();
            panel7.ResumeLayout(false);
            panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel9;
        private Label label1;
        private Label lblTotalRevenue;
        private Label lblTotalCustomers;
        private Label label2;
        private Label lblTotalOrders;
        private Label label4;
        private Label lblAverageOrderValue;
        private Label label6;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private System.Windows.Forms.DataVisualization.Charting.Chart revenueChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart categorySalesChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart orderchart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}
