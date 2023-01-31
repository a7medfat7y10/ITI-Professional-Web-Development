using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System_Lists
{
    internal class TFQuestion :Question
    {
        public TFQuestion(int _id, string sub, string _h, string _b, int _m, string _ma) : base(_id,sub ,_h, _b, _m, "TF", _ma)
        {

        }
        public override string ToString()
        {
            return $"{Header}: \n" +
                   $"{Body}: \n" +
                   $"T\n" +
                   $"F\n" +
                   $"[Marks: {Marks}] \n" +
                   $"Your Answer: {Q_answers.Std_answer}\n";
        }
    }
}
