using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using BuffTeksPackageSystem;


class DataTier
{
    public string connStr = "server=34.69.59.37;user=jrlemmon1;database=jrlemmon1;port=8080;password=jrlemmon1";

    public bool LoginCheck(Staff staff)
    {
        MySqlConnection conn = new MySqlConnection(connStr);
        try
        {
            conn.Open();
            string procedure = "LoginCount";
            MySqlCommand cmd = new MySqlCommand(procedure, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@inputUsername", staff.staff_username);
            cmd.Parameters.AddWithValue("@inputPassword", staff.staff_password);
            cmd.Parameters.Add("@userCount", MySqlDbType.Int32).Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            int returnCount = (int)cmd.Parameters["@userCount"].Value;
            conn.Close();

            return returnCount == 1;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            conn.Close();
            return false;
        }
    }

    public DataTable GetPackageHistoryForResident(Staff staff)
    {
        MySqlConnection conn = new MySqlConnection(connStr);
        try
        {
            conn.Open();
            string procedure = "GetPackageHistory";
            MySqlCommand cmd = new MySqlCommand(procedure, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@inputResidentID", staff.staff_username);

            MySqlDataReader rdr = cmd.ExecuteReader();
            DataTable packageHistoryTable = new DataTable();
            packageHistoryTable.Load(rdr);
            rdr.Close();
            conn.Close();

            return packageHistoryTable;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            conn.Close();
            return null;
        }
    }
    public void ViewPackageHistory(string residentUsername)
    {
        using var conn = new MySqlConnection(connStr);
        conn.Open();
        string query = @"SELECT tracking_number, carrier, delivery_date, pickup_date 
                     FROM ResidentPackageHistory 
                     WHERE resident_username = @username";

        using var command = new MySqlCommand(query, conn);
        command.Parameters.AddWithValue("@username", residentUsername);

        using var reader = command.ExecuteReader();

        Console.WriteLine("=== Package History ===");
        while (reader.Read())
        {
            string tracking = reader.GetString("tracking_number");
            string carrier = reader.GetString("carrier");
            DateTime delivered = reader.GetDateTime("delivery_date");
            string pickup = reader.IsDBNull("pickup_date") ? "Not Picked Up" : reader.GetDateTime("pickup_date").ToShortDateString();

            Console.WriteLine($"Tracking #: {tracking}, Carrier: {carrier}, Delivered: {delivered.ToShortDateString()}, Pickup: {pickup}");
        }
    }
}
