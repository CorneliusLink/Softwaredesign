using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace Abschlussaufgabe
{
    class Program
    {
        static void Main(string[] args)
        {
            //Collect Data
            List<Dozent> dozentiList = new List<Dozent>();
            List<Room> roomList = new List<Room>();
            List<Room> currentRooms = new List<Room>();
            List<Students> studentList = new List<Students>();
            Dictionary<String, int> studentDictionary = new Dictionary<String, int>();

            CollectProfData(dozentiList);
            CollectRoomData(roomList, currentRooms);
            CollectStudentData(studentList);

            Schedule table1 = new Schedule();
            table1.CreateSchedule(dozentiList, roomList, studentDictionary);

            string mainMenuUserInput;

            Console.Clear();
            Console.WriteLine("Bitte wähle den Stundenplan aus, den Du anzeigen möchtest:\n\n1.) Für einen bestimmten Studiengang/ein bestimmtes Semester\n2.) Für einen bestimmten Dozenten\n3.) Gesamter Plan");
            mainMenuUserInput = Console.ReadLine();
            Console.Clear();

            switch(mainMenuUserInput)
            {
                case "1":
                    Console.WriteLine("Gib' die Studiengangs ID ein: (MIB1, MKB2, OMB4 usw.):");
                    string courseIdUserChoice = Console.ReadLine();
                    table1.PrintCourseSchedule(courseIdUserChoice);
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Gib' den Nachnamen des gewünschten Dozenten ein:");
                    string dozentUserChoice = Console.ReadLine();
                    table1.PrintDozentSchedule(dozentUserChoice);
                    break;
                case "3":
                    table1.PrintSchedule();
                    break;
                default:
                    Console.WriteLine("Falsche Eingabe! Bitte nur eine Zahl zwischen 1 und 3 eingeben.");
                    break;
            }
        }

        public static List<Dozent> CollectProfData(List<Dozent> dozentiList)
        {
            XmlSerializer ser = new XmlSerializer(typeof(Dozent));
            String path = Directory.GetCurrentDirectory() + "/data/dozenti";

            foreach(var prof in Directory.GetFiles(path))
            {
                StreamReader reader = new StreamReader(prof);
                dozentiList.Add((Dozent)ser.Deserialize(reader));
                reader.Close();
            }

            return dozentiList;
        }

        public static List<Room> CollectRoomData(List<Room> roomList, List<Room> currentRooms)
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Room>));
            String path = Directory.GetCurrentDirectory() + "/data/rooms";

            foreach(var room in Directory.GetFiles(path))
            {
                StreamReader reader = new StreamReader(room);
                currentRooms = (List<Room>)ser.Deserialize(reader);
                reader.Close();
                roomList.AddRange(currentRooms);
            }

            return roomList;
        }

        public static Dictionary<string, int> CollectStudentData(List<Students> studentList)
        {
            XmlSerializer ser = new XmlSerializer(typeof(Students));
            String path = Directory.GetCurrentDirectory() + "/data/courses";

            foreach(var dir in Directory.GetDirectories(path))
            {
                foreach(var cohort in Directory.GetFiles(dir))
                {
                    StreamReader reader = new StreamReader(cohort);
                    studentList.Add((Students)ser.Deserialize(reader));
                    reader.Close();
                }
            }

            Dictionary<String, int> cohortDict = new Dictionary<string, int>();

            foreach(Students cohort in studentList)
            {
                cohortDict.Add(cohort.name, cohort.numberOfStundents);
            }

            return cohortDict;
        }

    }
}
