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
        Cart cart = new Cart();
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

        // Add an item to the cart
        public void AddItem(Item item, int quantity)
        {

            if (item != null && quantity > 0 && item.Stock >= quantity)
            {

                if (Items.ContainsKey(item))
                {
                    int currQuant = Items[item].Item1 + quantity;
                    Items[item] = Tuple.Create(currQuant, currQuant * item.Price);
                }
                else
                {
                    Items.Add(item, Tuple.Create(quantity, quantity * item.Price));
                }
            }
        }

        // Remove an item from the cart
        public void RemoveItem(Item item, int quantity)
        {

            if (item != null && quantity > 0)
            {

                if (Items.ContainsKey(item))
                {
                    int currQuant = Items[item].Item1;
                    if (currQuant > quantity)
                    {
                        currQuant -= quantity;
                        Items[item] = Tuple.Create(currQuant, currQuant * item.Price);
                    }
                    else
                    {
                        Items.Remove(item);
                    }
                }
            }
        }
    }
}
