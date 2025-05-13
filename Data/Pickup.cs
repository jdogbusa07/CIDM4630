namespace BuffTeksPackageSystem
{
    public class Pickup
    {
        public int PickupId { get; set; }
        public DateTime PickupDate { get; set; }

        public int ResidentId { get; set; }
        public Resident Resident { get; set; }

        public int PackageId { get; set; }
        public Package Package { get; set; }
    }
}
