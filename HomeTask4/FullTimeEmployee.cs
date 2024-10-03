using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask4
{
  internal class FullTimeEmployee : Employee
  {
    #region Базовый класс

    public override decimal CalculateSalary()
    {
      return BaseSalary;
    }
    #endregion

    #region Конструкторы

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="baseSalary"></param>
    public FullTimeEmployee(string name, decimal baseSalary) : base(name, baseSalary)
    {
    }
    #endregion
  }
}
