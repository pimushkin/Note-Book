using System;

namespace Notebook
{
    public class Person
    {
        public string Surname;
        public string Name;
        private string _patronymic;

        public string Patronymic
        {
            get => _patronymic;
            set => _patronymic = value == "" ? "отсутствует" : value;
        }
        public long PhoneNumber;
        public string Country;
        public DateTime DateOfBirth;
        private string _organisation;

        public string Organization
        {
            get => _organisation;
            set => _organisation = value == "" ? "отсутствует" : value;
        }
        private string _position;

        public string Position
        {
            get => _position;
            set => _position = value == "" ? "отсутствует" : value;
        }
        private string _otherNotes;

        public string OtherNotes
        {
            get => _otherNotes;
            set => _otherNotes = value == "" ? "отсутствуют" : value;
        }

        public Person(string surname, string name, string patronymic, long phoneNumber, string country,
            DateTime dateOfBirth, string organization, string position, string otherNotes)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            PhoneNumber = phoneNumber;
            Country = country;
            DateOfBirth = dateOfBirth;
            Organization = organization;
            Position = position;
            OtherNotes = otherNotes;
        }

        public override string ToString()
        {
            if (DateOfBirth == DateTime.MinValue)
            {
                return $"1. Фамилия: {Surname}\n" +
                       $"2. Имя: {Name}\n" +
                       $"3. Отчество: {Patronymic}\n" +
                       $"4. Номер телефона: {PhoneNumber}\n" +
                       $"5. Страна: {Country}\n" +
                       "6. Дата рождения: отсутствует\n" +
                       $"7. Организация: {Organization}\n" +
                       $"8. Должность: {Position}\n" +
                       $"9. Прочие заметки: {OtherNotes}";
            }
            return $"1. Фамилия: {Surname}\n" +
                   $"2. Имя: {Name}\n" +
                   $"3. Отчество: {Patronymic}\n" +
                   $"4. Номер телефона: {PhoneNumber}\n" +
                   $"5. Страна: {Country}\n" +
                   $"6. Дата рождения: {DateOfBirth:D}\n" +
                   $"7. Организация: {Organization}\n" +
                   $"8. Должность: {Position}\n" +
                   $"9. Прочие заметки: {OtherNotes}";
        }
    }
}