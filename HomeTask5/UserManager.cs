using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask5
{
  internal class UserManager
  {
    #region Поля и свойства

    /// <summary>
    /// Уникальный индекс.
    /// </summary>
    private int Index = 0;

    /// <summary>
    /// Список пользователей.
    /// </summary>
    private List<User> ListUsers;
    #endregion

    #region Методы

    /// <summary>
    /// Добавление пользователя.
    /// </summary>
    /// <param name="user">Имя</param>
    /// <exception cref="ArgumentNullException">Ошибка отстсвуют данные пользователя</exception>
    /// <exception cref="UserAlreadyExistsException">Существующий пользователь</exception>
    public void AddUser(User user)
    {
      if (user == null)
        throw new ArgumentNullException("Ошибка отстсвуют данные пользователя");
      if (this.ListUsers.Any())
      {
        foreach (var userr in this.ListUsers)
        {
          if (userr.Id ==user.Id)
          {
            throw new UserAlreadyExistsException("Существующий пользователь");
          }
        }
        this.ListUsers.Add(user);
      }
      else
      {
        this.ListUsers.Add(user);
      }
    }
    /// <summary>
    /// Поиск пользователя
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    /// <exception cref="UserNotFoundException">Пользователь не найден</exception>
    /// <exception cref="ArgumentNullException">Пустой список</exception>
    public User GetUser(int Id)
    {
      if (this.ListUsers.Any())
      {
        foreach (var user in this.ListUsers)
        {
          if (user.Id == Id)
            return user;
        }
        throw new UserNotFoundException("Пользователь не найден");
      }
      else
        throw new ArgumentNullException("Пустой список");
    }

    /// <summary>
    /// Удаление пользователя.
    /// </summary>
    /// <param name="Id"></param>
    /// <exception cref="UserNotFoundException">Пользователь не найден</exception>
    /// <exception cref="ArgumentNullException">Пустой список</exception>
    public void RemoveUser(int Id)
    {
      if (this.ListUsers.Any())
      {
        foreach (var user in this.ListUsers)
        {
          if (user.Id == Id)
            this.ListUsers.Remove(user);     
        }
        throw new UserNotFoundException("Пользователь не найден");
      }
      else
        throw new ArgumentNullException("Пустой список");
    }

    public void ListUser()
    {
      if (this.ListUsers.Any())
      {
        foreach (var user in this.ListUsers)
        {
          Console.WriteLine($"ID: {user.Id} Имя пользователя: {user.Name} Почта: {user.Email}");
        }
      }
      else
        throw new ArgumentNullException("Пустой список");
    }
    #endregion

    #region Конструкторы

    /// <summary>
    /// Список пользователей.
    /// </summary>
    public UserManager()
    {
      this.ListUsers = new List<User>();
    }

    #endregion
  }
}
