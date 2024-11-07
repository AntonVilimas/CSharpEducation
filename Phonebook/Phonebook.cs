using System;
using System.Collections.Generic;
using System.Linq;

namespace Phonebook
{
  /// <summary>
  /// Телефонная книга.
  /// </summary>
  public class Phonebook
  {
    #region Поля и свойства

    /// <summary>
    /// Абоненты в книге.
    /// </summary>
    private readonly List<Subscriber> phonebook;

    #endregion

    #region Методы

    /// <summary>
    /// Получить абонента из книги.
    /// </summary>
    /// <param name="id">ИД абонента.</param>
    /// <returns>Найденный абонент в книге.</returns>
    public Subscriber GetSubscriber(Guid id)
    {
      if (this.phonebook.Any()) 
      {
        if (id != Guid.Empty)
        {
          if (this.phonebook.Count(s => s.Id == id) < 2)
            return this.phonebook.Single(s => s.Id == id);
          else
            throw new InvalidOperationException("Повторяющиеся АЙДИ");
        }
        else 
          throw new ArgumentNullException("Пустой АЙДИ");
      }
      else
        throw new ArgumentNullException("Пустой список");
    }

    /// <summary>
    /// Получить всех абонентов.
    /// </summary>
    /// <returns>Список всех абонентов.</returns>
    public IEnumerable<Subscriber> GetAll()
    {
      if (this.phonebook.Any())
      {
        return this.phonebook;
      }
      else
        throw new NullReferenceException("Список пуст");
    }

    /// <summary>
    /// Добавить абонента в книгу.
    /// </summary>
    /// <param name="subscriber">Абонент, которого нужно добавить.</param>
    /// <exception cref="InvalidOperationException">Возникает, если абонент уже существует в книге.</exception>
    public void AddSubscriber(Subscriber subscriber)
    {
      if (subscriber != null)
      {
        if (this.phonebook.Contains(subscriber) && this.phonebook.Where(s => s.Id == subscriber.Id).ToList().Count != 0)
          throw new InvalidOperationException("Unable to add subscriber. Subscriber exists");

        if (subscriber.PhoneNumbers != null)
          PhoneNumberValidator.ValidateList(subscriber.PhoneNumbers);

        this.phonebook.Add(subscriber);
      }
      else
        throw new ArgumentNullException($"Подписчик {subscriber} не заполнен");
    }

    /// <summary>
    /// Добавить номер для абонента.
    /// </summary>
    /// <param name="subscriber">Абонент, которому нужно добавить номер.</param>
    /// <param name="number">Добавляемый номер абонента.</param>
    public void AddNumberToSubscriber(Subscriber subscriber, PhoneNumber number)
    {
      if (this.phonebook.Any())
      {
        if (!string.IsNullOrEmpty(number.Number))
        {
          PhoneNumberValidator.Validate(number);
          if (this.phonebook.Single(s => s.Id == subscriber.Id).Equals(subscriber))
          {
            var newNumbers = new List<PhoneNumber>(subscriber.PhoneNumbers)
          {
              number
          };
            var subscriberWithNewNumber = new Subscriber(subscriber.Id, subscriber.Name, newNumbers);

            this.UpdateSubscriber(subscriber, subscriberWithNewNumber);
          }
          else
            throw new ArgumentException($"Такой подподписчик {subscriber.Name} отсутсвует");
        }
        else throw new ArgumentException("Новый номер телефона не указан");
      }
      else
        throw new NullReferenceException("Список пуст");
    }

    /// <summary>
    /// Сменить имя абонента.
    /// </summary>
    /// <param name="subscriber">Абонент, которому нужно сменить имя.</param>
    /// <param name="newName">Новое имя абонента.</param>
    public void RenameSubscriber(Subscriber subscriber, string newName)
    {
      var subscriberWithNewName = new Subscriber(subscriber.Id, newName, subscriber.PhoneNumbers);

      this.UpdateSubscriber(subscriber, subscriberWithNewName);
    }

    /// <summary>
    /// Обновить абонента в книге.
    /// </summary>
    /// <param name="oldSubscriber">Старый абонент.</param>
    /// <param name="newSubscriber">Новый абонент.</param>
    public void UpdateSubscriber(Subscriber oldSubscriber, Subscriber newSubscriber)
    {
      var foundSubscriber = this.GetSubscriber(oldSubscriber.Id);
      int foundSubscriberPlace = this.phonebook.FindIndex(s => s.Id == foundSubscriber.Id);
      this.phonebook[foundSubscriberPlace] = newSubscriber;
    }

    /// <summary>
    /// Удалить абонента в книге.
    /// </summary>
    /// <param name="subscriberToDelete">Абонент, которого нужно удалить из книги.</param>
    public void DeleteSubscriber(Subscriber subscriberToDelete)
    {
      this.phonebook.Remove(subscriberToDelete);
    }

    /// <summary>
    /// Очистка телефонной книги
    /// </summary>
    public void ClearListSubscriber()
    {
      this.phonebook.Clear();
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    public Phonebook()
        : this(new List<Subscriber>())
    {
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="subscribers">Список абонентов для инициализации книги.</param>
    public Phonebook(List<Subscriber> subscribers)
    {
      this.phonebook = subscribers;
    }

    #endregion
  }
}