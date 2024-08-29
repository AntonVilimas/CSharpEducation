using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask3._1
{
  internal class Phonebook
  {
    private List<Contact> contactList;
    /// <summary>
    /// Метод удаление записи
    /// </summary>
    /// <exception cref="ArgumentException">Вызов ошибки</exception>
    public void Delete()
    {
      if (SearchContact(out int indexContactList))
      {
        Console.WriteLine("Запись удалена успешно");
        contactList.RemoveAt(indexContactList);
      }
      else
      {
        throw new ArgumentException("Такой контакт не существует");
      }
    }
    /// <summary>
    /// Метод замены записи где поиск осуществляется по индексу записи так как запись двух мерный массив Имя и Номер
    /// </summary>
    public void Update()
    {
      if (SearchContact(out int indexContactList))
      {
        Console.WriteLine("Изменить имя - 1\nИзменить номер телефона - 2");
        string pin = Console.ReadLine();
        if (int.TryParse(pin, out int code) && (code == 1 || code == 2))
        {
          Console.Write("Введите новые данные ");
          string data = Console.ReadLine();
          if (code == 1)
          {
            Contact contact = contactList[indexContactList];
            contact.Name = data;
            contactList[indexContactList] = contact;
          }
          else
          {
            Contact contact = contactList[indexContactList];
            contact.Phone = data;
            contactList[indexContactList] = contact;
          }
        }
        else
        {
          Console.WriteLine("Не корректный запрос");
          Update();
        }
      }
      else
      {
        Console.WriteLine("Запись не найдена");
        Update();
      }

    }
    /// <summary>
    /// метод сохранения записи
    /// </summary>
    /// <exception cref="ArgumentException">Вызов ошибки</exception>
    public void Save()
    {
      Console.Write("Введите имя контакта: ");
      string Name = Console.ReadLine();
      Console.Write("Введите телефон контакта: ");
      string Phone= Console.ReadLine();
      Contact contact = new Contact();
      contact.Name = Name;
      contact.Phone = Phone;
       if (SearchContact(contact))
      {
        throw new ArgumentException("Такой контакт уже существует");
      }
      else
      {
      contactList.Add(contact); 
      }
    }
    /// <summary>
    /// Метод поиска записи
    /// </summary>
    public void Search ()
    {
      if (SearchContact(out int indexContactList))
      {
        Console.WriteLine($"Имя: {contactList[indexContactList].Name}\nТелефон: {contactList[indexContactList].Phone} ");
      }
      else
      {
        Console.WriteLine("Контакт не найден");
      }
    }
    /// <summary>
    /// Поиск записи с выводом индекса записи с проверкой если это long то это соответсвенно номер и обратное то это имя
    /// </summary>
    /// <param name="indexContactList">индекс записи </param>
    /// <returns></returns>
    /// <exception cref="ArgumentException">Вызов ошибки</exception>
    private bool SearchContact(out int indexContactList)
    {
      if (contactList.Any())
      {     
        Console.Write("Введите имя или номер контакта: ");
        string result = Console.ReadLine();
        if (long.TryParse(result, out long number))
        {
          for (int i = 0; i < contactList.Count; i++)
          {
            if (contactList[i].Phone == result)
            {
              indexContactList = i;
              return true;
            }
          }
          indexContactList = -1;
          return false;
        }
        else if(!string.IsNullOrEmpty(result))
        {
          for (int i = 0; i < contactList.Count; i++)
          {
            if (contactList[i].Name == result)
            {
              indexContactList = i;
              return true;
            }
          }
          indexContactList = -1;
          return false;
        }
        else
        {
          Console.WriteLine("Была передана пустая строка");
          throw new ArgumentException("Ашипка рукожоп");
        }
      }
      else
      {
        throw new ArgumentException("Список пуст");
      }

    }
    /// <summary>
    /// Отправка записи в контакт лист
    /// </summary>
    /// <param name="abonent">Переменная заначения абонента равная записи в контакт  листе </param>
    /// <returns></returns>
    private bool SearchContact(Contact abonent)
    {
        for (int i = 0; i < contactList.Count; i++)
        {
          if (contactList[i].Phone == abonent.Phone && contactList[i].Name == abonent.Name)
          {
            return true;
          }
        }
        return false;
    }
    /// <summary>
    /// Считывание контак листа содержащего масив из двух индексов Имя и Телефон с 0 и 1 индексом соотвественно
    /// </summary>
    private void ReadPhoneBook()
    {
      if (File.Exists("Phonebook.txt"))
      {
        using (StreamReader sr = File.OpenText("Phonebook.txt"))
        {
          string temp = sr.ReadLine();
          while (temp != "" && temp != null)
          {
            string[] ContactOk = temp.Split('\t');
            Contact Lonely = new Contact();
            Lonely.Name = ContactOk[0];
            Lonely.Phone = ContactOk[1];
            contactList.Add(Lonely);
            temp = sr.ReadLine();
          }
          sr.Close();
        }
      }
    }
    /// <summary>
    /// Сохраанение контак листа (записной книжки)
    /// </summary>
    public void SavePhoneBook()
    {
      if (contactList.Any())
      {
        for (int i = 0; i < contactList.Count; i++)
        {
          contactList[i].WriteEmployee();
        }
      }
      else
      {
        File.Create("Phonebook.txt");
        Console.WriteLine("Список пуст сохранен пустой фаил");
      }

    }
    public Phonebook()
    {
      contactList = new List<Contact>();
      ReadPhoneBook();
    }
  }
}
