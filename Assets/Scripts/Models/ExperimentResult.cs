using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;

namespace Assets.Scripts.Models
{
    class ExperimentResult
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public int SettingId { get; set; }
        public int Method { get; set; }
        public int ArousalScale { get; set; }
        public int ValenceScale { get; set; }
        public int DominanceScale { get; set; }
        public DateTime Timestamp { get; set; }
        public int Counter { get; set; }

        public ExperimentResult(int userId, int settingId, int method, int arousal, int valence, int dominance, int counter)
        {
            UserId = userId;
            SettingId = settingId;
            Method = method;
            ArousalScale = arousal;
            ValenceScale = valence;
            DominanceScale = dominance;
            Counter = counter;
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
                        //cmd.CommandText = "INSERT INTO Result VALUES (null, '" + manikin + "', " + userId + ", CURRENT_TIMESTAMP, " + counter + ")";

                        cmd.CommandText = "INSERT INTO ExperimentResult (\"userId\", \"settingId\", \"method\", \"arousalScale\", \"valenceScale\", \"dominanceScale\", \"timestamp\", \"counter\") VALUES(" + UserId + ", " + SettingId + ", " + Method + ", " + ArousalScale + ", " + ValenceScale + ", " + DominanceScale + ", 'CURRENT_TIMESTAMP', " + Counter + "); ";

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
