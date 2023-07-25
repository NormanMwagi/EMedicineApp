
using EMediceBE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace EMediceBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AdminController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        [Route("addUpdateMedicine")]
        public IActionResult addUpdateMedicine(Medicines medicines)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            DAL dal = new DAL();
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("myConnection").ToString()))
            {
                Response response = dal.addUpdateMedicine(medicines, connection);
                return Ok(response); // Return HTTP 200 OK with the response data
            }
        }
        [HttpGet]
        [Route("userList")]
        public IActionResult userList()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            DAL dal = new DAL();
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("myConnection").ToString()))
            {
                Response response = dal.userList(connection);
                return Ok(response); // Return HTTP 200 OK with the response data
            }
        }
    }
}
