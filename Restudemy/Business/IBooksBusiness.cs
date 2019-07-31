using Restudemy.Model;
using System.Collections.Generic;

namespace Restudemy.Business
{
    public interface IBooksBusiness
    {
        Book Create(Book book);
        Book FindById(long id);
        List<Book> FindAll();
        Book Update(Book book);
        void Delete(long id);
    }
}
