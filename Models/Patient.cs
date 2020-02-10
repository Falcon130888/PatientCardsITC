using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PatientCardsITC.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [Display(Name = "ИИН пациента")]
        [RegularExpression(@" ^ (\d{10})$", ErrorMessage = "ИИН должен содержать только цифры")]
        public string IIN { get; set; }

        [Display(Name = "ФИО пациента")]
        public string FIO { get; set; }

        [Display(Name = "Адрес проживания")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Вы должны ввести номер телефона")]
        [Display(Name = "Контактный номер пациента")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Номер телефона введен неверно")]
        public string PhoneNumber { get; set; }
    }
}
