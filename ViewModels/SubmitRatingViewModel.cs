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

        [MaxLength(500, ErrorMessage = "Review comments cannot exceed 500 characters.")]
        public string? Comment { get; set; }
    }
}