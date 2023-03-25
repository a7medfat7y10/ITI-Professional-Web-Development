namespace Task_1_Instructor_API.Models
{
    public enum Gender { Female, Male }
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Address { get; set; } = string.Empty;
        public double Salary { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department? Department { get; set; }
    }
}
