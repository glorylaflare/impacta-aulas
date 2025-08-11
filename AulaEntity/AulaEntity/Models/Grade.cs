namespace AulaEntity.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        public string? GradeName { get; set; }
        // Navigation property for the relationship with Student
        public ICollection<Student>? Students { get; set; } = new List<Student>();
    }
}
