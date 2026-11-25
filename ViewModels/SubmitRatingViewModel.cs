using System.ComponentModel.DataAnnotations;

namespace final_project.ViewModels
{
    public class SubmitRatingViewModel
    {
        [Required]
        public string StoreId { get; set; } = string.Empty;

        [Required]
        [Range(1, 5, ErrorMessage = "Please select a rating between 1 and 5 stars.")]
        public int Score { get; set; }

        [MaxLength(1000, ErrorMessage = "Review comments cannot exceed 1000 characters.")]
        public string? Comment { get; set; }
    }
}