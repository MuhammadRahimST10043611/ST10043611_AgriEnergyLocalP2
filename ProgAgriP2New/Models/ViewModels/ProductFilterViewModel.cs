namespace ProgAgriP2New.Models.ViewModels
{
    public class ProductFilterViewModel
    {
        public int? FarmerId { get; set; }
        public string? Category { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();
        public List<Farmer> Farmers { get; set; } = new List<Farmer>();
        public List<string> Categories { get; set; } = new List<string>();
    }
}