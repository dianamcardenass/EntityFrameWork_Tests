using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_CodeFirst.FluentAPI
{
    public class Student
    {
        public Guid Guid { get; set; }

        public string StudentName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [NotMapped]
        public int? Age { get; set; }

        public byte[] Photo { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }

        public Grade Grade { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //public DateTime CreatedDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Row { get; set; }

        public int CurrentGradeId { get; set; }

        public int Diana { get; set; }

    }
}
