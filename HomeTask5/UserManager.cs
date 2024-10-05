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
    /// 
    /// </summary>
    private int Index = 0;

    /// <summary>
    /// 
    /// </summary>
    private List<User> ListUsers;
    #endregion

    #region Методы

    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="UserAlreadyExistsException"></exception>
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
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    /// <exception cref="UserNotFoundException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    public User GetUser(int Id)
    {
      if (this.ListUsers.Any())
      {
        foreach (var user in this.ListUsers)
        {
          if (user.Id == Id)
            return user;
        }
        throw new UserNotFoundException("пользователь не найден");
      }
      else
        throw new ArgumentNullException("Пустой список");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <exception cref="UserNotFoundException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    public void RemoveUser(int Id)
    {
      if (this.ListUsers.Any())
      {
        foreach (var user in this.ListUsers)
        {
          if (user.Id == Id)
            this.ListUsers.Remove(user);     
        }
        throw new UserNotFoundException("пользователь не найден");
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
    /// 
    /// </summary>
    public UserManager()
    {
      this.ListUsers = new List<User>();
    }

    #endregion
  }
}
