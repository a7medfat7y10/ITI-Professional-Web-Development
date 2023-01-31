using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam_system
{
    internal class ChooseOneQuestion : Question
    {
        string[] Choices = new string[4];

        public ChooseOneQuestion(int _id, string _h, string _b, int _m, string _ma, string[] _ch) : base(_id,_h, _b, _m, "Choose One", _ma)
        {
            for(int i=0; i< _ch.Length;i++) {
                Choices[i] = _ch[i];
            }
        }

        public override string ToString()
        {
            return $"{Header}: \n" +
                   $"{Body}:  \n" +
                   $"A.{Choices[0]}\nB.{Choices[1]}\nC.{Choices[2]}\nD.{Choices[3]} \n" +
                   $" [Marks: {Marks}] \n" +
                   $"Your Answer: {Answer}\n";
        }
    }
}
