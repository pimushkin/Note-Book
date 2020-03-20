using System;

namespace Notebook
{
    internal static class Program
    {
        private static void Main()
        {
            while (true)
            {
                Console.WriteLine("МЕНЮ:\n" +
                                  "1. Создать новый контакт;\n" +
                                  "2. Редактировать созданный контакт;\n" +
                                  "3. Удалить созданный контакт;\n" +
                                  "4. Просмотреть созданный контакт;\n" +
                                  "5. Просмотреть все созданные контакты;\n" +
                                  "6. Завершить работую.");
                while (true)
                {
                    Console.WriteLine("Выберите действие(номер одного из пукнтов выше): ");
                    var isCorrectInput = int.TryParse(Console.ReadLine(), out var choose);
                    if (!isCorrectInput)
                    {
                        Console.WriteLine("Ошибка! Некорректный ввод.");
                        continue;
                    }

                    switch (choose)
                    {
                        case 1:
                            Note.CreateNewContact();
                            break;
                        case 2:
                            Note.EditContact();
                            break;
                        case 3:
                            Note.DeleteContact();
                            break;
                        case 4:
                            Note.ViewContactInfo();
                            break;
                        case 5:
                            Note.ViewAllList();
                            break;
                        case 6:
                            return;
                    }

                    break;
                }

                Console.Clear();
            }
        }
    }
}