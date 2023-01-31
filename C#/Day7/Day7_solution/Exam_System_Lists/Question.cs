namespace Exam_System_Lists
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
        //public string Model_Answer { get; set; }
        //public string? Answer { get; set; }
        public Answers Q_answers { get; set; }
        public string subject { get; set; }

        public Question(int _id, string sub, string _h, string _b, int _m, string _t, string _ma)
        {
            Id = _id;
            Header = _h;
            Body = _b;
            Marks = _m;
            Q_answers = new Answers();
            Type = _t;
            Q_answers.model_answer = _ma;
            subject = sub;
        }
        public void GetAnswer(string _answer)
        {
            Q_answers.Std_answer = _answer;
        }
    }
}
