using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
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

        public static SqliteConnection connection;

        /// <summary>
        /// Used to read/write unique identifier
        /// </summary>
        public static string FieldHardDisk = "HardDisk0";
        /// <summary>
        /// This field used for read/write test
        /// </summary>
        public static string FieldTest = "Test";

        /// <summary>
        /// Connection creation is time consuming in this dll, create only once
        /// </summary>
        /// <returns></returns>
        public static bool InitConnection(bool createDatabase, out string sMessage)
        {
            sMessage = "";
            try
            {
                if (!File.Exists(sDataBasePath) && !createDatabase)
                {
                    sMessage = "Database file is missing.";
                    return false;
                }

                if (connection == null)
                {
                    //Init the settings
                    string baseConnectionString = $"data source={sDataBasePath};";
                    var connectionString = new SqliteConnectionStringBuilder(baseConnectionString)
                    {
                        Mode = createDatabase ? SqliteOpenMode.ReadWriteCreate : SqliteOpenMode.ReadWrite
                    }.ToString();

                    connection = new SqliteConnection(connectionString);
                }

                connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("CreateOrConnectDatabase:" + ex.Message);
            }

            return false;
        }

        public static bool CreateDataBase(out string sMessage)
        {
            sMessage = "";
            SqliteCommand cmd = null;
            SqliteTransaction trans = null;

            try
            {
                //File exist, just check if database is valid
                if (File.Exists(sDataBasePath))
                {
                    sMessage = "File already exist.";
                    return false;
                }

                //Create directory
                string sDir = Path.GetDirectoryName(sDataBasePath);
                //Make sure directory is valid
                if (!string.IsNullOrWhiteSpace(sDir) && !Directory.Exists(sDir))
                {
                    Directory.CreateDirectory(sDir);
                }

                //Create connection
                if (!InitConnection(createDatabase: true, out sMessage)) return false;

                //Prepare to start
                cmd = connection.CreateCommand();
                trans = connection.BeginTransaction();
                cmd.Transaction = trans;

                //Create table
                cmd.CommandText = @"
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
                cmd.ExecuteNonQuery();

                //Create index
                cmd.CommandText = @"
                            CREATE UNIQUE INDEX ""Record_Index_SerialNumber"" ON ""Records"" (
	                            ""SerialNumber""	ASC
                            )
                            ";
                cmd.ExecuteNonQuery();

                //Create hardare table
                cmd.CommandText = @"
                        CREATE TABLE ""HardwareInfo"" (
	                        ""Name""	TEXT,
	                        ""Value""	TEXT,
	                        ""Description""	TEXT,
	                        PRIMARY KEY(""Name"")
                        );
                        ";
                cmd.ExecuteNonQuery();

                //Insert hardwareID info
                string sID = csHardware.FirstHardDriveID;
                if (string.IsNullOrWhiteSpace(sID))
                {
                    sMessage = $"Unable to fetch device info.";
                    return false;
                }
                cmd.CommandText = $"INSERT INTO HardwareInfo (Name,Value,Description) VALUES ('{FieldHardDisk}','{sID}','Main/First Drive ID');";
                cmd.ExecuteNonQuery();

                //A sample data used for read/write test
                //Must make sure the database is readable
                cmd.CommandText = $"INSERT INTO HardwareInfo (Name,Value,Description) VALUES ('{FieldTest}','{DateTime.Now}','Read/Write Test');";
                cmd.ExecuteNonQuery();

                //Commit 
                trans.Commit();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("CreateDataBase:\r\n" + ex.Message);
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
                if (connection == null)
                {
                    sMessage = "Connection not yet init.";
                    return false;
                }
                else if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                var cmd = connection.CreateCommand();

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
