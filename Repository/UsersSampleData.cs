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
                        PostionName = "Терапевт",
                    },
                    new Position
                    {
                        PostionName = "Лор",
                    },
                    new Position
                    {
                        PostionName = "Кардиолог",
                    },
                    new Position
                    {
                        PostionName = "Хирург",
                    },
                    new Position
                    {
                        PostionName = "Стоматолог",
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
                        PhoneNumber = "8(777)9784307"
                    },
                    new Patient
                    {
                        IIN = "190640006862",
                        FIO = "Тамимова Гульмира Бакытбековна",
                        Address = "Ауэзова 147, кв 28",
                        PhoneNumber = "8(777)9784307"
                    },
                    new Patient
                    {
                        IIN = "200140023083",
                        FIO = "Скакова Улжан Каспаметовна",
                        Address = "Абая 25, кв 40",
                        PhoneNumber = "8(777)9784307"
                    }
                    );
                }
            }
        }
    }