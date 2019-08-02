using Restudemy.Data.VO;
using System.Collections.Generic;

namespace Restudemy.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindById(long id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO person);
        void Delete(long id);
        bool Exists(long? id); 
    }
}
