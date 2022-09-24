using mci_main.Data;
using mci_main.Models.View;

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
            return _mciContext.Practitioner.Where(x => x.MciIdx.Equals(mciIdx)).First();
        }

        public PractitionerViewModel GetPractitionerView(Practitioner practitioner)
        {
            var viewModel = new PractitionerViewModel()
            {
                Name = practitioner.Name,
                Bio = practitioner.Bio,
                DOB = practitioner.DOB,
                Location = practitioner.Location,
                Specialties = practitioner.PractitionerSpecialties.Select(x => x.Specialty).ToList()
            };
            return viewModel;
        }
    }
}

