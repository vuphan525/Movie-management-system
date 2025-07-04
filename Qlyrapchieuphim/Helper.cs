using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qlyrapchieuphim
{
    static class Helper
    {
        public static void Populate<T>(this T[] arr, T value)
        {
            if (arr == null)
                return;
            for (int i = 0; i < arr.Length; i++)
                arr[i] = value;
        }
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
            return CheckDbConnection(new SqlConnection(getConnString()));
        }
        public static bool IsInWinFormsDesignMode()
        {
            bool returnValue = false;
            if (System.ComponentModel.LicenseManager.UsageMode ==
                 System.ComponentModel.LicenseUsageMode.Designtime)
            {
                returnValue = true;
            }
            return returnValue;
        }
        private static void CopyFilesRecursively(string sourcePath, string targetPath)
        {
            if (!Directory.Exists(sourcePath))
            { Directory.CreateDirectory(targetPath); }
            //Now Create all of the directories
            int count = 0;
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
                count++;
                if (count > 10)
                    break;
            }
            if (!Directory.Exists(targetPath))
            { Directory.CreateDirectory(targetPath); }
            //Copy all the files & Replaces any files with the same name
            count = 0;
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
                count++;
                if (count > 10)
                    break;
            }
        }
        public static void CopyDatabaseForDesign()
        {
            string databasePath = Environment.CurrentDirectory + "\\Qlyrapchieuphim\\database\\";
            string backupPath = Environment.CurrentDirectory + "\\Qlyrapchieuphim\\database_backup\\";
            CopyFilesRecursively(databasePath, backupPath);
        }
        public static SqlConnection SqlConnectionSwitcher()
        {
            string projectDirectory = Environment.CurrentDirectory;
            string newConnstring = Properties.Settings.Default.ConnString2 + projectDirectory + "\\Qlyrapchieuphim\\database_backup\\QuanLyRapPhim.mdf";
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
            finally
            {
                conn.Close();
            }
            return conn;
        }
    }
}
