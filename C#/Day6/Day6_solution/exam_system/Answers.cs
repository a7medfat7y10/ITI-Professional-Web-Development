using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam_system
{
    internal class Answers
    {
        public Answers(string[] ans) {
            Exam_answers= ans;
        }
        public string[] Exam_answers { get; set; }

        public override string ToString()
        {
            string str = "";
            for(int i = 0; i < Exam_answers.Length; i++)
            {
                str += $"{Exam_answers[i]},";
            }
            return str;
        }
    }
}
