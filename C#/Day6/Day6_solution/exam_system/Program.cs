namespace exam_system
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Question[] questions = new Question[10];
            questions[0] = new TFQuestion(100, "Write T or F", "C# is .....", 5, "T");
            questions[1] = new ChooseOneQuestion(200, "Choose", "what is ....?", 5, "B", new string[4] { "Choice 1", "Choice 2", "Choice 3", "Choice 4" });
            questions[2] = new ChooseAllQuestion(300, "Choose", "what is .....?", 5, "All", new string[4] { "Choice 1", "Choice 2", "Choice 3", "Choice 4" });
            questions[3] = new TFQuestion(100, "Write T or F", "C# is .....", 5, "T");
            questions[4] = new ChooseOneQuestion(200, "Choose", "what is ....?", 5, "B", new string[4] { "Choice 1", "Choice 2", "Choice 3", "Choice 4" });
            questions[5] = new ChooseAllQuestion(300, "Choose", "what is .....?", 5, "All", new string[4] { "Choice 1", "Choice 2", "Choice 3", "Choice 4" });
            questions[6] = new ChooseOneQuestion(200, "Choose", "what is ....?", 5, "B", new string[4] { "Choice 1", "Choice 2", "Choice 3", "Choice 4" });
            questions[7] = new ChooseAllQuestion(300, "Choose", "what is .....?", 5, "All", new string[4] { "Choice 1", "Choice 2", "Choice 3", "Choice 4" });
            questions[8] = new TFQuestion(100, "Write T or F", "C# is .....", 5, "T");
            questions[9] = new ChooseOneQuestion(200, "Choose", "what is ....?", 5, "B", new string[4] { "Choice 1", "Choice 2", "Choice 3", "Choice 4" });

            Subject Sub1 = new Subject("C#", questions);
            
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
                    
                    string[] pe_answers = new string[Practice_exam.No_Of_Questions];
                    
                    for (int i=0;i< Practice_exam.No_Of_Questions; i++)
                    {
                        Console.WriteLine($"Answer no. {i+1} question");
                        pe_answers[i] = Console.ReadLine();
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

                    Console.WriteLine("student answers");
                    Console.WriteLine(Practice_exam.Exam_answers.ToString());
                break;

                case 2:
                    FinalExam Final_exam = new FinalExam(new DateTime(), "10 mins", 10, Sub1);

                    Console.WriteLine("\n\n################## welcome to Final Exam 1 #################\n\n");
                    
                    Console.WriteLine(Final_exam.Show_Exam());
                    string[] fe_answers = new string[Final_exam.No_Of_Questions];
                    for (int i = 0; i < Final_exam.No_Of_Questions; i++)
                    {
                        Console.WriteLine($"Answer no. {i + 1} question");
                        fe_answers[i] = Console.ReadLine();
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

                    Console.WriteLine("student answers");
                    Console.WriteLine(Final_exam.Exam_answers.ToString());
                    break;

                default:
                    Console.WriteLine("wrong choice");
                break;
            }
        }
    }
}