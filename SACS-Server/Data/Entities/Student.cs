﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SACS_Server.Data.Entities
{ 
    [Index(nameof(RecordbookNumber), IsUnique = true, Name = "IX_Students_RecordbookNumber")]
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

        [Required]
        public int RecordbookNumber { get; set; }
        
        [Required]
        public virtual StudentsGroup Group { get; set; }
    }
}
