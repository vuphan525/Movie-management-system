namespace Qlyrapchieuphim
{
    partial class QlyDoanhThu
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_Time_Start = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtp_Time_End = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_Pie_Chart_Date = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.tenphim = new Guna.UI2.WinForms.Guna2ComboBox();
            this.pieChart1 = new LiveCharts.WinForms.PieChart();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(17, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(362, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chọn khoảng thời gian thống kê";
            // 
            // dtp_Time_Start
            // 
            this.dtp_Time_Start.BorderRadius = 15;
            this.dtp_Time_Start.Checked = true;
            this.dtp_Time_Start.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.dtp_Time_Start.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtp_Time_Start.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Time_Start.Location = new System.Drawing.Point(23, 69);
            this.dtp_Time_Start.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtp_Time_Start.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtp_Time_Start.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_Time_Start.Name = "dtp_Time_Start";
            this.dtp_Time_Start.Size = new System.Drawing.Size(271, 39);
            this.dtp_Time_Start.TabIndex = 85;
            this.dtp_Time_Start.Value = new System.DateTime(2024, 11, 29, 16, 51, 14, 647);
            this.dtp_Time_Start.ValueChanged += new System.EventHandler(this.dtp_Time_Start_ValueChanged);
            // 
            // dtp_Time_End
            // 
            this.dtp_Time_End.BorderRadius = 15;
            this.dtp_Time_End.Checked = true;
            this.dtp_Time_End.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.dtp_Time_End.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtp_Time_End.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Time_End.Location = new System.Drawing.Point(355, 69);
            this.dtp_Time_End.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtp_Time_End.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtp_Time_End.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_Time_End.Name = "dtp_Time_End";
            this.dtp_Time_End.Size = new System.Drawing.Size(271, 39);
            this.dtp_Time_End.TabIndex = 86;
            this.dtp_Time_End.Value = new System.DateTime(2024, 11, 29, 16, 51, 14, 647);
            this.dtp_Time_End.ValueChanged += new System.EventHandler(this.dtp_Time_End_ValueChanged);
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Location = new System.Drawing.Point(19, 11);
            this.cartesianChart1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(829, 668);
            this.cartesianChart1.TabIndex = 87;
            this.cartesianChart1.Text = "cartesianChart1";
            this.cartesianChart1.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.cartesianChart1_ChildChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(896, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 31);
            this.label2.TabIndex = 88;
            this.label2.Text = "Ngày thống kê";
            // 
            // dtp_Pie_Chart_Date
            // 
            this.dtp_Pie_Chart_Date.BorderRadius = 15;
            this.dtp_Pie_Chart_Date.Checked = true;
            this.dtp_Pie_Chart_Date.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.dtp_Pie_Chart_Date.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtp_Pie_Chart_Date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Pie_Chart_Date.Location = new System.Drawing.Point(1109, 25);
            this.dtp_Pie_Chart_Date.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtp_Pie_Chart_Date.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtp_Pie_Chart_Date.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_Pie_Chart_Date.Name = "dtp_Pie_Chart_Date";
            this.dtp_Pie_Chart_Date.Size = new System.Drawing.Size(349, 39);
            this.dtp_Pie_Chart_Date.TabIndex = 89;
            this.dtp_Pie_Chart_Date.Value = new System.DateTime(2024, 11, 29, 16, 51, 14, 647);
            this.dtp_Pie_Chart_Date.ValueChanged += new System.EventHandler(this.dtp_Pie_Chart_Date_ValueChanged);
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
            "Doraemon"});
            this.tenphim.Location = new System.Drawing.Point(902, 72);
            this.tenphim.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tenphim.Name = "tenphim";
            this.tenphim.Size = new System.Drawing.Size(556, 36);
            this.tenphim.TabIndex = 90;
            this.tenphim.SelectedIndexChanged += new System.EventHandler(this.tenphim_SelectedIndexChanged);
            // 
            // pieChart1
            // 
            this.pieChart1.Location = new System.Drawing.Point(96, 175);
            this.pieChart1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pieChart1.Name = "pieChart1";
            this.pieChart1.Size = new System.Drawing.Size(384, 274);
            this.pieChart1.TabIndex = 91;
            this.pieChart1.Text = "pieChart1";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.guna2Panel1.BorderThickness = 2;
            this.guna2Panel1.Controls.Add(this.pieChart1);
            this.guna2Panel1.Location = new System.Drawing.Point(901, 132);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(572, 697);
            this.guna2Panel1.TabIndex = 92;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.guna2Panel2.BorderThickness = 2;
            this.guna2Panel2.Controls.Add(this.cartesianChart1);
            this.guna2Panel2.Location = new System.Drawing.Point(4, 132);
            this.guna2Panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(865, 697);
            this.guna2Panel2.TabIndex = 93;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // QlyDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.tenphim);
            this.Controls.Add(this.dtp_Pie_Chart_Date);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtp_Time_End);
            this.Controls.Add(this.dtp_Time_Start);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "QlyDoanhThu";
            this.Size = new System.Drawing.Size(1477, 832);
            this.Load += new System.EventHandler(this.QlyDoanhThu_Load);
            this.Enter += new System.EventHandler(this.QlyDoanhThu_Enter);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtp_Time_Start;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtp_Time_End;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtp_Pie_Chart_Date;
        private Guna.UI2.WinForms.Guna2ComboBox tenphim;
        private LiveCharts.WinForms.PieChart pieChart1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
    }
}
