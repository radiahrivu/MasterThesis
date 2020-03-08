using Mono.Data.Sqlite;
using System;
using System.Data;
using UnityEngine;

namespace Assets.Scripts.Models
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
                using (IDbConnection dbConnection = new SqliteConnection(connString))
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
                Debug.Log(e);
            }
        }
    }
}
