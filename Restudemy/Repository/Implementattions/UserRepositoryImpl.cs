using Restudemy.Model;
using Restudemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restudemy.Repository.Implementattions
{
    public class UserRepositoryImpl :IUserRepository
    {
        private MySQLContext _context;

        public UserRepositoryImpl(MySQLContext context)
        {
            _context = context;
        }

        public User FindByLogin(string login)
        {
            return _context.Users.SingleOrDefault(u => u.Login.Equals(login));
        }
   
    }
}
