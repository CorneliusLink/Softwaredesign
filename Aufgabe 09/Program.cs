using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;



namespace Aufgabe_09
{
    class Program
    {
        static int score;
        static int answeredQuestions;
        static bool isRunning;
        static Random randomValue = new Random();
        static List<QuizElement> questionList = new List<QuizElement>();

        static void Main(string[] args)
        {
            //LoadJson();
            ShowMainMenu();
        }

        static void ShowMainMenu()
        {
            isRunning = true;

            do
            {
                Console.WriteLine("Punkte: " + score + " | Beantwortete Fragen: " + answeredQuestions);
                Console.WriteLine("\nWas möchtest Du tun? (Gib' eine Zahl ein)\n\n1. Spielen\n2. Quizelement erstellen\n3. Programm beenden\n");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        ImportJson();
                        PlayQuiz();
                        break;
                    case "2":
                        Console.Clear();
                        WriteQuizelementsInJSON();
                        break;
                    case "3":
                    default:
                        Console.Clear();
                        Console.WriteLine("Das Programm wird beendet!");
                        break;
                }
            } while (isRunning);
        }

        public static JArray ImportJson()
        {
            using (StreamReader reader = new StreamReader("Quizelements.json"))
            {
                var json = reader.ReadToEnd();
                JArray deserializedObject = (JArray)JsonConvert.DeserializeObject(json);
                PreloadQuestions(deserializedObject);
                return deserializedObject;
            }
        }

        public static void PreloadQuestions(JArray deserializedObject)
        {
            for (int i = 0; i < deserializedObject.Count; i ++)
            {
                dynamic item = deserializedObject[i];
                String type = item.type;

                switch (type)
                {
                    case "Single":
                        QuizSingle quizSingle = item.ToObject<QuizSingle>();
                        questionList.Add(quizSingle);
                        break;
                    case "Multiple":
                        QuizMultiple quizMultiple = item.ToObject<QuizMultiple>();
                        questionList.Add(quizMultiple);
                        break;
                    case "Guess":
                        QuizGuess quizGuess = item.ToObject<QuizGuess>();
                        questionList.Add(quizGuess);
                        break;
                    case "Binary":
                        QuizBinary quizBinary = item.ToObject<QuizBinary>();
                        questionList.Add(quizBinary);
                        break;
                    case "Free":
                        QuizFree quizFree = item.ToObject<QuizFree>();
                        questionList.Add(quizFree);
                        break;
                    default:
                        break;
                }
            }
        }

        public static void PlayQuiz()
        {
            QuizElement currentQuiz = questionList[randomValue.Next(questionList.Count)];
            currentQuiz.Show();
            string choice = Console.ReadLine();

            if (currentQuiz.IsChoiceCorrect(choice))
            {
                Console.WriteLine("Richtig!\n");
                score += 10;
                answeredQuestions++;
            }
            else
            {
                Console.WriteLine("Leider Falsch!!\n");
            }
        }

        public static JObject AddNewQuizElement() {
            Console.WriteLine("Was für eine Frage möchtest Du hinzufügen? (Gib' eine Zahl ein)\n\n1. Normales Quiz\n2. Ja/Nein Quiz\n3. Freitextantworten\n4. Werte erraten\n5. Multiple Choice");
            string questionType = Console.ReadLine();
            Console.WriteLine("Wie lautet die Frage?");
            string question = Console.ReadLine();

            switch(questionType)
            {
                case "1":
                    var single = CreateSingleQuiz(question);
                    JObject jSingle = JObject.FromObject(single);
                    return jSingle;
                case "2":
                    var multiple = CreateBinaryQuiz(question);
                    JObject jMultiple = JObject.FromObject(multiple);
                    return jMultiple;
                case "3":
                    var binary = CreateFreeQuiz(question);
                    JObject jBinary = JObject.FromObject(binary);
                    return jBinary;
                case "4":
                    var guess = CreateGuessQuiz(question);
                    JObject jGuess = JObject.FromObject(guess);
                    return jGuess;
                case "5":
                    var free = CreateMultipleQuiz(question);
                    JObject jFree = JObject.FromObject(free);
                    return jFree;
                default:
                    break;
            }
            return null;
        }

        public static QuizElement CreateSingleQuiz(string question)
        {
            Console.WriteLine("Wie viele Antwortmöglichkeiten hat Dein Standard Quiz?");
            int numberOfAnswers = Int32.Parse(Console.ReadLine());
            Answer[] arrayOfAnswers = new Answer[numberOfAnswers];
            Console.WriteLine("Tippe nun die korrekte Antwort ein:");
            arrayOfAnswers[0] = new Answer(Console.ReadLine(), true);

            for (int i = 1; i < numberOfAnswers; i++)
            {
                Console.WriteLine("Tippe eine falsche Antwort ein:");
                arrayOfAnswers[i] = new Answer(Console.ReadLine(), false);
            }
            return new QuizSingle(question, arrayOfAnswers);
        }

        public static QuizElement CreateBinaryQuiz(string question)
        {
            Console.WriteLine("Wie soll die Frage beantwortet werden? Mit Ja ('j') oder Nein ('n')?");
            bool theAnswer = false;

            if (Console.ReadLine() == "j")
            {
                theAnswer = true;
            }
            return new QuizBinary(question, theAnswer);
        }

        public static QuizElement CreateFreeQuiz(string newQuestion)
        {
            Console.WriteLine("Wie lautet die richtige Antwort?");
            string correctAnswer = Console.ReadLine();
            return new QuizFree(newQuestion, correctAnswer);
        }

        public static QuizElement CreateGuessQuiz(string question)
        {
            Console.WriteLine("Wie lautet das Ergebnis (bitte nur Zahlen eingeben)?");
            return new QuizGuess(question, Int32.Parse(Console.ReadLine()));
        }

        public static QuizElement CreateMultipleQuiz(string question)
        {
            Console.WriteLine("Wie viele Antwortmöglichkeiten hat Dein Multiple Choice Quiz?");
            int answerCount = Int32.Parse(Console.ReadLine());
            Answer[] answerArray = new Answer[answerCount];

            for (int i = 0; i < answerCount; i++)
            {
                Console.WriteLine("Tippe eine Antwort ein:");
                string answer = Console.ReadLine();
                Console.WriteLine("Ist diese Antwort korrekt? (j/n)");
                bool isTrue = Console.ReadLine() == "j";
                answerArray[i] = new Answer(answer, isTrue);
            }
            return new QuizMultiple(question, answerArray);
        }

        public static void WriteQuizelementsInJSON()
        {
            JObject newQuizElement = AddNewQuizElement();

            using (FileStream fs = new FileStream("Quizelements.json", FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    JArray array = ImportJson();
                    array.Add(newQuizElement);
                    string json = JsonConvert.SerializeObject(array, Formatting.Indented);
                    File.WriteAllText("Quizelements.json", json);
                }
            }
        }
    }
}