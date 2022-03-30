using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EFCore.CheckConstraints;
using SACS_Server.Data.Enums;

namespace SACS_Server.Data.Entities
{
    public class RelatedAccount : IEntity
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int Id { get; set; }
        public virtual Employee Employee { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
        public UserRole UserRole { get; set; }

    }
}
