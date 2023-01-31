using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System_Lists
{
    public class AnswerList:List<Answers>
    {
        public List<Answers> Answer_List { get; set; }
        public AnswerList()
        {
            Answer_List = new List<Answers>();
        }
    }
}
