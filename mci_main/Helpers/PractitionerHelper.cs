/******************************
* MCI Practitioner Helper
* Helper methods for practitioner classes
*
* Author: Mark Brown
* Authored: 24/09/2022
******************************/
using mci_main.Data;
using mci_main.Models.View;
namespace mci_main.Helpers
{
    public class PractitionerHelper
    {
        public static PractitionerViewModel DbModelToViewModel(Practitioner dbPrac)
        {
            string specialtiesStr = "";

            if (dbPrac.PractitionerSpecialties != null && dbPrac.PractitionerSpecialties.Any())
            {
                // Make its own method??
                var specialties = dbPrac.PractitionerSpecialties.Select(x => x.Specialty.Title).ToArray();

                if (specialties.Length.Equals(1))
                {
                    specialtiesStr = specialties[0];
                }
                else if (specialties.Length.Equals(0))
                {
                    specialtiesStr = ""; 
                }
                else
                { 
                    for (int i = 0; i < specialties.Length; i++)
                    {
                        if (i < specialties.Length - 1)
                        { 
                            specialtiesStr += $"{specialties[i]},";
                        }
                        else
                        {
                            specialtiesStr += $" {specialties[i]}";
                        }
                    }
                }
            }

            return new PractitionerViewModel()
            {
                MciIdx = dbPrac.MciIdx,
                Name = dbPrac.Name,
                DOB = dbPrac.DOB,
                Title = dbPrac.Title,
                Location = dbPrac.Location,
                SpecialtiesStr = specialtiesStr,
                Bio = dbPrac.Bio,
                ReviewsInBrief = GetReviewsInBrief(dbPrac)
            };
        }

        public static Dictionary<int, string> GetReviewsInBrief(Practitioner practitioner) 
        {
            Dictionary<int, string> reviewsInBrief;
            if (practitioner.Reviews != null && practitioner.Reviews.Any())
            {
                reviewsInBrief = practitioner.Reviews.ToDictionary(x => x.MciIdx, x => x.Title);
            }
            else
            { 
                reviewsInBrief = new Dictionary<int, string>();
            }
            return reviewsInBrief;
        }

        public static List<PractitionerViewModel> DbListToViewList(List<Practitioner> dbPracs)
        {
            var viewModels = new List<PractitionerViewModel>();

            foreach(var dbPrac in dbPracs)
            {
                viewModels.Add(DbModelToViewModel(dbPrac));
            }

            return viewModels;
        }
    }
}

