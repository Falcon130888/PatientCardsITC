using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PatientCardsITC.Models
{
    public class Position
    {
        [Key]
        public int PositionId { get; set; }

        [Display(Name = "должность")]
        public string PostionName { get; set; }

        public IEnumerable<Doctor> Doctors { get; }
    }
}