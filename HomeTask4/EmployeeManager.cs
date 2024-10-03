﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HomeTask4
{
  internal class EmployeeManager : IEmpolyeeManager<Employee>
  {
    #region Поля и свойства

    /// <summary>
    /// 
    /// </summary>
    private int Index = 0;
    
    /// <summary>
    /// 
    /// </summary>
    private Dictionary <int,Employee> listEmployee;
    #endregion

    #region Методы

    public void Add(Employee emloyee)
    {
      if (emloyee == null)
        throw new ArgumentNullException("Ошибка отстсвуют данные работника");
      if (this.listEmployee.Any())
      {
        if (!this.listEmployee.ContainsValue(emloyee))
        {
          this.listEmployee.Add(Index, emloyee);
          emloyee.Index = Index;
          Index++;
        }
        else
          throw new ArgumentException("Существующий сотрудник");
      }
      else
      {
        this.listEmployee.Add(Index, emloyee);
        emloyee.Index = Index;
        Index++;
      }
    }

    public Employee Get(string name)
    {
      if (this.listEmployee.Any())
      {
        foreach(var employee in this.listEmployee)
        {  
          if (employee.Value.Name.ToLower() == name.ToLower())
            return employee.Value;
        }
        throw new ArgumentException("Сотрудник не найден");
      }
      else
        throw new ArgumentNullException("Пустой список");
    }

    public void Update(Employee employee)
    {
      if (this.listEmployee.Any())
      {
        foreach (var employeer in this.listEmployee)
        {
          if (employeer.Key ==employee.Index)
          {
            this.listEmployee[employeer.Value.Index] = employee;
            return;
          }
        }
        throw new ArgumentException("Сотрудник не найден");
      }
      else
        throw new ArgumentNullException("Пустой список");
    }
    #endregion

    #region Конструкторы

    /// <summary>
    /// 
    /// </summary>
    public EmployeeManager()
    {
      this.listEmployee = new Dictionary<int,Employee>();
    }

    #endregion

  }
}
