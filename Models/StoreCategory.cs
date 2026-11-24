namespace final_project.Models
{
    public class StoreCategory
    {
        public string StoreId { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        public Store Store { get; set; } = null!;

        public Category Category { get; set; } = null!;
    }
}