using Microsoft.EntityFrameworkCore;
using final_project.Data;
using final_project.Models;
using final_project.Models.Enums;
using final_project.ViewModels;

namespace final_project.Services
{
    public class RatingService : IRatingService
    {
        private readonly ApplicationDbContext _context;

        public RatingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SubmitRatingAsync(string customerId, SubmitRatingViewModel model)
        {
            var storeExists = await _context.Stores
                .AnyAsync(s => s.AccountId == model.StoreId && s.ApprovalStatus == StoreApprovalStatus.Approved);

            var customerExists = await _context.Customers
                .AnyAsync(c => c.AccountId == customerId);

            if (!storeExists || !customerExists)
            {
                return false;
            }

            var existingRating = await _context.StoreRatings
                .FirstOrDefaultAsync(r => r.StoreId == model.StoreId && r.CustomerId == customerId);

            if (existingRating != null)
            {
                existingRating.Score = model.Score;
                existingRating.Comment = string.IsNullOrWhiteSpace(model.Comment) ? null : model.Comment.Trim();
                existingRating.UpdatedAt = DateTime.UtcNow;
            }
            else
            {
                var rating = new StoreRating
                {
                    StoreId = model.StoreId,
                    CustomerId = customerId,
                    Score = model.Score,
                    Comment = string.IsNullOrWhiteSpace(model.Comment) ? null : model.Comment.Trim()
                };

                _context.StoreRatings.Add(rating);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<StoreRatingSummaryViewModel> GetStoreRatingSummaryAsync(
            string storeId,
            string? currentCustomerId = null)
        {
            var ratings = await _context.StoreRatings
                .AsNoTracking()
                .Where(r => r.StoreId == storeId)
                .Include(r => r.Customer)
                .OrderByDescending(r => r.UpdatedAt ?? r.CreatedAt)
                .ToListAsync();

            var currentCustomerRating = currentCustomerId == null
                ? null
                : ratings.FirstOrDefault(r => r.CustomerId == currentCustomerId);

            return new StoreRatingSummaryViewModel
            {
                StoreId = storeId,
                TotalRatings = ratings.Count,
                AverageScore = ratings.Count > 0 ? Math.Round(ratings.Average(r => r.Score), 1) : 0.0,
                CurrentCustomerScore = currentCustomerRating?.Score,
                CurrentCustomerComment = currentCustomerRating?.Comment,
                Reviews = ratings.Select(r => new StoreReviewItemViewModel
                {
                    CustomerDisplayName = r.Customer.DisplayName,
                    Score = r.Score,
                    Comment = r.Comment,
                    CreatedAt = r.UpdatedAt ?? r.CreatedAt
                }).ToList()
            };
        }
    }
}