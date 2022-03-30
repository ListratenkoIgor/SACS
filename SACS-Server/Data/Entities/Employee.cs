using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SACS_Server.Data.Entities
{
    public class Employee : IEntity
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        //[Required]
        public string MiddleName { get; set; }

        [StringLength(100)]
        public string Degree { get; set; }

        [StringLength(100)]
        public string Rank { get; set; }

        public virtual ICollection<Department> AcademicDepartment { get; set; }
    }
}
