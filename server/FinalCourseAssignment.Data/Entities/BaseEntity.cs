using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FinalCourseAssignment.Domain;

namespace FinalCourseAssignment.Data.Entities
{
    public class BaseEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
    }
}