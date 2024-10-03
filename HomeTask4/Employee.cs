﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask4
{
  internal abstract class Employee
  {
    #region Поля и свойства

    /// <summary>
    /// Имя работника.
    /// </summary>
    public string Name {  get; set; }

    /// <summary>
    /// Базовая рабочая ставка.
    /// </summary>
    public decimal BaseSalary { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int Index {  get; set; }
    #endregion

    #region Методы

    /// <summary>
    /// Расчет зарплаты.
    /// </summary>
    /// <returns></returns>
    public abstract decimal CalculateSalary();
    #endregion

    #region Конструкторы

    /// <summary>
    /// Создание сторудника.
    /// </summary>
    /// <param name="name">Имя сотрудника</param>
    /// <param name="baseSalary">Базовая рабочая ставка</param>
    public Employee(string name, decimal baseSalary)
    {
      Name = name;
      BaseSalary = baseSalary;
    }
    #endregion
  }
}
