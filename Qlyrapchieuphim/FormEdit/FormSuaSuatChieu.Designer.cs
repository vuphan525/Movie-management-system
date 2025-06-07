namespace Qlyrapchieuphim.FormEdit
{
    partial class FormSuaSuatChieu
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
            this.lbl_FormSuaSuatChieu_MaSuatChieu = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.date_FormSuaSuatChieu_GioChieu = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cb_FormSuaSuatChieu_PhongChieu = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.date_FormSuaSuatChieu_NgayChieu = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.them = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_FormSuaSuatChieu_TenPhim = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // lbl_FormSuaSuatChieu_MaSuatChieu
            // 
            this.lbl_FormSuaSuatChieu_MaSuatChieu.BorderColor = System.Drawing.Color.Gray;
            this.lbl_FormSuaSuatChieu_MaSuatChieu.BorderRadius = 10;
            this.lbl_FormSuaSuatChieu_MaSuatChieu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lbl_FormSuaSuatChieu_MaSuatChieu.DefaultText = "";
            this.lbl_FormSuaSuatChieu_MaSuatChieu.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.lbl_FormSuaSuatChieu_MaSuatChieu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.lbl_FormSuaSuatChieu_MaSuatChieu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.lbl_FormSuaSuatChieu_MaSuatChieu.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.lbl_FormSuaSuatChieu_MaSuatChieu.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lbl_FormSuaSuatChieu_MaSuatChieu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_FormSuaSuatChieu_MaSuatChieu.ForeColor = System.Drawing.Color.Black;
            this.lbl_FormSuaSuatChieu_MaSuatChieu.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lbl_FormSuaSuatChieu_MaSuatChieu.Location = new System.Drawing.Point(16, 80);
            this.lbl_FormSuaSuatChieu_MaSuatChieu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbl_FormSuaSuatChieu_MaSuatChieu.Name = "lbl_FormSuaSuatChieu_MaSuatChieu";
            this.lbl_FormSuaSuatChieu_MaSuatChieu.PasswordChar = '\0';
            this.lbl_FormSuaSuatChieu_MaSuatChieu.PlaceholderText = "";
            this.lbl_FormSuaSuatChieu_MaSuatChieu.SelectedText = "";
            this.lbl_FormSuaSuatChieu_MaSuatChieu.Size = new System.Drawing.Size(487, 44);
            this.lbl_FormSuaSuatChieu_MaSuatChieu.TabIndex = 96;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 57);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 18);
            this.label6.TabIndex = 95;
            this.label6.Text = "Mã suất chiếu";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // date_FormSuaSuatChieu_GioChieu
            // 
            this.date_FormSuaSuatChieu_GioChieu.BorderRadius = 15;
            this.date_FormSuaSuatChieu_GioChieu.Checked = true;
            this.date_FormSuaSuatChieu_GioChieu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.date_FormSuaSuatChieu_GioChieu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.date_FormSuaSuatChieu_GioChieu.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.date_FormSuaSuatChieu_GioChieu.Location = new System.Drawing.Point(17, 416);
            this.date_FormSuaSuatChieu_GioChieu.Margin = new System.Windows.Forms.Padding(4);
            this.date_FormSuaSuatChieu_GioChieu.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.date_FormSuaSuatChieu_GioChieu.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.date_FormSuaSuatChieu_GioChieu.Name = "date_FormSuaSuatChieu_GioChieu";
            this.date_FormSuaSuatChieu_GioChieu.Size = new System.Drawing.Size(487, 39);
            this.date_FormSuaSuatChieu_GioChieu.TabIndex = 94;
            this.date_FormSuaSuatChieu_GioChieu.Value = new System.DateTime(2024, 11, 29, 16, 51, 14, 647);
            // 
            // cb_FormSuaSuatChieu_PhongChieu
            // 
            this.cb_FormSuaSuatChieu_PhongChieu.BackColor = System.Drawing.Color.Transparent;
            this.cb_FormSuaSuatChieu_PhongChieu.BorderColor = System.Drawing.Color.Gray;
            this.cb_FormSuaSuatChieu_PhongChieu.BorderRadius = 10;
            this.cb_FormSuaSuatChieu_PhongChieu.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_FormSuaSuatChieu_PhongChieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_FormSuaSuatChieu_PhongChieu.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cb_FormSuaSuatChieu_PhongChieu.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cb_FormSuaSuatChieu_PhongChieu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cb_FormSuaSuatChieu_PhongChieu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cb_FormSuaSuatChieu_PhongChieu.ItemHeight = 30;
            this.cb_FormSuaSuatChieu_PhongChieu.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cb_FormSuaSuatChieu_PhongChieu.Location = new System.Drawing.Point(16, 248);
            this.cb_FormSuaSuatChieu_PhongChieu.Margin = new System.Windows.Forms.Padding(4);
            this.cb_FormSuaSuatChieu_PhongChieu.Name = "cb_FormSuaSuatChieu_PhongChieu";
            this.cb_FormSuaSuatChieu_PhongChieu.Size = new System.Drawing.Size(485, 36);
            this.cb_FormSuaSuatChieu_PhongChieu.TabIndex = 93;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 225);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 18);
            this.label5.TabIndex = 92;
            this.label5.Text = "Phòng chiếu:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 394);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 18);
            this.label4.TabIndex = 91;
            this.label4.Text = "Giờ chiếu:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // date_FormSuaSuatChieu_NgayChieu
            // 
            this.date_FormSuaSuatChieu_NgayChieu.BorderRadius = 15;
            this.date_FormSuaSuatChieu_NgayChieu.Checked = true;
            this.date_FormSuaSuatChieu_NgayChieu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.date_FormSuaSuatChieu_NgayChieu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.date_FormSuaSuatChieu_NgayChieu.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_FormSuaSuatChieu_NgayChieu.Location = new System.Drawing.Point(17, 332);
            this.date_FormSuaSuatChieu_NgayChieu.Margin = new System.Windows.Forms.Padding(4);
            this.date_FormSuaSuatChieu_NgayChieu.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.date_FormSuaSuatChieu_NgayChieu.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.date_FormSuaSuatChieu_NgayChieu.Name = "date_FormSuaSuatChieu_NgayChieu";
            this.date_FormSuaSuatChieu_NgayChieu.Size = new System.Drawing.Size(487, 39);
            this.date_FormSuaSuatChieu_NgayChieu.TabIndex = 90;
            this.date_FormSuaSuatChieu_NgayChieu.Value = new System.DateTime(2024, 11, 29, 16, 51, 14, 647);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 20);
            this.label3.TabIndex = 85;
            this.label3.Text = "Cập nhật suất chiếu:";
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
            this.them.Location = new System.Drawing.Point(355, 502);
            this.them.Margin = new System.Windows.Forms.Padding(4);
            this.them.Name = "them";
            this.them.Size = new System.Drawing.Size(149, 44);
            this.them.TabIndex = 89;
            this.them.Text = "Cập nhật";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 310);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 18);
            this.label2.TabIndex = 88;
            this.label2.Text = "Ngày chiếu:";
            // 
            // cb_FormSuaSuatChieu_TenPhim
            // 
            this.cb_FormSuaSuatChieu_TenPhim.BackColor = System.Drawing.Color.Transparent;
            this.cb_FormSuaSuatChieu_TenPhim.BorderColor = System.Drawing.Color.Gray;
            this.cb_FormSuaSuatChieu_TenPhim.BorderRadius = 10;
            this.cb_FormSuaSuatChieu_TenPhim.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_FormSuaSuatChieu_TenPhim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_FormSuaSuatChieu_TenPhim.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cb_FormSuaSuatChieu_TenPhim.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cb_FormSuaSuatChieu_TenPhim.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cb_FormSuaSuatChieu_TenPhim.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cb_FormSuaSuatChieu_TenPhim.ItemHeight = 30;
            this.cb_FormSuaSuatChieu_TenPhim.Location = new System.Drawing.Point(16, 166);
            this.cb_FormSuaSuatChieu_TenPhim.Margin = new System.Windows.Forms.Padding(4);
            this.cb_FormSuaSuatChieu_TenPhim.Name = "cb_FormSuaSuatChieu_TenPhim";
            this.cb_FormSuaSuatChieu_TenPhim.Size = new System.Drawing.Size(485, 36);
            this.cb_FormSuaSuatChieu_TenPhim.TabIndex = 87;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 142);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 18);
            this.label7.TabIndex = 86;
            this.label7.Text = "Tên phim:";
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
            this.guna2Button2.Location = new System.Drawing.Point(473, 11);
            this.guna2Button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(35, 34);
            this.guna2Button2.TabIndex = 97;
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // FormSuaSuatChieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(524, 567);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.lbl_FormSuaSuatChieu_MaSuatChieu);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.date_FormSuaSuatChieu_GioChieu);
            this.Controls.Add(this.cb_FormSuaSuatChieu_PhongChieu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.date_FormSuaSuatChieu_NgayChieu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.them);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_FormSuaSuatChieu_TenPhim);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormSuaSuatChieu";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormSuaSuatChieu";
            this.Load += new System.EventHandler(this.FormSuaSuatChieu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2TextBox lbl_FormSuaSuatChieu_MaSuatChieu;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2DateTimePicker date_FormSuaSuatChieu_GioChieu;
        private Guna.UI2.WinForms.Guna2ComboBox cb_FormSuaSuatChieu_PhongChieu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2DateTimePicker date_FormSuaSuatChieu_NgayChieu;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button them;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cb_FormSuaSuatChieu_TenPhim;
        private System.Windows.Forms.Label label7;
    }
}