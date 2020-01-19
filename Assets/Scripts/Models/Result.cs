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
    class Result
    {
        public int ResultId { get; set; }
        public string Manikin { get; set; }
        public int UserId { get; set; }
        public DateTime Timestamp { get; set; }
        public int Counter { get; set; }

        public static void InsertResult(string connString, string manikin, int userId, int counter)
        {
            try
            {
                using (IDbConnection dbConnection = new SqliteConnection(connString))
                {
                    dbConnection.Open();
                    using (IDbCommand cmd = dbConnection.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO Result VALUES (null, '" + manikin + "', " + userId + ", CURRENT_TIMESTAMP, " + counter + ")";
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
