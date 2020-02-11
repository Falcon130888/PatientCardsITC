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

        [Display(Name = "Должность")]
        [Required(ErrorMessage = "Поле должность пусто")]
        [RegularExpression(@"^[А-Я]+[а-яА-Я""'\s-]*$", ErrorMessage = "Название должности должно содержать только буквы кирилицы"), StringLength(30)]
        public string PositionName { get; set; }

        public IEnumerable<Doctor> Doctors { get; }
    }
}