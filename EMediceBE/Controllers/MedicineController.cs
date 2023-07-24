
using EMediceBE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace EMediceBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public MedicineController(IConfiguration configuration)
        {
                _configuration = configuration;
        }
        [HttpPost]
        [Route("addToCart")]
        public IActionResult addToCart(Cart cart)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            DAL dal = new DAL();
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("myConnection").ToString()))
            {
                Response response = dal.addToCart(cart, connection);
                return Ok(response);
            }
        }
        [HttpPost]
        [Route("updateProfile")]
        public IActionResult placeOrder(Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            DAL dal = new DAL();
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("myConnection").ToString()))
            {
                Response response = dal.placeOrder(users, connection);
                return Ok(response); // Return HTTP 200 OK with the response data
            }
        }
        [HttpGet]
        [Route("orderList")]
        public IActionResult orderList(Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            DAL dal = new DAL();
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("myConnection").ToString()))
            {
                Response response = dal.orderList(users, connection);
                return Ok(response); // Return HTTP 200 OK with the response data
            }
        }
    }
}
