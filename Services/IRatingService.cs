using final_project.ViewModels;

namespace final_project.Services
{
    public interface IRatingService
    {
        Task<bool> SubmitRatingAsync(string customerId, SubmitRatingViewModel model);

        Task<StoreRatingSummaryViewModel> GetStoreRatingSummaryAsync(string storeId, string? currentCustomerId = null);
    }
}