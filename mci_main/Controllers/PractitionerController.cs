using System;
using mci_main.Repository;
using Microsoft.AspNetCore.Mvc;

namespace mci_main.Controllers
{
    public class PractitionerController : Controller
    {
        private readonly IPractitionerRepository _practitionerRepository;

        public PractitionerController(IPractitionerRepository practitionerRepository)
        {
            _practitionerRepository = practitionerRepository;
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            var practitioner = _practitionerRepository.GetPractitioner(id);
            if (practitioner != null)
            {
                return View(_practitionerRepository.GetPractitionerView(practitioner));
            }
            else
            {
                return NotFound();
            }
        }
    }
}

