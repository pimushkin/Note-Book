using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace Notebook
{
    public static class Note
    {
        private static readonly List<Person> Notebook = new List<Person>();

        public static void CreateNewContact()
        {
            Console.Clear();
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
            
            Console.Write("Для продолжения нажмите любую клавишу . . .");
            Console.ReadKey();
        }

        public static void EditContact()
        {
            Console.Clear();
            if (Notebook.Count == 0)
            {
                Console.WriteLine("Записная книжка пуста!");
                Console.Write("Для продолжения нажмите любую клавишу . . .");
                Console.ReadKey();
                return;
            }

            while (true)
            {
                Console.WriteLine("Список всех контактов:");
                var index = 1;
                foreach (var person in Notebook)
                {
                    Console.WriteLine($"{index++}. {person.Surname} {person.Name}");
                }

                Console.WriteLine("Информацию о каком пользователе Вы желаете изменить? (введите -1, чтобы вернуться в главное меню)");
                Console.Write("Укажите порядковый номер контакта: ");
                var isCorrectInput = int.TryParse(Console.ReadLine(), out int firstChoose);
                if (firstChoose == -1)
                {
                    return;
                }
                if (!isCorrectInput || firstChoose < 1 || firstChoose > Notebook.Count)
                {
                    Console.WriteLine("Ошибка! Некорректный ввод.");
                    
                    Console.Write("Для продолжения нажмите любую клавишу . . .");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine(Notebook[firstChoose - 1]);
                    Console.Write(
                        "Укажите порядковый номер поля, который желаете изменить (введите -1, чтобы вернуться в главное меню): ");
                    isCorrectInput = int.TryParse(Console.ReadLine(), out int secondChoose);
                    if (secondChoose == -1)
                    {
                        return;
                    }
                    if (!isCorrectInput || secondChoose < 1 || secondChoose > 9)
                    {
                        Console.WriteLine("Ошибка! Некорректный ввод.");
                        
                        Console.Write("Для продолжения нажмите любую клавишу . . .");
                        Console.ReadKey();
                        continue;
                    }

                    switch (secondChoose)
                    {
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

                    Console.WriteLine("Поле успешно изменено.\n");
                    
                    Console.Write("Для продолжения нажмите любую клавишу . . .");
                    Console.ReadKey();
                }
            }
        }

        public static void DeleteContact()
        {
            Console.Clear();
            if (Notebook.Count == 0)
            {
                Console.WriteLine("Записная книжка пуста!");
                Console.Write("Для продолжения нажмите любую клавишу . . .");
                Console.ReadKey();
                return;
            }

            bool isCorrectInput = false;
            while (!isCorrectInput)
            {
                Console.WriteLine("Список всех контактов:");
                var index = 1;
                foreach (var person in Notebook)
                {
                    Console.WriteLine($"{index++}. {person.Surname} {person.Name}");
                }

                Console.WriteLine("Какой контакт желаете удалить?");
                Console.Write("Укажите порядковый номер контакта (введите -1, чтобы вернуться в главное меню): ");
                isCorrectInput = int.TryParse(Console.ReadLine(), out int choose);
                if (choose == -1)
                {
                    return;
                }
                if (!isCorrectInput || choose < 1 || choose > Notebook.Count)
                {
                    Console.WriteLine("Ошибка! Некорректный ввод.");
                    isCorrectInput = false;
                    Console.Write("Для продолжения нажмите любую клавишу . . .");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                Notebook.RemoveAt(choose - 1);
                Console.WriteLine("Контакт удален.");
            }

            Console.Write("Для продолжения нажмите любую клавишу . . .");
            Console.ReadKey();
        }

        public static void ViewContactInfo()
        {
            Console.Clear();
            if (Notebook.Count == 0)
            {
                Console.WriteLine("Записная книжка пуста!");
                Console.Write("Для продолжения нажмите любую клавишу . . .");
                Console.ReadKey();
                return;
            }

            bool isCorrectInput = false;
            while (!isCorrectInput)
            {
                Console.WriteLine("Список всех контактов:");
                var index = 1;
                foreach (var person in Notebook)
                {
                    Console.WriteLine($"{index++}. {person.Surname} {person.Name}");
                }

                Console.WriteLine("Полную информацию о каком контакте Вам показать? (введите -1, чтобы вернуться в главное меню)");
                Console.Write("Укажите порядковый номер контакта: ");
                isCorrectInput = int.TryParse(Console.ReadLine(), out int choose);
                if (choose == -1)
                {
                    return;
                }
                if (!isCorrectInput || choose < 1 || choose > Notebook.Count)
                {
                    Console.WriteLine("Ошибка! Некорректный ввод.");
                    isCorrectInput = false;
                    Console.Write("Для продолжения нажмите любую клавишу . . .");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                Console.Clear();
                Console.WriteLine(Notebook[choose - 1]);
                isCorrectInput = false;
                Console.Write("Для продолжения нажмите любую клавишу . . .");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void ViewAllList()
        {
            Console.Clear();
            if (Notebook.Count == 0)
            {
                Console.WriteLine("Записная книжка пуста!");
                Console.Write("Для продолжения нажмите любую клавишу . . .");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Список всех контактов:");
            foreach (var person in Notebook)
            {
                Console.WriteLine($"1. Фамилия: {person.Surname}\n" +
                                  $"2. Имя: {person.Name}\n" +
                                  $"3. Номер телефона: {person.PhoneNumber}\n");
            }

            Console.Write("Для продолжения нажмите любую клавишу . . .");
            Console.ReadKey();
        }
    }
}