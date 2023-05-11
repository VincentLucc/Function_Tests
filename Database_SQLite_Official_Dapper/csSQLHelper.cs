using Dapper;
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

namespace Database_SQLite_Official_Dapper
{
    public class csSQLHelper
    {
        public static string sPath = "abc.db";

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
                    SQLiteCommand command = new SQLiteCommand(sCreateTable, con);
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
                Debug.WriteLine("csSQLHelper.CreateDataBase:\r\n" + ex.Message);
                sMessage = "Create database exception:\r\n" + ex.Message;
                return false;
            }


            //Pass all steps
            return true;

        }

        public static bool AddRecord(RecordRow record, out string sMEssage)
        {
            sMEssage = "";
            try
            {
                using (IDbConnection con = NewConnection())
                {
                    //Auto match the database column name
                    string sTableInfo = "insert into Records (SerialNumber,CustomerID) values (@SerialNumber,@CustomerID)";
                    con.Execute(sTableInfo, record);
                }
            }
            catch (Exception ex)
            {
                sMEssage = "Add record exception:" + ex.Message;
                Debug.WriteLine("csSQLHelper.AddRecord:\r\n" + ex.Message);
                return false;
            }

            //Pass all steps
            return true;
        }

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
