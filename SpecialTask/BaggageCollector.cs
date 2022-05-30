using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace SpecialTask
{
    public class BaggageCollector
    {
        public Cell[] cells = null;
        public BaggageCollector(int max, double maxWeight)
        {
            cells = new Cell[max];
            for (int i = 0; i < max; i++)
            {
                cells[i] = new Cell(i, maxWeight);
            }
        }

        public BaggageCollector(int max, double maxWeight, string loadPath)
        {
            cells = new Cell[max];
            for (int i = 0; i < max; i++)
            {
                cells[i] = new Cell(i, maxWeight);
            }
            LoadBaggageFromSQLite(loadPath);
        }

        public void FindAndPut(Baggage bag)
        {
            for (int i = 0; i < cells.Length; i++)
            {
                if (cells[i].IsEmpty())
                {
                    cells[i].Put(bag);
                    using (var connection = new SQLiteConnection($"DataSource='SpecialTask.db';Version=3;"))
                    {
                        connection.Open();
                        SQLiteCommand sqCom = connection.CreateCommand();
                        sqCom.CommandText = $"UPDATE Baggage SET Cell = {i} WHERE OwnerID = {bag.ownerId}";
                        sqCom.ExecuteNonQuery();
                        connection.Close();
                    }
                    return;
                }
            }    
        }

        public void LoadBaggageFromSQLite(string path)
        {
            using (var connection = new SQLiteConnection($"DataSource='{path}';Version=3;"))
            {
                connection.Open();
                SQLiteCommand sqCom = connection.CreateCommand();
                sqCom.CommandText = "SELECT * FROM Baggage Where Cell > -1;";
                SQLiteDataReader reader = sqCom.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cells[reader.GetInt32(4)].Put(new Baggage(reader.GetInt64(0), reader.GetDouble(1), reader.GetValue(2).ToString(), reader.GetValue(3).ToString()));
                    }
                }
                connection.Close();
            }
        }

        public void SetAmount(int nAmount)
        {
            if (cells.Length != nAmount)
            {
                cells = new Cell[nAmount];
                for (int i = 0; i < nAmount; i++)
                {
                    cells[i] = new Cell(i, nAmount);
                }
            }
        }

        public Baggage FindAndExtract(long ownerID)
        {
            for (int i = 0; i < cells.Length; i++)
            {
                if (!cells[i].IsEmpty() && cells[i].BaggageOwnerID == ownerID)
                {
                    return cells[i].Exctract();
                }
            }
            return null;
        }

        public double MaxWeight
        {
            get => cells[0].weightLimit;
            set
            {
                for (int i = 0; i < cells.Length; i++)
                {
                    cells[i].weightLimit = value;
                }
            }
        }

        public int Availible
        {
            get => cells.Where(x => x.IsEmpty()).Count();
        }

        public long[] OwnerIDs
        {
            get => cells.Where(x=>!x.IsEmpty()).Select(x => x.BaggageOwnerID).ToArray();
        }

        public void Defragment()
        {
            List<Cell> defragmentedCells = new List<Cell>();
            defragmentedCells.AddRange(cells.Where(x => !x.IsEmpty()));
            for (int i = 0; i < cells.Length; i++)
            {
                if (i < defragmentedCells.Count)
                {
                    defragmentedCells[i].ID = i;
                }
                else
                {
                    defragmentedCells.Add(new Cell(i, cells[0].weightLimit));
                }
            }
            cells = defragmentedCells.ToArray();
        }
    }
}
