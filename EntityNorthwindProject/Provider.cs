using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EntityNorthwindProject
{
    class Provider
    {

        public static DataTable GetQueryDataTable(string SQL)
        {
            SqlConnection DB = Provider.DBConnection();
            if (DB.State != ConnectionState.Open)
            {
                DB.Open();
            }
            DataTable Table = new DataTable("CustomTable");
            new SqlDataAdapter
            {
                SelectCommand = new SqlCommand
                { CommandText = SQL, Connection = DB, CommandTimeout = 0, CommandType = CommandType.Text }
            }.Fill(Table);
            DB.Close();
            DB.Dispose();  // değişkeni öldürmek yok etmek.. SQL ram de yer tutmasın diye..
            return Table;

        }
        private static SqlConnection DBConnection()
        {
            SqlConnection Conn = new SqlConnection { ConnectionString = @"Data source = localhost; initial Catalog= NorthwindTR_Db; Connection Timeout = 0; user id=sa; password=1234" };
            Conn.Open();
            return Conn;

        }
        public static void Excel_Aktar(DataGridView dataGridView)
        {

            SaveFileDialog save = new SaveFileDialog();
            save.OverwritePrompt = false;
            save.Title = "Excel Dosyaları";
            save.DefaultExt = "xlsx";
            save.Filter = "xlsx Dosyaları (.xlsx)|.xlsx|Tüm Dosyalar(.)|.";

            if (save.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                app.Visible = true;
                worksheet = workbook.Sheets["Sayfa1"];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Sayfa1";
                for (int i = 1; i < dataGridView.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataGridView.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView.Rows[i].Cells[j].Value.ToString();
                    }
                }
                workbook.SaveAs(save.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing,Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                //app.Quit();
            }
        }

        public static string ExecuteNonQuery(string SQL)

        {
            SqlConnection DB = Provider.DBConnection();
            if (DB.State != ConnectionState.Open)
            {
                DB.Open();
            }
            string S = new SqlCommand
            {
                CommandText = SQL,
                Connection = DB,
                CommandTimeout = 0

            }.ExecuteNonQuery().ToString();
            DB.Close();
            DB.Dispose();
            return S;
        }

    }
}
