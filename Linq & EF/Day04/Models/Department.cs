using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day04;

public class Department
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    [ForeignKey("HeadInstructor")]

    public int? HeadInstructorId { get; set; }

    public virtual ICollection<Student> Students { get; set; }

    public virtual Instructor HeadInstructor { get; set; }
}
