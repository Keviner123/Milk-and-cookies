using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MNK.Controllers
{
    [Route("Controller2/GetCookie")]
    public class GetCookieTest : ControllerBase
    {
        [HttpGet]
        public string GetCookieValueTest()
        {
            //The cookie is unable to be read
            return (Request.Cookies["Controller1Cookie"]);
        }
    }

}
