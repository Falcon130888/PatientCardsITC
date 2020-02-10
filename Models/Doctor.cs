using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientCardsITC.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [Display(Name = "ФИО доктора")]
        public string FIO { get; set; }

        public int PositionId { get; set; }

        [ForeignKey("PositionId")]
        public Position Position { get; set; }
    }
}
