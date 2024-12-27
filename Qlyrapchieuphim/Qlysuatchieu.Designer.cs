namespace Qlyrapchieuphim
{
    partial class Qlysuatchieu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.timkiem = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.idphim = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chinhsua = new Guna.UI2.WinForms.Guna2Button();
            this.giochieu = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.xoa = new Guna.UI2.WinForms.Guna2Button();
            this.phongchieu = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ngaychieu = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.them = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tenphim = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column5,
            this.Column6});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(21, 69);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1392, 318);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 70F;
            this.Column1.HeaderText = "STT";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.FillWeight = 130F;
            this.Column2.HeaderText = "Tên phim";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column4
            // 
            this.Column4.FillWeight = 70F;
            this.Column4.HeaderText = "Phòng chiếu";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Ngày chiếu";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Giờ chiếu ";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.timkiem);
            this.panel2.Controls.Add(this.guna2Button1);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(21, 22);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1436, 409);
            this.panel2.TabIndex = 9;
            // 
            // timkiem
            // 
            this.timkiem.BorderRadius = 15;
            this.timkiem.Checked = true;
            this.timkiem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.timkiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.timkiem.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.timkiem.Location = new System.Drawing.Point(985, 12);
            this.timkiem.Margin = new System.Windows.Forms.Padding(4);
            this.timkiem.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.timkiem.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.timkiem.Name = "timkiem";
            this.timkiem.Size = new System.Drawing.Size(172, 39);
            this.timkiem.TabIndex = 60;
            this.timkiem.Value = new System.DateTime(2024, 11, 29, 16, 51, 14, 647);
            this.timkiem.ValueChanged += new System.EventHandler(this.timkiem_ValueChanged);
            this.timkiem.TextChanged += new System.EventHandler(this.timkiem_TextChanged);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 10;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(1185, 12);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(228, 44);
            this.guna2Button1.TabIndex = 56;
            this.guna2Button1.Text = "Tìm kiếm suất chiếu ";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Suất chiếu:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.idphim);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.chinhsua);
            this.panel1.Controls.Add(this.giochieu);
            this.panel1.Controls.Add(this.xoa);
            this.panel1.Controls.Add(this.phongchieu);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.ngaychieu);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.them);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tenphim);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(21, 452);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1436, 363);
            this.panel1.TabIndex = 11;
            // 
            // idphim
            // 
            this.idphim.BorderColor = System.Drawing.Color.Gray;
            this.idphim.BorderRadius = 10;
            this.idphim.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.idphim.DefaultText = "";
            this.idphim.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.idphim.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.idphim.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.idphim.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.idphim.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.idphim.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.idphim.ForeColor = System.Drawing.Color.Black;
            this.idphim.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.idphim.Location = new System.Drawing.Point(731, 67);
            this.idphim.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.idphim.Name = "idphim";
            this.idphim.PasswordChar = '\0';
            this.idphim.PlaceholderText = "";
            this.idphim.SelectedText = "";
            this.idphim.Size = new System.Drawing.Size(228, 43);
            this.idphim.TabIndex = 61;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(606, 84);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 18);
            this.label6.TabIndex = 60;
            this.label6.Text = "Mã suất chiếu:";
            // 
            // chinhsua
            // 
            this.chinhsua.BorderRadius = 10;
            this.chinhsua.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.chinhsua.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.chinhsua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.chinhsua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.chinhsua.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.chinhsua.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chinhsua.ForeColor = System.Drawing.Color.White;
            this.chinhsua.Location = new System.Drawing.Point(501, 267);
            this.chinhsua.Margin = new System.Windows.Forms.Padding(4);
            this.chinhsua.Name = "chinhsua";
            this.chinhsua.Size = new System.Drawing.Size(149, 44);
            this.chinhsua.TabIndex = 59;
            this.chinhsua.Text = "Chỉnh sửa ";
            this.chinhsua.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // giochieu
            // 
            this.giochieu.BorderRadius = 15;
            this.giochieu.Checked = true;
            this.giochieu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.giochieu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.giochieu.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.giochieu.Location = new System.Drawing.Point(1119, 63);
            this.giochieu.Margin = new System.Windows.Forms.Padding(4);
            this.giochieu.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.giochieu.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.giochieu.Name = "giochieu";
            this.giochieu.Size = new System.Drawing.Size(188, 39);
            this.giochieu.TabIndex = 58;
            this.giochieu.Value = new System.DateTime(2024, 11, 29, 16, 51, 14, 647);
            this.giochieu.ValueChanged += new System.EventHandler(this.giochieu_ValueChanged);
            // 
            // xoa
            // 
            this.xoa.BorderRadius = 10;
            this.xoa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.xoa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.xoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.xoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.xoa.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.xoa.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xoa.ForeColor = System.Drawing.Color.White;
            this.xoa.Location = new System.Drawing.Point(297, 267);
            this.xoa.Margin = new System.Windows.Forms.Padding(4);
            this.xoa.Name = "xoa";
            this.xoa.Size = new System.Drawing.Size(149, 44);
            this.xoa.TabIndex = 55;
            this.xoa.Text = "Xóa suất ";
            this.xoa.Click += new System.EventHandler(this.xoa_Click);
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
            this.phongchieu.Location = new System.Drawing.Point(224, 162);
            this.phongchieu.Margin = new System.Windows.Forms.Padding(4);
            this.phongchieu.Name = "phongchieu";
            this.phongchieu.Size = new System.Drawing.Size(179, 36);
            this.phongchieu.TabIndex = 52;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(87, 174);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 18);
            this.label5.TabIndex = 51;
            this.label5.Text = "Phòng chiếu:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(999, 75);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 18);
            this.label4.TabIndex = 50;
            this.label4.Text = "Giờ chiếu:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // ngaychieu
            // 
            this.ngaychieu.BorderRadius = 15;
            this.ngaychieu.Checked = true;
            this.ngaychieu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.ngaychieu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ngaychieu.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ngaychieu.Location = new System.Drawing.Point(731, 162);
            this.ngaychieu.Margin = new System.Windows.Forms.Padding(4);
            this.ngaychieu.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.ngaychieu.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.ngaychieu.Name = "ngaychieu";
            this.ngaychieu.Size = new System.Drawing.Size(172, 39);
            this.ngaychieu.TabIndex = 49;
            this.ngaychieu.Value = new System.DateTime(2024, 11, 29, 16, 51, 14, 647);
            this.ngaychieu.ValueChanged += new System.EventHandler(this.ngaychieu_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 25);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Thêm suất chiếu:";
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
            this.them.Location = new System.Drawing.Point(96, 267);
            this.them.Margin = new System.Windows.Forms.Padding(4);
            this.them.Name = "them";
            this.them.Size = new System.Drawing.Size(149, 44);
            this.them.TabIndex = 47;
            this.them.Text = "Thêm suất ";
            this.them.Click += new System.EventHandler(this.them_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(625, 174);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 18);
            this.label2.TabIndex = 45;
            this.label2.Text = "Ngày chiếu:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
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
            this.tenphim.Items.AddRange(new object[] {
            "Conan",
            "Aquaman",
            "Avenger"});
            this.tenphim.Location = new System.Drawing.Point(224, 74);
            this.tenphim.Margin = new System.Windows.Forms.Padding(4);
            this.tenphim.Name = "tenphim";
            this.tenphim.Size = new System.Drawing.Size(311, 36);
            this.tenphim.TabIndex = 44;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(109, 84);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 18);
            this.label7.TabIndex = 33;
            this.label7.Text = "Tên phim:";
            // 
            // Qlysuatchieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Qlysuatchieu";
            this.Size = new System.Drawing.Size(1477, 832);
            this.Load += new System.EventHandler(this.Qlysuatchieu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2DateTimePicker giochieu;
        private Guna.UI2.WinForms.Guna2Button xoa;
        private Guna.UI2.WinForms.Guna2ComboBox phongchieu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2DateTimePicker ngaychieu;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button them;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox tenphim;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2Button chinhsua;
        private Guna.UI2.WinForms.Guna2DateTimePicker timkiem;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private Guna.UI2.WinForms.Guna2TextBox idphim;
        private System.Windows.Forms.Label label6;
    }
}
