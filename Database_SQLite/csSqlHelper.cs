using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_SQLite
{
    class csSqlHelper
    {
        public static string DataBasePath = $"{Application.StartupPath}\\Data.db";

        public static SQLiteConnection NewConnection()
        {
            //Must set to version 3 to setup the password
            string ConnectionString = $"data source={DataBasePath};Version=3;";

            return new SQLiteConnection(ConnectionString);
        }

        public static bool InitDataBase()
        {
            try
            {
                //File exist, just check if database is valid
                if (File.Exists(DataBasePath))
                {
                    //Verify connection
                    using (var connection = NewConnection())
                    {
                        connection.Open();
                    }
                    return true;
                }

                //File not exist, create a new data base
                SQLiteConnection.CreateFile(DataBasePath);
                using (var connection = NewConnection())
                {
                    connection.SetPassword("Test01");
                    connection.Open();

                    //Create table
                    string sCreateTable = "Create Table highscores (name varchar(20), score int)";
                    SQLiteCommand command = new SQLiteCommand(sCreateTable, connection);
                    command.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("InitDataBase:\r\n" + ex.Message);
                return false;
            }

            //Pass all steps
            return true;
        }

    }
}
