using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Sqlite_SqlCipher
{
    class csSqlHelper
    {
        public static string sDataBasePath = $"Data.db";
        public static string sPassword = "INKRecord2305041034!";

        /// <summary>
        /// Only used to encrypt the database
        /// </summary>
        /// <returns></returns>
        public static SqliteConnection PasswordConnection()
        {
            //Must set to version 3 to setup the password
            string baseConnectionString = $"data source={sDataBasePath};";
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


                using (var connection = PasswordConnection())
                {
                    connection.Open();

                    //Create table
                    var command = connection.CreateCommand();
                    command.CommandText = "Create Table highscores (name varchar(20), score int)";
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
