using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System_Lists
{
    internal abstract class Exam
    {

        public DateTime Date { get; }
        public int No_Of_Questions { get; set; }
        public Subject Exam_Subject { get; set; }

        public int Grade { get; set; }

        public List<Question> questions;
        public AnswerList Exam_Answers { get; set; }

        public string Time { get; set; }

        public Answers Exam_answers { get; set; }
        //public List<string> Exam_answers { get; set; }

        public Exam(DateTime _d, string _t , int _no, Subject _sub)
        {
            Date = _d;
            No_Of_Questions = _no;
            Exam_Subject = _sub;
            questions = _sub.Subject_Questions;
            Time = _t;
        }

        public void AnswerExam(List<string> ans)
        {
            for (int i = 0; i < ans.Count ;i++)
            {
                questions[i].GetAnswer(ans[i]);
            }
        }

        public void Correct_Exam()
        {
            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].Q_answers.Std_answer == questions[i].Q_answers.model_answer)
                {
                    Grade += questions[i].Marks;
                }
            }
        }

        public abstract string Show_Exam();
    }
}
