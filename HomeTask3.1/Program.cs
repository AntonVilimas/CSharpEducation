using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask3._1
{
  internal class Program
  {
    /// <summary>
    /// Создание файла записной книжки и обращение к ней используя соответсвующие методы, проверка на сущесвтование уже файла.
    /// </summary>
    static void Main(string[] args)
    {
      Phonebook phonebook = new Phonebook();
      string file_name = "Phonebook.txt";
      string state = null;
      Console.ForegroundColor = ConsoleColor.Blue;
      Console.BackgroundColor = ConsoleColor.Gray;
      Console.Clear();
      Console.WriteLine("Запускаем телефонную книгу . .");
      if (File.Exists(Convert.ToString(Path.GetFullPath(file_name))) == false)
        Console.WriteLine("Не найден файл Phonebook.txt. . он будет создан автоматически . .");
      Console.WriteLine("Готово . .");
      while (state != "5")
      {
        try
        {
          Console.WriteLine("1 - добавить новую запись\n2 - найти запись\n3 - обновить запись\n4 - удалить запись\n5 - выход");
          state = Console.ReadLine();
          switch (state)
          {
            case "1":
              phonebook.Save();
              break;
            case "2":
              phonebook.Search();
              break;
            case "3":
              phonebook.Update();
              break;
            case "4":
              phonebook.Delete();
              break;
            default:
              phonebook.SavePhoneBook();
              break;
          }
        }
        catch (Exception e)
        {
          Console.WriteLine(e.Message);
        }
      }
      Console.WriteLine("Работа завершена . . Нажмите клавишу для выхода . .");
      Console.ReadLine();
    }


  }

  
}
