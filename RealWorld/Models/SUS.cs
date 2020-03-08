using System;
using System.Data.SQLite;
using System.Data;
using System.Diagnostics;

namespace RealWorld.Models
{
    public class SUS
    {
        public int ID { get; set; }
        public int SettingId { get; set; }
        public int Counter { get; set; }
        public int Result { get; set; }

        public SUS(int settingId, int counter, int result)
        {
            SettingId = settingId;
            Counter = counter;
            Result = result;
        }

        public void InsertResult(string connString)
        {
            try
            {
                using (IDbConnection dbConnection = new SQLiteConnection(connString))
                {
                    dbConnection.Open();
                    using (IDbCommand cmd = dbConnection.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO SUS (\"settingId\", \"counter\", \"result\") VALUES(" + SettingId + ", " + Counter + ", " + Result + "); ";

                        cmd.ExecuteNonQuery();
                        dbConnection.Close();
                    }
                }
            }
            catch (Exception e)
            {
                Trace.TraceError(e.Message);
            }
        }
    }
}
