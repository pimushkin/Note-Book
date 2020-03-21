using System;
using System.Linq;

namespace Notebook
{
    public static class FieldHandler
    {
        public enum Field
        {
            NameOrSurname,
            Patronymic,
            PhoneNumber,
            Country,
            DateOfBirth,
            Organisation,
            Position
        }

        public static dynamic RequestData(Field option)
        {
            var field = "";
            switch (option)
            {
                case Field.NameOrSurname:
                case Field.Patronymic:
                {
                    while (true)
                    {
                        field = Console.ReadLine();
                        var isInvalidCharacter = field.Any(symbol =>
                            (symbol < 'А' || symbol > 'Я') && (symbol < 'а' || symbol > 'я'));

                        switch (option)
                        {
                            case Field.NameOrSurname:
                                if (field == "" || isInvalidCharacter)
                                {
                                    Console.WriteLine(
                                        "Ошибка! Некорректный ввод (поле не может быть пустым и должно содержать только буквы русского алфавита).");
                                    continue;
                                }

                                break;
                            case Field.Patronymic:
                                if (isInvalidCharacter)
                                {
                                    Console.WriteLine(
                                        "Ошибка! Некорректный ввод (поле может содержать только буквы русского алфавита).");
                                    continue;
                                }

                                break;
                        }

                        if (field != "")
                        {
                            field = field[0].ToString().ToUpper() + field.Substring(1, field.Length - 1).ToLower();
                        }

                        break;
                    }

                    break;
                }
                case Field.PhoneNumber:
                {
                    while (true)
                    {
                        field = Console.ReadLine();
                        var isInvalidNumber = field.Any(symbol => symbol < '0' || symbol > '9');
                        if (field == "" || isInvalidNumber)
                        {
                            Console.WriteLine(
                                "Ошибка! Некорректный ввод (поле не может быть пустым и должно содержать только цифры).");
                            continue;
                        }

                        var phoneNumber = long.Parse(field);
                        return phoneNumber;
                    }
                }
                case Field.Country:
                case Field.Organisation:
                case Field.Position:
                    while (true)
                    {
                        field = Console.ReadLine();
                        if (field == "" && option == Field.Country)
                        {
                            Console.WriteLine("Ошибка! Поле не может быть пустым.");
                            continue;
                        }

                        if (field == "" && option != Field.Country)
                        {
                            break;
                        }

                        var isInvalidField = false;
                        var isEmptyWord = false;
                        var strField = field.Split(' ');
                        foreach (var word in strField)
                        {
                            isInvalidField = word.Any(symbol =>
                                (symbol < 'А' || symbol > 'Я') && (symbol < 'а' || symbol > 'я'));
                            if (word == "")
                            {
                                isEmptyWord = true;
                            }

                            if (!isInvalidField && !isEmptyWord) continue;
                            Console.WriteLine(
                                "Ошибка! Некорректный ввод (поле может содержать только буквы русского алфавита).");
                            break;
                        }

                        if (isInvalidField || isEmptyWord)
                        {
                            continue;
                        }

                        field = "";
                        switch (option)
                        {
                            case Field.Country:
                            case Field.Organisation:
                                for (int i = 0; i < strField.Length; i++)
                                {
                                    strField[i] = strField[i][0].ToString().ToUpper() +
                                                  strField[i].Substring(1, strField[i].Length - 1).ToLower();
                                    field += strField[i] + " ";
                                }

                                field = field.Remove(field.Length - 1);
                                break;
                            case Field.Position:
                                foreach (var word in strField)
                                {
                                    field += word + " ";
                                }

                                field = field.Remove(field.Length - 1);
                                break;
                        }

                        break;
                    }

                    break;
                case Field.DateOfBirth:
                    while (true)
                    {
                        bool isNotEmpty;
                        int year;
                        int month;
                        int date;
                        while (true)
                        {
                            Console.WriteLine(
                                "День (число от 1 до 31). Оставьте поле пустым, если не желаете вводить дату рождения: ");
                            field = Console.ReadLine();
                            isNotEmpty = int.TryParse(field, out var tempDate);
                            if (!isNotEmpty && field == "")
                            {
                                return DateTime.MinValue;
                            }

                            if (tempDate < 1 || tempDate > 31)
                            {
                                Console.WriteLine(
                                    "Ошибка! Некорректный ввод.");
                                continue;
                            }

                            date = tempDate;
                            break;
                        }

                        while (true)
                        {
                            Console.WriteLine("Месяц (число от 1 до 12):");
                            isNotEmpty = int.TryParse(Console.ReadLine(), out var tempMonth);

                            if (tempMonth < 1 || tempMonth > 12 || !isNotEmpty)
                            {
                                Console.WriteLine(
                                    "Ошибка! Некорректный ввод.");
                                continue;
                            }

                            month = tempMonth;
                            break;
                        }

                        while (true)
                        {
                            Console.WriteLine($"Год (число от 1900 до {DateTime.Now.Year - 18}):");
                            isNotEmpty = int.TryParse(Console.ReadLine(), out var tempYear);
                            if (tempYear < 1900 || tempYear > DateTime.Now.Year - 18 || !isNotEmpty)
                            {
                                Console.WriteLine(
                                    "Ошибка! Некорректный ввод.");
                                continue;
                            }

                            year = tempYear;
                            break;
                        }

                        var dateOfBirth = new DateTime(year, month, date);
                        return dateOfBirth;
                    }
            }

            return field;
        }
    }
}