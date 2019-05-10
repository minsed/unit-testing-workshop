using UnitTesting.Database.Interfaces;

namespace UnitTesting.Database.Models
{
    public class Person : IPerson
    {
        public Person(long id, string username)
        {
            Id = id;
            Username = username;
        }

        public long Id { get; }
        public string Username { get; }
    }
}
