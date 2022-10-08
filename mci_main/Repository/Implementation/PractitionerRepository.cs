using mci_main.Data;
using mci_main.Helpers;
using mci_main.Models.View;
using Microsoft.EntityFrameworkCore;

namespace mci_main.Repository.Implementation
{
    public class PractitionerRepository : IPractitionerRepository
    {
        private readonly MciContext _mciContext;

        public PractitionerRepository(MciContext mciContext)
        {
            _mciContext = mciContext;
        }

        // TODO Split - Lite View with details only for result, full view including reviews for profile pages
        public Practitioner GetPractitioner(int mciIdx)
        {
            var practitioner =  _mciContext.Practitioner.Include("PractitionerSpecialties.Specialty").Include("Reviews")
                .Where(x => x.MciIdx.Equals(mciIdx)).First();
            return practitioner;
        }

        public PractitionerViewModel GetPractitionerView(Practitioner practitioner)
        {
            var newPracViewModel = PractitionerHelper.DbModelToViewModel(practitioner);
            return PractitionerHelper.DbModelToViewModel(practitioner);
        }
    }
}

