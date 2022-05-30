using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialTask
{
    public class Baggage
    {
        public long ownerId;
        public double weight;
        public string color;
        public string[] inside;

        public Baggage(long ownerId, double weight, string color, string insides)
        {
            this.ownerId = ownerId;
            this.weight = weight;
            this.color = color;
            if (insides.Contains(","))
            {
                inside = insides.Split(',');
            }
            else if (insides.Length == 0)
            {
                inside = new string[0];
            }
            else
            {
                inside = new string[1] { insides };
            }
        }

        public override string ToString()
        {
            return $"Владеллец: [ID: {ownerId}] |Вес: {weight} кг|Цвет: {color}|Внутри: {string.Join(",",inside)}";
        }
    }
}
