using System;
using System.Collections.Generic;

namespace Abschlussaufgabe
{
    [Serializable]
    public class Course
    {
        public String name;
        public List<String> course;
        public List<Equipment> neededEquipment;
    }
}