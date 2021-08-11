using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MNK.Controllers
{
    [Route("Controller1/SetCookie")]
    public class SetCookieTest : ControllerBase
    {
        [HttpGet]
        public string SetCookieValue()
        {
            CookieOptions co = new CookieOptions();
            co.Expires = new DateTimeOffset(DateTime.Now.AddMinutes(5));
            co.Path = "/Controller1";

            Response.Cookies.Append("Controller1Cookie", "CookieContent", co);
            return ("Success");
        }
    }

}
