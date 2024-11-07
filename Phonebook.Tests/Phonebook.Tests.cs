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
      Subscriber sab1 = new Subscriber(guid1, "Batman", new List<PhoneNumber>());

      var subs = new List<Subscriber>() { sab1, sab1 };
      this.phonebook = new Phonebook(subs);
      Assert.Throws<InvalidOperationException>(()=> this.phonebook.GetSubscriber(guid1));
    }

    [Test]
    public void GetAll_WithEmptyListSubscriber_GetEmptyList()
    {
      Assert.Throws<NullReferenceException>(() => this.phonebook.GetAll());
    }

    [Test]
    public void GetAll_ListSubscriber_GetAllList()
    {
      string subscriberName = "Persona";
      Guid guid1 = Guid.Parse("DB13A0FA-6BAD-47B6-B557-54FE4FF3B663");
      Guid guid2 = Guid.Parse("DB13A0FA-6BAD-47B6-B557-54FE4FF3B663");
      var Pers1 = new Subscriber(guid1, subscriberName, new List<PhoneNumber>());
      var Pers2 = new Subscriber(guid2, subscriberName, new List<PhoneNumber>());
      List<Subscriber> listSubcribers = new List<Subscriber>() { Pers1, Pers2 };
      this.phonebook = new Phonebook(listSubcribers);

      Assert.That(this.phonebook.GetAll().Count, Is.EqualTo(2));
    }

    [Test]
    public void AddSubscriber_NewSubscriber_AddedSuccessfully()
    {
      Guid guid = Guid.Parse("852A3553-FAA0-40E4-BEBA-7D953C58AB9F");
      var expectedSubscriber = new Subscriber(guid, "Personal", new List<PhoneNumber>());
      this.phonebook.AddSubscriber(expectedSubscriber);

      Assert.That(this.phonebook.GetSubscriber(guid), Is.EqualTo(expectedSubscriber));
    }

    [Test]
    public void AddSubscriber_ReAdditionSubscriber_ThrowInvalidOperationException()
    {
      Guid subscriberId = Guid.Parse("20385F57-2CFE-41AF-8A0F-97FD71E12F92");
      string subscriberName = "Personal";
      var expectedSubscriber = new Subscriber(subscriberId, subscriberName, new List<PhoneNumber>());
      this.phonebook.AddSubscriber(expectedSubscriber);

      Assert.Throws<InvalidOperationException>(() => this.phonebook.AddSubscriber(expectedSubscriber));
    }
    
    [Test]
    public void AddNumberToSubscriber_AdditioValidingPhoneNumber_SubscriberReceivesPhoneNumber()
    {
      Guid subscriberId = Guid.Parse("CA225873-A14B-420E-AF89-A8C59D722777");
      string subscriberName = "Pascal";
      var expectedSubscriber = new Subscriber(subscriberId, subscriberName, new List<PhoneNumber>());
      this.phonebook.AddSubscriber(expectedSubscriber);
      PhoneNumber phoneNumber = new PhoneNumber("3332221113333", PhoneNumberType.Personal);
      phonebook.AddNumberToSubscriber(expectedSubscriber, phoneNumber);
      Assert.That(phonebook.GetSubscriber(subscriberId).PhoneNumbers[0], Is.EqualTo(phoneNumber));
    }

    [Test]
    public void AddNumberToSubscriber_DuplicationSubscribers_ThrowInvalidOperationException()
    {
      Guid subscriberId = Guid.Parse("3F3D9A4B-528B-45A9-A0D0-05539CE401F3");
      string subscriberName = "Hobbit";
      Subscriber expectedSubs = new Subscriber(subscriberId, subscriberName, new List<PhoneNumber>());
      List<Subscriber> listSubscriber = new List<Subscriber>()
      {
        expectedSubs, expectedSubs
      };
      this.phonebook = new Phonebook(listSubscriber);
      PhoneNumber phoneNumber = new PhoneNumber("99999999999999", PhoneNumberType.Personal);

      Assert.Throws<InvalidOperationException>(() => this.phonebook.AddNumberToSubscriber(expectedSubs, phoneNumber));
    }

    [Test]
    public void AddNumberToSubscriber_WithEmptySubscribers_ThrowNullReferenceException()
    {
      Subscriber expectedSubs = null!;
      PhoneNumber phoneNumber = new PhoneNumber("99999999999999", PhoneNumberType.Personal);

      Assert.Throws<NullReferenceException>(() => this.phonebook.AddNumberToSubscriber(expectedSubs, phoneNumber));
    }

    [Test]
    public void UpdateSubscriber_UpdateDataSubscriber_UpdateSuccessfully()
    {
      string subscriberName = "Shurup";
      Guid guid = Guid.Parse("29777CA3-C07D-4545-9328-6E87579AD014");
      var OldSub = new Subscriber(guid, subscriberName, new List<PhoneNumber>());
      this.phonebook.AddSubscriber(OldSub);
      Subscriber NewSub = new Subscriber(OldSub.Id, "Vintik", OldSub.PhoneNumbers);
      this.phonebook.UpdateSubscriber(OldSub, NewSub);

      Assert.That(this.phonebook.GetSubscriber(guid).Id, Is.EqualTo(OldSub.Id));
    }

    [Test]
    public void RenameSubscriber_ChangeNameSubcriber_SubscriberWillBecomIvan()
    {
      Guid subscriberId = Guid.Parse("29777CA3-C07D-4545-9328-6E87579AD084");
      var expectedSubscriber = new Subscriber(subscriberId, "Bulba", new List<PhoneNumber>());
      this.phonebook.AddSubscriber(expectedSubscriber);
      this.phonebook.RenameSubscriber(expectedSubscriber, "Kortoplia");

      Assert.That(this.phonebook.GetSubscriber(subscriberId).Name, Is.EqualTo("Ivan"));
    }
  }
}