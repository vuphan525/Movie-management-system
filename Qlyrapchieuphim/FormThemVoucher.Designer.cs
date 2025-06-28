namespace Qlyrapchieuphim
{
    partial class FormThemVoucher
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
            this.components = new System.ComponentModel.Container();
            this.them = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.label11 = new System.Windows.Forms.Label();
            this.lbl_FormThemVoucher_MoTa = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbl_FormThemVoucher_DiscountPercent = new Guna.UI2.WinForms.Guna2TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl_FormThemVoucher_HoaDonToiThieu = new Guna.UI2.WinForms.Guna2TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_FormThemVoucher_SoLuong = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.date_FormThemVoucher_NgayHetHan = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_FormThemVoucher_TrangThai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lbl_FormThemVoucher_MaPhatHanh = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_Refresh = new Guna.UI2.WinForms.Guna2Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // them
            // 
            this.them.BorderRadius = 10;
            this.them.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.them.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.them.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.them.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.them.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.them.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.them.ForeColor = System.Drawing.Color.White;
            this.them.Location = new System.Drawing.Point(404, 429);
            this.them.Name = "them";
            this.them.Size = new System.Drawing.Size(126, 36);
            this.them.TabIndex = 62;
            this.them.Text = "Thêm";
            this.them.Click += new System.EventHandler(this.them_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 16);
            this.label2.TabIndex = 52;
            this.label2.Text = "Thêm voucher";
            // 
            // guna2Button2
            // 
            this.guna2Button2.BorderRadius = 15;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button2.ForeColor = System.Drawing.Color.Black;
            this.guna2Button2.Image = global::Qlyrapchieuphim.Properties.Resources.icons8_exit_35;
            this.guna2Button2.Location = new System.Drawing.Point(505, 11);
            this.guna2Button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(26, 28);
            this.guna2Button2.TabIndex = 85;
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(286, 171);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 15);
            this.label11.TabIndex = 137;
            this.label11.Text = "Mô tả:";
            // 
            // lbl_FormThemVoucher_MoTa
            // 
            this.lbl_FormThemVoucher_MoTa.BorderColor = System.Drawing.Color.Gray;
            this.lbl_FormThemVoucher_MoTa.BorderRadius = 5;
            this.lbl_FormThemVoucher_MoTa.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lbl_FormThemVoucher_MoTa.DefaultText = "";
            this.lbl_FormThemVoucher_MoTa.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.lbl_FormThemVoucher_MoTa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.lbl_FormThemVoucher_MoTa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.lbl_FormThemVoucher_MoTa.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.lbl_FormThemVoucher_MoTa.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lbl_FormThemVoucher_MoTa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_FormThemVoucher_MoTa.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lbl_FormThemVoucher_MoTa.Location = new System.Drawing.Point(287, 189);
            this.lbl_FormThemVoucher_MoTa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbl_FormThemVoucher_MoTa.Multiline = true;
            this.lbl_FormThemVoucher_MoTa.Name = "lbl_FormThemVoucher_MoTa";
            this.lbl_FormThemVoucher_MoTa.PasswordChar = '\0';
            this.lbl_FormThemVoucher_MoTa.PlaceholderText = "";
            this.lbl_FormThemVoucher_MoTa.SelectedText = "";
            this.lbl_FormThemVoucher_MoTa.Size = new System.Drawing.Size(242, 127);
            this.lbl_FormThemVoucher_MoTa.TabIndex = 136;
            // 
            // lbl_FormThemVoucher_DiscountPercent
            // 
            this.lbl_FormThemVoucher_DiscountPercent.BorderColor = System.Drawing.Color.Gray;
            this.lbl_FormThemVoucher_DiscountPercent.BorderRadius = 10;
            this.lbl_FormThemVoucher_DiscountPercent.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lbl_FormThemVoucher_DiscountPercent.DefaultText = "";
            this.lbl_FormThemVoucher_DiscountPercent.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.lbl_FormThemVoucher_DiscountPercent.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.lbl_FormThemVoucher_DiscountPercent.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.lbl_FormThemVoucher_DiscountPercent.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.lbl_FormThemVoucher_DiscountPercent.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lbl_FormThemVoucher_DiscountPercent.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_FormThemVoucher_DiscountPercent.ForeColor = System.Drawing.Color.Black;
            this.lbl_FormThemVoucher_DiscountPercent.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lbl_FormThemVoucher_DiscountPercent.Location = new System.Drawing.Point(15, 139);
            this.lbl_FormThemVoucher_DiscountPercent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbl_FormThemVoucher_DiscountPercent.Name = "lbl_FormThemVoucher_DiscountPercent";
            this.lbl_FormThemVoucher_DiscountPercent.PasswordChar = '\0';
            this.lbl_FormThemVoucher_DiscountPercent.PlaceholderText = "";
            this.lbl_FormThemVoucher_DiscountPercent.SelectedText = "";
            this.lbl_FormThemVoucher_DiscountPercent.Size = new System.Drawing.Size(246, 33);
            this.lbl_FormThemVoucher_DiscountPercent.TabIndex = 135;
            this.lbl_FormThemVoucher_DiscountPercent.TextChanged += new System.EventHandler(this.lbl_FormThemVoucher_DiscountPercent_TextChanged);
            this.lbl_FormThemVoucher_DiscountPercent.Leave += new System.EventHandler(this.lbl_FormThemVoucher_DiscountPercent_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(13, 106);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 15);
            this.label10.TabIndex = 134;
            this.label10.Text = "Mức giảm(%):";
            // 
            // lbl_FormThemVoucher_HoaDonToiThieu
            // 
            this.lbl_FormThemVoucher_HoaDonToiThieu.BorderColor = System.Drawing.Color.Gray;
            this.lbl_FormThemVoucher_HoaDonToiThieu.BorderRadius = 10;
            this.lbl_FormThemVoucher_HoaDonToiThieu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lbl_FormThemVoucher_HoaDonToiThieu.DefaultText = "";
            this.lbl_FormThemVoucher_HoaDonToiThieu.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.lbl_FormThemVoucher_HoaDonToiThieu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.lbl_FormThemVoucher_HoaDonToiThieu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.lbl_FormThemVoucher_HoaDonToiThieu.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.lbl_FormThemVoucher_HoaDonToiThieu.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lbl_FormThemVoucher_HoaDonToiThieu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_FormThemVoucher_HoaDonToiThieu.ForeColor = System.Drawing.Color.Black;
            this.lbl_FormThemVoucher_HoaDonToiThieu.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lbl_FormThemVoucher_HoaDonToiThieu.Location = new System.Drawing.Point(287, 53);
            this.lbl_FormThemVoucher_HoaDonToiThieu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbl_FormThemVoucher_HoaDonToiThieu.Name = "lbl_FormThemVoucher_HoaDonToiThieu";
            this.lbl_FormThemVoucher_HoaDonToiThieu.PasswordChar = '\0';
            this.lbl_FormThemVoucher_HoaDonToiThieu.PlaceholderText = "";
            this.lbl_FormThemVoucher_HoaDonToiThieu.SelectedText = "";
            this.lbl_FormThemVoucher_HoaDonToiThieu.Size = new System.Drawing.Size(242, 33);
            this.lbl_FormThemVoucher_HoaDonToiThieu.TabIndex = 133;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(287, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 15);
            this.label9.TabIndex = 132;
            this.label9.Text = "Hóa đơn tối thiểu:";
            // 
            // lbl_FormThemVoucher_SoLuong
            // 
            this.lbl_FormThemVoucher_SoLuong.BorderColor = System.Drawing.Color.Gray;
            this.lbl_FormThemVoucher_SoLuong.BorderRadius = 10;
            this.lbl_FormThemVoucher_SoLuong.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lbl_FormThemVoucher_SoLuong.DefaultText = "";
            this.lbl_FormThemVoucher_SoLuong.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.lbl_FormThemVoucher_SoLuong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.lbl_FormThemVoucher_SoLuong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.lbl_FormThemVoucher_SoLuong.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.lbl_FormThemVoucher_SoLuong.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lbl_FormThemVoucher_SoLuong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_FormThemVoucher_SoLuong.ForeColor = System.Drawing.Color.Black;
            this.lbl_FormThemVoucher_SoLuong.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lbl_FormThemVoucher_SoLuong.Location = new System.Drawing.Point(13, 283);
            this.lbl_FormThemVoucher_SoLuong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbl_FormThemVoucher_SoLuong.Name = "lbl_FormThemVoucher_SoLuong";
            this.lbl_FormThemVoucher_SoLuong.PasswordChar = '\0';
            this.lbl_FormThemVoucher_SoLuong.PlaceholderText = "";
            this.lbl_FormThemVoucher_SoLuong.SelectedText = "";
            this.lbl_FormThemVoucher_SoLuong.Size = new System.Drawing.Size(246, 33);
            this.lbl_FormThemVoucher_SoLuong.TabIndex = 131;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 260);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 15);
            this.label8.TabIndex = 130;
            this.label8.Text = "Số lượng:";
            // 
            // date_FormThemVoucher_NgayHetHan
            // 
            this.date_FormThemVoucher_NgayHetHan.BorderRadius = 15;
            this.date_FormThemVoucher_NgayHetHan.Checked = true;
            this.date_FormThemVoucher_NgayHetHan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.date_FormThemVoucher_NgayHetHan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.date_FormThemVoucher_NgayHetHan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_FormThemVoucher_NgayHetHan.Location = new System.Drawing.Point(13, 207);
            this.date_FormThemVoucher_NgayHetHan.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.date_FormThemVoucher_NgayHetHan.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.date_FormThemVoucher_NgayHetHan.Name = "date_FormThemVoucher_NgayHetHan";
            this.date_FormThemVoucher_NgayHetHan.Size = new System.Drawing.Size(246, 32);
            this.date_FormThemVoucher_NgayHetHan.TabIndex = 129;
            this.date_FormThemVoucher_NgayHetHan.Value = new System.DateTime(2024, 11, 29, 16, 51, 14, 647);
            this.date_FormThemVoucher_NgayHetHan.ValueChanged += new System.EventHandler(this.date_FormThemVoucher_NgayHetHan_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 128;
            this.label6.Text = "Ngày hết hạn:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // cb_FormThemVoucher_TrangThai
            // 
            this.cb_FormThemVoucher_TrangThai.BackColor = System.Drawing.Color.Transparent;
            this.cb_FormThemVoucher_TrangThai.BorderColor = System.Drawing.Color.Gray;
            this.cb_FormThemVoucher_TrangThai.BorderRadius = 10;
            this.cb_FormThemVoucher_TrangThai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_FormThemVoucher_TrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_FormThemVoucher_TrangThai.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cb_FormThemVoucher_TrangThai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cb_FormThemVoucher_TrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cb_FormThemVoucher_TrangThai.ForeColor = System.Drawing.Color.Black;
            this.cb_FormThemVoucher_TrangThai.ItemHeight = 30;
            this.cb_FormThemVoucher_TrangThai.Items.AddRange(new object[] {
            "NOT ACTIVE",
            "ACTIVE"});
            this.cb_FormThemVoucher_TrangThai.Location = new System.Drawing.Point(287, 124);
            this.cb_FormThemVoucher_TrangThai.Name = "cb_FormThemVoucher_TrangThai";
            this.cb_FormThemVoucher_TrangThai.Size = new System.Drawing.Size(243, 36);
            this.cb_FormThemVoucher_TrangThai.TabIndex = 127;
            // 
            // lbl_FormThemVoucher_MaPhatHanh
            // 
            this.lbl_FormThemVoucher_MaPhatHanh.BorderColor = System.Drawing.Color.Gray;
            this.lbl_FormThemVoucher_MaPhatHanh.BorderRadius = 10;
            this.lbl_FormThemVoucher_MaPhatHanh.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lbl_FormThemVoucher_MaPhatHanh.DefaultText = "";
            this.lbl_FormThemVoucher_MaPhatHanh.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.lbl_FormThemVoucher_MaPhatHanh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.lbl_FormThemVoucher_MaPhatHanh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.lbl_FormThemVoucher_MaPhatHanh.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.lbl_FormThemVoucher_MaPhatHanh.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lbl_FormThemVoucher_MaPhatHanh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_FormThemVoucher_MaPhatHanh.ForeColor = System.Drawing.Color.Black;
            this.lbl_FormThemVoucher_MaPhatHanh.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lbl_FormThemVoucher_MaPhatHanh.Location = new System.Drawing.Point(13, 53);
            this.lbl_FormThemVoucher_MaPhatHanh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbl_FormThemVoucher_MaPhatHanh.Name = "lbl_FormThemVoucher_MaPhatHanh";
            this.lbl_FormThemVoucher_MaPhatHanh.PasswordChar = '\0';
            this.lbl_FormThemVoucher_MaPhatHanh.PlaceholderText = "";
            this.lbl_FormThemVoucher_MaPhatHanh.SelectedText = "";
            this.lbl_FormThemVoucher_MaPhatHanh.Size = new System.Drawing.Size(246, 33);
            this.lbl_FormThemVoucher_MaPhatHanh.TabIndex = 125;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(287, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 15);
            this.label4.TabIndex = 124;
            this.label4.Text = "Trạng thái:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 15);
            this.label7.TabIndex = 122;
            this.label7.Text = "Mã phát hành:";
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.BorderRadius = 10;
            this.btn_Refresh.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Refresh.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Refresh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Refresh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Refresh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.btn_Refresh.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Refresh.ForeColor = System.Drawing.Color.White;
            this.btn_Refresh.Location = new System.Drawing.Point(254, 429);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(126, 36);
            this.btn_Refresh.TabIndex = 138;
            this.btn_Refresh.Text = "Làm mới";
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FormThemVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(542, 475);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lbl_FormThemVoucher_MoTa);
            this.Controls.Add(this.lbl_FormThemVoucher_DiscountPercent);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lbl_FormThemVoucher_HoaDonToiThieu);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbl_FormThemVoucher_SoLuong);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.date_FormThemVoucher_NgayHetHan);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cb_FormThemVoucher_TrangThai);
            this.Controls.Add(this.lbl_FormThemVoucher_MaPhatHanh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.them);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormThemVoucher";
            this.ShowInTaskbar = false;
            this.Text = "FormThemVoucher";
            this.Load += new System.EventHandler(this.FormThemVoucher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button them;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2TextBox lbl_FormThemVoucher_MoTa;
        private Guna.UI2.WinForms.Guna2TextBox lbl_FormThemVoucher_DiscountPercent;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2TextBox lbl_FormThemVoucher_HoaDonToiThieu;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2TextBox lbl_FormThemVoucher_SoLuong;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2DateTimePicker date_FormThemVoucher_NgayHetHan;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2ComboBox cb_FormThemVoucher_TrangThai;
        private Guna.UI2.WinForms.Guna2TextBox lbl_FormThemVoucher_MaPhatHanh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2Button btn_Refresh;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}