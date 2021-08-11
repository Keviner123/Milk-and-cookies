using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MNK.Controllers
{
    [ApiController]
    [Route("api/SetCookie")]
    public class SetCookie : ControllerBase
    {
        [HttpGet]
        public string SetCookieValue(string favoritemilkshake)
        {
            //Set a cookie for the users favoritemilkshake

            CookieOptions co = new CookieOptions();
            co.Expires = new DateTimeOffset(DateTime.Now.AddMinutes(5));

            Response.Cookies.Append("favoritemilkshake", favoritemilkshake, co);
            return (favoritemilkshake);
        }
    }

    [Route("api/GetCookie")]
    public class GetCookie : ControllerBase
    {

        [HttpGet]
        public string GetCookieValue()
        {
            //Reads a cookie for the users favoritemilkshake
            if(Request.Cookies["favoriteMilkshake"] != null) {
                return (Request.Cookies["favoriteMilkshake"]);
            }
            else
            {
                return ("We dont know what your favorite milkshake is :(");
            }
        }
    }


    [Route("api/RemoveCookie")]
    public class RemoveCookie : ControllerBase
    {

        [HttpGet]
        public string RemoveCookieValue()
        {
            //Set a cookie for the users favoritemilkshake

            CookieOptions co = new CookieOptions();
            co.Expires = new DateTimeOffset(DateTime.Now.AddDays(-1));

            Response.Cookies.Append("favoritemilkshake", "", co);
            return ("Cookie removed");
        }
    }
}
