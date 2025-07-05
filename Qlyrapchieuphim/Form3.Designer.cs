namespace Qlyrapchieuphim
{
    partial class form_ThemGioChieu
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
            this.btn_Refresh = new Guna.UI2.WinForms.Guna2Button();
            this.sua = new Guna.UI2.WinForms.Guna2Button();
            this.date_FormThemSuatChieu_NgayChieu = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
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
            this.btn_Refresh.Location = new System.Drawing.Point(134, 114);
            this.btn_Refresh.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(109, 44);
            this.btn_Refresh.TabIndex = 91;
            this.btn_Refresh.Text = "Làm mới";
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // sua
            // 
            this.sua.BorderRadius = 10;
            this.sua.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.sua.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.sua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.sua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.sua.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.sua.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.sua.ForeColor = System.Drawing.Color.White;
            this.sua.Location = new System.Drawing.Point(269, 114);
            this.sua.Margin = new System.Windows.Forms.Padding(4);
            this.sua.Name = "sua";
            this.sua.Size = new System.Drawing.Size(109, 44);
            this.sua.TabIndex = 90;
            this.sua.Text = "Thêm";
            this.sua.Click += new System.EventHandler(this.sua_Click);
            // 
            // date_FormThemSuatChieu_NgayChieu
            // 
            this.date_FormThemSuatChieu_NgayChieu.BorderRadius = 15;
            this.date_FormThemSuatChieu_NgayChieu.Checked = true;
            this.date_FormThemSuatChieu_NgayChieu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.date_FormThemSuatChieu_NgayChieu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.date_FormThemSuatChieu_NgayChieu.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_FormThemSuatChieu_NgayChieu.Location = new System.Drawing.Point(17, 53);
            this.date_FormThemSuatChieu_NgayChieu.Margin = new System.Windows.Forms.Padding(4);
            this.date_FormThemSuatChieu_NgayChieu.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.date_FormThemSuatChieu_NgayChieu.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.date_FormThemSuatChieu_NgayChieu.Name = "date_FormThemSuatChieu_NgayChieu";
            this.date_FormThemSuatChieu_NgayChieu.Size = new System.Drawing.Size(361, 39);
            this.date_FormThemSuatChieu_NgayChieu.TabIndex = 89;
            this.date_FormThemSuatChieu_NgayChieu.Value = new System.DateTime(2024, 11, 29, 16, 51, 14, 647);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 20);
            this.label3.TabIndex = 88;
            this.label3.Text = "Thêm giờ chiếu:";
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
            this.guna2Button2.Location = new System.Drawing.Point(355, -3);
            this.guna2Button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(35, 34);
            this.guna2Button2.TabIndex = 92;
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // form_ThemGioChieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 169);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.sua);
            this.Controls.Add(this.date_FormThemSuatChieu_NgayChieu);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "form_ThemGioChieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.form_ThemGioChieu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btn_Refresh;
        private Guna.UI2.WinForms.Guna2Button sua;
        private Guna.UI2.WinForms.Guna2DateTimePicker date_FormThemSuatChieu_NgayChieu;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
    }
}