using System;
using System.Collections.Generic;

namespace Abschlussaufgabe
{
    public class Block
    {
        public List<Tuple<Students, Dozent, Room>> occupiedRooms {get; set;}

        public Block()
        {
            occupiedRooms = new List<Tuple<Students, Dozent, Room>>();
        }
    }
}