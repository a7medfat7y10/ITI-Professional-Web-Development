using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam_system
{
    internal class TFQuestion :Question
    {
        public TFQuestion(int _id, string _h, string _b, int _m, string _ma) : base(_id, _h, _b, _m, "TF", _ma)
        {

        }
        public override string ToString()
        {
            return $"{Header}: \n" +
                   $"{Body}: \n" +
                   $"(T / F)  " +
                   $"[Marks: {Marks}] \n" +
                   $"Your Answer: {Answer}\n";
        }
    }
}
