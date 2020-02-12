using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PatientCardsITC.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [Display(Name = "ИИН")]
        [Required(ErrorMessage = "Не заполнено ИИН")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "ИИН должен содержать только цифры")]
        public string IIN { get; set; }

        [Display(Name = "ФИО")]
        [Required(ErrorMessage = "Не заполнено поле ФИО")]
        public string FIO { get; set; }

        [Display(Name = "Адрес проживания")]
        [Required(ErrorMessage = "Не заполнен адрес проживания")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Не заполнен номер телефона")]
        [Display(Name = "Контактный номер")]
        [Phone]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Номер телефона введен неверно")]
        public string PhoneNumber { get; set; }
    }
}
