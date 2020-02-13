using PatientCardsITC.DBContext;
using PatientCardsITC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientCardsITC.Repository
{
    public class UsersSampleData
    {
        public static void Initialize(ApplicationContext context)
        {
            if (!context.Positions.Any())
            {
                context.Positions.AddRange(
                    new Position
                    {
                        PositionName = "Терапевт",
                    },
                    new Position
                    {
                        PositionName = "Лор",
                    },
                    new Position
                    {
                        PositionName = "Кардиолог",
                    },
                    new Position
                    {
                        PositionName = "Хирург",
                    },
                    new Position
                    {
                        PositionName = "Стоматолог",
                    }
                );
                context.SaveChanges();
            }

            if (!context.Doctors.Any())
            {
                context.Doctors.AddRange(
                    new Doctor
                    {
                        FIO = "Иванов И. И.",
                        PositionId = 1
                    },
                    new Doctor
                    {
                        FIO = "Петров П.П.",
                        PositionId = 2
                    },
                    new Doctor
                    {
                        FIO = "Хамитов М.М.",
                        PositionId = 3
                    },
                    new Doctor
                    {
                        FIO = "Омаров А.К.",
                        PositionId = 4
                    },
                    new Doctor
                    {
                        FIO = "Айсин А.М.",
                        PositionId = 5
                    },
                    new Doctor
                    {
                        FIO = "Коновалова Т.А.",
                        PositionId = 1
                    },
                    new Doctor
                        {
                            FIO = "Иванов И.И.",
                            PositionId = 1
                        }
                );
                context.SaveChanges();
            }

            if (!context.Patients.Any())
            {
                context.Patients.AddRange(
                    new Patient
                    {
                        IIN = "810906301161",
                        FIO = "Бекбулатов Артыкбай Усейнович",
                        Address = "Валиханова 48а, кв 42",
                        PhoneNumber = "8(777)9784307"
                    },
                    new Patient
                    {
                        IIN = "910928301083",
                        FIO = "Нейфельд Станислав Викторович",
                        Address = "Букетова 42, кв 32",
                        PhoneNumber = "8(777)9784307",
                    },
                    new Patient
                    {
                        IIN = "190640006862",
                        FIO = "Тамимова Гульмира Бакытбековна",
                        Address = "Ауэзова 147, кв 28",
                        PhoneNumber = "8(777)9784307",
                    },
                    new Patient
                    {
                        IIN = "200140023083",
                        FIO = "Скакова Улжан Каспаметовна",
                        Address = "Абая 25, кв 40",
                        PhoneNumber = "8(777)9784307",
                    },
                    new Patient
                     {
                         IIN = "77777777777",
                         FIO = "Сидоров Иван Иванович",
                         Address = "Пушкина 10, кв 5",
                         PhoneNumber = "8(777)9784307",
                     }
                    );
                context.SaveChanges();
            }

            if (!context.Histories.Any())
            {
                context.Histories.AddRange(
                   new History
                   {
                       PatientId = 1,
                       PositionId = 1,
                       DoctorId = 1,
                       Diagnos = "простуда",
                       Complain = "температура",
                       VisitDate = DateTime.Now
                   },
                   new History
                    {
                        PatientId = 2,
                        PositionId = 2,
                        DoctorId = 2,
                        Diagnos = "грыжа",
                        Complain = "боль в животе",
                        VisitDate = DateTime.Now
                    },
                   new History
                    {
                        PatientId = 3,
                        PositionId = 3,
                        DoctorId = 3,
                        Diagnos = "воспаление уха",
                        Complain = "боль в ухе",
                        VisitDate = DateTime.Now
                    },
                   new History
                   {
                       PatientId = 1,
                       PositionId = 1,
                       DoctorId = 7,
                       Diagnos = "бронхит",
                       Complain = "кашель",
                       VisitDate = DateTime.Now
                   },
                   new History
                   {
                       PatientId = 1,
                       PositionId = 1,
                       DoctorId = 6,
                       Diagnos = "подозрение на гастрит",
                       Complain = "боль в животе",
                       VisitDate = DateTime.Now
                   }
                    );
                context.SaveChanges();
            }
            }
        }
    }