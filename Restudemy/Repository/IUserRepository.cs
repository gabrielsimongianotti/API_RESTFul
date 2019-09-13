using Restudemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restudemy.Repository
{
    public interface IUserRepository
    {
        User FindByLogin(string login);
    }
}
