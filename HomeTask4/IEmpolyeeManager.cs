using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask4
{
  /// <summary>
  /// Унаследование данных работника.
  /// </summary>
  /// <typeparam name="T">"Работник".</typeparam>
  internal interface IEmpolyeeManager <T> where T : Employee
  {
    /// <summary>
    /// Добавление работника.
    /// </summary>
    /// <param name="emloyee">Имя работника.</param>
    void Add(T emloyee);

    /// <summary>
    /// Получить работника.
    /// </summary>
    /// <param name="name">Имя работника.</param>
    /// <returns>Работник.</returns>
    T Get(string name);

    /// <summary>
    /// Измененние данных работника.
    /// </summary>
    /// <param name="emloyee">Имя работника.</param>
    void Update(T emloyee);
  }
}
