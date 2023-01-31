using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam_system
{
    internal abstract class Exam
    {

        public DateTime Date { get; }
        public int No_Of_Questions { get; set; }
        public Subject Exam_Subject { get; set; }

        public int Grade { get; set; }

        public Question[] questions;

        public string Time { get; set; }

        public Answers Exam_answers { get; set; }

        public Exam(DateTime _d, string _t , int _no, Subject _sub)
        {
            Date = _d;
            No_Of_Questions = _no;
            Exam_Subject = _sub;
            questions = _sub.Subject_Questions;
            Time = _t;
        }

        public void AnswerExam(string[] ans)
        {
            Exam_answers = new Answers(ans);
            for (int i = 0; i < ans.Length; i++)
            {
                questions[i].GetAnswer(ans[i]);
            }
        }

        public void Correct_Exam()
        {
            for (int i = 0; i < questions.Length; i++)
            {
                if (questions[i].Answer == questions[i].Model_Answer)
                {
                    Grade += questions[i].Marks;
                }
            }
        }

        public abstract string Show_Exam();
    }
}
