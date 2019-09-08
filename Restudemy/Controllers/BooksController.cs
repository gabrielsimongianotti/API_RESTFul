using Microsoft.AspNetCore.Mvc;
using Restudemy.Business;
using Restudemy.Data.VO;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using Tapioca.HATEOAS;

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
        [SwaggerResponse((200), Type = typeof(List<BookVO>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_booksBusiness.FindAll());
        }

        [HttpGet("{id}")]
        [SwaggerResponse((200), Type = typeof(List<BookVO>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(int id)
        {
            var book = _booksBusiness.FindById(id);
            if (book == null) return NotFound();
            return Ok(book);
    
        }
        [HttpPost]
        [SwaggerResponse((201), Type = typeof(List<BookVO>))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody]BookVO books)
        {
            if (books == null) return BadRequest();
            return new ObjectResult(_booksBusiness.Create(books));
        }
        [HttpPut]
        [SwaggerResponse((202), Type = typeof(List<BookVO>))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody]BookVO books)
        {
            if (books == null) return BadRequest();
            return new ObjectResult(_booksBusiness.Update(books));
        }
        [HttpDelete("{id}")]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(int id)
        {
            _booksBusiness.Delete(id);
            return NoContent();
        }
    }
}