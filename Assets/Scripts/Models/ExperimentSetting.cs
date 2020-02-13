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
    public class ExperimentSetting
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public int Environment { get; set; }
        public int Emotion { get; set; }
        public int Sequence { get; set; }

        public ExperimentSetting GetExperimentSettingByUserId(string connString, int userId)
        {
            try
            {
                using (IDbConnection dbConnection = new SqliteConnection(connString))
                {
                    dbConnection.Open();

                    using (IDbCommand cmd = dbConnection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT id, environment, emotion, sequence FROM ExperimentSetting where userId=" + userId;

                        using (IDataReader reader = cmd.ExecuteReader())
                        {
                            var setting = new ExperimentSetting();
                            while (reader.Read())
                            {
                                setting.ID = reader.GetInt32(0);
                                setting.Environment = reader.GetInt32(1);
                                setting.Emotion = reader.GetInt32(2);
                                setting.Sequence = reader.GetInt32(3);
                            }
                            dbConnection.Close();
                            reader.Close();
                            return setting;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log(e);
                return null;
            }
        }
    }
}
