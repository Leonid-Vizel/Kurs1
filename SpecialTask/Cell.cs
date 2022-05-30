using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialTask
{
    public class Cell
    {
        public long ID;
        public double weightLimit;
        private Baggage baggage = null;

        public Cell(long ID, double weightLimit)
        {
            this.ID = ID;
            this.weightLimit = weightLimit;
        }

        public Baggage Exctract()
        {
            Baggage b = baggage;
            baggage = null;
            return b;
        }

        public long BaggageOwnerID
        {
            get
            {
                if (baggage == null)
                {
                    return -1;
                }
                else
                {
                    return baggage.ownerId;
                }
            }
        }

        public void Put(Baggage baggage) => this.baggage = baggage;

        public bool IsEmpty() => baggage == null;
    }
}
