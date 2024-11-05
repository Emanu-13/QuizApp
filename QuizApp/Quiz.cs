using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp
{
    internal class Quiz
    {
        private Question[] _questions;
        private int _score;

        public Quiz(Question[] questions)
        {
            this._questions = questions;
            _score = 0;
            
        }

        public void StartQuiz()
        {
            Console.WriteLine("Welome to the quiz!");
            int questionNumber = 1;
            foreach (Question question in _questions)
            {
                Console.WriteLine($"Question {questionNumber++}");
                DisplayQuestion(question);
                int userChoice = GetUserChoice();
                if (question.ValidateAnswer(userChoice))
                {
                    Console.WriteLine("Correct!!");
                    _score++;
                }
                else
                {
                    Console.WriteLine($"Incorrect!! The correct answer was: {question.Answers[question.CorrectIndex]}");
                }

            }
            DisplayResults();
        }

        private void DisplayResults()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("╔═════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                 Results                                 ║");
            Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine($"Quiz finished. Your score is {_score} out of {_questions.Length}");
            Console.WriteLine();
            double perentage = _score / _questions.Length;
            if (perentage >= 0.8) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You've nailed it");
            }else if (perentage >= 0.5)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Good Effort!");

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Keep practicing!");
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        private void DisplayQuestion(Question question)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔═════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                 Question                                ║");
            Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();

            Console.WriteLine(question.QuestionText);
            Console.WriteLine();

            for (int i =0; i< question.Answers.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(" ");
                Console.Write(i+1);
                Console.Write(" ) ");
                Console.ResetColor();
                Console.WriteLine($"{question.Answers[i]}");
            }
            Console.WriteLine();
        }

        private int GetUserChoice()
        {
            Console.WriteLine("Your answer (number):");
            string input = Console.ReadLine();
            int choice = 0;
            while (!int.TryParse(input,out choice) || choice < 1 || choice > 4) {
                Console.WriteLine("Invalid Choice. Please enter a number between 1 and 4:");
                input = Console.ReadLine();
            }
            return choice - 1;
        }
    }
}
