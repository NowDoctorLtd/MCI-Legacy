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

        public Practitioner GetPractitioner(int mciIdx)
        {
            return _mciContext.Practitioner.Include("PractitionerSpecialties.Specialty")
                .Where(x => x.MciIdx.Equals(mciIdx)).First();
        }

        public PractitionerViewModel GetPractitionerView(Practitioner practitioner)
        {
            return PractitionerHelper.DbModelToViewModel(practitioner);
        }
    }
}

