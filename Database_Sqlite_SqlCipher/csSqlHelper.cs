using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
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
        public static string sDataBasePath = $"{Application.StartupPath}\\Data.db";
        public static string sPassword = "123";

        /// <summary>
        /// Only used to encrypt the database
        /// </summary>
        /// <returns></returns>
        public static SqliteConnection PasswordConnection()
        {
            //Must set to version 3 to setup the password
            string baseConnectionString = $"data source={sDataBasePath};Version=3;";
            var connectionString = new SqliteConnectionStringBuilder(baseConnectionString)
            {
                Mode = SqliteOpenMode.ReadWriteCreate,
                Password = sPassword
            }.ToString();

            return new SqliteConnection(connectionString);
        }

        public static bool InitDataBase()
        {
            try
            {
                //File exist, just check if database is valid
                if (File.Exists(sDataBasePath))
                {
                    //Verify connection
                    using (var connection = PasswordConnection())
                    {
                        connection.Open();
                    }
                    return true;
                }

                //File not exist, create a new data base
                SqliteConnection.CreateFile(sDataBasePath);
                
                using (var connection = PasswordConnection())
                {
                    connection.SetPassword("Test01");
                    connection.Open();

                    //Create table
                    var command = connection.CreateCommand();
                    string sCreateTable = "Create Table highscores (name varchar(20), score int)";
                    SqliteCommand command = new SqliteCommand(sCreateTable, connection);
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
