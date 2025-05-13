using MySql.Data.MySqlClient;
using System;
using System.Data;
using BuffTeksPackageSystem;


public class AuthenticateUser
{
    public string connStr = "server=34.69.59.37;user=jrlemmon1;database=jrlemmon1;port=8080;password=jrlemmon1";
    public bool LoginCheck(Staff staff)
    {
        MySqlConnection conn = new MySqlConnection(connStr);
        try
        {
            conn.Open();
            string procedure = "LoginCount";  // Ensure this matches your stored procedure name exactly
            MySqlCommand cmd = new MySqlCommand(procedure, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // Ensure the parameter names match exactly what the stored procedure expects
            cmd.Parameters.AddWithValue("@inputUsername", staff.staff_username);
            cmd.Parameters.AddWithValue("@inputPassword", staff.staff_password);

            // Output parameter to capture result from stored procedure
            cmd.Parameters.Add("@userCount", MySqlDbType.Int32).Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery(); // Execute stored procedure

            int returnCount = (int)cmd.Parameters["@userCount"].Value;  // Get output parameter value
            conn.Close();

            return returnCount == 1;  // Check if login is successful
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());  // Log the exception
            conn.Close();
            return false;
        }
    }
}