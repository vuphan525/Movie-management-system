namespace Qlyrapchieuphim
{
    partial class Yesfrm
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
            this.thanhtoan = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // thanhtoan
            // 
            this.thanhtoan.BorderRadius = 10;
            this.thanhtoan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.thanhtoan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.thanhtoan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.thanhtoan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.thanhtoan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.thanhtoan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thanhtoan.ForeColor = System.Drawing.Color.White;
            this.thanhtoan.Location = new System.Drawing.Point(253, 162);
            this.thanhtoan.Margin = new System.Windows.Forms.Padding(4);
            this.thanhtoan.Name = "thanhtoan";
            this.thanhtoan.Size = new System.Drawing.Size(118, 50);
            this.thanhtoan.TabIndex = 51;
            this.thanhtoan.Text = "OK";
            // 
            // Yesfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 225);
            this.Controls.Add(this.thanhtoan);
            this.Name = "Yesfrm";
            this.Text = "Yesfrm";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button thanhtoan;
    }
}