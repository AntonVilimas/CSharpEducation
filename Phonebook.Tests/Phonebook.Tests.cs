using System.Security.Cryptography.X509Certificates;

namespace Phonebook.Tests
{
  public class Tests
  {
    private Phonebook phonebook;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
      this.phonebook = new Phonebook();
    }

    [TearDown]
    public void TearDown()
    {
      this.phonebook.ClearListSubscriber();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
      this.phonebook = null;
    }

    [Test]
    public void GetSubscriber_EmptyGuid_ArgumentNullException()
    {
      Guid guid = Guid.Empty;
      Assert.Throws<ArgumentNullException>(() => this.phonebook.GetSubscriber(guid)); 
    }

    [Test]
    public void GetSubscriber_RepetitivGuid_InvalidOperation()
    {
      Guid guid1 = Guid.Parse("08A5FE60-2F76-4AAE-A9A4-22D286C357DF");
      Subscriber sab1 = new Subscriber(guid1, "dyhyh", new List<PhoneNumber>());

      var subs = new List<Subscriber>() { sab1, sab1 };
      this.phonebook = new Phonebook(subs);
      Assert.Throws<InvalidOperationException>(()=> this.phonebook.GetSubscriber(guid1));
    }

  }
}