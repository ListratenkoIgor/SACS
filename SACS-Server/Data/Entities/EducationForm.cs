using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SACS_Server.Data.Entities
{
    public class EducationForm : IEntity
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)] 
        [Required]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
    }
}
