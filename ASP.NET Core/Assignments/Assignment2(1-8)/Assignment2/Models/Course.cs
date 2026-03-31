namespace Assignment2.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;

        public int StudentId { get; set; }

        public Student? Student { get; set; }
    }
}