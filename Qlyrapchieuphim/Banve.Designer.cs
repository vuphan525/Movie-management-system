﻿namespace Qlyrapchieuphim
{
    partial class Banve
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Search = new Guna.UI2.WinForms.Guna2Button();
            this.tenphim = new Guna.UI2.WinForms.Guna2ComboBox();
            this.date = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.movidColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roomColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.movieColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NGAYCHIEU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1477, 92);
            this.label1.TabIndex = 10;
            this.label1.Text = "LỊCH CHIẾU PHIM";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.groupBox1.Controls.Add(this.Search);
            this.groupBox1.Controls.Add(this.tenphim);
            this.groupBox1.Controls.Add(this.date);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 96);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(436, 736);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết";
            // 
            // Search
            // 
            this.Search.BorderRadius = 20;
            this.Search.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Search.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Search.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Search.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Search.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Search.ForeColor = System.Drawing.Color.White;
            this.Search.Location = new System.Drawing.Point(137, 38);
            this.Search.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(180, 46);
            this.Search.TabIndex = 53;
            this.Search.Text = "Tìm kiếm suất chiếu";
            this.Search.Click += new System.EventHandler(this.Search_Click);
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
            "conan ",
            "aquaman"});
            this.tenphim.Location = new System.Drawing.Point(24, 192);
            this.tenphim.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tenphim.Name = "tenphim";
            this.tenphim.Size = new System.Drawing.Size(384, 36);
            this.tenphim.TabIndex = 51;
            // 
            // date
            // 
            this.date.BorderRadius = 15;
            this.date.Checked = true;
            this.date.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.date.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date.Location = new System.Drawing.Point(24, 90);
            this.date.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.date.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.date.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(385, 39);
            this.date.TabIndex = 50;
            this.date.Value = new System.DateTime(2024, 11, 29, 16, 51, 14, 647);
            this.date.ValueChanged += new System.EventHandler(this.date_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "Phim:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Thời Gian:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idColumn,
            this.movidColumn,
            this.roomColumn,
            this.movieColumn,
            this.NGAYCHIEU,
            this.timeColumn,
            this.stateColumn});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(444, 96);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1033, 736);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // idColumn
            // 
            this.idColumn.DataPropertyName = "MASUATCHIEU";
            this.idColumn.HeaderText = "MASUATCHIEU";
            this.idColumn.MinimumWidth = 6;
            this.idColumn.Name = "idColumn";
            this.idColumn.ReadOnly = true;
            this.idColumn.Visible = false;
            // 
            // movidColumn
            // 
            this.movidColumn.DataPropertyName = "MAPHIM";
            this.movidColumn.HeaderText = "MAPHIM";
            this.movidColumn.MinimumWidth = 6;
            this.movidColumn.Name = "movidColumn";
            this.movidColumn.ReadOnly = true;
            this.movidColumn.Visible = false;
            // 
            // roomColumn
            // 
            this.roomColumn.DataPropertyName = "MAPHONG";
            this.roomColumn.HeaderText = "Tên Phòng Chiếu";
            this.roomColumn.MinimumWidth = 6;
            this.roomColumn.Name = "roomColumn";
            this.roomColumn.ReadOnly = true;
            // 
            // movieColumn
            // 
            this.movieColumn.DataPropertyName = "TENPHIM";
            this.movieColumn.HeaderText = "Tên Phim";
            this.movieColumn.MinimumWidth = 6;
            this.movieColumn.Name = "movieColumn";
            this.movieColumn.ReadOnly = true;
            // 
            // NGAYCHIEU
            // 
            this.NGAYCHIEU.DataPropertyName = "NGAYCHIEU";
            this.NGAYCHIEU.HeaderText = "Ngày Chiếu";
            this.NGAYCHIEU.MinimumWidth = 6;
            this.NGAYCHIEU.Name = "NGAYCHIEU";
            this.NGAYCHIEU.ReadOnly = true;
            // 
            // timeColumn
            // 
            this.timeColumn.DataPropertyName = "THOIGIANBATDAU";
            this.timeColumn.HeaderText = "Giờ Chiếu";
            this.timeColumn.MinimumWidth = 6;
            this.timeColumn.Name = "timeColumn";
            this.timeColumn.ReadOnly = true;
            // 
            // stateColumn
            // 
            this.stateColumn.HeaderText = "Tình Trạng";
            this.stateColumn.MinimumWidth = 6;
            this.stateColumn.Name = "stateColumn";
            this.stateColumn.ReadOnly = true;
            this.stateColumn.Visible = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Banve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Banve";
            this.Size = new System.Drawing.Size(1477, 832);
            this.Load += new System.EventHandler(this.Banve_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Guna.UI2.WinForms.Guna2ComboBox tenphim;
        private Guna.UI2.WinForms.Guna2DateTimePicker date;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Guna.UI2.WinForms.Guna2Button Search;
        private System.Windows.Forms.DataGridViewTextBoxColumn idColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn movidColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn roomColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn movieColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NGAYCHIEU;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stateColumn;
    }
}
