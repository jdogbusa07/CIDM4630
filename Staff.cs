using System.ComponentModel.DataAnnotations;

namespace BuffTeksPackageSystem
{
    public class Staff
    {
        [Key]
        public string staff_username { get; set; } = string.Empty;
        public string staff_password { get; set; } = string.Empty;
    }
}
