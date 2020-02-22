﻿//using Mono.Data.Sqlite;
using System.Data.SQLite;
using System;
using System.Data;
using System.Diagnostics;

namespace RealWorld.Models
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

        // 0 means no clip (step AbR), 1 means clip 1, 2 means clip 2
        public int Clip { get; set; }

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
                using (IDbConnection dbConnection = new SQLiteConnection(connString))
                {
                    dbConnection.Open();
                    using (IDbCommand cmd = dbConnection.CreateCommand())
                    {
                        //cmd.CommandText = "INSERT INTO Result VALUES (null, '" + manikin + "', " + userId + ", CURRENT_TIMESTAMP, " + counter + ")";

                        cmd.CommandText = "INSERT INTO ExperimentResult (\"userId\", \"settingId\", \"method\", \"arousalScale\", \"valenceScale\", \"dominanceScale\", \"counter\", \"clip\") VALUES(" + UserId + ", " + SettingId + ", " + Method + ", " + ArousalScale + ", " + ValenceScale + ", " + DominanceScale + ", " + Counter + ", " + Clip + "); ";

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
