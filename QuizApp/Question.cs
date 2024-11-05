using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp
{
    internal class Question
    {
        public string QuestionText { get; set; }
        public string[] Answers { get; set; }
        public int CorrectIndex { get; set; }

        public Question(string questionText,string[] answers,int correctIndex)
        {
            QuestionText = questionText;
            Answers = answers;
            CorrectIndex = correctIndex;
        }

        public bool ValidateAnswer(int choice)
        {
            return CorrectIndex == choice;
        }

    }
}
