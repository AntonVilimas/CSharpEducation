using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask3._1
{
  public struct Contact
  {
    private string phone;

    /// <summary>
    /// Номер телефона.
    /// </summary>
    public string Phone
    {
      get
      {
        if (this.phone == null)
        {
          throw new ArgumentException("Exception: Номер телефона не стандартный");
        }
        else
        {
          return this.phone;
        }
      }
      set
      {
        if (value != null)
        {
          this.phone = value;
          
        }
        else
        {
          this.phone = null;
         
        }
      }
    }

    private string name;

    /// <summary>
    /// Имя абонента.
    /// </summary>
    public string Name
    {
      get
      {
        if (this.name == null)
        {
          throw new ArgumentException("Exception: Имя записи не стандартная");
        }
        else
        {
          return this.name;
        }
      }
      set
      {
        if (string.IsNullOrEmpty(value))
        {
          throw new ArgumentNullException("Имя абонента не должно быть пустым");
        }
        else
        {
          this.name = value;
        }

      }
    }
    /// <summary>
    /// Обращение к текстовому файлу.
    /// </summary>
    public void WriteEmployee()
    {
      using (StreamWriter sw = File.AppendText("Phonebook.txt"))
      {
        sw.WriteLine($"{this.Name}\t{this.Phone}");
        sw.Close();
      }
    }
    

  }
}
