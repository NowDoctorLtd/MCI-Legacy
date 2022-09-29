﻿/******************************
* MCI Review Repository 
* Database operations for reviews.
* Author: Mark Brown
* Authored: 25/09/2022
******************************/
using mci_main.Data;
using mci_main.Models;

namespace mci_main.Repository.Implementation
{
	public class ReviewRepository : IReviewRepository
	{
		private MciContext _mciContext;

		public ReviewRepository(MciContext mciContext)
		{
			_mciContext = mciContext; 
        }

		public Review GetReview(int mciIdx)
		{
			return _mciContext.Review.Where(x => x.MciIdx.Equals(mciIdx)).First();
        }

		public List<Review> GetAllPractitionerReviews(Practitioner practitioner)
		{
			var reviewList = new List<Review>();

			var practitionerReviews = _mciContext.Review
				.Where(p => p.PracIdx.Equals(practitioner.MciIdx))
				.ToList();

			reviewList.AddRange(practitionerReviews);
			return reviewList;
        }

		public async Task CreateReview(Review newReview)
		{
			_mciContext.Review.Add(newReview);
			await _mciContext.SaveChangesAsync();
        }

		public async Task CreateReviewFromFormModel(ReviewFormModel formModel)
		{
			var newReview = new Review()
			{
				Title = formModel.Title,
                ReviewerName = formModel.ReviewerName,
                Comment = formModel.Comment,
                DateVisited = formModel.DateVisited,
                PracIdx = formModel.PracIdx	
			};
			await this.CreateReview(newReview);
        }
	}
}

