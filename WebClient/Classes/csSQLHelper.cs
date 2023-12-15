using Dapper;
using DevExpress.Data.XtraReports.DataProviders;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebClient.Classes;

namespace WebClient
{
    public class csSQLHelper
    {
        public static string sPath = "abc.db";

        public static bool Exist()
        {
            string sFullPath = Application.StartupPath + "//" + sPath;
            return File.Exists(sFullPath);
        }

        public static SQLiteConnection NewConnection()
        {
            string sConnection = $"Data Source={sPath};";
            var con = new SQLiteConnection(sConnection);
            return con;
        }

        public static bool CreateDataBase(out string sMessage)
        {
            sMessage = "";

            try
            {
                //File exist, just check if database is valid
                if (File.Exists(sPath))
                {
                    sMessage = "File already exist.";
                    return false;
                }

                //Create directory
                string sDir = Path.GetDirectoryName(sPath);
                //Make sure directory is valid
                if (!string.IsNullOrWhiteSpace(sDir) && !Directory.Exists(sDir))
                {
                    Directory.CreateDirectory(sDir);
                }

                //Create database
                SQLiteConnection.CreateFile(sPath);

                using (var con = NewConnection())
                {
                    con.Open();

                    //Create request list
                    string sCommand = @"
                    CREATE TABLE ""RequestList"" (
	                ""RecordID""	INTEGER NOT NULL,
	                ""TypeOfCodes""	TEXT,
	                ""Time""	NUMERIC,
	                ""BrandIdentifier""	TEXT,
	                ""Gtin""	TEXT NOT NULL,
	                ""Sku""	TEXT,
	                PRIMARY KEY(""RecordID"" AUTOINCREMENT)
                    )
                            ";
                    SQLiteCommand command = new SQLiteCommand(sCommand, con);
                    command.ExecuteNonQuery();

                    //Create request list table index
                    command.CommandText = @"
                    CREATE INDEX ""RequestList_GTIN"" ON ""RequestList"" (
	                ""Gtin""	ASC
                    )
                            ";
                    command.ExecuteNonQuery();


                    //Create code table
                    command.CommandText = @"
                    CREATE TABLE ""Codes"" (
	                ""RecordID""	INTEGER NOT NULL,
	                ""Code""	INTEGER NOT NULL,
	                ""Used""	NUMERIC NOT NULL
                    );
                            ";
                    command.ExecuteNonQuery();

                    //Create code table index
                    command.CommandText = @"
                    CREATE INDEX ""Codes_RecordID"" ON ""Codes"" (
	                ""RecordID""	ASC
                    )
                            ";
                    command.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("csSQLHelper.CreateDataBase:\r\n" + ex.Message);
                sMessage = "Create database exception:\r\n" + ex.Message;
                return false;
            }


            //Pass all steps
            return true;

        }

        public static bool CheckGTINStorage(csGTINConfig gtinConfig, out string sMessage)
        {
            sMessage = "";
            try
            {
                using (IDbConnection con = NewConnection())
                {
                    con.Open();



                    //Get the ID
                    string sQuery = $"select Code FROM Codes WHERE RecordID in (select RecordID from RequestList where Gtin='{gtinConfig.GTIN}') and Used=0";
                    var recordIds = con.Query<string>(sQuery);

                    //If whether ID is valid
                    gtinConfig.CurrentStorage = recordIds.Count();

                }
            }
            catch (Exception ex)
            {
                sMessage = "Check storage exception:" + ex.Message;
                Debug.WriteLine("cssqlhelper.CheckGTINStorage:\r\n" + ex.Message);
                return false;
            }

            //pass all steps
            return true;
        }

        public static bool AddRecords(csCodeInfo codeInfo, out string sMessage)
        {
            sMessage = "";
            try
            {
                using (IDbConnection con = NewConnection())
                {
                    con.Open();

                    using (var tran = con.BeginTransaction())
                    {
                        //Insert to record list
                        string sInsert = $"insert into RequestList(TypeOfCodes,Time,BrandIdentifier,Gtin,Sku) Values(" +
                            $"@{nameof(csCodeInfo.typeOfCodes)}," +
                            $"@{nameof(csCodeInfo.time)}," +
                            $"@{nameof(csCodeInfo.brandIdentifier)}," +
                            $"@{nameof(csCodeInfo.gtin)}," +
                            $"@{nameof(csCodeInfo.sku)})";
                        con.Execute(sInsert, codeInfo);

                        //Get the ID
                        string sCmdMax = "select max(RecordID) FROM RequestList";
                        int? iValue = con.QuerySingle<int?>(sCmdMax);

                        //If whether ID is valid
                        if (iValue == null || iValue < 1)
                        {
                            tran.Rollback();
                            sMessage = "Invalid [RecordID].";
                            return false;
                        }

                        //Insert to record
                        var stringList = csStringValue.FromListString(codeInfo.Codes);
                        sInsert = $"insert into Codes(RecordID,Code,Used) Values(" +
                            $"{iValue}," +
                            $"@{nameof(csStringValue.Value)}," +
                            $"{false}" +
                            ");";
                        con.Execute(sInsert, stringList);
                        tran.Commit();
                    }

                }


            }
            catch (Exception ex)
            {
                sMessage = "add record exception:" + ex.Message;
                Debug.WriteLine("cssqlhelper.addrecord:\r\n" + ex.Message);
                return false;
            }

            //pass all steps
            return true;
        }


        //public static bool AddRecord(RecordRow record, out string sMEssage)
        //{
        //    sMEssage = "";
        //    try
        //    {
        //        using (IDbConnection con = NewConnection())
        //        {
        //            //Auto match the database column name
        //            string sTableInfo = "insert into Records (SerialNumber,CustomerID) values (@SerialNumber,@CustomerID)";
        //            con.Execute(sTableInfo, record);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        sMEssage = "Add record exception:" + ex.Message;
        //        Debug.WriteLine("csSQLHelper.AddRecord:\r\n" + ex.Message);
        //        return false;
        //    }

        //    //Pass all steps
        //    return true;
        //}

        public static bool GetMaxRecord(out int? iValue, out string sMEssage)
        {
            sMEssage = "";
            iValue = -1;
            try
            {
                using (IDbConnection con = NewConnection())
                {
                    //Auto match the database column name
                    string sMax = "select max(SerialNumber) FROM Records";
                    iValue = con.QuerySingle<int?>(sMax);
                }
            }
            catch (Exception ex)
            {
                sMEssage = "Query max record exception:" + ex.Message;
                Debug.WriteLine("csSQLHelper.GetMaxRecord:\r\n" + ex.Message);
                return false;
            }

            //Pass all steps
            return true;
        }
    }
}
