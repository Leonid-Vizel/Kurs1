using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork8
{
    interface IGame
    {
        string name { get; }

        int Play(Member mem);
    }
}
