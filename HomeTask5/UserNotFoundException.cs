using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask5
{
  /// <summary>
  /// Представляет ошибки что пользователь не был найден.
  /// </summary>
  internal class UserNotFoundException : Exception
  {
    public UserNotFoundException(string messege) : base(messege) { }
  }
}
