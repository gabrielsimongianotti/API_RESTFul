using Restudemy.Data.VO;

using System.Collections.Generic;
using Tapioca.HATEOAS.Utils;

namespace Restudemy.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PagedSearchDTO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);
        PersonVO FindById(long id);
        List<PersonVO> FindAll();
        List<PersonVO> FindByName(string firstName, string lastName);
        PersonVO Update(PersonVO person);
        void Delete(long id);
        bool Exists(long? id); 
    }
}
