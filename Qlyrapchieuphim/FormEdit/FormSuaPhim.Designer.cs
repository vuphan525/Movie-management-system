namespace Qlyrapchieuphim.FormEdit
{
    partial class FormSuaPhim
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
            this.label8 = new System.Windows.Forms.Label();
            this.AddButton = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.label11 = new System.Windows.Forms.Label();
            this.date_FormSuaPhim_NgayPhatHanh = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox_FormSuaPhim_Poster = new System.Windows.Forms.PictureBox();
            this.lbl_FormSuaPhim_MoTa = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbl_FormSuaPhim_ThoiLuong = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbl_FormSuaPhim_TenPhim = new Guna.UI2.WinForms.Guna2TextBox();
            this.cb_FormSuaPhim_TinhTrang = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cb_FormSuaPhim_TheLoai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lbl_FormSuaPhim_MovieID = new Guna.UI2.WinForms.Guna2TextBox();
            this.btn_FormSuaPhim_ThemPoster = new Guna.UI2.WinForms.Guna2Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.date_FormSuaPhim_NgayNhap = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btn_Refresh = new Guna.UI2.WinForms.Guna2Button();
            this.lbl_FormSuaPhim_Gia = new Guna.UI2.WinForms.Guna2TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cb_FormSuaPhim_NhaPhatHanh = new Guna.UI2.WinForms.Guna2ComboBox();
            this.errorProvider_Gia = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider_ThoiLuong = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_FormSuaPhim_Poster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_Gia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_ThoiLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(141, 25);
            this.label8.TabIndex = 101;
            this.label8.Text = "Cập nhật phim";
            // 
            // AddButton
            // 
            this.AddButton.BorderRadius = 10;
            this.AddButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.AddButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.AddButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.AddButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.AddButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.AddButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.ForeColor = System.Drawing.Color.White;
            this.AddButton.Location = new System.Drawing.Point(383, 632);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(137, 36);
            this.AddButton.TabIndex = 108;
            this.AddButton.Text = "Cập nhật";
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
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
            this.guna2Button2.Location = new System.Drawing.Point(498, 11);
            this.guna2Button2.Margin = new System.Windows.Forms.Padding(2);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(26, 28);
            this.guna2Button2.TabIndex = 100;
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(268, 326);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 15);
            this.label11.TabIndex = 129;
            this.label11.Text = "Poster:";
            // 
            // date_FormSuaPhim_NgayPhatHanh
            // 
            this.date_FormSuaPhim_NgayPhatHanh.BorderRadius = 15;
            this.date_FormSuaPhim_NgayPhatHanh.Checked = true;
            this.date_FormSuaPhim_NgayPhatHanh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.date_FormSuaPhim_NgayPhatHanh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.date_FormSuaPhim_NgayPhatHanh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_FormSuaPhim_NgayPhatHanh.Location = new System.Drawing.Point(14, 529);
            this.date_FormSuaPhim_NgayPhatHanh.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.date_FormSuaPhim_NgayPhatHanh.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.date_FormSuaPhim_NgayPhatHanh.Name = "date_FormSuaPhim_NgayPhatHanh";
            this.date_FormSuaPhim_NgayPhatHanh.Size = new System.Drawing.Size(233, 32);
            this.date_FormSuaPhim_NgayPhatHanh.TabIndex = 128;
            this.date_FormSuaPhim_NgayPhatHanh.Value = new System.DateTime(2024, 11, 29, 16, 51, 14, 647);
            this.date_FormSuaPhim_NgayPhatHanh.ValueChanged += new System.EventHandler(this.date_FormSuaPhim_NgayPhatHanh_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(268, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 15);
            this.label10.TabIndex = 125;
            this.label10.Text = "Nhà phát hành: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 511);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 15);
            this.label5.TabIndex = 124;
            this.label5.Text = "Ngày phát hành: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 404);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 123;
            this.label1.Text = "Ngày nhập: ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(271, 183);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 15);
            this.label9.TabIndex = 122;
            this.label9.Text = "Mô tả:";
            // 
            // pictureBox_FormSuaPhim_Poster
            // 
            this.pictureBox_FormSuaPhim_Poster.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox_FormSuaPhim_Poster.Location = new System.Drawing.Point(271, 344);
            this.pictureBox_FormSuaPhim_Poster.Name = "pictureBox_FormSuaPhim_Poster";
            this.pictureBox_FormSuaPhim_Poster.Size = new System.Drawing.Size(250, 175);
            this.pictureBox_FormSuaPhim_Poster.TabIndex = 110;
            this.pictureBox_FormSuaPhim_Poster.TabStop = false;
            // 
            // lbl_FormSuaPhim_MoTa
            // 
            this.lbl_FormSuaPhim_MoTa.BorderColor = System.Drawing.Color.Gray;
            this.lbl_FormSuaPhim_MoTa.BorderRadius = 5;
            this.lbl_FormSuaPhim_MoTa.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lbl_FormSuaPhim_MoTa.DefaultText = "";
            this.lbl_FormSuaPhim_MoTa.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.lbl_FormSuaPhim_MoTa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.lbl_FormSuaPhim_MoTa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.lbl_FormSuaPhim_MoTa.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.lbl_FormSuaPhim_MoTa.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lbl_FormSuaPhim_MoTa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_FormSuaPhim_MoTa.ForeColor = System.Drawing.Color.Black;
            this.lbl_FormSuaPhim_MoTa.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lbl_FormSuaPhim_MoTa.Location = new System.Drawing.Point(273, 202);
            this.lbl_FormSuaPhim_MoTa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbl_FormSuaPhim_MoTa.Multiline = true;
            this.lbl_FormSuaPhim_MoTa.Name = "lbl_FormSuaPhim_MoTa";
            this.lbl_FormSuaPhim_MoTa.PasswordChar = '\0';
            this.lbl_FormSuaPhim_MoTa.PlaceholderText = "";
            this.lbl_FormSuaPhim_MoTa.SelectedText = "";
            this.lbl_FormSuaPhim_MoTa.Size = new System.Drawing.Size(250, 134);
            this.lbl_FormSuaPhim_MoTa.TabIndex = 121;
            // 
            // lbl_FormSuaPhim_ThoiLuong
            // 
            this.lbl_FormSuaPhim_ThoiLuong.BorderColor = System.Drawing.Color.Gray;
            this.lbl_FormSuaPhim_ThoiLuong.BorderRadius = 10;
            this.lbl_FormSuaPhim_ThoiLuong.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lbl_FormSuaPhim_ThoiLuong.DefaultText = "";
            this.lbl_FormSuaPhim_ThoiLuong.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.lbl_FormSuaPhim_ThoiLuong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.lbl_FormSuaPhim_ThoiLuong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.lbl_FormSuaPhim_ThoiLuong.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.lbl_FormSuaPhim_ThoiLuong.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lbl_FormSuaPhim_ThoiLuong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_FormSuaPhim_ThoiLuong.ForeColor = System.Drawing.Color.Black;
            this.lbl_FormSuaPhim_ThoiLuong.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lbl_FormSuaPhim_ThoiLuong.Location = new System.Drawing.Point(14, 270);
            this.lbl_FormSuaPhim_ThoiLuong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbl_FormSuaPhim_ThoiLuong.Name = "lbl_FormSuaPhim_ThoiLuong";
            this.lbl_FormSuaPhim_ThoiLuong.PasswordChar = '\0';
            this.lbl_FormSuaPhim_ThoiLuong.PlaceholderText = "";
            this.lbl_FormSuaPhim_ThoiLuong.SelectedText = "";
            this.lbl_FormSuaPhim_ThoiLuong.Size = new System.Drawing.Size(235, 35);
            this.lbl_FormSuaPhim_ThoiLuong.TabIndex = 120;
            this.lbl_FormSuaPhim_ThoiLuong.TextChanged += new System.EventHandler(this.lbl_FormSuaPhim_ThoiLuong_TextChanged);
            // 
            // lbl_FormSuaPhim_TenPhim
            // 
            this.lbl_FormSuaPhim_TenPhim.BorderColor = System.Drawing.Color.Gray;
            this.lbl_FormSuaPhim_TenPhim.BorderRadius = 10;
            this.lbl_FormSuaPhim_TenPhim.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lbl_FormSuaPhim_TenPhim.DefaultText = "";
            this.lbl_FormSuaPhim_TenPhim.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.lbl_FormSuaPhim_TenPhim.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.lbl_FormSuaPhim_TenPhim.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.lbl_FormSuaPhim_TenPhim.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.lbl_FormSuaPhim_TenPhim.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lbl_FormSuaPhim_TenPhim.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_FormSuaPhim_TenPhim.ForeColor = System.Drawing.Color.Black;
            this.lbl_FormSuaPhim_TenPhim.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lbl_FormSuaPhim_TenPhim.Location = new System.Drawing.Point(14, 132);
            this.lbl_FormSuaPhim_TenPhim.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbl_FormSuaPhim_TenPhim.Name = "lbl_FormSuaPhim_TenPhim";
            this.lbl_FormSuaPhim_TenPhim.PasswordChar = '\0';
            this.lbl_FormSuaPhim_TenPhim.PlaceholderText = "";
            this.lbl_FormSuaPhim_TenPhim.SelectedText = "";
            this.lbl_FormSuaPhim_TenPhim.Size = new System.Drawing.Size(235, 35);
            this.lbl_FormSuaPhim_TenPhim.TabIndex = 119;
            // 
            // cb_FormSuaPhim_TinhTrang
            // 
            this.cb_FormSuaPhim_TinhTrang.BackColor = System.Drawing.Color.Transparent;
            this.cb_FormSuaPhim_TinhTrang.BorderColor = System.Drawing.Color.Gray;
            this.cb_FormSuaPhim_TinhTrang.BorderRadius = 10;
            this.cb_FormSuaPhim_TinhTrang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_FormSuaPhim_TinhTrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_FormSuaPhim_TinhTrang.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cb_FormSuaPhim_TinhTrang.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cb_FormSuaPhim_TinhTrang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cb_FormSuaPhim_TinhTrang.ForeColor = System.Drawing.Color.Black;
            this.cb_FormSuaPhim_TinhTrang.ItemHeight = 30;
            this.cb_FormSuaPhim_TinhTrang.Items.AddRange(new object[] {
            "Đang chiếu",
            "Sắp chiếu"});
            this.cb_FormSuaPhim_TinhTrang.Location = new System.Drawing.Point(14, 344);
            this.cb_FormSuaPhim_TinhTrang.Name = "cb_FormSuaPhim_TinhTrang";
            this.cb_FormSuaPhim_TinhTrang.Size = new System.Drawing.Size(235, 36);
            this.cb_FormSuaPhim_TinhTrang.TabIndex = 118;
            // 
            // cb_FormSuaPhim_TheLoai
            // 
            this.cb_FormSuaPhim_TheLoai.BackColor = System.Drawing.Color.Transparent;
            this.cb_FormSuaPhim_TheLoai.BorderColor = System.Drawing.Color.Gray;
            this.cb_FormSuaPhim_TheLoai.BorderRadius = 10;
            this.cb_FormSuaPhim_TheLoai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_FormSuaPhim_TheLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_FormSuaPhim_TheLoai.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cb_FormSuaPhim_TheLoai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cb_FormSuaPhim_TheLoai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cb_FormSuaPhim_TheLoai.ForeColor = System.Drawing.Color.Black;
            this.cb_FormSuaPhim_TheLoai.ItemHeight = 30;
            this.cb_FormSuaPhim_TheLoai.Items.AddRange(new object[] {
            "Phim hành động",
            "Phim phiêu lưu",
            "Phim hài kịch",
            "Phim kinh dị",
            "Phim giật gân",
            "Phim lãng mạn",
            "Phim chính kịch"});
            this.cb_FormSuaPhim_TheLoai.Location = new System.Drawing.Point(14, 199);
            this.cb_FormSuaPhim_TheLoai.Name = "cb_FormSuaPhim_TheLoai";
            this.cb_FormSuaPhim_TheLoai.Size = new System.Drawing.Size(235, 36);
            this.cb_FormSuaPhim_TheLoai.TabIndex = 117;
            // 
            // lbl_FormSuaPhim_MovieID
            // 
            this.lbl_FormSuaPhim_MovieID.BorderColor = System.Drawing.Color.Gray;
            this.lbl_FormSuaPhim_MovieID.BorderRadius = 10;
            this.lbl_FormSuaPhim_MovieID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lbl_FormSuaPhim_MovieID.DefaultText = "";
            this.lbl_FormSuaPhim_MovieID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.lbl_FormSuaPhim_MovieID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.lbl_FormSuaPhim_MovieID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.lbl_FormSuaPhim_MovieID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.lbl_FormSuaPhim_MovieID.Enabled = false;
            this.lbl_FormSuaPhim_MovieID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lbl_FormSuaPhim_MovieID.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_FormSuaPhim_MovieID.ForeColor = System.Drawing.Color.Black;
            this.lbl_FormSuaPhim_MovieID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lbl_FormSuaPhim_MovieID.Location = new System.Drawing.Point(14, 64);
            this.lbl_FormSuaPhim_MovieID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbl_FormSuaPhim_MovieID.Name = "lbl_FormSuaPhim_MovieID";
            this.lbl_FormSuaPhim_MovieID.PasswordChar = '\0';
            this.lbl_FormSuaPhim_MovieID.PlaceholderText = "";
            this.lbl_FormSuaPhim_MovieID.ReadOnly = true;
            this.lbl_FormSuaPhim_MovieID.SelectedText = "";
            this.lbl_FormSuaPhim_MovieID.Size = new System.Drawing.Size(235, 35);
            this.lbl_FormSuaPhim_MovieID.TabIndex = 116;
            // 
            // btn_FormSuaPhim_ThemPoster
            // 
            this.btn_FormSuaPhim_ThemPoster.BorderRadius = 10;
            this.btn_FormSuaPhim_ThemPoster.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_FormSuaPhim_ThemPoster.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_FormSuaPhim_ThemPoster.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_FormSuaPhim_ThemPoster.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_FormSuaPhim_ThemPoster.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.btn_FormSuaPhim_ThemPoster.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_FormSuaPhim_ThemPoster.ForeColor = System.Drawing.Color.White;
            this.btn_FormSuaPhim_ThemPoster.Location = new System.Drawing.Point(337, 525);
            this.btn_FormSuaPhim_ThemPoster.Name = "btn_FormSuaPhim_ThemPoster";
            this.btn_FormSuaPhim_ThemPoster.Size = new System.Drawing.Size(108, 36);
            this.btn_FormSuaPhim_ThemPoster.TabIndex = 115;
            this.btn_FormSuaPhim_ThemPoster.Text = "Thêm poster";
            this.btn_FormSuaPhim_ThemPoster.Click += new System.EventHandler(this.btn_FormSuaPhim_ThemPoster_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 326);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 15);
            this.label7.TabIndex = 114;
            this.label7.Text = "Tình trạng:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 15);
            this.label6.TabIndex = 113;
            this.label6.Text = "Thời lượng (phút): ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 15);
            this.label4.TabIndex = 112;
            this.label4.Text = "Thể loại:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.label3.TabIndex = 111;
            this.label3.Text = "Tên phim:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 109;
            this.label2.Text = "ID phim:";
            // 
            // date_FormSuaPhim_NgayNhap
            // 
            this.date_FormSuaPhim_NgayNhap.BorderRadius = 15;
            this.date_FormSuaPhim_NgayNhap.Checked = true;
            this.date_FormSuaPhim_NgayNhap.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.date_FormSuaPhim_NgayNhap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.date_FormSuaPhim_NgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_FormSuaPhim_NgayNhap.Location = new System.Drawing.Point(14, 422);
            this.date_FormSuaPhim_NgayNhap.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.date_FormSuaPhim_NgayNhap.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.date_FormSuaPhim_NgayNhap.Name = "date_FormSuaPhim_NgayNhap";
            this.date_FormSuaPhim_NgayNhap.Size = new System.Drawing.Size(234, 32);
            this.date_FormSuaPhim_NgayNhap.TabIndex = 130;
            this.date_FormSuaPhim_NgayNhap.Value = new System.DateTime(2024, 11, 29, 16, 51, 14, 647);
            this.date_FormSuaPhim_NgayNhap.ValueChanged += new System.EventHandler(this.date_FormSuaPhim_NgayNhap_ValueChanged);
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
            this.btn_Refresh.Location = new System.Drawing.Point(214, 632);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(137, 36);
            this.btn_Refresh.TabIndex = 131;
            this.btn_Refresh.Text = "Làm mới";
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // lbl_FormSuaPhim_Gia
            // 
            this.lbl_FormSuaPhim_Gia.BorderColor = System.Drawing.Color.Gray;
            this.lbl_FormSuaPhim_Gia.BorderRadius = 10;
            this.lbl_FormSuaPhim_Gia.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lbl_FormSuaPhim_Gia.DefaultText = "";
            this.lbl_FormSuaPhim_Gia.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.lbl_FormSuaPhim_Gia.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.lbl_FormSuaPhim_Gia.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.lbl_FormSuaPhim_Gia.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.lbl_FormSuaPhim_Gia.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lbl_FormSuaPhim_Gia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_FormSuaPhim_Gia.ForeColor = System.Drawing.Color.Black;
            this.lbl_FormSuaPhim_Gia.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lbl_FormSuaPhim_Gia.Location = new System.Drawing.Point(273, 132);
            this.lbl_FormSuaPhim_Gia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbl_FormSuaPhim_Gia.Name = "lbl_FormSuaPhim_Gia";
            this.lbl_FormSuaPhim_Gia.PasswordChar = '\0';
            this.lbl_FormSuaPhim_Gia.PlaceholderText = "";
            this.lbl_FormSuaPhim_Gia.SelectedText = "";
            this.lbl_FormSuaPhim_Gia.Size = new System.Drawing.Size(249, 35);
            this.lbl_FormSuaPhim_Gia.TabIndex = 133;
            this.lbl_FormSuaPhim_Gia.TextChanged += new System.EventHandler(this.lbl_FormSuaPhim_Gia_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(270, 114);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 15);
            this.label12.TabIndex = 132;
            this.label12.Text = "Giá phim:";
            // 
            // cb_FormSuaPhim_NhaPhatHanh
            // 
            this.cb_FormSuaPhim_NhaPhatHanh.BackColor = System.Drawing.Color.Transparent;
            this.cb_FormSuaPhim_NhaPhatHanh.BorderColor = System.Drawing.Color.Gray;
            this.cb_FormSuaPhim_NhaPhatHanh.BorderRadius = 10;
            this.cb_FormSuaPhim_NhaPhatHanh.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_FormSuaPhim_NhaPhatHanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_FormSuaPhim_NhaPhatHanh.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cb_FormSuaPhim_NhaPhatHanh.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cb_FormSuaPhim_NhaPhatHanh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cb_FormSuaPhim_NhaPhatHanh.ForeColor = System.Drawing.Color.Black;
            this.cb_FormSuaPhim_NhaPhatHanh.ItemHeight = 30;
            this.cb_FormSuaPhim_NhaPhatHanh.Items.AddRange(new object[] {
            "Marvel",
            "DC",
            "Warner Bros",
            "Studio Ghibli",
            "A24",
            "Universal Pictures",
            "Walt Disney Studios",
            "Paramount Pictures",
            "20th Century Studios",
            "Lionsgate Films"});
            this.cb_FormSuaPhim_NhaPhatHanh.Location = new System.Drawing.Point(275, 64);
            this.cb_FormSuaPhim_NhaPhatHanh.Name = "cb_FormSuaPhim_NhaPhatHanh";
            this.cb_FormSuaPhim_NhaPhatHanh.Size = new System.Drawing.Size(249, 36);
            this.cb_FormSuaPhim_NhaPhatHanh.TabIndex = 134;
            // 
            // errorProvider_Gia
            // 
            this.errorProvider_Gia.ContainerControl = this;
            // 
            // errorProvider_ThoiLuong
            // 
            this.errorProvider_ThoiLuong.ContainerControl = this;
            // 
            // FormSuaPhim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(535, 687);
            this.Controls.Add(this.cb_FormSuaPhim_NhaPhatHanh);
            this.Controls.Add(this.lbl_FormSuaPhim_Gia);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.date_FormSuaPhim_NgayNhap);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.date_FormSuaPhim_NgayPhatHanh);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pictureBox_FormSuaPhim_Poster);
            this.Controls.Add(this.lbl_FormSuaPhim_MoTa);
            this.Controls.Add(this.lbl_FormSuaPhim_ThoiLuong);
            this.Controls.Add(this.lbl_FormSuaPhim_TenPhim);
            this.Controls.Add(this.cb_FormSuaPhim_TinhTrang);
            this.Controls.Add(this.cb_FormSuaPhim_TheLoai);
            this.Controls.Add(this.lbl_FormSuaPhim_MovieID);
            this.Controls.Add(this.btn_FormSuaPhim_ThemPoster);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.guna2Button2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSuaPhim";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormSuaPhim";
            this.Load += new System.EventHandler(this.FormSuaPhim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_FormSuaPhim_Poster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_Gia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_ThoiLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Button AddButton;
        private System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2DateTimePicker date_FormSuaPhim_NgayPhatHanh;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox_FormSuaPhim_Poster;
        private Guna.UI2.WinForms.Guna2TextBox lbl_FormSuaPhim_MoTa;
        private Guna.UI2.WinForms.Guna2TextBox lbl_FormSuaPhim_ThoiLuong;
        private Guna.UI2.WinForms.Guna2TextBox lbl_FormSuaPhim_TenPhim;
        private Guna.UI2.WinForms.Guna2ComboBox cb_FormSuaPhim_TinhTrang;
        private Guna.UI2.WinForms.Guna2ComboBox cb_FormSuaPhim_TheLoai;
        private Guna.UI2.WinForms.Guna2TextBox lbl_FormSuaPhim_MovieID;
        private Guna.UI2.WinForms.Guna2Button btn_FormSuaPhim_ThemPoster;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2DateTimePicker date_FormSuaPhim_NgayNhap;
        private Guna.UI2.WinForms.Guna2Button btn_Refresh;
        private Guna.UI2.WinForms.Guna2TextBox lbl_FormSuaPhim_Gia;
        private System.Windows.Forms.Label label12;
        private Guna.UI2.WinForms.Guna2ComboBox cb_FormSuaPhim_NhaPhatHanh;
        private System.Windows.Forms.ErrorProvider errorProvider_Gia;
        private System.Windows.Forms.ErrorProvider errorProvider_ThoiLuong;
    }
}