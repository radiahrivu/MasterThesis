using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;

namespace Assets.Scripts
{
    public class DatabaseController
    {
        public static void DatabaseSetup(string connString)
        {
            try
            {
                using (IDbConnection dbConnection = new SqliteConnection(connString))
                {
                    dbConnection.Open();

                    using (IDbCommand cmd = dbConnection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT * FROM User";

                        using (IDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Debug.Log("First Name: " + reader.GetString(1));
                                Debug.Log("Last Name: " + reader.GetString(2));
                            }
                            dbConnection.Close();
                            reader.Close();
                        }
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
