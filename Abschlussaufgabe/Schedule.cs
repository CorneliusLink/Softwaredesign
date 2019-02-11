using System;
using System.Collections.Generic;

namespace Abschlussaufgabe
{
    public class Schedule
    {
        public Schedule()
        {
            //create days and blocks
        }

        public void CreateSchedule(List<Dozent> profList, List<Room> roomList, Dictionary<string, int> studentDictionary)
        {
            //Go through each professors course
            //Find a room, that fits the requirements
            //Afterwards check if prof is free
            //Then Check if course is free during a specific block
            //if everything is okay, add the course to the schedule
        }


        public void PrintCourseSchedule(String courseName)
        {
            //Print a schedule for a specific course
            //Similar steps like above
        }

        public void PrintDozentSchedule(String dozentName)
        {
            //Print a schedule for a specific dozent (nearly the same like the course schedule)
            //Similar steps like above
        }

        public void PrintSchedule()
        {
            //Print a complete schedule
        }
    }
}