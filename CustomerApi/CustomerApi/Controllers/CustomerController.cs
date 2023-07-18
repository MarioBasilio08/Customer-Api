using CustomerApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public readonly PruebaContext _bdContext;

        public CustomerController(PruebaContext bdContext)
        {
            _bdContext = bdContext;
        }

        [HttpGet]
        [Route("GetList")]
        public IActionResult GetList()
        {
            List<Customer> lista = new List<Customer>();
            try
            {
                lista = _bdContext.Customers.ToList();

                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = lista });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message, response = lista });

            }
        }

        [HttpGet]
        [Route("GetById/{idCustomer:int}")]
        public IActionResult GetById(int idCustomer)
        {
            Customer oCustomer = _bdContext.Customers.Find(idCustomer);

            if (oCustomer == null)
            {
                return BadRequest("Producto no encontrado");
            }
            try
            {
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = oCustomer });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message, response = oCustomer });

            }
        }

        [HttpPost]
        [Route("Save")]
        public IActionResult Save([FromBody] Customer obj)
        {
            try
            {
                _bdContext.Customers.Add(obj);
                _bdContext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { message = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] Customer obj)
        {
            Customer oCustomer = _bdContext.Customers.Find(obj.Id);

            if (oCustomer == null)
            {
                return BadRequest("Producto no encontrado");
            }

            try
            {
                _bdContext.Entry(oCustomer).CurrentValues.SetValues(obj);
                _bdContext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { message = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            Customer oCustomer = _bdContext.Customers.Find(id);

            if (oCustomer == null)
            {
                return NotFound("Cliente no encontrado");
            }

            try
            {
                _bdContext.Customers.Remove(oCustomer);
                _bdContext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { message = "Cliente eliminado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

    }
}
