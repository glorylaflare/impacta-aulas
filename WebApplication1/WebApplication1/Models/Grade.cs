namespace WebApplication1.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }

        public ICollection<Student> Student { get; set; } = new List<Student>();
    }
}
