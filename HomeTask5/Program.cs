using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask5
{
  internal class Program
  {
    static void Main(string[] args)
    {
      UserManager userManager = new UserManager();
      MainMenu(userManager);
    }
    /// <summary>
    /// Главное меню.
    /// </summary>
    /// <exception cref="ArgumentException">Введено не число.</exception>
    static public void MainMenu(UserManager userManager)
    {
      Console.Write(
        "1. Добавить пользователя\n" +
        "2. Удаление пользователя\n" +
        "3. Найти пользователя\n" +
        "4. Вывести весь список пользрвателей\n" +
        "5. Выйти\n" +
        "Выберите действие: ");
      if (int.TryParse(Console.ReadLine(), out int request))
      {
        switch (request)
        {
          case 1:
            Console.Write("Введите Id: ");
            int.TryParse(Console.ReadLine(), out int IDAdd);
            Console.Write("Введите Имя: ");
            string Name = Console.ReadLine();
            Console.Write("Введите почту: ");
            string Email = Console.ReadLine();
            var user = new User(IDAdd, Name, Email);
            userManager.AddUser(user);
            Console.WriteLine("Пользователь добавлен успешно!\n__________________");
            break;
          case 2:
            Console.Write("Введите Id: ");
            int.TryParse(Console.ReadLine(), out int IDRemove);
            userManager.RemoveUser(IDRemove);
            Console.WriteLine("Пользователь удален успешно!\n__________________");
            break;
          case 3:
            Console.Write("Введите ID искомого пользователя: ");
            int.TryParse(Console.ReadLine(), out int IDGet);
            var userGet = userManager.GetUser(IDGet);
            Console.WriteLine("Пользователь возвращен из списка успешно!\n__________________");
            Console.WriteLine($"ID: {userGet.Id}\nName: {userGet.Name}\nEmail: {userGet.Email}\n__________________");
            break;
          case 4:
            userManager.ListUser();
            break;
          case 5:
            return;
          default:
            Console.WriteLine("Неизвестная команда\n__________________");
            break;
        }
        MainMenu(userManager);
      }
      else
        throw new ArgumentException("Уточнить запрос");
      Console.ReadLine();
    }
  }
}
