/******************************
* MCI Practitioner Controller
* Author: Mark Brown
* Authored: 10/09/2022
******************************/
using mci_main.Data;
using mci_main.Models;
using mci_main.Repository;
using mci_main.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mci_main.Controllers
{
    public class PractitionerController : Controller
    {
        private readonly IPractitionerRepository _practitionerRepository;
        private readonly IReviewRepository _reviewRepository;

        public PractitionerController(IPractitionerRepository practitionerRepository,
            IReviewRepository reviewRepository)
        {
            _practitionerRepository = practitionerRepository;
            _reviewRepository = reviewRepository;
        }

        [HttpGet]
        [Route("practitioner/{id:int}")]
        public IActionResult Index(int id)
        {
            var practitioner = _practitionerRepository.GetPractitioner(id);
            if (id >=0 && practitioner != null)
            {
                return View(_practitionerRepository.GetPractitionerView(practitioner));
            }
            else
            {
                return NotFound();
            }
        }

        /* BEGIN REVIEWS */
        [HttpGet]
        [Route("practitioner/{id:int}/review")]
        public IActionResult AddReviewForm(int id)
        {
            // todo: include prac details on review form page 
            return View(new ReviewFormModel(id));
        }

        [HttpPost]
        [Route("practitioner/{id:int}/review")]
        public IActionResult SubmitReview(int id, [Bind("PracIdx,Title,Comment,ReviewerName,DateVisited")] ReviewFormModel review)
        {
            review.PracIdx = id;
            // todo: will prob need to convert ReviewFormModel into Db review class

            if (ModelState.IsValid)
            {
                try
                {
                    _reviewRepository.CreateReviewFromFormModel(review);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                return StatusCode(500); 
            }
            return View("ViewReview", review);
        }

        /* Get a specific review associated with a prac */
        [HttpGet]
        [Route("practitioner/{id:int}/review/{reviewId:int}")]
        public IActionResult GetReview(int id, int reviewId)
        {
            var review = _reviewRepository.GetReview(reviewId);
            if (review != null && review.PracIdx.Equals(id))
            {
                return View("ViewReview", ReviewHelper.DbReviewToViewModel(review));
            }
            else
            {
                return NotFound(); 
            }
        }

        /* Get all reviews associated with a practitioner */
        [HttpGet]
        [Route("practitioner/{id:int}/reviews")]
        public IActionResult GetAllReviews(int id)
        {
            var practitioner = _practitionerRepository.GetPractitioner(id);
            var reviews = _reviewRepository.GetAllPractitionerReviews(practitioner);
            // Todo - reveiw list model?? or some way to get prac details
            return View(reviews);
        }
    }
}

