using System;
using System.Collections.Generic;

namespace Notebook
{
    public static class Note
    {
        private static readonly List<Person> Notebook = new List<Person>();

        public static void CreateNewContact()
        {
            Console.WriteLine("Введите данные (обязательные поля помечены *):");

            Console.WriteLine("Фамилия*:");
            var surname = FieldHandler.RequestData(FieldHandler.Field.NameOrSurname);

            Console.WriteLine("Имя*:");
            var name = FieldHandler.RequestData(FieldHandler.Field.NameOrSurname);

            Console.WriteLine("Отчество:");
            var patronymic = FieldHandler.RequestData(FieldHandler.Field.Patronymic);

            Console.WriteLine("Номер телефона* (только цифры):");
            var phoneNumber = FieldHandler.RequestData(FieldHandler.Field.PhoneNumber);

            Console.WriteLine("Страна*:");
            var country = FieldHandler.RequestData(FieldHandler.Field.Country);

            Console.WriteLine("Дата рождения:");
            var dateOfBirth = Console.ReadLine();

            Console.WriteLine("Организация:");
            var organization = Console.ReadLine();

            Console.WriteLine("Должность:");
            var position = Console.ReadLine();

            Console.WriteLine("Прочие заметки:");
            var otherNotes = Console.ReadLine();

            Notebook.Add(new Person(surname, name, patronymic, phoneNumber, country, dateOfBirth, organization,
                position, otherNotes));
            Console.ReadLine();
        }

        public static void EditContact()
        {
            if (Notebook.Count == 0)
            {
                Console.WriteLine("Записная книжка пуста!");
                Console.ReadLine();
                return;
            }

            var index = 1;
            foreach (var person in Notebook)
            {
                Console.WriteLine($"{index++}. {person.Surname} {person.Name}");
            }

            Console.WriteLine("Информацию о каком пользователе Вы желаете изменить?");

            while (true)
            {
                Console.Write("Укажите порядковый номер контакта: ");
                var isCorrectInput = int.TryParse(Console.ReadLine(), out int firstChoose);
                if (!isCorrectInput || firstChoose < 1 || firstChoose > Notebook.Count)
                {
                    Console.WriteLine("Ошибка!");
                    continue;
                }

                Console.WriteLine(Notebook[firstChoose - 1]);
                while (true)
                {
                    Console.Write(
                        "Укажите порядковый номер поля, который желаете изменить(введите 0, чтобы завершить редактирование): ");
                    isCorrectInput = int.TryParse(Console.ReadLine(), out int secondChoose);
                    if (!isCorrectInput || secondChoose < 0 || secondChoose > 9)
                    {
                        Console.WriteLine("Ошибка!");
                        continue;
                    }

                    switch (secondChoose)
                    {
                        case 0:
                            return;
                        case 1:
                            Console.WriteLine("Фамилия*:");
                            var surname = FieldHandler.RequestData(FieldHandler.Field.NameOrSurname);
                            Notebook[firstChoose - 1].Surname = surname;
                            break;
                        case 2:
                            Console.WriteLine("Имя*:");
                            var name = FieldHandler.RequestData(FieldHandler.Field.NameOrSurname);
                            Notebook[firstChoose - 1].Name = name;
                            break;
                        case 3:
                            Console.WriteLine("Отчество:");
                            var patronymic = FieldHandler.RequestData(FieldHandler.Field.Patronymic);
                            Notebook[firstChoose - 1].Patronymic = patronymic;
                            break;
                        case 4:
                            Console.WriteLine("Номер телефона*:");
                            var phoneNumber = FieldHandler.RequestData(FieldHandler.Field.PhoneNumber);
                            Notebook[firstChoose - 1].PhoneNumber = phoneNumber;
                            break;
                        case 5:
                            Console.WriteLine("Страна*:");
                            var country = FieldHandler.RequestData(FieldHandler.Field.Country);
                            Notebook[firstChoose - 1].Country = country;
                            break;
                        case 6:
                            Console.WriteLine("Дата рождения:");
                            Notebook[firstChoose - 1].DateOfBirth = Console.ReadLine();
                            break;
                        case 7:
                            Console.WriteLine("Организация:");
                            Notebook[firstChoose - 1].Organization = Console.ReadLine();
                            break;
                        case 8:
                            Console.WriteLine("Должность:");
                            Notebook[firstChoose - 1].Position = Console.ReadLine();
                            break;
                        case 9:
                            Console.WriteLine("Прочие заметки:");
                            Notebook[firstChoose - 1].OtherNotes = Console.ReadLine();
                            break;
                    }
                }
            }
        }

        public static void DeleteContact()
        {
            if (Notebook.Count == 0)
            {
                Console.WriteLine("Записная книжка пуста!");
                Console.ReadLine();
                return;
            }

            var index = 1;
            foreach (var person in Notebook)
            {
                Console.WriteLine($"{index++}. {person.Surname} {person.Name}");
            }

            Console.WriteLine("Какой контакт желаете удалить?");

            bool isCorrectInput = false;
            while (!isCorrectInput)
            {
                Console.Write("Укажите порядковый номер контакта: ");
                isCorrectInput = int.TryParse(Console.ReadLine(), out int choose);
                if (!isCorrectInput || choose < 1 || choose > Notebook.Count)
                {
                    Console.WriteLine("Ошибка!");
                    isCorrectInput = false;
                    continue;
                }

                Notebook.RemoveAt(choose - 1);
                Console.WriteLine("Контакт удален.");
            }

            Console.ReadLine();
        }

        public static void ViewContactInfo()
        {
            if (Notebook.Count == 0)
            {
                Console.WriteLine("Записная книжка пуста!");
                Console.ReadLine();
                return;
            }

            var index = 1;
            foreach (var person in Notebook)
            {
                Console.WriteLine($"{index++}. {person.Surname} {person.Name}");
            }

            Console.WriteLine("Полную информацию о каком контакте Вам показать?");

            bool isCorrectInput = false;
            while (!isCorrectInput)
            {
                Console.Write("Укажите порядковый номер контакта: ");
                isCorrectInput = int.TryParse(Console.ReadLine(), out int choose);
                if (!isCorrectInput || choose < 1 || choose > Notebook.Count)
                {
                    Console.WriteLine("Ошибка!");
                    isCorrectInput = false;
                    continue;
                }

                Console.WriteLine(Notebook[choose - 1]);
            }

            Console.ReadLine();
        }

        public static void ViewAllList()
        {
            if (Notebook.Count == 0)
            {
                Console.WriteLine("Записная книжка пуста!");
                Console.ReadLine();
                return;
            }

            foreach (var person in Notebook)
            {
                Console.WriteLine(person);
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}