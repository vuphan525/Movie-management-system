using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Qlyrapchieuphim
{
    static class Helper
    {
        public static string getConnString()
        {
            string str = Properties.Settings.Default.ConnString;
            return str;
        }
        public static string SubStringBetween(string original, string start, string stop)
        {
            int startAt = original.IndexOf(start) + start.Length;
            int stopAt = original.LastIndexOf(stop);
            string result = original.Substring(startAt, stopAt - startAt);
            return result;
        }
        public static void DrawNumbering(object sender, DataGridViewRowPostPaintEventArgs e, UserControl contextForm)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, contextForm.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
        public static SqlConnection getdbConnection()
        {
            return new SqlConnection(getConnString());
        }
        public static SqlConnection SqlConnectionSwitcher()
        {
            string projectDirectory = Environment.CurrentDirectory;
            string newConnstring = Properties.Settings.Default.ConnString2 + projectDirectory + "\\Qlyrapchieuphim\\database\\QuanLyRapPhim.mdf";
            return new SqlConnection(newConnstring);
        }
        public static SqlConnection CheckDbConnection(SqlConnection conn)
        {
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                if (ex is SqlException)
                    conn = SqlConnectionSwitcher();
                conn.Open();
            }
            conn.Close();
            return conn;
        }
    }
}
