using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_SQLite_MS_Normal
{
    class csSqlHelper
    {
        public static string sDataBasePath = $"Data.db";
        //File operation flag
        public static bool IsBusy;

        /// <summary>
        /// Only used to encrypt the database
        /// </summary>
        /// <returns></returns>
        public static SqliteConnection GetConnection()
        {
            string baseConnectionString = $"data source={sDataBasePath};";
            var connectionString = new SqliteConnectionStringBuilder(baseConnectionString)
            {
                Mode = SqliteOpenMode.ReadWriteCreate,
            }.ToString();
       
       
            var con = new SqliteConnection(connectionString);
            

            return con;
        }

        public static bool InitDataBase()
        {
            try
            {
                //File exist, just check if database is valid
                if (File.Exists(sDataBasePath))
                {
                    //Verify connection
                    using (var connection = GetConnection())
                    {
                        connection.Open();
                    }
                    return true;
                }


                using (var connection = GetConnection())
                {
                    connection.Open();

                    //Create table
                    var command = connection.CreateCommand();
                    command.CommandText = @"
                            CREATE TABLE ""Records"" (
	                            ""ID""	INTEGER,
	                            ""SerialNumber""	INTEGER UNIQUE,
	                            ""CustomerID""	INTEGER,
	                            ""HeadType""	INTEGER,
	                            ""Volume""	INTEGER,
	                            ""ExpiringDate""	NUMERIC,
	                            ""Description""	INTEGER,
	                            ""AddTime""	NUMERIC DEFAULT CURRENT_TIMESTAMP,
	                            PRIMARY KEY(""ID"" AUTOINCREMENT)
                            );
                            ";
                    command.ExecuteNonQuery();

                    //Create index
                    command.CommandText = @"
                            CREATE UNIQUE INDEX ""Record_Index_SerialNumber"" ON ""Records"" (
	                            ""SerialNumber""	ASC
                            )
                            ";
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


        public static bool AddRecord(RecordRow recordRow, out string sMessage)
        {
            sMessage = "";
            IsBusy = true;
            Stopwatch watch = new Stopwatch();
            watch.Start();

            try
            {
                using (var con = GetConnection())
                {
                    con.Open();
                    var cmd = con.CreateCommand();

                    //Verify dupilication
                    cmd.CommandText = $"select * from records WHERE SerialNumber={recordRow.SerialNumber} LIMIT 1";
                    var result = cmd.ExecuteReader();
                    string sSerialNumber = recordRow.SerialNumber < 999999 ? recordRow.SerialNumber.ToString("D6") : recordRow.SerialNumber.ToString();
                    if (result.HasRows)
                    {
                        sMessage = $"SerialNumber {sSerialNumber} already used.";
                        goto Fail;
                    }
                    result.Close();
                    watch.Stop();
                    Debug.WriteLine($"AddRecord.CheckExist:{watch.ElapsedMilliseconds}ms");
                    watch.Restart();

                    string sValues = $"({recordRow.SerialNumber},{recordRow.CustomerID},{recordRow.HeadType},{recordRow.Volume},'{recordRow.ExpDate}','{recordRow.Description}');";
                    cmd.CommandText = @"
                    INSERT INTO Records (
                    SerialNumber,
                    CustomerID,
                    HeadType,
                    Volume,
                    ExpiringDate,
                    Description
                    ) VALUES " + sValues;

                    cmd.ExecuteNonQuery();
                    
                    //success
                    IsBusy = false;
                    watch.Stop();
                    Debug.WriteLine($"AddRecord.Insert:{watch.ElapsedMilliseconds}ms");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                sMessage = ex.Message;
            }


            Fail:
            watch.Stop();
            Debug.WriteLine($"AddRecord.Fail:{watch.ElapsedMilliseconds}ms");
            IsBusy = false;
            return false;
        }

    }

 
}
