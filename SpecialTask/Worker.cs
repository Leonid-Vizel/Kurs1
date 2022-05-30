using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace SpecialTask
{
    public class Worker : Person
    {
        public Profession profession;
        public Worker(long ID, string name, byte age, Sex sex, Profession prof) : base(ID,name, age, sex)
        {
            profession = prof;
        }

        public static List<Worker> ReadFromSQLite(string path)
        {
            List<Worker> wkers = new List<Worker>();
            using (var connection = new SQLiteConnection($"DataSource='{path}';Version=3;"))
            {
                connection.Open();
                SQLiteCommand sqCom = connection.CreateCommand();
                sqCom.CommandText = "SELECT * FROM Workers;";
                SQLiteDataReader reader = sqCom.ExecuteReader();
                if (reader.HasRows)
                    while (reader.Read())
                        wkers.Add(new Worker(reader.GetInt64(0), reader.GetValue(1).ToString(),reader.GetByte(2), (Sex)reader.GetInt32(3), (Profession)reader.GetInt32(4)));
                connection.Close();
            }
            return wkers;
        }

        public override string ToString()
        {
            return $"{base.ToString()}|Профессия: {profession}";
        }
    }

    public enum Profession
    {
        Security = 0,
        Cashier = 1
    }
}
