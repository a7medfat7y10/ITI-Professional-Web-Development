using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam_system
{
    public enum Types
    {
        TF, ChooseOne, ChooseAll
    }
    public class Question
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public int Marks { get; set; }
        public string Type { get; set; }
        public string Model_Answer { get; set; }
        public string? Answer { get; set; }

        public Question(int _id, string _h, string _b, int _m, string _t, string _ma)
        {
            Id = _id;
            Header = _h;
            Body = _b;
            Marks = _m;
            Type = _t;
            Model_Answer = _ma;
        }
        public void GetAnswer(string _answer)
        {
            Answer = _answer;
        }
    }
}
