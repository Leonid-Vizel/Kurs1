using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialTask
{
    public class Visitor : Person
    {
        private int _cash = 0;
        public int Cash
        {
            get => _cash;
            set
            {
                _cash = value;
                using (var connection = new SQLiteConnection($"DataSource='SpecialTask.db';Version=3;"))
                {
                    connection.Open();
                    SQLiteCommand sqCom = connection.CreateCommand();
                    sqCom.CommandText = $"UPDATE Visitors SET Cash = {_cash} WHERE ID = {ID}";
                    sqCom.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
        public Baggage baggage;
        public Aim aim;
        public int days;
        public Visitor(long ID, string name, byte age, Sex sex, int cash, int days, Baggage baggage, Aim aim) : base(ID, name, age, sex)
        {
            this.baggage = baggage;
            _cash = cash;
            this.aim = aim;
            this.days = days;
        }

        public static List<Visitor> LoadFromSQLite(string path)
        {
            List<Visitor> vtors = new List<Visitor>();
            using (var connection = new SQLiteConnection($"DataSource='{path}';Version=3;"))
            {
                connection.Open();
                SQLiteCommand sqCom = connection.CreateCommand();
                sqCom.CommandText = "SELECT * FROM Visitors;";
                SQLiteDataReader reader = sqCom.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        vtors.Add(new Visitor(reader.GetInt64(0), reader.GetValue(1).ToString(), reader.GetByte(2), (Sex)reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), null, (Aim)reader.GetInt32(6)));
                    }
                }
                reader.Close();
                sqCom.CommandText = "SELECT * FROM Baggage Where Cell = -1;";
                reader = sqCom.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        long OwnerID = reader.GetInt64(0);
                        if (vtors.Where(x=>x.ID == OwnerID).Count() > 0)
                        {
                            vtors.Where(x => x.ID == OwnerID).First().baggage = new Baggage(OwnerID, reader.GetDouble(1), reader.GetValue(2).ToString(), reader.GetValue(3).ToString());
                        }
                    }
                }
                connection.Close();
            }
            return vtors;
        }

        public Baggage GiveBaggage()
        {
            aim = Aim.Take;
            Baggage b = baggage;
            baggage = null;
            using (var connection = new SQLiteConnection($"DataSource='SpecialTask.db';Version=3;"))
            {
                connection.Open();
                SQLiteCommand sqCom = connection.CreateCommand();
                sqCom.CommandText = $"UPDATE Visitors SET Aim = 1 WHERE ID = {ID}";
                sqCom.ExecuteNonQuery();
                connection.Close();
            }
            return b;
        }

        public void TakeBaggage(Baggage baggage)
        {
            using (var connection = new SQLiteConnection($"DataSource='SpecialTask.db';Version=3;"))
            {
                connection.Open();
                SQLiteCommand sqCom = connection.CreateCommand();
                sqCom.CommandText = $"UPDATE Baggage SET Cell = -1 WHERE OwnerID = {baggage.ownerId}";
                sqCom.ExecuteNonQuery();
                connection.Close();
            }
            this.baggage = baggage;
        }

        public override string ToString()
        {
            if (baggage != null)
            {
                return $"{base.ToString()}|Намеревается: {aim.ToString().Replace("Take", "Получить багаж").Replace("Give", "Сдать багаж")} на {days} дней|Денег при себе: {Cash} RUB\nБагаж: {baggage}";
            }
            else
            {
                return $"{base.ToString()}|Намеревается: {aim.ToString().Replace("Take", "Получить багаж").Replace("Give", "Сдать багаж")}|Денег при себе: {Cash} RUB";
            }
        }
    }

    public enum Aim
    {
        Give = 0,
        Take = 1
    }
}
