using System;
using System.Collections.Generic;

namespace Abschlussaufgabe
{
    [Serializable]
    public class Room
    {
        public String name;
        public int size;
        public List<Equipment> equipment;
    }
}