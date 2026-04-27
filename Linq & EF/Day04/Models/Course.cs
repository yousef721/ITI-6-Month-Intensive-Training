using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day04;

public class Course
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public int Credits { get; set; }
    [ForeignKey("Instructor")]
    public int InstructorId { get; set; }

    public virtual Instructor Instructor { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; }
}