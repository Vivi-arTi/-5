using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using Mysqlx;

namespace _23._11
{
    internal class MyClassKlient
    {
        static public DataTable dtKlient = new DataTable();

        static public void ViewStudent()
        {
            try
            {
                MyClassConnection.myCommand.CommandText = "select*from client";
                dtKlient.Clear();
                MyClassConnection.myDataAdapter.Fill(dtKlient);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при выводе данных");
            }
        }
    }
}
