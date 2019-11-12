using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using OrdersAPI.Repositories;
using OrdersAPI.Models;


namespace OrdersAPI.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        
        public IOrderRepository Orders { get; set; }

        public OrdersController(IOrderRepository orders)   
        {
            Orders = orders;
        }
               

        #region POST
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ClientOrder order)
        {
            OrderResult result = new OrderResult();

            try
            {
                string id = await Orders.Add(order);

                if (id != null)
                {
                    result.Id = id;
                }

                //Return a HTTP 200 with the created id
                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        #endregion


        #region GET
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {

            var order = Orders.Find(id);

            if (order == null)
            {
                return NotFound();
            }


            return Ok(order);
        }
        #endregion

        
        #region PUT
        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody]ClientOrder order)
        {
            try
            {
         
                string result = await Orders.Update(id, order);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok("Order updated");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        #endregion


        #region DELETE
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                string result = await Orders.Remove(id);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok("Order deleted");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        #endregion

    }
}
