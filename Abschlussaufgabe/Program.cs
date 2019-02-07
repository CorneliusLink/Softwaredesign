using System;
using System.Xml;

namespace Abschlussaufgabe
{
    class Program
    {
        static void Main(string[] args)
        {
            // XmlDocument xmlDoc = new XmlDocument();
            // xmlDoc.Load("data/lecturers.xml");
            // XmlNodeList userNodes = xmlDoc.SelectNodes("//lecturers/lecturer");
            // // foreach(XmlNode userNode in userNodes)
            // // {
            // //     int age = int.Parse(userNode.Attributes["age"].Value);
            // //     userNode.Attributes["age"].Value = (age + 1).ToString();
            // // }
            // // xmlDoc.Save("data/test.xml");

            XmlDocument xml = new XmlDocument();
            xml.Load("data/lecturers.xml");

            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateElement("users");
            xmlDoc.AppendChild(rootNode);

            XmlNodeList xnList = xml.SelectNodes("/profs/prof");
            foreach (XmlNode xn in xnList)
            {

                //Auslesen
                string name = xn.Attributes["name"].Value;;
                string lectureId = xn["lecture"].Attributes["gridId"].Value;
                string firstName = xn["lecture"].InnerText;
                string speakingId = xn["visitingTime"].Attributes["gridId"].Value;
                string lastName = xn["visitingTime"].InnerText;

                //In neue Datei schreiben
                XmlNode userNode = xmlDoc.CreateElement("user");
                XmlAttribute attribute = xmlDoc.CreateAttribute("age");
                attribute.Value = name;
                userNode.Attributes.Append(attribute);
                userNode.InnerText = firstName;
                rootNode.AppendChild(userNode);
                //Neues Dokument speichern
                xmlDoc.Save("test-doc.xml");

                Console.WriteLine(name);
                Console.WriteLine(lectureId + ". Block: " + firstName);
                Console.WriteLine(speakingId + ". Block: " + lastName);
            }

        }
    }
}
