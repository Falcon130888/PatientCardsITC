using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientCardsITC.Models
{
    public class History
    {
        [Key]
        public int HistoryId { get; set; }

        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        [Display(Name = "Пациент")]
        public Patient Patient { get; set; }

        public int PositionId { get; set; }
        [ForeignKey("PositionId")]
        [Display(Name = "Специалист")]
        public Position Position { get; set; }

        public int DoctorId { get; set; }
        [Display(Name = "Доктор")]
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }

        [Required(ErrorMessage = "заполните диагноз")]
        [Display(Name = "Диагноз")]
        public string Diagnos { get; set; }

        [Required(ErrorMessage = "заполните жалобы")]
        [Display(Name = "Жалобы")]
        public string Complain { get; set; }

        [Required(ErrorMessage = "заполните дату обращения")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата визита")]
        public DateTime VisitDate { get; set; }
    }
}