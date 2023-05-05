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

namespace Database_Sqlite_SqlCipher
{
    class csSqlHelper
    {
        public static string sDataBasePath = $"Data.db";
        public static string sPassword = "INKRecord2305041034!";
        //File operation flag
        public static bool IsBusy;

        /// <summary>
        /// Used to read/write unique identifier
        /// </summary>
        public static string FieldHardDisk = "HardDisk0";
        /// <summary>
        /// This field used for read/write test
        /// </summary>
        public static string FieldTest = "Test";

        //Current Connection
        public static SqliteConnection Connection;

        /// <summary>
        /// Connect to the encrypted database
        /// </summary>
        /// <returns></returns>
        public static bool InitPasswordConnection()
        {
            try
            {
                if (Connection == null)
                {
                    string baseConnectionString = $"data source={sDataBasePath};";
                    var connectionString = new SqliteConnectionStringBuilder(baseConnectionString)
                    {
                        Mode = SqliteOpenMode.ReadWriteCreate,
                        Password = sPassword,
                    }.ToString();

                    Connection = new SqliteConnection(connectionString);

                }

                Connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("InitPasswordConnection:" + ex.Message);
            }

            return false;
        }

        public static bool CreateDataBase(out string sMessage)
        {
            //Init variables
            sMessage = "";
            SqliteCommand cmd = null;
            SqliteTransaction trans = null;

            try
            {
                //File exist, just check if database is valid
                if (File.Exists(sDataBasePath))
                {
                    File.Delete(sDataBasePath);
                }

                InitPasswordConnection();

                //Prepare to start
                cmd = Connection.CreateCommand();
                trans = Connection.BeginTransaction();
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
                Debug.WriteLine("InitDataBase:\r\n" + ex.Message);
                sMessage = $"InitDataBase:{ex.Message}";
                trans?.Rollback();
                return false;
            }

            //Pass all steps
            return true;
        }


        public static bool CanAddRecord(int iSN, out string sMessage)
        {
            sMessage = "";
            Stopwatch watch = new Stopwatch();
            watch.Start();

            try
            {
                //Prepare connection
                if (Connection.State == ConnectionState.Closed)
                    Connection.Open();


                using (var cmd = Connection.CreateCommand())
                {
                    //Reset timeout
                    cmd.CommandTimeout = 2;

                    //Verify device ID
                    cmd.CommandText = "SELECT HardwareInfo.Value FROM HardwareInfo WHERE HardwareInfo.Name='HardDisk0';";
                    var reader = cmd.ExecuteReader();
                    if (!reader.Read())
                    {
                        sMessage = "Device info is missing.";
                        return false;
                    }
                    //read first column result
                    string sDriveID_Device = csHardware.FirstHardDriveID;
                    string sDriveID_Record = reader.GetString(0);
                    reader.Close();
                    if (string.IsNullOrWhiteSpace(sDriveID_Record) || sDriveID_Record != sDriveID_Device)
                    {
                        sMessage = $"Device info mis-match. Device:{sDriveID_Device},Record:{sDriveID_Record}.";
                        return false;
                    }

                    //Verify dupilication
                    if (iSN == 1) return true;//Always allow test tag adding
                    cmd.CommandText = $"select * from records WHERE SerialNumber={iSN} LIMIT 1";
                    var result = cmd.ExecuteReader();
                    string sSerialNumber = iSN < 999999 ? iSN.ToString("D6") : iSN.ToString();
                    if (result.HasRows)
                    {
                        sMessage = $"SerialNumber {sSerialNumber} already used.";
                        return false;
                    }
                    result.Close();

                    //Verify write
                    cmd.CommandTimeout = 1;
                    cmd.CommandText = $"UPDATE HardwareInfo SET Value='{DateTime.Now}' WHERE name='{FieldTest}';";
                    cmd.ExecuteNonQuery();

                    
                }

            }
            catch (Exception ex)
            {
                sMessage = $"CanAddRecord.Exception:{ex.Message}";
                Debug.WriteLine(sMessage);
                return false;
            }

            //Pass all steps
            watch.Stop();
            sMessage = watch.ElapsedMilliseconds.ToString();
            Debug.WriteLine($"CanAddRecord.Completed:{watch.ElapsedMilliseconds}ms");
            return true;
        }

        public static bool AddRecord(RecordRow recordRow, out string sMessage)
        {
            sMessage = "";
            IsBusy = true;
            Stopwatch watch = new Stopwatch();
            SqliteTransaction trans = null;
            watch.Start();

            try
            {
                //Verify connection
                if (Connection.State == ConnectionState.Closed)
                    Connection.Open();
                watch.Stop();
                Debug.WriteLine($"AddRecord.OpenConnection:{watch.ElapsedMilliseconds}ms");
                watch.Restart();

                trans = Connection.BeginTransaction();
                using (var cmd = Connection.CreateCommand())
                {
                    cmd.CommandTimeout = 3;
                    //Test tag record
                    string sValues = "";
                    if (recordRow.SerialNumber == 1)
                    {
                        cmd.CommandText = "SELECT max(Records.SerialNumber) FROM Records;";
                        var reader = cmd.ExecuteReader();
                        //Test number start from 1000000000
                        int iTestSN = 1000000000;
                        if (reader.Read())
                        {
                            int iMax = reader.GetInt32(0);
                            if (iMax > 999999999) iTestSN = iMax + 1;
                        }
                        reader.Close();
                        sValues = $"({iTestSN},{recordRow.CustomerID},{recordRow.HeadType},{recordRow.Volume},'{recordRow.ExpDate}','Test Tag');";
                    }
                    else
                    {
                        sValues = $"({recordRow.SerialNumber},{recordRow.CustomerID},{recordRow.HeadType},{recordRow.Volume},'{recordRow.ExpDate}','{recordRow.Description}');";
                    }

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
                }

                trans.Commit();

                //success
                IsBusy = false;
                watch.Stop();
                sMessage = watch.ElapsedMilliseconds.ToString();
                Debug.WriteLine($"AddRecord.Insert:{watch.ElapsedMilliseconds}ms");
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                trans?.Rollback();
                sMessage = ex.Message;
            }


            watch.Stop();
            Debug.WriteLine($"AddRecord.Fail:{watch.ElapsedMilliseconds}ms");
            IsBusy = false;
            return false;
        }

    }
}
