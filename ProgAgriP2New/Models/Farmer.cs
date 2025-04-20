namespace ProgAgriP2New.Models
{
    public class Farmer
    {
        public int FarmerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }

        // Navigation property
        public virtual ICollection<Product> Products { get; set; }
    }
}