using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SACS_Server.Data.Entities
{
    public class Student : IEntity
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

        public int StudentsStreamNumber { get; set; }

        public virtual StudentsGroup Group { get; set; }
    }
}
