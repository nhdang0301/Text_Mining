namespace Text_Mining_Admin_Controller
{
    partial class AddProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddProduct));
            btnAdd = new Button();
            panel7 = new Panel();
            pictureBoxPreview = new PictureBox();
            labelLogin = new Label();
            txtCategoryID = new TextBox();
            txtStockQuantity = new TextBox();
            txtPrice = new TextBox();
            txtDescription = new TextBox();
            txtName = new TextBox();
            txtID = new TextBox();
            label6 = new Label();
            label2 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            button1 = new Button();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPreview).BeginInit();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(85, 85, 170);
            btnAdd.FlatAppearance.BorderColor = Color.White;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(140, 629);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(98, 34);
            btnAdd.TabIndex = 21;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(43, 45, 85);
            panel7.Controls.Add(pictureBoxPreview);
            panel7.Location = new Point(36, 68);
            panel7.Name = "panel7";
            panel7.Size = new Size(310, 310);
            panel7.TabIndex = 18;
            // 
            // pictureBoxPreview
            // 
            pictureBoxPreview.Location = new Point(5, 5);
            pictureBoxPreview.Name = "pictureBoxPreview";
            pictureBoxPreview.Size = new Size(300, 300);
            pictureBoxPreview.TabIndex = 0;
            pictureBoxPreview.TabStop = false;
            // 
            // labelLogin
            // 
            labelLogin.Anchor = AnchorStyles.None;
            labelLogin.AutoSize = true;
            labelLogin.BackColor = Color.Transparent;
            labelLogin.FlatStyle = FlatStyle.Flat;
            labelLogin.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelLogin.ForeColor = Color.FromArgb(85, 85, 170);
            labelLogin.Location = new Point(72, 24);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(236, 32);
            labelLogin.TabIndex = 16;
            labelLogin.Text = "Add Product to List";
            // 
            // txtCategoryID
            // 
            txtCategoryID.ForeColor = SystemColors.ControlDarkDark;
            txtCategoryID.Location = new Point(150, 588);
            txtCategoryID.Name = "txtCategoryID";
            txtCategoryID.Size = new Size(196, 23);
            txtCategoryID.TabIndex = 19;
            // 
            // txtStockQuantity
            // 
            txtStockQuantity.ForeColor = SystemColors.ControlDarkDark;
            txtStockQuantity.Location = new Point(150, 556);
            txtStockQuantity.Name = "txtStockQuantity";
            txtStockQuantity.Size = new Size(196, 23);
            txtStockQuantity.TabIndex = 20;
            // 
            // txtPrice
            // 
            txtPrice.ForeColor = SystemColors.ControlDarkDark;
            txtPrice.Location = new Point(150, 524);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(196, 23);
            txtPrice.TabIndex = 17;
            // 
            // txtDescription
            // 
            txtDescription.ForeColor = SystemColors.ControlDarkDark;
            txtDescription.Location = new Point(150, 492);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(196, 23);
            txtDescription.TabIndex = 15;
            // 
            // txtName
            // 
            txtName.ForeColor = SystemColors.ControlDarkDark;
            txtName.Location = new Point(150, 458);
            txtName.Name = "txtName";
            txtName.Size = new Size(196, 23);
            txtName.TabIndex = 14;
            // 
            // txtID
            // 
            txtID.ForeColor = SystemColors.ControlDarkDark;
            txtID.Location = new Point(150, 424);
            txtID.Name = "txtID";
            txtID.Size = new Size(196, 23);
            txtID.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label6.ForeColor = SystemColors.ControlDarkDark;
            label6.Location = new Point(30, 594);
            label6.Name = "label6";
            label6.Size = new Size(84, 17);
            label6.TabIndex = 8;
            label6.Text = "Category ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(30, 430);
            label2.Name = "label2";
            label2.Size = new Size(24, 17);
            label2.TabIndex = 9;
            label2.Text = "ID:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label5.ForeColor = SystemColors.ControlDarkDark;
            label5.Location = new Point(30, 562);
            label5.Name = "label5";
            label5.Size = new Size(45, 17);
            label5.TabIndex = 10;
            label5.Text = "Stock:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label4.ForeColor = SystemColors.ControlDarkDark;
            label4.Location = new Point(30, 530);
            label4.Name = "label4";
            label4.Size = new Size(40, 17);
            label4.TabIndex = 11;
            label4.Text = "Price:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(30, 498);
            label3.Name = "label3";
            label3.Size = new Size(79, 17);
            label3.TabIndex = 12;
            label3.Text = "Description:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(30, 464);
            label1.Name = "label1";
            label1.Size = new Size(47, 17);
            label1.TabIndex = 13;
            label1.Text = "Name:";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(85, 85, 170);
            button1.FlatAppearance.BorderColor = Color.White;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(36, 384);
            button1.Name = "button1";
            button1.Size = new Size(98, 24);
            button1.TabIndex = 21;
            button1.Text = "Choose Image";
            button1.UseVisualStyleBackColor = false;
            button1.Click += btnSelectImage_Click;
            // 
            // AddProduct
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 192, 255);
            ClientSize = new Size(384, 681);
            Controls.Add(button1);
            Controls.Add(btnAdd);
            Controls.Add(panel7);
            Controls.Add(labelLogin);
            Controls.Add(txtCategoryID);
            Controls.Add(txtStockQuantity);
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
            Name = "AddProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddProduct";
            panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxPreview).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAdd;
        private Panel panel7;
        private PictureBox pictureBoxPreview;
        private Label labelLogin;
        private TextBox txtCategoryID;
        private TextBox txtStockQuantity;
        private TextBox txtPrice;
        private TextBox txtDescription;
        private TextBox txtName;
        private TextBox txtID;
        private Label label6;
        private Label label2;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label1;
        private Button button1;
    }
}