using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SACS_Server.Data.Entities
{
    public class Speciality : IEntity
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int Id { get; set; }

        [StringLength(100)]
        public string Abbrev { get; set; }

        public string Name { get; set; }

        public virtual Faculty Faculty { get; set; }

        public virtual EducationForm EducationForm { get; set; }

        [StringLength(50)]
        public string Code { get; set; }
    }
}
