using Microsoft.AspNetCore.Mvc;
using Restudemy.Model;
using Restudemy.Business;
using Restudemy.Data.VO;
using Tapioca.HATEOAS;

namespace Restudemy.Controllers
{
    
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{vesion:apiVersion}")]
    public class PersonsController : ControllerBase
    {
        private IPersonBusiness _personBusiness;

        //private readonly BooksController _converter;

        public PersonsController(IPersonBusiness personBusiness)
        {
            _personBusiness = personBusiness;
        }
        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }
        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(int id)
        {
            var person = _personBusiness.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }
        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody]PersonVO person)
        {
            if(person ==null) return BadRequest();
            if (_personBusiness.Exists(person.Id) ) return BadRequest();
            return new ObjectResult(_personBusiness.Create(person));
        }
        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody]PersonVO person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personBusiness.Update(person));
        }
        [HttpDelete("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(int id)
        { 
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}