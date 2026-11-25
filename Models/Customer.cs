
namespace final_project.Models
{
    public class Customer
    {
        public string AccountId { get; set; } = string.Empty;

        public string DisplayName { get; set; } = string.Empty;

        public Account Account { get; set; } = null!;

        public ICollection<StoreRating> Ratings { get; set; } = new List<StoreRating>();
    }
}
