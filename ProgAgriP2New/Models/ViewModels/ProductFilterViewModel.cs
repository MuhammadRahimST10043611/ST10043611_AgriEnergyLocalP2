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
        public string SortOrder { get; set; } = "desc"; // Default sort order is newest first
        public int PageSize { get; set; } = 20;
        public int CurrentPage { get; set; } = 1;
        public int TotalItems { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalItems / (double)PageSize);
        public List<int> PageSizeOptions { get; set; } = new List<int> { 20, 50, 100 };
    }
}