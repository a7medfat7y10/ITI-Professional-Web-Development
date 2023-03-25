namespace Task_1_Instructor_API.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public virtual List<Instructor>? Instructors { get; set; }
    }
}
