using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SACS_Server.Data.Entities
{
    public class Department : IEntity
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int Id { get; set; }

        [StringLength(100)]
        public string Abbrev { get; set; }

        [Required]
        public string Name { get; set; }


    }
}
