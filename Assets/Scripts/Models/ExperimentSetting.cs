﻿using Mono.Data.Sqlite;
using System;
using System.Data;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public class ExperimentSetting
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        // 0=VR, 1=RW
        public int Environment { get; set; }
        // 0=Sad, 1=Anger, 2=Happy, 3=Exciting
        public int Emotion { get; set; }
        // 24 combinations, from 0 to 23
        public int Sequence { get; set; }

        // 1 means clip 1, 2 means clip 2
        public int VideoClip { get; set; }
        public int AudioClip { get; set; }
        public int ImageClip { get; set; }

        public ExperimentSetting GetExperimentSettingByUserId(string connString, int userId)
        {
            try
            {
                using (IDbConnection dbConnection = new SqliteConnection(connString))
                {
                    dbConnection.Open();

                    using (IDbCommand cmd = dbConnection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT id, emotion, sequence, videoClip, audioClip, imageClip FROM ExperimentSetting where userId=" + userId + " and environment = 0";

                        using (IDataReader reader = cmd.ExecuteReader())
                        {
                            var setting = new ExperimentSetting();
                            while (reader.Read())
                            {
                                setting.ID = reader.GetInt32(0);
                                setting.Environment = 0;
                                setting.Emotion = reader.GetInt32(1);
                                setting.Sequence = reader.GetInt32(2);
                                setting.VideoClip = reader.GetInt32(3);
                                setting.AudioClip = reader.GetInt32(4);
                                setting.ImageClip = reader.GetInt32(5);
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
