using System;
using mci_main.Data;
using mci_main.Models.View;

namespace mci_main.Repository
{
    public interface IPractitionerRepository
    {
        public Practitioner GetPractitioner(int mciIdx);
        public PractitionerViewModel GetPractitionerView(Practitioner practitioner);
    }
}

