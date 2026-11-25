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
    internal class MyClassConnection
    {
        static string connectionString = @"Database=bd_polomka; DataSource=localhost;
                                            user=root; password=qwerty; charset=utf8mb4;";

        static MySqlConnection myConnect;
        static public MySqlCommand myCommand;
        static public MySqlDataAdapter myDataAdapter;

        static public string role;
        static public string user;

        static public bool ConnectBD()
        {
            try
            {
                myConnect = new MySqlConnection(connectionString);
                myConnect.Open();
                myCommand = new MySqlCommand(); // для выполнения запрос
                myCommand.Connection = myConnect;
                myDataAdapter = new MySqlDataAdapter(myCommand);
                return true;

            }
            catch
            {
                return false;
            }
        }

        static public bool CloseBD()
        {
            try
            {
                myConnect.Close();  
                return true;
            }
            catch
            {
                return false;
            }
        }

        static public void Authorization(string log, string pas)
        {
            object result;

            try
            {
               string sql = $@"select id_admin_login from  admin where id_admin_login = '{log}' and password = ('{pas}')";
                 myCommand.CommandText = sql;

                result = myCommand.ExecuteScalar();

                if (result != null )
                {
                    role = "admin";
                    user = result.ToString();
                    return;
                }
             }
            catch
            {
                role = user = null;
                System.Windows.Forms.MessageBox.Show("Ошибка при авторизации");
            }
            
        }
    }
}
