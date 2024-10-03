using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask4
{
  /// <summary>
  /// ????
  /// </summary>
  /// <typeparam name="T"></typeparam>
  internal interface IEmpolyeeManager <T> where T : Employee
  {
    /// <summary>
    /// ????
    /// </summary>
    /// <param name="emloyee"></param>
    void Add(T emloyee);

    /// <summary>
    /// ????
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    T Get(string name);

    /// <summary>
    /// ????
    /// </summary>
    /// <param name="emloyee"></param>
    void Update(T emloyee);
  }
}
