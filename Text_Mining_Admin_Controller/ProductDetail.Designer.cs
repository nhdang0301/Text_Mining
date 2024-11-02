namespace Text_Mining_Admin_Controller
{
    partial class ProductDetail
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductDetail));
            pictureBoxProduct = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtID = new TextBox();
            txtName = new TextBox();
            txtDescription = new TextBox();
            txtPrice = new TextBox();
            txtStock = new TextBox();
            labelLogin = new Label();
            panel7 = new Panel();
            btnUpdate = new Button();
            label6 = new Label();
            txtCatID = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProduct).BeginInit();
            panel7.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBoxProduct
            // 
            pictureBoxProduct.Location = new Point(5, 5);
            pictureBoxProduct.Name = "pictureBoxProduct";
            pictureBoxProduct.Size = new Size(300, 300);
            pictureBoxProduct.TabIndex = 0;
            pictureBoxProduct.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(31, 446);
            label1.Name = "label1";
            label1.Size = new Size(47, 17);
            label1.TabIndex = 1;
            label1.Text = "Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(31, 412);
            label2.Name = "label2";
            label2.Size = new Size(24, 17);
            label2.TabIndex = 1;
            label2.Text = "ID:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(31, 480);
            label3.Name = "label3";
            label3.Size = new Size(79, 17);
            label3.TabIndex = 1;
            label3.Text = "Description:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label4.ForeColor = SystemColors.ControlDarkDark;
            label4.Location = new Point(31, 512);
            label4.Name = "label4";
            label4.Size = new Size(40, 17);
            label4.TabIndex = 1;
            label4.Text = "Price:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label5.ForeColor = SystemColors.ControlDarkDark;
            label5.Location = new Point(31, 544);
            label5.Name = "label5";
            label5.Size = new Size(45, 17);
            label5.TabIndex = 1;
            label5.Text = "Stock:";
            // 
            // txtID
            // 
            txtID.ForeColor = SystemColors.ControlDarkDark;
            txtID.Location = new Point(151, 406);
            txtID.Name = "txtID";
            txtID.Size = new Size(196, 23);
            txtID.TabIndex = 1;
            // 
            // txtName
            // 
            txtName.ForeColor = SystemColors.ControlDarkDark;
            txtName.Location = new Point(151, 440);
            txtName.Name = "txtName";
            txtName.Size = new Size(196, 23);
            txtName.TabIndex = 2;
            // 
            // txtDescription
            // 
            txtDescription.ForeColor = SystemColors.ControlDarkDark;
            txtDescription.Location = new Point(151, 474);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(196, 23);
            txtDescription.TabIndex = 3;
            // 
            // txtPrice
            // 
            txtPrice.ForeColor = SystemColors.ControlDarkDark;
            txtPrice.Location = new Point(151, 506);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(196, 23);
            txtPrice.TabIndex = 4;
            // 
            // txtStock
            // 
            txtStock.ForeColor = SystemColors.ControlDarkDark;
            txtStock.Location = new Point(151, 538);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(196, 23);
            txtStock.TabIndex = 5;
            // 
            // labelLogin
            // 
            labelLogin.Anchor = AnchorStyles.None;
            labelLogin.AutoSize = true;
            labelLogin.BackColor = Color.Transparent;
            labelLogin.FlatStyle = FlatStyle.Flat;
            labelLogin.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelLogin.ForeColor = Color.FromArgb(85, 85, 170);
            labelLogin.Location = new Point(32, 32);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(324, 32);
            labelLogin.TabIndex = 4;
            labelLogin.Text = "Product Detail Information";
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(43, 45, 85);
            panel7.Controls.Add(pictureBoxProduct);
            panel7.Location = new Point(37, 70);
            panel7.Name = "panel7";
            panel7.Size = new Size(310, 310);
            panel7.TabIndex = 5;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(85, 85, 170);
            btnUpdate.FlatAppearance.BorderColor = Color.White;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(141, 619);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(98, 34);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label6.ForeColor = SystemColors.ControlDarkDark;
            label6.Location = new Point(31, 576);
            label6.Name = "label6";
            label6.Size = new Size(84, 17);
            label6.TabIndex = 1;
            label6.Text = "Category ID:";
            // 
            // txtCatID
            // 
            txtCatID.ForeColor = SystemColors.ControlDarkDark;
            txtCatID.Location = new Point(151, 570);
            txtCatID.Name = "txtCatID";
            txtCatID.Size = new Size(196, 23);
            txtCatID.TabIndex = 5;
            // 
            // ProductDetail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 192, 255);
            ClientSize = new Size(384, 681);
            Controls.Add(btnUpdate);
            Controls.Add(panel7);
            Controls.Add(labelLogin);
            Controls.Add(txtCatID);
            Controls.Add(txtStock);
            Controls.Add(txtPrice);
            Controls.Add(txtDescription);
            Controls.Add(txtName);
            Controls.Add(txtID);
            Controls.Add(label6);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "ProductDetail";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ProductDetail";
            ((System.ComponentModel.ISupportInitialize)pictureBoxProduct).EndInit();
            panel7.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxProduct;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtID;
        private TextBox txtName;
        private TextBox txtDescription;
        private TextBox txtPrice;
        private TextBox txtStock;
        private Label labelLogin;
        private Panel panel7;
        private Button btnUpdate;
        private Label label6;
        private TextBox txtCatID;
    }
}