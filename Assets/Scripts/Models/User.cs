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
    class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public static List<User> GetAllUsers(string connString)
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
                            var users = new List<User>();

                            while (reader.Read())
                            {
                                var user = new User
                                {
                                    UserId = reader.GetInt32(0),
                                    FirstName = reader.GetString(1),
                                    LastName = reader.GetString(2)
                                };
                                users.Add(user);
                            }
                            dbConnection.Close();
                            reader.Close();
                            return users;
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
