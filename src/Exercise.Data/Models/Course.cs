using System.ComponentModel.DataAnnotations.Schema;

namespace Exercise.Data.Models
{
    [Table("courses")]
    public class Course
    {
        [Column("course_id")]
        public int CourseId { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("description")]
        public string? Description { get; set; }
    }
}
