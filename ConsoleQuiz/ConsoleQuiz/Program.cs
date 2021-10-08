using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows;


namespace ConsoleQuiz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine((double)2 / 3);
            startTest();
            
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
            while (num < sizeOfQuestions)
            {
                Console.WriteLine(questions[num]);
                Console.WriteLine(choices[num]);
                //Console.WriteLine(answers[num]);
                string userAnswer = Console.ReadLine();
                if (userAnswer == answers[num])
                {
                    Console.WriteLine("Correct");
                    correct++;
                }
                else
                {
                    Console.WriteLine("Wrong");
                    wrong++;
                }
                num++;
            }

            Console.WriteLine("Your score was: "+ (double)correct/num*100);
            Console.WriteLine("You got {0} answers correct and {1} answers wrong", correct, wrong);

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
                        if(line.StartsWith("QUESTIONS:"))
                        {
                            string question = line;
                            questions.Add(question);
                        }
                        if(line.Contains(')'))
                        {
                            string choice = line;
                            choices.Add(choice);
                        }
                        if(line.StartsWith("ANSWERS:"))
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
