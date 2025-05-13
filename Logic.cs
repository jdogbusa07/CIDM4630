using System.Data;
using MySql.Data.MySqlClient;
using BuffTeksPackageSystem;


class Logic
{
    static void Main(string[] args)
    {
        bool _continue = true;
        Staff staff;
        GuiTier appGUI = new GuiTier();
        DataTier database = new DataTier();

        // Start GUI and login
        staff = appGUI.Login();

        if (database.LoginCheck(staff))
        {
            while (_continue)
            {
                int option = appGUI.Dashboard(staff);
                switch (option)
                {
                    // View Package History
                    case 1:
                        DataTable history = database.GetPackageHistoryForResident(staff);
                        if (history != null)
                            appGUI.DisplayPackageHistory(history);
                        else
                            Console.WriteLine("No package history found or an error occurred.");
                        break;

                    // Add a Package (Placeholder)
                    case 2:
                        Console.WriteLine("Add Package feature coming soon.");
                        break;

                    // Mark Package as Picked Up (Placeholder)
                    case 3:
                        Console.WriteLine("Pickup Package feature coming soon.");
                        break;

                    // Log Out
                    case 4:
                        _continue = false;
                        Console.WriteLine("Logged out. Goodbye!");
                        break;

                    // Default: Invalid input
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            }
        }
        else
        {
            Console.WriteLine("Login failed. Goodbye.");
        }
    }
}
