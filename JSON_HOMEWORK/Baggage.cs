using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_HOMEWORK
{
    public class Baggage
    {
        public long Id { get; set; }
        public long OwnerId { get; set; }
        public double Weight { get; set; }
        public string Color { get; set; }
        public string[] Inside { get; set; }
    }
}
