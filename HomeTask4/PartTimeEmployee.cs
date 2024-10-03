using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask4
{
  internal class PartTimeEmployee : Employee
  {
    #region Поля и свойства

    /// <summary>
    /// Отработанные часы.
    /// </summary>
    public float TimeWork {  get; set; } 
    #endregion

    #region Базовый класс

    public override decimal CalculateSalary()
    {
      if (TimeWork > 0 && !float.IsNaN(TimeWork))
        return (BaseSalary / 176) * (decimal)TimeWork;
      else
        throw new ArgumentException("Бездельничал");
    }
    #endregion

    #region Конструкторы

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="baseSalary"></param>
    public PartTimeEmployee (string name, decimal baseSalary) : base(name, baseSalary)
    {
    }
    #endregion
  }
}
