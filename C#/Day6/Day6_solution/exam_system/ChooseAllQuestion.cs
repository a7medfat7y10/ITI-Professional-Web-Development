using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam_system
{
    internal class ChooseAllQuestion : Question
    {
        string[] Choices = new string[5];

        public ChooseAllQuestion(int _id, string _h, string _b, int _m, string _ma, string[] _ch) : base(_id, _h, _b, _m, "Choose All", _ma)
        {
            for (int i = 0; i < _ch.Length; i++)
            {
                Choices[i] = _ch[i];
            }
            Choices[4] = "All";
        }

        public override string ToString()
        {
            return $"{Header}: \n" +
                   $"{Body}:\n" +
                   $"A.{Choices[0]}\nB.{Choices[1]}\nC.{Choices[2]}\nD.{Choices[3]}\nE.{Choices[4]} \n" +
                   $" [Marks: {Marks}] \n" +
                   $"Your Answer: {Answer}\n";
        }
    }
}
