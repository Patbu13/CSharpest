using Microsoft.AspNetCore.Mvc;
using CSharpest.Classes;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CSharpest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        Cart cart = new Cart(0);
        // GET: api/<CartController>
        [HttpGet("GetCartItems")]
        public Dictionary<Item, Tuple<int, decimal>> GetCartItems()
        {
            Dictionary < Item, Tuple<int, decimal> > cartItems = cart.Items;
            return cartItems;
        }

        // GET api/<CartController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CartController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CartController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CartController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
