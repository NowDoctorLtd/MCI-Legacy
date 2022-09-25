/******************************
* MCI Review View Model
* Details for the submit a review page.
*
* Author: Mark Brown
* Authored: 25/09/2022
******************************/
namespace mci_main.Models
{
    public class ReviewFormModel
    {
        public int PracIdx { get; set; }
        public string Title { get; set; }
        public string ReviewerName { get; set; }
        public string Comment { get; set; }
        public DateTime DateVisited { get; set; }

        public ReviewFormModel(int pracIdx)
        {
            this.PracIdx = pracIdx; 
        }
    }
}

