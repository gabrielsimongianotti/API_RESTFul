using Restudemy.Data.Converter;
using Restudemy.Data.VO;
using Restudemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restudemy.Data.Converters
{
    public class BookConverter : IBook<BookVO, Book>, IBook<Book, BookVO>
    {
        public BookVO Parse(Book origin)
        {
            if (origin == null) return new BookVO();
            return new BookVO
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = origin.Author,
                Price = origin.Price,
                LaunchDate = origin.LaunchDate
            };
        }

        public Book Parse(BookVO origin)
        {
            if (origin == null) return new Book();
            return new Book
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = origin.Author,
                Price = origin.Price,
                LaunchDate = origin.LaunchDate
            };
        }

        public List<BookVO> ParseList(List<Book> origin)
        {
            if (origin == null) return new List<BookVO>();
            return origin.Select(Item => Parse(Item)).ToList();
        }

        public List<Book> ParseList(List<BookVO> origin)
        {
            if (origin == null) return new List<Book>();
            return origin.Select(Item => Parse(Item)).ToList();
        }
    }
}
