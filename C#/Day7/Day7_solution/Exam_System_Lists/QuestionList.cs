using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System_Lists
{
    internal class QuestionList:List<Question>
    {
        public List<Question> Question_List { get; set; }
        FileInfo MyFile;
        StreamWriter MyText;

        public QuestionList()
        {
            //Question_List = new List<Question>();
            MyFile = new FileInfo("C#.txt");

            Question_List = new List<Question>();

            #region Read questions from file into Question_list

            string qFile = System.IO.File.ReadAllText("C#.txt");
            string[] Questions = qFile.Split(Environment.NewLine + Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            int id = 1;

            foreach (string Question in Questions)
            {
                string header = Question.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)[0];
                string body = Question.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)[1];
                int pFrom = Question.IndexOf(body);
                int pTo = Question.LastIndexOf("[Marks: 5]");
                string[] choices = Question.Substring(pFrom, pTo).Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

                if (header.Trim() == "Write T or F:")
                {
                    string model_answer = Question.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)[6].Split(" ")[2];
                    Question_List.Add(new TFQuestion(id++, "C#", header, body, 5, model_answer));
                }
                else if (header.Trim() == "Choose one:")
                {
                    string model_answer = Question.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)[8].Split(" ")[2];


                    string choice1 = choices[1];
                    string choice2 = choices[2];
                    string choice3 = choices[3];
                    string choice4 = choices[4];

                    List<string> q_choices = new List<string> { choice1, choice2, choice3, choice4 };

                    Question_List.Add(new ChooseOneQuestion(id++, "C#", header, body, 5, model_answer, q_choices));
                }
                else if (header.Trim() == "Choose multi:")
                {
                    string model_answer = Question.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)[9].Split(" ")[2];
                    string choice1 = choices[1];
                    string choice2 = choices[2];
                    string choice3 = choices[3];
                    string choice4 = choices[4];

                    List<string> q_choices = new List<string> { choice1, choice2, choice3, choice4 };

                    Question_List.Add(new ChooseAllQuestion(id++, "C#", header, body, 5, model_answer, q_choices));
                }
            }
            #endregion
        }

        public new void Add(Question question)
        {
            Question_List.Add(question);

            MyText = MyFile.AppendText();

            using (MyText)
            {
                MyText.WriteLine(question.ToString() +
                    $"Model Answer: {question.Q_answers.model_answer}");
                MyText.Write(MyText.NewLine);
            }
        }

    }
}
