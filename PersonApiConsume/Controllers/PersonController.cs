using DataAccess.DTOs;
using Microsoft.AspNetCore.Mvc;
using PersonApiConsume.Services.Implementation;

namespace PersonApiConsume.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonApiService _personApiService;
        public PersonController(IPersonApiService personApiService)
        {
            _personApiService = personApiService;
        }
        public async Task<IActionResult> Persons()
        {
            List<PersonGetDTO> persons = await _personApiService.GetPersons();
            return View(persons);
        }
    }
}
