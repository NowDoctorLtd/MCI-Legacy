using System;
using mci_main.Models;
using mci_main.Data;

namespace mci_main.Helpers
{
    public class ReviewHelper
    {
        public static ReviewFormModel DbReviewToViewModel(Review dbReview)
        {
            return new ReviewFormModel()
            {
                Title = dbReview.Title,
                Comment = dbReview.Comment,
                DateVisited = dbReview.DateVisited,
                ReviewerName = dbReview.ReviewerName,
                PracIdx = dbReview.PracIdx
            };
        }
    }
}

