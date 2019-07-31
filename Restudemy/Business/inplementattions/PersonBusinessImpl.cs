﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Restudemy.Model;
using Restudemy.Model.Context;
using Restudemy.Repository;
using Restudemy.Repository.Generic;

namespace Restudemy.Business.inplementattions
{
    public class PersonBusinessImpl : IPersonBusiness
    {
        private IRepository<Person> _repository;

        public PersonBusinessImpl(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public bool Exists(long? id)
        {
            return _repository.Exists(id);
        }
    }
}
