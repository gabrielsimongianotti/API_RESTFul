using Restudemy.Model;
using Restudemy.Model.Context;
using Restudemy.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restudemy.Repository.Implementattions
{
    public class PersonRepositoryImpl : GenericRepository <Person>, IPersonRepository
    {
        public PersonRepositoryImpl(MySQLContext context): base(context){}

        public List<Person> FindByName(string firstName, string lastName)
        {
            if ((!string.IsNullOrEmpty(firstName)) && !string.IsNullOrEmpty(lastName))
            {
                return _context.Persons.Where(p => p.FirstName.Equals(firstName) && p.LastName.Equals(lastName)).ToList();
            }
            else if ((string.IsNullOrEmpty(firstName)) && !string.IsNullOrEmpty(lastName))
            {
                return _context.Persons.Where(p => p.LastName.Equals(lastName)).ToList();
            }
            else if ((string.IsNullOrEmpty(firstName)) && string.IsNullOrEmpty(lastName))
            {
                return _context.Persons.Where(p => p.LastName.Equals(firstName)).ToList();
            }
            else 
            {
                return _context.Persons.ToList();
            }
        }
    }
}
