using mci_main.Data;
using mci_main.Models;
namespace mci_main.Repository
{
    public interface IReviewRepository
    {
        public Review GetReview(int MciIdx);
        public Task CreateReview(Review newReview);
		public List<Review> GetAllPractitionerReviews(Practitioner practitioner);
        public Task CreateReviewFromFormModel(ReviewFormModel formModel);

        // Mock Methods, DO NOT use live!
        public Task<List<Adjective>> MockGetAdjectives(int practitonerId);
    }
}

