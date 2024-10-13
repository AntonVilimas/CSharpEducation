using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask4
{
  internal class Program
  {
    static void Main(string[] args)
    {
      EmployeeManager ingener = new EmployeeManager();
      MainMenu(ingener);
      Console.ReadLine();
    }

    /// <summary>
    /// Главное меню. 
    /// </summary>
    /// <param name="manager">Работник.Инженер.</param>
    static void MainMenu(EmployeeManager manager)
    {
      try
      {
        Console.Write(
          "1. Добавить постоянного работника\n" +
          "2. Добавить временного работника\n" +
          "3. Получить информацию о работнике\n" +
          "4. Обновить данные работника\n" +
          "5. Выйти\n" +
          "Выберите действие: ");
        if (int.TryParse(Console.ReadLine(), out int request))
        {
          switch (request)
          {
            case 1:
              Console.Write("Введите имя работника: ");
              string Name = Console.ReadLine();
              Console.Write("Введите месячную зарплату у работника: ");
              string stringSalary = Console.ReadLine();
              FullTimeEmployee FullEmployee;
              if (decimal.TryParse(stringSalary, out decimal salary))
              {
                FullEmployee = new FullTimeEmployee(Name, salary);
                manager.Add(FullEmployee);
                Console.WriteLine("___Выполнено___");
              }
              else
                throw new ArgumentException("Ошибка не число");

              break;
            case 2:
              Console.Write("Введите имя работника: ");
              string NameP = Console.ReadLine();
              Console.Write("Введите месячную зарплату у работника: ");
              string stringSalaryP = Console.ReadLine();
              PartTimeEmployee PartEmployee;
              if (decimal.TryParse(stringSalaryP, out decimal salaryF))
              {
                PartEmployee = new PartTimeEmployee(NameP, salaryF);
                manager.Add(PartEmployee);
                Console.WriteLine("___Выполнено___");
              }
              else
                throw new ArgumentException("Ошибка не число");
              break;
            case 3:
              Console.Write("Введите для поиска има работника: ");
              var employee = manager.Get(Console.ReadLine());
              Console.Write($"Имя: {employee.Name}\nЗарплата: {employee.CalculateSalary()}\n");
              Console.WriteLine("___Выполнено___");
              break;
            case 4:
              Console.Write("Введите для поиска имя работника: ");
              Employee employeeGet = (Employee)manager.Get(Console.ReadLine());
              if (employeeGet == null)
                throw new ArgumentNullException("Был передан работник с незаполненными данными");
              Console.Write(
              "Какие данные поменять\n" +
              "1. Изменить имя работника\n" +
              "2. Изменить зарплату работника\n" +
              "Выберите действие: ");
              if (int.TryParse(Console.ReadLine(), out int requesting))
              {
                switch (requesting)
                {
                  case 1:
                    Console.Write("Введите имя: ");
                    string nameUp = Console.ReadLine();
                    if (string.IsNullOrEmpty(nameUp))
                      throw new ArgumentException("Новое имя пустое");
                    else
                      employeeGet.Name = nameUp;
                    break;
                  case 2:
                    Console.Write("Введите зарлату: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal salaryUp))
                      employeeGet.BaseSalary = salaryUp;
                    else
                      throw new ArgumentException("Новая зарплата введено не число");
                    break;
                  default:
                    throw new ArgumentException("Такого выбора не существует");
                }
              }
              else
                throw new InvalidOperationException("Такой операции не существует");

              manager.Update(employeeGet);
              Console.WriteLine("___Выполнено___");
              break;
            case 5:
              return;
            default:
              Console.WriteLine("Не существющая команда");
              break;
          }
        }
        else
          throw new ArgumentException("Не выполнимый запрос");
        MainMenu(manager);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }
  }
}
