using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask5
{
  internal class User

  {
    #region Поля и свойства

    /// <summary>
    /// 
    /// </summary>
    public int Id;

    /// <summary>
    /// 
    /// </summary>
    public string Name;

    /// <summary>
    /// 
    /// </summary>
    public string Email;
    #endregion

    #region Конструкторы

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id">Айди.</param>
    /// <param name="name">Имя.</param>
    /// <param name="email">Электронная почта.</param>
    public User(int id, string name, string email) 
    { 
      this.Id = id;
      this.Name = name;
      this.Email = email;
    }
  }
}
