namespace Qlyrapchieuphim
{
    partial class Bansanpham
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.loai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.ten = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2TextBox4 = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewImageColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.sanpham1 = new Qlyrapchieuphim.Sanpham();
            this.sanpham2 = new Qlyrapchieuphim.Sanpham();
            this.sanpham3 = new Qlyrapchieuphim.Sanpham();
            this.sanpham4 = new Qlyrapchieuphim.Sanpham();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.guna2Button5 = new Guna.UI2.WinForms.Guna2Button();
            this.thanhtoan = new Guna.UI2.WinForms.Guna2Button();
            this.sanpham5 = new Qlyrapchieuphim.Sanpham();
            this.sanpham6 = new Qlyrapchieuphim.Sanpham();
            this.sanpham7 = new Qlyrapchieuphim.Sanpham();
            this.sanpham8 = new Qlyrapchieuphim.Sanpham();
            this.sanpham9 = new Qlyrapchieuphim.Sanpham();
            this.sanpham10 = new Qlyrapchieuphim.Sanpham();
            this.sanpham11 = new Qlyrapchieuphim.Sanpham();
            this.sanpham12 = new Qlyrapchieuphim.Sanpham();
            this.sanpham13 = new Qlyrapchieuphim.Sanpham();
            this.sanpham14 = new Qlyrapchieuphim.Sanpham();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(50, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 18);
            this.label3.TabIndex = 27;
            this.label3.Text = "Tên:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(360, 21);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 18);
            this.label4.TabIndex = 28;
            this.label4.Text = "Loại:";
            // 
            // loai
            // 
            this.loai.BackColor = System.Drawing.Color.Transparent;
            this.loai.BorderColor = System.Drawing.Color.Gray;
            this.loai.BorderRadius = 10;
            this.loai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loai.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.loai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.loai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.loai.ForeColor = System.Drawing.Color.Black;
            this.loai.ItemHeight = 30;
            this.loai.Items.AddRange(new object[] {
            "Đồ ăn",
            "Thức uống"});
            this.loai.Location = new System.Drawing.Point(337, 43);
            this.loai.Margin = new System.Windows.Forms.Padding(4);
            this.loai.Name = "loai";
            this.loai.Size = new System.Drawing.Size(208, 36);
            this.loai.TabIndex = 30;
            // 
            // ten
            // 
            this.ten.BorderColor = System.Drawing.Color.Gray;
            this.ten.BorderRadius = 10;
            this.ten.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ten.DefaultText = "";
            this.ten.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.ten.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.ten.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ten.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ten.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ten.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ten.ForeColor = System.Drawing.Color.Black;
            this.ten.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ten.Location = new System.Drawing.Point(29, 43);
            this.ten.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ten.Name = "ten";
            this.ten.PasswordChar = '\0';
            this.ten.PlaceholderText = "";
            this.ten.SelectedText = "";
            this.ten.Size = new System.Drawing.Size(213, 36);
            this.ten.TabIndex = 29;
            // 
            // guna2TextBox4
            // 
            this.guna2TextBox4.BorderColor = System.Drawing.Color.Gray;
            this.guna2TextBox4.BorderRadius = 10;
            this.guna2TextBox4.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox4.DefaultText = "";
            this.guna2TextBox4.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox4.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox4.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox4.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox4.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBox4.ForeColor = System.Drawing.Color.Black;
            this.guna2TextBox4.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox4.Location = new System.Drawing.Point(29, 125);
            this.guna2TextBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.guna2TextBox4.Name = "guna2TextBox4";
            this.guna2TextBox4.PasswordChar = '\0';
            this.guna2TextBox4.PlaceholderText = "";
            this.guna2TextBox4.SelectedText = "";
            this.guna2TextBox4.Size = new System.Drawing.Size(308, 37);
            this.guna2TextBox4.TabIndex = 56;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 102);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 18);
            this.label1.TabIndex = 58;
            this.label1.Text = "Tìm kiếm:";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderRadius = 10;
            this.guna2Panel1.Controls.Add(this.label5);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.guna2Panel1.Location = new System.Drawing.Point(1021, 43);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(506, 100);
            this.guna2Panel1.TabIndex = 59;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(261, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(229, 54);
            this.label5.TabIndex = 1;
            this.label5.Text = "0.00";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(26, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 54);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tổng tiền";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeight = 40;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column4,
            this.Column6});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(1021, 150);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(506, 646);
            this.dataGridView1.TabIndex = 60;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Id";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "IdSanPham";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Visible = false;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 92.35294F;
            this.Column3.HeaderText = "Sản phẩm";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // Column5
            // 
            this.Column5.FillWeight = 92.35294F;
            this.Column5.HeaderText = "Giá";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            // 
            // Column4
            // 
            this.Column4.FillWeight = 92.35294F;
            this.Column4.HeaderText = "Số lượng";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // Column6
            // 
            this.Column6.FillWeight = 30F;
            this.Column6.HeaderText = "";
            this.Column6.Image = global::Qlyrapchieuphim.Properties.Resources.icons8_delete_24;
            this.Column6.MinimumWidth = 30;
            this.Column6.Name = "Column6";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.sanpham1);
            this.flowLayoutPanel1.Controls.Add(this.sanpham2);
            this.flowLayoutPanel1.Controls.Add(this.sanpham3);
            this.flowLayoutPanel1.Controls.Add(this.sanpham4);
            this.flowLayoutPanel1.Controls.Add(this.sanpham5);
            this.flowLayoutPanel1.Controls.Add(this.sanpham6);
            this.flowLayoutPanel1.Controls.Add(this.sanpham7);
            this.flowLayoutPanel1.Controls.Add(this.sanpham8);
            this.flowLayoutPanel1.Controls.Add(this.sanpham9);
            this.flowLayoutPanel1.Controls.Add(this.sanpham10);
            this.flowLayoutPanel1.Controls.Add(this.sanpham11);
            this.flowLayoutPanel1.Controls.Add(this.sanpham12);
            this.flowLayoutPanel1.Controls.Add(this.sanpham13);
            this.flowLayoutPanel1.Controls.Add(this.sanpham14);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(29, 191);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(966, 657);
            this.flowLayoutPanel1.TabIndex = 61;
            // 
            // sanpham1
            // 
            this.sanpham1.BackColor = System.Drawing.Color.White;
            this.sanpham1.Location = new System.Drawing.Point(3, 3);
            this.sanpham1.Name = "sanpham1";
            this.sanpham1.Size = new System.Drawing.Size(201, 196);
            this.sanpham1.TabIndex = 0;
            // 
            // sanpham2
            // 
            this.sanpham2.BackColor = System.Drawing.Color.White;
            this.sanpham2.Location = new System.Drawing.Point(210, 3);
            this.sanpham2.Name = "sanpham2";
            this.sanpham2.Size = new System.Drawing.Size(201, 196);
            this.sanpham2.TabIndex = 1;
            // 
            // sanpham3
            // 
            this.sanpham3.BackColor = System.Drawing.Color.White;
            this.sanpham3.Location = new System.Drawing.Point(417, 3);
            this.sanpham3.Name = "sanpham3";
            this.sanpham3.Size = new System.Drawing.Size(201, 196);
            this.sanpham3.TabIndex = 2;
            // 
            // sanpham4
            // 
            this.sanpham4.BackColor = System.Drawing.Color.White;
            this.sanpham4.Location = new System.Drawing.Point(624, 3);
            this.sanpham4.Name = "sanpham4";
            this.sanpham4.Size = new System.Drawing.Size(201, 196);
            this.sanpham4.TabIndex = 3;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.FillWeight = 30F;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::Qlyrapchieuphim.Properties.Resources.icons8_delete_24;
            this.dataGridViewImageColumn1.MinimumWidth = 6;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 126;
            // 
            // guna2Button5
            // 
            this.guna2Button5.BorderRadius = 20;
            this.guna2Button5.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button5.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button5.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button5.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button5.FillColor = System.Drawing.Color.LightSteelBlue;
            this.guna2Button5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button5.ForeColor = System.Drawing.Color.White;
            this.guna2Button5.Image = global::Qlyrapchieuphim.Properties.Resources.icons8_find_30;
            this.guna2Button5.Location = new System.Drawing.Point(345, 125);
            this.guna2Button5.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Button5.Name = "guna2Button5";
            this.guna2Button5.Size = new System.Drawing.Size(40, 37);
            this.guna2Button5.TabIndex = 57;
            // 
            // thanhtoan
            // 
            this.thanhtoan.BorderRadius = 10;
            this.thanhtoan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.thanhtoan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.thanhtoan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.thanhtoan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.thanhtoan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.thanhtoan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thanhtoan.ForeColor = System.Drawing.Color.White;
            this.thanhtoan.Location = new System.Drawing.Point(1338, 804);
            this.thanhtoan.Margin = new System.Windows.Forms.Padding(4);
            this.thanhtoan.Name = "thanhtoan";
            this.thanhtoan.Size = new System.Drawing.Size(189, 44);
            this.thanhtoan.TabIndex = 62;
            this.thanhtoan.Text = "Thanh toán";
            this.thanhtoan.Click += new System.EventHandler(this.thanhtoan_Click);
            // 
            // sanpham5
            // 
            this.sanpham5.BackColor = System.Drawing.Color.White;
            this.sanpham5.Location = new System.Drawing.Point(3, 205);
            this.sanpham5.Name = "sanpham5";
            this.sanpham5.Size = new System.Drawing.Size(201, 196);
            this.sanpham5.TabIndex = 4;
            // 
            // sanpham6
            // 
            this.sanpham6.BackColor = System.Drawing.Color.White;
            this.sanpham6.Location = new System.Drawing.Point(210, 205);
            this.sanpham6.Name = "sanpham6";
            this.sanpham6.Size = new System.Drawing.Size(201, 196);
            this.sanpham6.TabIndex = 5;
            // 
            // sanpham7
            // 
            this.sanpham7.BackColor = System.Drawing.Color.White;
            this.sanpham7.Location = new System.Drawing.Point(417, 205);
            this.sanpham7.Name = "sanpham7";
            this.sanpham7.Size = new System.Drawing.Size(201, 196);
            this.sanpham7.TabIndex = 6;
            // 
            // sanpham8
            // 
            this.sanpham8.BackColor = System.Drawing.Color.White;
            this.sanpham8.Location = new System.Drawing.Point(624, 205);
            this.sanpham8.Name = "sanpham8";
            this.sanpham8.Size = new System.Drawing.Size(201, 196);
            this.sanpham8.TabIndex = 7;
            // 
            // sanpham9
            // 
            this.sanpham9.BackColor = System.Drawing.Color.White;
            this.sanpham9.Location = new System.Drawing.Point(3, 407);
            this.sanpham9.Name = "sanpham9";
            this.sanpham9.Size = new System.Drawing.Size(201, 196);
            this.sanpham9.TabIndex = 8;
            // 
            // sanpham10
            // 
            this.sanpham10.BackColor = System.Drawing.Color.White;
            this.sanpham10.Location = new System.Drawing.Point(210, 407);
            this.sanpham10.Name = "sanpham10";
            this.sanpham10.Size = new System.Drawing.Size(201, 196);
            this.sanpham10.TabIndex = 9;
            // 
            // sanpham11
            // 
            this.sanpham11.BackColor = System.Drawing.Color.White;
            this.sanpham11.Location = new System.Drawing.Point(417, 407);
            this.sanpham11.Name = "sanpham11";
            this.sanpham11.Size = new System.Drawing.Size(201, 196);
            this.sanpham11.TabIndex = 10;
            // 
            // sanpham12
            // 
            this.sanpham12.BackColor = System.Drawing.Color.White;
            this.sanpham12.Location = new System.Drawing.Point(624, 407);
            this.sanpham12.Name = "sanpham12";
            this.sanpham12.Size = new System.Drawing.Size(201, 196);
            this.sanpham12.TabIndex = 11;
            // 
            // sanpham13
            // 
            this.sanpham13.BackColor = System.Drawing.Color.White;
            this.sanpham13.Location = new System.Drawing.Point(3, 609);
            this.sanpham13.Name = "sanpham13";
            this.sanpham13.Size = new System.Drawing.Size(201, 196);
            this.sanpham13.TabIndex = 12;
            // 
            // sanpham14
            // 
            this.sanpham14.BackColor = System.Drawing.Color.White;
            this.sanpham14.Location = new System.Drawing.Point(210, 609);
            this.sanpham14.Name = "sanpham14";
            this.sanpham14.Size = new System.Drawing.Size(201, 196);
            this.sanpham14.TabIndex = 13;
            // 
            // Bansanpham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1553, 875);
            this.Controls.Add(this.thanhtoan);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2Button5);
            this.Controls.Add(this.guna2TextBox4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.loai);
            this.Controls.Add(this.ten);
            this.Name = "Bansanpham";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bansanpham";
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2ComboBox loai;
        private Guna.UI2.WinForms.Guna2TextBox ten;
        private Guna.UI2.WinForms.Guna2Button guna2Button5;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox4;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewImageColumn Column6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Sanpham sanpham1;
        private Sanpham sanpham2;
        private Sanpham sanpham3;
        private Sanpham sanpham4;
        private Guna.UI2.WinForms.Guna2Button thanhtoan;
        private Sanpham sanpham5;
        private Sanpham sanpham6;
        private Sanpham sanpham7;
        private Sanpham sanpham8;
        private Sanpham sanpham9;
        private Sanpham sanpham10;
        private Sanpham sanpham11;
        private Sanpham sanpham12;
        private Sanpham sanpham13;
        private Sanpham sanpham14;
    }
}