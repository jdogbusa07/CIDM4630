using System;
using System.Data;
using BuffTeksPackageSystem;

namespace BuffTeksPackageSystem
{
    public class GuiTier
    {
        private bool isRunning = true;

        private DataTier dataTier = new DataTier();
        private string loggedInResidentUsername = "";
        public Staff Login()
        {
            Staff staff = new Staff();

            Console.WriteLine("===== BuffTeks Package Management System =====");
            Console.Write("Enter your Username: ");
            staff.staff_username = Console.ReadLine();
            loggedInResidentUsername = staff.staff_username;


            Console.Write("Enter your Password: ");
            staff.staff_password = Console.ReadLine();

            return staff;
        }

        public int Dashboard(Staff staff)
        {
            Console.WriteLine("\n===== Dashboard =====");
            Console.WriteLine($"Welcome, {staff.staff_username}!");
            Console.WriteLine("1. View Package History");
            Console.WriteLine("2. Add a Package (Coming Soon)");
            Console.WriteLine("3. Mark Package as Picked Up (Coming Soon)");
            Console.WriteLine("4. Log Out");
            Console.Write("Select an option (1-4): ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    dataTier.ViewPackageHistory(loggedInResidentUsername);
                    break;

                case "2":
                    Console.WriteLine("Add a Package - Coming Soon");
                    break;

                case "3":
                    Console.WriteLine("Mark Package as Picked Up - Coming Soon");
                    break;

                case "4":
                    Console.WriteLine("Logging out...");
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Invalid option. Please choose 1-4.");
                    break;
            }

            return int.Parse(option);
        }

        public void DisplayPackageHistory(DataTable history)
        {
            Console.WriteLine("\n===== Package History =====");

            if (history.Rows.Count == 0)
            {
                Console.WriteLine("No package history found.");
                return;
            }

            foreach (DataRow row in history.Rows)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine($"Package ID:       {row["PackageID"]}");
                Console.WriteLine($"Carrier:          {row["Carrier"]}");
                Console.WriteLine($"Tracking Number:  {row["TrackingNumber"]}");
                Console.WriteLine($"Status:           {row["Status"]}");
                Console.WriteLine($"Received Date:    {row["ReceivedDate"]}");
                Console.WriteLine($"Picked Up Date:   {(row["PickedUpDate"] == DBNull.Value ? "Not picked up" : row["PickedUpDate"])}");
            }
            Console.WriteLine("------------------------------------");
        }
    }
}