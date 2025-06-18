namespace Qlyrapchieuphim.FormEdit
{
    partial class FormSuaPhongChieu
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
            this.lbl_FormSuaPhongChieu_SoGhe = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.them = new Guna.UI2.WinForms.Guna2Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_FormSuaPhongChieu_TenPhong = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_FormSuaPhongChieu_MaPhong = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.cb_FormSuaPhongChieu_DinhDang = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btn_Refresh = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // lbl_FormSuaPhongChieu_SoGhe
            // 
            this.lbl_FormSuaPhongChieu_SoGhe.BorderColor = System.Drawing.Color.Gray;
            this.lbl_FormSuaPhongChieu_SoGhe.BorderRadius = 10;
            this.lbl_FormSuaPhongChieu_SoGhe.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lbl_FormSuaPhongChieu_SoGhe.DefaultText = "";
            this.lbl_FormSuaPhongChieu_SoGhe.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.lbl_FormSuaPhongChieu_SoGhe.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.lbl_FormSuaPhongChieu_SoGhe.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.lbl_FormSuaPhongChieu_SoGhe.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.lbl_FormSuaPhongChieu_SoGhe.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lbl_FormSuaPhongChieu_SoGhe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_FormSuaPhongChieu_SoGhe.ForeColor = System.Drawing.Color.Black;
            this.lbl_FormSuaPhongChieu_SoGhe.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lbl_FormSuaPhongChieu_SoGhe.Location = new System.Drawing.Point(16, 327);
            this.lbl_FormSuaPhongChieu_SoGhe.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbl_FormSuaPhongChieu_SoGhe.Name = "lbl_FormSuaPhongChieu_SoGhe";
            this.lbl_FormSuaPhongChieu_SoGhe.PasswordChar = '\0';
            this.lbl_FormSuaPhongChieu_SoGhe.PlaceholderText = "";
            this.lbl_FormSuaPhongChieu_SoGhe.SelectedText = "";
            this.lbl_FormSuaPhongChieu_SoGhe.Size = new System.Drawing.Size(437, 41);
            this.lbl_FormSuaPhongChieu_SoGhe.TabIndex = 120;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 222);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 18);
            this.label6.TabIndex = 118;
            this.label6.Text = "Định dạng:";
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
            this.them.Location = new System.Drawing.Point(279, 420);
            this.them.Margin = new System.Windows.Forms.Padding(4);
            this.them.Name = "them";
            this.them.Size = new System.Drawing.Size(175, 44);
            this.them.TabIndex = 117;
            this.them.Text = "Cập nhật";
            this.them.Click += new System.EventHandler(this.them_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 304);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 18);
            this.label5.TabIndex = 116;
            this.label5.Text = "Số ghế:";
            // 
            // lbl_FormSuaPhongChieu_TenPhong
            // 
            this.lbl_FormSuaPhongChieu_TenPhong.BorderColor = System.Drawing.Color.Gray;
            this.lbl_FormSuaPhongChieu_TenPhong.BorderRadius = 10;
            this.lbl_FormSuaPhongChieu_TenPhong.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lbl_FormSuaPhongChieu_TenPhong.DefaultText = "";
            this.lbl_FormSuaPhongChieu_TenPhong.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.lbl_FormSuaPhongChieu_TenPhong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.lbl_FormSuaPhongChieu_TenPhong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.lbl_FormSuaPhongChieu_TenPhong.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.lbl_FormSuaPhongChieu_TenPhong.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lbl_FormSuaPhongChieu_TenPhong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_FormSuaPhongChieu_TenPhong.ForeColor = System.Drawing.Color.Black;
            this.lbl_FormSuaPhongChieu_TenPhong.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lbl_FormSuaPhongChieu_TenPhong.Location = new System.Drawing.Point(16, 161);
            this.lbl_FormSuaPhongChieu_TenPhong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbl_FormSuaPhongChieu_TenPhong.Name = "lbl_FormSuaPhongChieu_TenPhong";
            this.lbl_FormSuaPhongChieu_TenPhong.PasswordChar = '\0';
            this.lbl_FormSuaPhongChieu_TenPhong.PlaceholderText = "";
            this.lbl_FormSuaPhongChieu_TenPhong.SelectedText = "";
            this.lbl_FormSuaPhongChieu_TenPhong.Size = new System.Drawing.Size(437, 41);
            this.lbl_FormSuaPhongChieu_TenPhong.TabIndex = 115;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 138);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 18);
            this.label4.TabIndex = 114;
            this.label4.Text = "Tên phòng:";
            // 
            // lbl_FormSuaPhongChieu_MaPhong
            // 
            this.lbl_FormSuaPhongChieu_MaPhong.BorderColor = System.Drawing.Color.Gray;
            this.lbl_FormSuaPhongChieu_MaPhong.BorderRadius = 10;
            this.lbl_FormSuaPhongChieu_MaPhong.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lbl_FormSuaPhongChieu_MaPhong.DefaultText = "";
            this.lbl_FormSuaPhongChieu_MaPhong.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.lbl_FormSuaPhongChieu_MaPhong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.lbl_FormSuaPhongChieu_MaPhong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.lbl_FormSuaPhongChieu_MaPhong.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.lbl_FormSuaPhongChieu_MaPhong.Enabled = false;
            this.lbl_FormSuaPhongChieu_MaPhong.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lbl_FormSuaPhongChieu_MaPhong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_FormSuaPhongChieu_MaPhong.ForeColor = System.Drawing.Color.Black;
            this.lbl_FormSuaPhongChieu_MaPhong.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lbl_FormSuaPhongChieu_MaPhong.Location = new System.Drawing.Point(16, 76);
            this.lbl_FormSuaPhongChieu_MaPhong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbl_FormSuaPhongChieu_MaPhong.Name = "lbl_FormSuaPhongChieu_MaPhong";
            this.lbl_FormSuaPhongChieu_MaPhong.PasswordChar = '\0';
            this.lbl_FormSuaPhongChieu_MaPhong.PlaceholderText = "";
            this.lbl_FormSuaPhongChieu_MaPhong.ReadOnly = true;
            this.lbl_FormSuaPhongChieu_MaPhong.SelectedText = "";
            this.lbl_FormSuaPhongChieu_MaPhong.Size = new System.Drawing.Size(437, 38);
            this.lbl_FormSuaPhongChieu_MaPhong.TabIndex = 113;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 53);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 18);
            this.label3.TabIndex = 112;
            this.label3.Text = "Mã phòng:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 20);
            this.label1.TabIndex = 111;
            this.label1.Text = "Cập nhật phòng chiếu";
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
            this.guna2Button2.Location = new System.Drawing.Point(420, 11);
            this.guna2Button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(35, 34);
            this.guna2Button2.TabIndex = 110;
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // cb_FormSuaPhongChieu_DinhDang
            // 
            this.cb_FormSuaPhongChieu_DinhDang.BackColor = System.Drawing.Color.Transparent;
            this.cb_FormSuaPhongChieu_DinhDang.BorderColor = System.Drawing.Color.Gray;
            this.cb_FormSuaPhongChieu_DinhDang.BorderRadius = 10;
            this.cb_FormSuaPhongChieu_DinhDang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_FormSuaPhongChieu_DinhDang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_FormSuaPhongChieu_DinhDang.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cb_FormSuaPhongChieu_DinhDang.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cb_FormSuaPhongChieu_DinhDang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cb_FormSuaPhongChieu_DinhDang.ForeColor = System.Drawing.Color.Black;
            this.cb_FormSuaPhongChieu_DinhDang.ItemHeight = 30;
            this.cb_FormSuaPhongChieu_DinhDang.Items.AddRange(new object[] {
            "Imax",
            "4k"});
            this.cb_FormSuaPhongChieu_DinhDang.Location = new System.Drawing.Point(20, 256);
            this.cb_FormSuaPhongChieu_DinhDang.Margin = new System.Windows.Forms.Padding(4);
            this.cb_FormSuaPhongChieu_DinhDang.Name = "cb_FormSuaPhongChieu_DinhDang";
            this.cb_FormSuaPhongChieu_DinhDang.Size = new System.Drawing.Size(433, 36);
            this.cb_FormSuaPhongChieu_DinhDang.TabIndex = 121;
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
            this.btn_Refresh.Location = new System.Drawing.Point(62, 420);
            this.btn_Refresh.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(175, 44);
            this.btn_Refresh.TabIndex = 122;
            this.btn_Refresh.Text = "Làm mới";
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // FormSuaPhongChieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(469, 479);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.cb_FormSuaPhongChieu_DinhDang);
            this.Controls.Add(this.lbl_FormSuaPhongChieu_SoGhe);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.them);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl_FormSuaPhongChieu_TenPhong);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_FormSuaPhongChieu_MaPhong);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2Button2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormSuaPhongChieu";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormSuaPhongChieu";
            this.Load += new System.EventHandler(this.FormSuaPhongChieu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox lbl_FormSuaPhongChieu_SoGhe;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2Button them;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox lbl_FormSuaPhongChieu_TenPhong;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox lbl_FormSuaPhongChieu_MaPhong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2ComboBox cb_FormSuaPhongChieu_DinhDang;
        private Guna.UI2.WinForms.Guna2Button btn_Refresh;
    }
}