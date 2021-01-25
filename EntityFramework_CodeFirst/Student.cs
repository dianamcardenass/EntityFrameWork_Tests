using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_CodeFirst
{
    [Table("StudentInfo")]
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        [Column("Name", TypeName = "ntext")]
        [MaxLength(20)]
        public string StudentName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [NotMapped]
        public int? Age { get; set; }

        public byte[] Photo { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }

        public string Country { get; set; }

        // public string Other { get; set; }

        public int GradeId { get; set; }

        [ForeignKey("GradeId")]

        public Grade Grade { get; set; }
    }
}
