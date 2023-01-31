namespace Exam_System_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            //creating question list(default constructor reads questions from the file)
            QuestionList question_list = new QuestionList();

            #region Write questions in file using Add in QuestionList
            //List<Question> questions = new List<Question>()
            //{
            //    new TFQuestion          (1,"C#" ,   "Write T or F", "C# is .....",      5, "T"  ),
            //    new ChooseOneQuestion   (2,"C#" ,   "Choose one",   "what is ....?",    5, "B"  ,   new List<string> { "Choice 1", "Choice 2", "Choice 3", "Choice 4" }),
            //    new ChooseAllQuestion   (3,"C#" ,   "Choose multi", "what is .....?",   5, "All",   new List<string> { "Choice 1", "Choice 2", "Choice 3", "Choice 4" }),
            //    new TFQuestion          (4,"C#" ,   "Write T or F", "C# is .....",      5, "T") ,
            //    new ChooseOneQuestion   (5,"C#" ,   "Choose one",   "what is ....?",    5, "B"  ,   new List<string> { "Choice 1", "Choice 2", "Choice 3", "Choice 4" }),
            //    new ChooseAllQuestion   (6,"C#" ,   "Choose multi", "what is .....?",   5, "A,B",   new List<string> { "Choice 1", "Choice 2", "Choice 3", "Choice 4" }),
            //    new ChooseOneQuestion   (7,"C#" ,   "Choose one",   "what is ....?",    5, "B"  ,   new List<string> { "Choice 1", "Choice 2", "Choice 3", "Choice 4" }),
            //    new ChooseAllQuestion   (8,"C#" ,   "Choose multi", "what is .....?",   5, "All",   new List<string> { "Choice 1", "Choice 2", "Choice 3", "Choice 4" }),
            //    new TFQuestion          (9,"C#" ,   "Write T or F", "C# is .....",      5, "T") ,
            //    new ChooseOneQuestion   (10,"C#" ,  "Choose one",   "what is ....?",    5, "B"  ,   new List<string> { "Choice 1", "Choice 2", "Choice 3", "Choice 4" })
            //};


            //for (int i = 0; i < questions.Count; i++)
            //{
            //    question_list.Add(questions[i]);
            //} 
            #endregion

            Subject Sub1 = new Subject("C#");
            
            int e;
            do
            {
                Console.WriteLine("1.Practice Exam\n" +
                                  "2.Final Exam");
            }while(!int.TryParse(Console.ReadLine(), out e));

            
            switch (e)
            {
                case 1:
                    PracticeExam Practice_exam = new PracticeExam(new DateTime(), "10 mins", 10, Sub1);

                    Console.WriteLine("\n\n################## welcome to Practice Exam 1 #################\n\n");

                    Console.WriteLine(Practice_exam.Show_Exam());

                    //string[] pe_answers = new string[Practice_exam.No_Of_Questions];
                    List<string> pe_answers = new List<string>();

                    for (int i=0;i< Practice_exam.No_Of_Questions; i++)
                    {
                        Console.WriteLine($"Answer no. {i+1} question");
                        pe_answers.Add(Console.ReadLine());
                    }
                    Practice_exam.AnswerExam(pe_answers);

                    Practice_exam.Correct_Exam();

                    string option;
                    do
                    {
                        Console.WriteLine("To Show Answers and grade press y");
                        option = Console.ReadLine();
                    }
                    while (option != "y");
                    Console.Clear();

                    Practice_exam.Show_Result();
                break;

                case 2:
                    FinalExam Final_exam = new FinalExam(new DateTime(), "10 mins", 10, Sub1);

                    Console.WriteLine("\n\n################## welcome to Final Exam 1 #################\n\n");
                    
                    Console.WriteLine(Final_exam.Show_Exam());
                    //string[] fe_answers = new string[Final_exam.No_Of_Questions];
                    List<string> fe_answers = new List<string>();
                    for (int i = 0; i < Final_exam.No_Of_Questions; i++)
                    {
                        Console.WriteLine($"Answer no. {i + 1} question");
                        fe_answers.Add(Console.ReadLine());
                    }
                    Final_exam.AnswerExam(fe_answers);
                    Final_exam.Correct_Exam();

                    string option2;
                    do
                    {
                        Console.WriteLine("To Show Answers and grade press y");
                        option2 = Console.ReadLine();
                    }
                    while (option2 != "y");
                    Console.Clear();

                    Final_exam.Show_Result();
                    break;

                default:
                    Console.WriteLine("wrong choice");
                break;
            }
        }
    }
}