namespace Qlyrapchieuphim.FormEdit
{
    partial class FormSuaNhanVien
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
            this.label11 = new System.Windows.Forms.Label();
            this.chucvu = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.passTxtBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.usrnameTxtBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ngaysinh = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.email = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.hoten = new Guna.UI2.WinForms.Guna2TextBox();
            this.sodienthoai = new Guna.UI2.WinForms.Guna2TextBox();
            this.manv = new Guna.UI2.WinForms.Guna2TextBox();
            this.them = new Guna.UI2.WinForms.Guna2Button();
            this.trangthai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(235, 257);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 15);
            this.label11.TabIndex = 111;
            this.label11.Text = "Chức vụ:";
            // 
            // chucvu
            // 
            this.chucvu.BackColor = System.Drawing.Color.Transparent;
            this.chucvu.BorderColor = System.Drawing.Color.Gray;
            this.chucvu.BorderRadius = 10;
            this.chucvu.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.chucvu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chucvu.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chucvu.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chucvu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chucvu.ForeColor = System.Drawing.Color.Black;
            this.chucvu.ItemHeight = 30;
            this.chucvu.Items.AddRange(new object[] {
            "Nhân viên",
            "ADMIN"});
            this.chucvu.Location = new System.Drawing.Point(238, 276);
            this.chucvu.Name = "chucvu";
            this.chucvu.Size = new System.Drawing.Size(178, 36);
            this.chucvu.TabIndex = 110;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 322);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 15);
            this.label9.TabIndex = 109;
            this.label9.Text = "Mật khẩu:";
            // 
            // passTxtBox
            // 
            this.passTxtBox.BorderColor = System.Drawing.Color.Gray;
            this.passTxtBox.BorderRadius = 10;
            this.passTxtBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.passTxtBox.DefaultText = "";
            this.passTxtBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.passTxtBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.passTxtBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.passTxtBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.passTxtBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.passTxtBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.passTxtBox.ForeColor = System.Drawing.Color.Black;
            this.passTxtBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.passTxtBox.Location = new System.Drawing.Point(12, 341);
            this.passTxtBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.passTxtBox.Name = "passTxtBox";
            this.passTxtBox.PasswordChar = '\0';
            this.passTxtBox.PlaceholderText = "";
            this.passTxtBox.SelectedText = "";
            this.passTxtBox.Size = new System.Drawing.Size(177, 36);
            this.passTxtBox.TabIndex = 108;
            // 
            // usrnameTxtBox
            // 
            this.usrnameTxtBox.BorderColor = System.Drawing.Color.Gray;
            this.usrnameTxtBox.BorderRadius = 10;
            this.usrnameTxtBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.usrnameTxtBox.DefaultText = "";
            this.usrnameTxtBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.usrnameTxtBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.usrnameTxtBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.usrnameTxtBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.usrnameTxtBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.usrnameTxtBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.usrnameTxtBox.ForeColor = System.Drawing.Color.Black;
            this.usrnameTxtBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.usrnameTxtBox.Location = new System.Drawing.Point(12, 276);
            this.usrnameTxtBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.usrnameTxtBox.Name = "usrnameTxtBox";
            this.usrnameTxtBox.PasswordChar = '\0';
            this.usrnameTxtBox.PlaceholderText = "";
            this.usrnameTxtBox.SelectedText = "";
            this.usrnameTxtBox.Size = new System.Drawing.Size(180, 36);
            this.usrnameTxtBox.TabIndex = 107;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 257);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 15);
            this.label10.TabIndex = 106;
            this.label10.Text = "Tên đăng nhập:";
            // 
            // ngaysinh
            // 
            this.ngaysinh.BorderRadius = 15;
            this.ngaysinh.Checked = true;
            this.ngaysinh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.ngaysinh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ngaysinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ngaysinh.Location = new System.Drawing.Point(12, 205);
            this.ngaysinh.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.ngaysinh.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.ngaysinh.Name = "ngaysinh";
            this.ngaysinh.Size = new System.Drawing.Size(180, 32);
            this.ngaysinh.TabIndex = 105;
            this.ngaysinh.Value = new System.DateTime(2024, 11, 29, 16, 51, 14, 647);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 182);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 15);
            this.label8.TabIndex = 104;
            this.label8.Text = "Ngày sinh:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(235, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 15);
            this.label7.TabIndex = 103;
            this.label7.Text = "Email:";
            // 
            // email
            // 
            this.email.BorderColor = System.Drawing.Color.Gray;
            this.email.BorderRadius = 10;
            this.email.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.email.DefaultText = "";
            this.email.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.email.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.email.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.email.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.email.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.email.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.email.ForeColor = System.Drawing.Color.Black;
            this.email.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.email.Location = new System.Drawing.Point(238, 132);
            this.email.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.email.Name = "email";
            this.email.PasswordChar = '\0';
            this.email.PlaceholderText = "";
            this.email.SelectedText = "";
            this.email.Size = new System.Drawing.Size(180, 31);
            this.email.TabIndex = 102;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(235, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 15);
            this.label6.TabIndex = 101;
            this.label6.Text = "Họ tên:";
            // 
            // hoten
            // 
            this.hoten.BorderColor = System.Drawing.Color.Gray;
            this.hoten.BorderRadius = 10;
            this.hoten.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.hoten.DefaultText = "";
            this.hoten.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.hoten.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.hoten.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.hoten.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.hoten.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.hoten.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.hoten.ForeColor = System.Drawing.Color.Black;
            this.hoten.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.hoten.Location = new System.Drawing.Point(238, 62);
            this.hoten.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hoten.Name = "hoten";
            this.hoten.PasswordChar = '\0';
            this.hoten.PlaceholderText = "";
            this.hoten.SelectedText = "";
            this.hoten.Size = new System.Drawing.Size(180, 31);
            this.hoten.TabIndex = 100;
            // 
            // sodienthoai
            // 
            this.sodienthoai.BorderColor = System.Drawing.Color.Gray;
            this.sodienthoai.BorderRadius = 10;
            this.sodienthoai.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.sodienthoai.DefaultText = "";
            this.sodienthoai.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.sodienthoai.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.sodienthoai.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.sodienthoai.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.sodienthoai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.sodienthoai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.sodienthoai.ForeColor = System.Drawing.Color.Black;
            this.sodienthoai.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.sodienthoai.Location = new System.Drawing.Point(12, 132);
            this.sodienthoai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sodienthoai.Name = "sodienthoai";
            this.sodienthoai.PasswordChar = '\0';
            this.sodienthoai.PlaceholderText = "";
            this.sodienthoai.SelectedText = "";
            this.sodienthoai.Size = new System.Drawing.Size(180, 31);
            this.sodienthoai.TabIndex = 99;
            // 
            // manv
            // 
            this.manv.BorderColor = System.Drawing.Color.Gray;
            this.manv.BorderRadius = 10;
            this.manv.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.manv.DefaultText = "";
            this.manv.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.manv.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.manv.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.manv.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.manv.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.manv.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.manv.ForeColor = System.Drawing.Color.Black;
            this.manv.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.manv.Location = new System.Drawing.Point(12, 62);
            this.manv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.manv.Name = "manv";
            this.manv.PasswordChar = '\0';
            this.manv.PlaceholderText = "";
            this.manv.SelectedText = "";
            this.manv.Size = new System.Drawing.Size(180, 31);
            this.manv.TabIndex = 98;
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
            this.them.Location = new System.Drawing.Point(146, 426);
            this.them.Name = "them";
            this.them.Size = new System.Drawing.Size(135, 36);
            this.them.TabIndex = 97;
            this.them.Text = "Cập nhật";
            // 
            // trangthai
            // 
            this.trangthai.BackColor = System.Drawing.Color.Transparent;
            this.trangthai.BorderColor = System.Drawing.Color.Gray;
            this.trangthai.BorderRadius = 10;
            this.trangthai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.trangthai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.trangthai.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.trangthai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.trangthai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.trangthai.ForeColor = System.Drawing.Color.Black;
            this.trangthai.ItemHeight = 30;
            this.trangthai.Location = new System.Drawing.Point(238, 205);
            this.trangthai.Name = "trangthai";
            this.trangthai.Size = new System.Drawing.Size(178, 36);
            this.trangthai.TabIndex = 96;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(235, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 15);
            this.label5.TabIndex = 95;
            this.label5.Text = "Trạng thái:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 94;
            this.label4.Text = "Số điện thoại:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 93;
            this.label3.Text = "Mã NV:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 16);
            this.label1.TabIndex = 92;
            this.label1.Text = "Cập nhật thông tin nhân viên";
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
            this.guna2Button2.Location = new System.Drawing.Point(396, 12);
            this.guna2Button2.Margin = new System.Windows.Forms.Padding(2);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(26, 28);
            this.guna2Button2.TabIndex = 112;
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // FormSuaNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(431, 482);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.chucvu);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.passTxtBox);
            this.Controls.Add(this.usrnameTxtBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.ngaysinh);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.email);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.sodienthoai);
            this.Controls.Add(this.manv);
            this.Controls.Add(this.them);
            this.Controls.Add(this.trangthai);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSuaNhanVien";
            this.ShowInTaskbar = false;
            this.Text = "FormSuaNhanVien";
            this.Load += new System.EventHandler(this.FormSuaNhanVien_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2ComboBox chucvu;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2TextBox passTxtBox;
        private Guna.UI2.WinForms.Guna2TextBox usrnameTxtBox;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2DateTimePicker ngaysinh;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2TextBox email;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2TextBox hoten;
        private Guna.UI2.WinForms.Guna2TextBox sodienthoai;
        private Guna.UI2.WinForms.Guna2TextBox manv;
        private Guna.UI2.WinForms.Guna2Button them;
        private Guna.UI2.WinForms.Guna2ComboBox trangthai;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}