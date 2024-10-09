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
    /// Конструктор на постоянного работника.
    /// </summary>
    /// <param name="name">Имя работника</param>
    /// <param name="baseSalary">Бащовая ставка работника</param>
    public FullTimeEmployee(string name, decimal baseSalary) : base(name, baseSalary)
    {
    }
    #endregion
  }
}
