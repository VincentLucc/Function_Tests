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
        public static string sDataBasePath = $"Data.db";
        public static string sPassword = "INKRecord2305041034!";
        public static bool IsBusy;

        public static SQLiteConnection NewConnection()
        {
            //Must set to version 3 to setup the password
            //Don't encrpt with official version, need to pay 2000$
            //Use sqlite cipher instead
            string ConnectionString = $"data source={sDataBasePath}";

            return new SQLiteConnection(ConnectionString);
        }

        public static bool InitDataBase()
        {
            try
            {
                //File exist, just check if database is valid
                if (File.Exists(sDataBasePath))
                {
                    //Verify connection
                    using (var connection = NewConnection())
                    {
                        connection.Open();
                    }
                    return true;
                }

                //File not exist, create a new data base
                SQLiteConnection.CreateFile(sDataBasePath);
                using (var connection = NewConnection())
                {
                    connection.Open();

                    //Create table
                    string sCreateTable = @"
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
                    SQLiteCommand command = new SQLiteCommand(sCreateTable, connection);
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
                using (var con = NewConnection())
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
