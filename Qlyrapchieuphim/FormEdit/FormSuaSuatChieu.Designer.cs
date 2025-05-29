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
            this.idTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.giochieu = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.phongchieu = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ngaychieu = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.them = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tenphim = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // idTextBox
            // 
            this.idTextBox.BorderColor = System.Drawing.Color.Gray;
            this.idTextBox.BorderRadius = 10;
            this.idTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.idTextBox.DefaultText = "";
            this.idTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.idTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.idTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.idTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.idTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.idTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.idTextBox.ForeColor = System.Drawing.Color.Black;
            this.idTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.idTextBox.Location = new System.Drawing.Point(13, 199);
            this.idTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.PasswordChar = '\0';
            this.idTextBox.PlaceholderText = "";
            this.idTextBox.SelectedText = "";
            this.idTextBox.Size = new System.Drawing.Size(365, 36);
            this.idTextBox.TabIndex = 96;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 15);
            this.label6.TabIndex = 95;
            this.label6.Text = "Mã suất chiếu";
            // 
            // giochieu
            // 
            this.giochieu.BorderRadius = 15;
            this.giochieu.Checked = true;
            this.giochieu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.giochieu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.giochieu.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.giochieu.Location = new System.Drawing.Point(13, 338);
            this.giochieu.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.giochieu.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.giochieu.Name = "giochieu";
            this.giochieu.Size = new System.Drawing.Size(365, 32);
            this.giochieu.TabIndex = 94;
            this.giochieu.Value = new System.DateTime(2024, 11, 29, 16, 51, 14, 647);
            // 
            // phongchieu
            // 
            this.phongchieu.BackColor = System.Drawing.Color.Transparent;
            this.phongchieu.BorderColor = System.Drawing.Color.Gray;
            this.phongchieu.BorderRadius = 10;
            this.phongchieu.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.phongchieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.phongchieu.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.phongchieu.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.phongchieu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.phongchieu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.phongchieu.ItemHeight = 30;
            this.phongchieu.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.phongchieu.Location = new System.Drawing.Point(13, 128);
            this.phongchieu.Name = "phongchieu";
            this.phongchieu.Size = new System.Drawing.Size(365, 36);
            this.phongchieu.TabIndex = 93;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 15);
            this.label5.TabIndex = 92;
            this.label5.Text = "Phòng chiếu:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 320);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 15);
            this.label4.TabIndex = 91;
            this.label4.Text = "Giờ chiếu:";
            // 
            // ngaychieu
            // 
            this.ngaychieu.BorderRadius = 15;
            this.ngaychieu.Checked = true;
            this.ngaychieu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.ngaychieu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ngaychieu.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ngaychieu.Location = new System.Drawing.Point(17, 270);
            this.ngaychieu.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.ngaychieu.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.ngaychieu.Name = "ngaychieu";
            this.ngaychieu.Size = new System.Drawing.Size(361, 32);
            this.ngaychieu.TabIndex = 90;
            this.ngaychieu.Value = new System.DateTime(2024, 11, 29, 16, 51, 14, 647);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 16);
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
            this.them.Location = new System.Drawing.Point(266, 408);
            this.them.Name = "them";
            this.them.Size = new System.Drawing.Size(112, 36);
            this.them.TabIndex = 89;
            this.them.Text = "Cập nhật";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 88;
            this.label2.Text = "Ngày chiếu:";
            // 
            // tenphim
            // 
            this.tenphim.BackColor = System.Drawing.Color.Transparent;
            this.tenphim.BorderColor = System.Drawing.Color.Gray;
            this.tenphim.BorderRadius = 10;
            this.tenphim.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.tenphim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenphim.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tenphim.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tenphim.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tenphim.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.tenphim.ItemHeight = 30;
            this.tenphim.Location = new System.Drawing.Point(13, 62);
            this.tenphim.Name = "tenphim";
            this.tenphim.Size = new System.Drawing.Size(365, 36);
            this.tenphim.TabIndex = 87;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 15);
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
            this.guna2Button2.Location = new System.Drawing.Point(355, 9);
            this.guna2Button2.Margin = new System.Windows.Forms.Padding(2);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(26, 28);
            this.guna2Button2.TabIndex = 97;
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // FormSuaSuatChieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(393, 461);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.giochieu);
            this.Controls.Add(this.phongchieu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ngaychieu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.them);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tenphim);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSuaSuatChieu";
            this.ShowInTaskbar = false;
            this.Text = "FormSuaSuatChieu";
            this.Load += new System.EventHandler(this.FormSuaSuatChieu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2TextBox idTextBox;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2DateTimePicker giochieu;
        private Guna.UI2.WinForms.Guna2ComboBox phongchieu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2DateTimePicker ngaychieu;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button them;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox tenphim;
        private System.Windows.Forms.Label label7;
    }
}