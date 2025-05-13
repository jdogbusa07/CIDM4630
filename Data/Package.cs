namespace BuffTeksPackageSystem
{
    public class Package
    {
        public int PackageId { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime ReceivedDate { get; set; }
        public bool PickedUp { get; set; }

        public int ResidentId { get; set; }
        public Resident Resident { get; set; }
    }
}
