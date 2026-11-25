namespace final_project.ViewModels
{
    public class StoreRatingSummaryViewModel
    {
        public string StoreId { get; set; } = string.Empty;

        public double AverageScore { get; set; }

        public int TotalRatings { get; set; }

        public int? CurrentCustomerScore { get; set; }

        public string? CurrentCustomerComment { get; set; }

        public List<StoreReviewItemViewModel> Reviews { get; set; } = new();
    }

    public class StoreReviewItemViewModel
    {
        public string CustomerDisplayName { get; set; } = string.Empty;

        public int Score { get; set; }

        public string? Comment { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}