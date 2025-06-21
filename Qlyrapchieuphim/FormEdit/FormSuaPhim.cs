using Guna.UI2.WinForms;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qlyrapchieuphim.FormEdit
{
    public partial class FormSuaPhim : Form
    {
        public FormSuaPhim()
        {
            InitializeComponent();
            Guna2ShadowForm shadow = new Guna2ShadowForm();
            shadow.TargetForm = this;
            this.Paint += FormThemPhim_Paint;
        }
        private string movieId;

public FormSuaPhim(string id)
{
    InitializeComponent();
    movieId = id;
}

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        SqlConnection conn = null;

        string poster_url = string.Empty;
        string projectFolder = AppDomain.CurrentDomain.BaseDirectory;
        private void FormSuaPhim_Load(object sender, EventArgs e)
        {
            date_FormSuaPhim_NgayNhap.Format = DateTimePickerFormat.Custom;
            date_FormSuaPhim_NgayNhap.CustomFormat = "dd/MM/yyyy";
            date_FormSuaPhim_NgayPhatHanh.Format = DateTimePickerFormat.Custom;
            date_FormSuaPhim_NgayPhatHanh.CustomFormat = "dd/MM/yyyy";

            LoadMovieData(movieId);
        }

        private void FormThemPhim_Paint(object sender, PaintEventArgs e)
        {
            int borderWidth = 2;
            Color borderColor = Color.MediumSlateBlue;

            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                borderColor, borderWidth, ButtonBorderStyle.Solid,
                borderColor, borderWidth, ButtonBorderStyle.Solid,
                borderColor, borderWidth, ButtonBorderStyle.Solid,
                borderColor, borderWidth, ButtonBorderStyle.Solid);
        }
    }
}
