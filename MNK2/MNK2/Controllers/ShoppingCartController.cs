using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MNK2.Controllers
{
    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key,
       object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) :
           JsonConvert.DeserializeObject<T>(value);
        }
    }



    [ApiController]
    [Route("api/AppendToShoppingCart")]
    public class AppendToShoppingCart : ControllerBase
    {

        // GET api/values
        [HttpGet]
        public IEnumerable<Produkt> Get(string Name, int Price)
        {
            List<Produkt> UserCart;

            //Check if the user has a shopping cart
            if (HttpContext.Session.GetObjectFromJson<List<Produkt>>("ShoppingCart") != null)
            {
                UserCart = HttpContext.Session.GetObjectFromJson<List<Produkt>>("ShoppingCart");
            }
            else
            {
                UserCart = new List<Produkt>();
            }

            //Create a product object to store the neccecary details and append
            var UserProduct = new Produkt();
            UserProduct.Name = Name;
            UserProduct.Price = Price;
            UserCart.Add(UserProduct);

            //Save the shoppingcart object to the session
            HttpContext.Session.SetObjectAsJson("ShoppingCart", UserCart);
            return (UserCart);


        }
    }


    [Route("api/RemoveFromShoppingCart")]
    public class RemoveFromShoppingCart : ControllerBase
    {

        // GET api/values
        [HttpGet]
        public IEnumerable<Produkt> Get(string Name)
        {
            List<Produkt> UserCart;

            //Get the users shopping cart
            UserCart = HttpContext.Session.GetObjectFromJson<List<Produkt>>("ShoppingCart");

            //Remove all instances of a product
            UserCart.RemoveAll(x => x.Name == Name);


            //Save the shoppingcart object to the session
            HttpContext.Session.SetObjectAsJson("ShoppingCart", UserCart);
            return (UserCart);
        }
    }
}
