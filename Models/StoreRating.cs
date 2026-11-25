using System.ComponentModel.DataAnnotations;

namespace final_project.Models
{
    public class StoreRating
    {
        public long Id { get; set; }

        public string StoreId { get; set; } = string.Empty;

        public string CustomerId { get; set; } = string.Empty;

        [Range(1, 5)]
        public int Score { get; set; }

        [MaxLength(1000)]
        public string? Comment { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        public Store Store { get; set; } = null!;

        public Customer Customer { get; set; } = null!;
    }
}