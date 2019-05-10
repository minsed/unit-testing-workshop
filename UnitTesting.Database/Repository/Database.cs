using System;
using System.Collections.Generic;
using System.Linq;
using UnitTesting.Database.Interfaces;

namespace UnitTestingWorkshop.Database.Repository
{
    public class Database
    {
        private readonly HashSet<IPerson> _people;

        public Database()
        {
            _people = new HashSet<IPerson>();
        }

        public Database(IEnumerable<IPerson> people) : this()
        {
            if (people != null)
            {
                foreach (var person in people)
                {
                    Add(person);
                }
            }
        }

        public int Count => _people.Count;

        public void Add(IPerson person)
        {
            if (_people.Any(p => p.Id == person.Id || p.Username == person.Username))
            {
                throw new InvalidOperationException();
            }

            _people.Add(person);
        }

        public void Remove(IPerson person)
        {
            _people.RemoveWhere(p => p.Id == person.Id && p.Username == person.Username);
        }

        public IPerson Find(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var foundPerson = _people.FirstOrDefault(p => p.Id == id);
            if (foundPerson == null)
            {
                throw new InvalidOperationException();
            }

            return foundPerson;
        }

        public IPerson Find(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException();
            }

            var foundPerson = _people.FirstOrDefault(p => p.Username == username);
            if (foundPerson == null)
            {
                throw new InvalidOperationException();
            }

            return foundPerson;
        }
    }
}
