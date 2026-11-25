
using final_project.Models.Enums;

namespace final_project.Models
{
    public class Store
    {
        public string AccountId { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? CoverImageUrl { get; set; }

        public int? StallNumber { get; set; }

        public StoreApprovalStatus ApprovalStatus { get; set; }
            = StoreApprovalStatus.Pending;

        public string? RejectionReason { get; set; }

        public DateTime? ReviewedAt { get; set; }

        public string? ReviewedByAccountId { get; set; }

        public Account Account { get; set; } = null!;

        public Account? ReviewedBy { get; set; }

        public ICollection<StoreCategory> StoreCategories { get; set; }
            = new List<StoreCategory>();

        public ICollection<Item> Items { get; set; } = new List<Item>();

        public ICollection<StoreRating> Ratings { get; set; } = new List<StoreRating>();

        public ICollection<StoreHour> StoreHours { get; set; } = new List<StoreHour>();

    }
}
