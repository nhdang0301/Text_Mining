namespace Text_Mining_Admin_Controller
{
    partial class ProductControl
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductControl));
            dataGridViewListProduct = new DataGridView();
            btnNext = new Button();
            btnPrevious = new Button();
            lblPageInfo = new Label();
            panel5 = new Panel();
            btnDelete = new Button();
            btnAdd = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            textBox2 = new TextBox();
            label1 = new Label();
            cmbCategory = new ComboBox();
            label2 = new Label();
            cbSortOrder = new ComboBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewListProduct).BeginInit();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewListProduct
            // 
            dataGridViewListProduct.AllowUserToAddRows = false;
            dataGridViewListProduct.AllowUserToDeleteRows = false;
            dataGridViewListProduct.AllowUserToResizeRows = false;
            dataGridViewListProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewListProduct.BackgroundColor = Color.FromArgb(43, 45, 85);
            dataGridViewListProduct.BorderStyle = BorderStyle.None;
            dataGridViewListProduct.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewListProduct.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(43, 45, 85);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(0, 0, 0, 10);
            dataGridViewCellStyle1.SelectionBackColor = Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewListProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewListProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(43, 45, 85);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(192, 192, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridViewListProduct.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewListProduct.EnableHeadersVisualStyles = false;
            dataGridViewListProduct.GridColor = Color.FromArgb(73, 75, 111);
            dataGridViewListProduct.Location = new Point(3, 7);
            dataGridViewListProduct.Name = "dataGridViewListProduct";
            dataGridViewListProduct.ReadOnly = true;
            dataGridViewListProduct.RowHeadersVisible = false;
            dataGridViewListProduct.RowTemplate.DividerHeight = 5;
            dataGridViewListProduct.RowTemplate.Height = 40;
            dataGridViewListProduct.RowTemplate.ReadOnly = true;
            dataGridViewListProduct.ScrollBars = ScrollBars.None;
            dataGridViewListProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewListProduct.Size = new Size(972, 433);
            dataGridViewListProduct.TabIndex = 0;
            dataGridViewListProduct.CellClick += dataGridViewListProduct_CellClick;
            dataGridViewListProduct.CellMouseEnter += dataGridViewListProduct_CellMouseEnter;
            dataGridViewListProduct.CellMouseLeave += dataGridViewListProduct_CellMouseLeave;
            // 
            // btnNext
            // 
            btnNext.BackColor = Color.FromArgb(85, 85, 170);
            btnNext.FlatAppearance.BorderColor = Color.White;
            btnNext.FlatAppearance.BorderSize = 0;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNext.ForeColor = Color.White;
            btnNext.Location = new Point(966, 537);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(37, 37);
            btnNext.TabIndex = 4;
            btnNext.Text = "▶️";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.BackColor = Color.FromArgb(85, 85, 170);
            btnPrevious.FlatAppearance.BorderColor = Color.White;
            btnPrevious.FlatAppearance.BorderSize = 0;
            btnPrevious.FlatStyle = FlatStyle.Flat;
            btnPrevious.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrevious.ForeColor = Color.White;
            btnPrevious.Location = new Point(812, 537);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(37, 37);
            btnPrevious.TabIndex = 4;
            btnPrevious.Text = "◀️";
            btnPrevious.UseVisualStyleBackColor = false;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // lblPageInfo
            // 
            lblPageInfo.AutoSize = true;
            lblPageInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPageInfo.ForeColor = Color.White;
            lblPageInfo.Location = new Point(855, 545);
            lblPageInfo.Name = "lblPageInfo";
            lblPageInfo.Size = new Size(57, 21);
            lblPageInfo.TabIndex = 5;
            lblPageInfo.Text = "label1";
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(43, 45, 85);
            panel5.Controls.Add(dataGridViewListProduct);
            panel5.Location = new Point(25, 64);
            panel5.Name = "panel5";
            panel5.Size = new Size(978, 450);
            panel5.TabIndex = 6;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(85, 85, 170);
            btnDelete.FlatAppearance.BorderColor = Color.White;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = Color.White;
            btnDelete.Image = (Image)resources.GetObject("btnDelete.Image");
            btnDelete.ImageAlign = ContentAlignment.MiddleLeft;
            btnDelete.Location = new Point(145, 537);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(98, 37);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "       Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(85, 85, 170);
            btnAdd.FlatAppearance.BorderColor = Color.White;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.Image = (Image)resources.GetObject("btnAdd.Image");
            btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdd.Location = new Point(25, 537);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(98, 37);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "       Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAddProduct_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(807, 18);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(126, 23);
            txtSearch.TabIndex = 8;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(85, 85, 170);
            btnSearch.FlatAppearance.BorderColor = Color.White;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.White;
            btnSearch.ImageAlign = ContentAlignment.MiddleLeft;
            btnSearch.Location = new Point(949, 17);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(51, 23);
            btnSearch.TabIndex = 7;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(1625, -510);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(704, 20);
            label1.Name = "label1";
            label1.Size = new Size(101, 21);
            label1.TabIndex = 5;
            label1.Text = "Find product:";
            // 
            // cmbCategory
            // 
            cmbCategory.BackColor = Color.FromArgb(192, 192, 255);
            cmbCategory.FlatStyle = FlatStyle.Flat;
            cmbCategory.ForeColor = Color.Black;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(104, 17);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(121, 23);
            cmbCategory.TabIndex = 9;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(25, 19);
            label2.Name = "label2";
            label2.Size = new Size(76, 21);
            label2.TabIndex = 5;
            label2.Text = "Category:";
            // 
            // cbSortOrder
            // 
            cbSortOrder.BackColor = Color.FromArgb(192, 192, 255);
            cbSortOrder.FlatStyle = FlatStyle.Flat;
            cbSortOrder.ForeColor = Color.Black;
            cbSortOrder.FormattingEnabled = true;
            cbSortOrder.Items.AddRange(new object[] { "Ascending", "Descending" });
            cbSortOrder.Location = new Point(354, 17);
            cbSortOrder.Name = "cbSortOrder";
            cbSortOrder.Size = new Size(121, 23);
            cbSortOrder.TabIndex = 9;
            cbSortOrder.SelectedIndexChanged += cbSortOrder_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(252, 19);
            label3.Name = "label3";
            label3.Size = new Size(101, 21);
            label3.TabIndex = 5;
            label3.Text = "Sort by Price:";
            // 
            // ProductControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(27, 27, 66);
            Controls.Add(cbSortOrder);
            Controls.Add(cmbCategory);
            Controls.Add(textBox2);
            Controls.Add(txtSearch);
            Controls.Add(btnSearch);
            Controls.Add(btnAdd);
            Controls.Add(btnDelete);
            Controls.Add(panel5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblPageInfo);
            Controls.Add(btnPrevious);
            Controls.Add(btnNext);
            Name = "ProductControl";
            Size = new Size(1028, 595);
            ((System.ComponentModel.ISupportInitialize)dataGridViewListProduct).EndInit();
            panel5.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewListProduct;
        private Button btnNext;
        private Button btnPrevious;
        private Label lblPageInfo;
        private Panel panel5;
        private Button btnDelete;
        private Button btnAdd;
        private TextBox txtSearch;
        private Button btnSearch;
        private TextBox textBox2;
        private Label label1;
        private ComboBox cmbCategory;
        private Label label2;
        private ComboBox cbSortOrder;
        private Label label3;
    }
}
