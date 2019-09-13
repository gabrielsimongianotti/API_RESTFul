using Microsoft.AspNetCore.Mvc;
using Restudemy.Model;
using Restudemy.Business;
using Microsoft.AspNetCore.Authorization;
using Restudemy.Data.VO;

namespace Restudemy.Controllers
{

    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{vesion:apiVersion}")]
    public class LoginController : ControllerBase
    {
        private ILoginBusiness _loginBusiness;

        //private readonly BooksController _converter;

        public LoginController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }

        [AllowAnonymous]
        [HttpPost]
        public object Post([FromBody]UserVO user)
        {
            if(user == null) return BadRequest();
            return _loginBusiness.FindByLogin(user);
        }
      
    }
}