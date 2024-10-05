using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask5
{
  /// <summary>
  /// Представляет ошибки что пользователь уже создан.
  /// </summary>
  internal class UserAlreadyExistsException: Exception
  {
    public UserAlreadyExistsException(string messege):base(messege) { }
  }
}
