using System.Data.SqlClient;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace EMediceBE.Models
{
    public class DAL
    {
        public Response register(Users users, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_register",connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@first_name", users.first_name);
            cmd.Parameters.AddWithValue("@last_name", users.last_name);
            cmd.Parameters.AddWithValue("@password", users.password);
            cmd.Parameters.AddWithValue("@email", users.email);
            cmd.Parameters.AddWithValue("@fund", 0);
            cmd.Parameters.AddWithValue("@type", "Pending");
            cmd.Parameters.AddWithValue("@type", "Users");
            connection.Open();

            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if(i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "User registered successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "User registration failed";
            }

            return response;
        }
        public Response login(Users users, SqlConnection connection)
        {
            SqlDataAdapter da = new SqlDataAdapter("sp_login", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@email", users.email);
            da.SelectCommand.Parameters.AddWithValue("@password", users.password);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response response = new Response();
            Users user = new Users();
            if (dt.Rows.Count > 0)
            {
                user.id = Convert.ToInt64(dt.Rows[0]["id"]);
                user.first_name = Convert.ToString(dt.Rows[0]["first_name"]);
                user.last_name = Convert.ToString(dt.Rows[0]["last_name"]);
                user.password = Convert.ToString(dt.Rows[0]["password"]);
                user.email = Convert.ToString(dt.Rows[0]["email"]);
                user.fund = Convert.ToDecimal(dt.Rows[0]["fund"]);
                user.type = Convert.ToString(dt.Rows[0]["type"]);
                user.created_on = Convert.ToDateTime(dt.Rows[0]["created_on"]);
                response.StatusCode = 200;
                response.StatusMessage = "User is valid";

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "User is invalid";
                response.user = null;
            }
            return response;
        }
        public Response viewUser(Users users, SqlConnection connection)
        {
            SqlDataAdapter da = new SqlDataAdapter("p_viewUser", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@id", users.id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response response = new Response();
            Users user = new Users();
            if(dt.Rows.Count > 0)
            {
                user.id = Convert.ToInt64(dt.Rows[0]["id"]);
                user.first_name = Convert.ToString(dt.Rows[0]["first_name"]);
                user.last_name = Convert.ToString(dt.Rows[0]["last_name"]);
                user.password = Convert.ToString(dt.Rows[0]["password"]);
                user.email = Convert.ToString(dt.Rows[0]["email"]);
                user.fund = Convert.ToDecimal(dt.Rows[0]["fund"]);
                user.type= Convert.ToString(dt.Rows[0]["type"]);
                user.created_on = Convert.ToDateTime(dt.Rows[0]["created_on"]);
                response.StatusCode = 200;
                response.StatusMessage = "User exists";
                response.user = user;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "User doesn't exist";
                response.user = null;
            }
            return response;
        }
        public Response updateProfile(Users users, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_update", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@first_name",users.first_name);
            cmd.Parameters.AddWithValue("@last_name", users.last_name);
            cmd.Parameters.AddWithValue("@password", users.password);
            cmd.Parameters.AddWithValue("@email", users.email);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if(i > 0)
            {
                response.StatusCode= 200;
                response.StatusMessage = "Record updated successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Record not updated ";
            }
            return response;    
        }
        public Response addToCart(Cart cart, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_AddToCart", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@user_id", cart.user_id);
            cmd.Parameters.AddWithValue("@unit_price", cart.unit_price);
            cmd.Parameters.AddWithValue("@discount", cart.discount);
            cmd.Parameters.AddWithValue("@quantity", cart.quantity);
            cmd.Parameters.AddWithValue("@total_price", cart.total_price);
            cmd.Parameters.AddWithValue("@medicine_id", cart.medicine_id);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Record updated successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Record not updated ";
            }
            return response;
        }
    }
}
