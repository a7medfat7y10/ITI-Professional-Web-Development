using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System_Lists
{
    internal class ChooseAllQuestion : Question
    {
        List<string> Choices = new List<string>();

        public ChooseAllQuestion(int _id,string sub, string _h, string _b, int _m, string _ma, List<string> _ch) : base(_id,sub ,_h, _b, _m, "Choose All", _ma)
        {
            Choices.AddRange(_ch);
            Choices.Add("All");
        }

        public override string ToString()
        {
            return $"{Header}: \n" +
                   $"{Body}:\n" +
                   $"A.{Choices[0]}\nB.{Choices[1]}\nC.{Choices[2]}\nD.{Choices[3]}\nE.{Choices[4]} \n" +
                   $" [Marks: {Marks}] \n" +
                   $"Your Answer: {Q_answers.Std_answer}\n";
        }
    }
}
