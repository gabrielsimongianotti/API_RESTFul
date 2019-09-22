using Restudemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restudemy.Repository.Generic
{
    public interface IPersonRepository :IRepository<Person>
    {
        List<Person> FindByName(string firstName, string lastName);
    }
}
