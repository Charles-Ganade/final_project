using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using final_project.Services;
using final_project.ViewModels;

namespace final_project.Controllers
{
    [Authorize(Roles = "customer")]
    public class RatingsController : Controller
    {
        private readonly IRatingService _ratingService;

        public RatingsController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(SubmitRatingViewModel model, string? returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                TempData["RatingError"] = "Please select a valid star rating (1–5).";
                return RedirectToLocal(returnUrl, model.StoreId);
            }

            var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(customerId))
            {
                return Challenge();
            }

            var success = await _ratingService.SubmitRatingAsync(customerId, model);
            if (!success)
            {
                TempData["RatingError"] = "Unable to submit rating. Ensure you have a customer profile and the stall is approved.";
                return RedirectToLocal(returnUrl, model.StoreId);
            }

            TempData["RatingSuccess"] = "Your stall rating has been saved!";
            return RedirectToLocal(returnUrl, model.StoreId);
        }

        private IActionResult RedirectToLocal(string? returnUrl, string storeId)
        {
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Details", "Stores", new { id = storeId });
        }
    }
}