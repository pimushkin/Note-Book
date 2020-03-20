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
            Country
        }

        public static string RequestData(Field option)
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

                        break;
                    }

                    break;
                }
                case Field.Country:
                    while (true)
                    {
                        field = Console.ReadLine();
                        if (field == "")
                        {
                            Console.WriteLine("Ошибка! Поле не может быть пустым.");
                            continue;
                        }

                        var isInvalidCountry = false;
                        var isEmptyWord = false;
                        var country = field.Split(' ');
                        foreach (var word in country)
                        {
                            isInvalidCountry = word.Any(symbol =>
                                (symbol < 'А' || symbol > 'Я') && (symbol < 'а' || symbol > 'я'));
                            if (word == "")
                            {
                                isEmptyWord = true;
                            }

                            if (!isInvalidCountry && !isEmptyWord) continue;
                            Console.WriteLine("Ошибка! Поле может содержать только буквы русского алфавита.");
                            break;
                        }

                        if (isInvalidCountry || isEmptyWord)
                        {
                            continue;
                        }

                        field = "";
                        for (int i = 0; i < country.Length; i++)
                        {
                            country[i] = country[i][0].ToString().ToUpper() +
                                         country[i].Substring(1, country[i].Length - 1).ToLower();
                            field += country[i] + " ";
                        }

                        field = field.Remove(field.Length - 1);

                        break;
                    }

                    break;
                // TODO: Add processing for the date of birth, organization, and position fields.
            }

            return field;
        }
    }
}