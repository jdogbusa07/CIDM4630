namespace BuffTeksPackageSystem
{
    public class Resident
    {
        public int ResidentId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public int UnitNumber { get; set; }

        public List<Package> Packages { get; set; }
        public List<Pickup> Pickups { get; set; }
    }
}
