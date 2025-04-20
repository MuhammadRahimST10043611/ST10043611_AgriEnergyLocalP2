namespace ProgAgriP2New.Models.ViewModels
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; } // "Farmer" or "Employee"
    }
}