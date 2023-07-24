using EMediceBE.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace EMediceBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        [Route("registration")]
        public IActionResult register([FromBody] Users users)
        {
            // Validate the user registration data
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Perform user registration logic using the DAL class

            DAL dal = new DAL();
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("myConnection").ToString()))
            {
                Response response = dal.register(users, connection);
                return Ok(response); // Return HTTP 200 OK with the response data
            }

        }
        [HttpPost]
        [Route("login")]
        public IActionResult login(Users users)
        { // Validate the user registration data
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Perform user registration logic using the DAL class

            DAL dal = new DAL();
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("myConnection").ToString()))
            {
                Response response = dal.login(users, connection);
                return Ok(response); // Return HTTP 200 OK with the response data
            }

        }
        [HttpPost]
        [Route("viewUser")]
        public IActionResult viewUser(Users users)
        {
            // Validate the user registration data
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Perform user registration logic using the DAL class

            DAL dal = new DAL();
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("myConnection").ToString()))
            {
                Response response = dal.viewUser(users, connection);
                return Ok(response); // Return HTTP 200 OK with the response data
            }

        }
        [HttpPost]
        [Route("updateProfile")]
        public IActionResult updateProfile(Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            DAL dal = new DAL();
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("myConnection").ToString()))
            {
                Response response = dal.viewUser(users, connection);
                return Ok(response); // Return HTTP 200 OK with the response data
            }
        }
    }

    }

