using Restudemy.Data.VO;
using System.Collections.Generic;

namespace Restudemy.Business
{
    public interface IBooksBusiness
    {
        BookVO Create(BookVO book);
        BookVO FindById(long id);
        List<BookVO> FindAll();
        BookVO Update(BookVO book);
        void Delete(long id);
    }
}
