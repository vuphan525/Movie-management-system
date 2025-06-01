namespace Qlyrapchieuphim.FormEdit
{
    partial class FormSuaSuCo
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
            this.manv = new Guna.UI2.WinForms.Guna2ComboBox();
            this.masuco = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ngaytiepnhan = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mota = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bcButton = new Guna.UI2.WinForms.Guna2Button();
            this.tinhtrang = new Guna.UI2.WinForms.Guna2ComboBox();
            this.tensuco = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // manv
            // 
            this.manv.BackColor = System.Drawing.Color.Transparent;
            this.manv.BorderColor = System.Drawing.Color.Gray;
            this.manv.BorderRadius = 10;
            this.manv.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.manv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manv.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.manv.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.manv.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.manv.ForeColor = System.Drawing.Color.Black;
            this.manv.ItemHeight = 30;
            this.manv.Items.AddRange(new object[] {
            "Đã xử lý",
            "Đang xử lý",
            "Chờ tiếp nhận"});
            this.manv.Location = new System.Drawing.Point(14, 59);
            this.manv.Name = "manv";
            this.manv.Size = new System.Drawing.Size(221, 36);
            this.manv.TabIndex = 99;
            // 
            // masuco
            // 
            this.masuco.BorderColor = System.Drawing.Color.Gray;
            this.masuco.BorderRadius = 10;
            this.masuco.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.masuco.DefaultText = "";
            this.masuco.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.masuco.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.masuco.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.masuco.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.masuco.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.masuco.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.masuco.ForeColor = System.Drawing.Color.Black;
            this.masuco.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.masuco.Location = new System.Drawing.Point(14, 276);
            this.masuco.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.masuco.Name = "masuco";
            this.masuco.PasswordChar = '\0';
            this.masuco.PlaceholderText = "";
            this.masuco.SelectedText = "";
            this.masuco.Size = new System.Drawing.Size(224, 34);
            this.masuco.TabIndex = 98;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 257);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 15);
            this.label8.TabIndex = 97;
            this.label8.Text = "Mã sự cố:";
            // 
            // ngaytiepnhan
            // 
            this.ngaytiepnhan.BorderRadius = 15;
            this.ngaytiepnhan.Checked = true;
            this.ngaytiepnhan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.ngaytiepnhan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ngaytiepnhan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ngaytiepnhan.Location = new System.Drawing.Point(262, 59);
            this.ngaytiepnhan.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.ngaytiepnhan.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.ngaytiepnhan.Name = "ngaytiepnhan";
            this.ngaytiepnhan.Size = new System.Drawing.Size(255, 32);
            this.ngaytiepnhan.TabIndex = 96;
            this.ngaytiepnhan.Value = new System.DateTime(2024, 11, 29, 16, 51, 14, 647);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(259, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 15);
            this.label5.TabIndex = 95;
            this.label5.Text = "Ngày tiếp nhận:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 15);
            this.label7.TabIndex = 94;
            this.label7.Text = "Mã nhân viên:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 16);
            this.label2.TabIndex = 86;
            this.label2.Text = "Cập nhật sự cố:";
            // 
            // mota
            // 
            this.mota.BorderColor = System.Drawing.Color.Gray;
            this.mota.BorderRadius = 5;
            this.mota.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.mota.DefaultText = "";
            this.mota.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.mota.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.mota.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.mota.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.mota.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.mota.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.mota.ForeColor = System.Drawing.Color.Black;
            this.mota.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.mota.Location = new System.Drawing.Point(262, 133);
            this.mota.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mota.Name = "mota";
            this.mota.PasswordChar = '\0';
            this.mota.PlaceholderText = "";
            this.mota.SelectedText = "";
            this.mota.Size = new System.Drawing.Size(255, 177);
            this.mota.TabIndex = 93;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 87;
            this.label3.Text = "Tên sự cố:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(259, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 15);
            this.label6.TabIndex = 92;
            this.label6.Text = "Mô tả:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 15);
            this.label4.TabIndex = 88;
            this.label4.Text = "Tình trạng:";
            // 
            // bcButton
            // 
            this.bcButton.BorderRadius = 10;
            this.bcButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.bcButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.bcButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.bcButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.bcButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.bcButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bcButton.ForeColor = System.Drawing.Color.White;
            this.bcButton.Location = new System.Drawing.Point(195, 439);
            this.bcButton.Name = "bcButton";
            this.bcButton.Size = new System.Drawing.Size(137, 36);
            this.bcButton.TabIndex = 91;
            this.bcButton.Text = "Cập nhật";
            // 
            // tinhtrang
            // 
            this.tinhtrang.BackColor = System.Drawing.Color.Transparent;
            this.tinhtrang.BorderColor = System.Drawing.Color.Gray;
            this.tinhtrang.BorderRadius = 10;
            this.tinhtrang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.tinhtrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tinhtrang.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tinhtrang.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tinhtrang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tinhtrang.ForeColor = System.Drawing.Color.Black;
            this.tinhtrang.ItemHeight = 30;
            this.tinhtrang.Items.AddRange(new object[] {
            "Đã xử lý",
            "Đang xử lý",
            "Chờ tiếp nhận"});
            this.tinhtrang.Location = new System.Drawing.Point(14, 200);
            this.tinhtrang.Name = "tinhtrang";
            this.tinhtrang.Size = new System.Drawing.Size(221, 36);
            this.tinhtrang.TabIndex = 90;
            // 
            // tensuco
            // 
            this.tensuco.BorderColor = System.Drawing.Color.Gray;
            this.tensuco.BorderRadius = 10;
            this.tensuco.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tensuco.DefaultText = "";
            this.tensuco.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tensuco.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tensuco.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tensuco.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tensuco.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tensuco.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tensuco.ForeColor = System.Drawing.Color.Black;
            this.tensuco.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tensuco.Location = new System.Drawing.Point(14, 133);
            this.tensuco.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tensuco.Name = "tensuco";
            this.tensuco.PasswordChar = '\0';
            this.tensuco.PlaceholderText = "";
            this.tensuco.SelectedText = "";
            this.tensuco.Size = new System.Drawing.Size(224, 34);
            this.tensuco.TabIndex = 89;
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
            this.guna2Button2.Location = new System.Drawing.Point(495, 8);
            this.guna2Button2.Margin = new System.Windows.Forms.Padding(2);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(26, 28);
            this.guna2Button2.TabIndex = 100;
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // guna2TextBox1
            // 
            this.guna2TextBox1.BorderColor = System.Drawing.Color.Gray;
            this.guna2TextBox1.BorderRadius = 10;
            this.guna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox1.DefaultText = "";
            this.guna2TextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBox1.ForeColor = System.Drawing.Color.Black;
            this.guna2TextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.Location = new System.Drawing.Point(14, 345);
            this.guna2TextBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2TextBox1.Name = "guna2TextBox1";
            this.guna2TextBox1.PasswordChar = '\0';
            this.guna2TextBox1.PlaceholderText = "";
            this.guna2TextBox1.SelectedText = "";
            this.guna2TextBox1.Size = new System.Drawing.Size(224, 34);
            this.guna2TextBox1.TabIndex = 102;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 326);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 101;
            this.label1.Text = "Hướng giải quyết";
            // 
            // FormSuaSuCo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(532, 487);
            this.Controls.Add(this.guna2TextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.manv);
            this.Controls.Add(this.masuco);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ngaytiepnhan);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mota);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bcButton);
            this.Controls.Add(this.tinhtrang);
            this.Controls.Add(this.tensuco);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSuaSuCo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormSuaSuCo";
            this.Load += new System.EventHandler(this.FormSuaSuCo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2ComboBox manv;
        private Guna.UI2.WinForms.Guna2TextBox masuco;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2DateTimePicker ngaytiepnhan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox mota;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Button bcButton;
        private Guna.UI2.WinForms.Guna2ComboBox tinhtrang;
        private Guna.UI2.WinForms.Guna2TextBox tensuco;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private System.Windows.Forms.Label label1;
    }
}