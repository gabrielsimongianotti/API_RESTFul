using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restudemy.Business;
using Restudemy.Model;

namespace Restudemy.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{vesion:apiVersion}")]
    public class BooksController : Controller
    {
        private IBooksBusiness _booksBusiness;

        public BooksController(IBooksBusiness booksBusiness)
        {
            _booksBusiness = booksBusiness;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_booksBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var book = _booksBusiness.FindById(id);
            if (book == null) return NotFound();
            return Ok(book);
    
        }
        [HttpPost]
        public IActionResult Post([FromBody]Book books)
        {
            if (books == null) return BadRequest();
            return new ObjectResult(_booksBusiness.Create(books));
        }
        [HttpPut]
        public IActionResult Put([FromBody]Book books)
        {
            if (books == null) return BadRequest();
            return new ObjectResult(_booksBusiness.Update(books));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _booksBusiness.Delete(id);
            return NoContent();
        }
    }
}