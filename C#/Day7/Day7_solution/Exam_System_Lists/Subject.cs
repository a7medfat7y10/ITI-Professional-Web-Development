using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System_Lists
{
    internal class Subject
    {
        public string Name { get; set; }
        //public Question[] Subject_Questions { get; set; }

        public List<Question> Subject_Questions { get; set; }
        public Subject(string _n)
        {
            Name = _n;
            QuestionList q_list = new QuestionList();
            List<Question> temp = new List<Question>();
            foreach (Question ques in q_list.Question_List)
            {
                if(ques.subject == _n)
                {
                    temp.Add(ques);
                }
            }
            Subject_Questions = temp;
        }
    }
}
