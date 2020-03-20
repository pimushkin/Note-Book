namespace Notebook
{
    public class Person
    {
        public string Surname;
        public string Name;
        public string Patronymic;
        public string PhoneNumber;
        public string Country;
        public string DateOfBirth;
        public string Organization;
        public string Position;
        public string OtherNotes;

        public Person(string surname, string name, string patronymic, string phoneNumber, string country,
            string dateOfBirth, string organization, string position, string otherNotes)
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
            return $"1. Фамилия: {Surname}\n" +
                   $"2. Имя: {Name}\n" +
                   $"3. Отчество: {Patronymic}\n" +
                   $"4. Номер телефона: {PhoneNumber}\n" +
                   $"5. Страна: {Country}\n" +
                   $"6. Дата рождения: {DateOfBirth}\n" +
                   $"7. Организация: {Organization}\n" +
                   $"8. Должность: {Position}\n" +
                   $"9. Прочите заметки: {OtherNotes}";
        }
    }
}