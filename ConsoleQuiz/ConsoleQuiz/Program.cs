using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Text.RegularExpressions;

namespace ConsoleQuiz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string data = @"C:\Users\seanv\Desktop\ConsoleQuiz\test.txt";
            List<string> questions = new List<string>();
            List<string> choices = new List<string>();
            List<string> answers = new List<string>();
            startTest();
            //LoadData(data, questions, choices, answers);
            //Console.WriteLine(choices[2]);
            // List<string> x = new List<string>();
            //Console.WriteLine(choices[0]);


            // string[] words = item.Split(new string[] { "a) ", "b) ", "c) ", "d) ", " ", "\n"}, StringSplitOptions.None);
            // foreach (var i in words)
            // {
            //Console.WriteLine(x);
            // }
        }

        public static void startTest()
        {
            string data = @"C:\Users\seanv\Desktop\ConsoleQuiz\Csharp.txt";
            List<string> questions = new List<string>();
            List<string> choices = new List<string>();
            List<string> answers = new List<string>();

            LoadData(data, questions, choices, answers);
            int num = 0;
            int correct = 0;
            int wrong = 0;
            int sizeOfQuestions = questions.Count;
            Console.WriteLine("Welcome to your C# quiz.\n\nEnter Q at anythime during this quiz to quit.\n\n");
            while (num < sizeOfQuestions)
            {
                Console.WriteLine(questions[num]);
                Console.WriteLine(choices[num]);
                //Console.WriteLine(answers[num]);
                string userAnswer = Console.ReadLine();
                if(userAnswer.ToUpper() == "Q")
                {
                    break;
                }
                else if (userAnswer == answers[num])
                {
                    Console.WriteLine("\nCorrect");
                    correct++;
                    Console.WriteLine(correct + "/" + (num + 1)+'\n');
                }
                else
                {
                    Console.WriteLine("\nWrong.");
                    Console.WriteLine("The correct answer is: " + answers[num]);
                    wrong++;
                    Console.WriteLine(correct + "/" + (num + 1)+'\n');
                }
                num++;
            }

            Console.WriteLine("\nYour score was: " + (double)correct / num * 100);
            Console.WriteLine("\nYou got {0} answers correct and {1} answers wrong", correct, wrong);

        }
        public static void LoadData(string filename, List<string> questions, List<string> choices, List<string> answers)
        {
            try
            {
                using (StreamReader file = new StreamReader(filename))
                {
                    string[] lines = file.ReadToEnd()
                        .Trim().Split(new[] { Environment.NewLine },
                        StringSplitOptions.RemoveEmptyEntries);
                    foreach (string _line in lines)
                    {
                        string line = _line;
                        //if (!line.Contains(','))
                        //{
                        //    Console.Error.WriteLine("!!! Line did not contain comma for separation");
                        //    Console.Error.WriteLine("!!!!!! " + line);
                        //    continue; //Just go on to the next line.
                        //}
                        if (line.StartsWith("QUESTIONS:"))
                        {
                            string question = line;
                            questions.Add(question);
                        }
                        if (line.Contains(')'))
                        {
                            string choice = line;
                            choices.Add(choice);
                        }
                        if (line.StartsWith("ANSWERS:"))
                        {
                            string answer = line;
                            answers.Add(answer.Substring(answer.IndexOf(':') + 1));
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("File could not be read");
                Console.WriteLine(ex.Message);
            }
        }
    }
}

