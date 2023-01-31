using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System_Lists
{
    internal class PracticeExam :Exam
    {
        public PracticeExam(DateTime _d, string _t, int _no, Subject _sub) : base(_d, _t, _no, _sub)
        {

        }

        public override string Show_Exam()
        {
            String str = $"Duration: {Time}, Date: {Date}\n" +
                $"Subject {Exam_Subject.Name}\n\n";

            for (int i = 0; i < questions.Count; i++)
            {
                str += questions[i].ToString() + "\n";
            }
            return str;
        }

        public void Show_Result()
        {
            int fullMark = 0;
            for (int i = 0; i < questions.Count; i++)
            {
                Console.WriteLine($"{questions[i].ToString()} \n " +
                    $"The Modal Answer is {questions[i].Q_answers.model_answer} \n");
                fullMark += questions[i].Marks;
            }
            Console.WriteLine($"Your Grade: {Grade} /{fullMark}\n");
        }

        public override string ToString()
        {
            return Show_Exam();
        }
    }
}
