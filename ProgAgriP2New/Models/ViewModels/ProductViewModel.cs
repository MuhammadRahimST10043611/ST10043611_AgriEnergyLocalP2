namespace ProgAgriP2New.Models.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public int FarmerId { get; set; }
        public string FarmerName { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public DateTime ProductionDate { get; set; }
    }
}