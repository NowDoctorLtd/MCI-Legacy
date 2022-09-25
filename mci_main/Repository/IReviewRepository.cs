using mci_main.Data;
namespace mci_main.Repository
{
    public interface IReviewRepository
    {
        public Review GetReview(int MciIdx);
        public Task CreateReview(Review newReview);
		public List<Review> GetAllPractitionerReviews(Practitioner practitioner);
    }
}

