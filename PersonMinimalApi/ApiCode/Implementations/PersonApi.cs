using DataAccess.DTOs;
using DataAccess.Interfaces;
using PersonMinimalApi.ApiCode.Interfaces;

namespace PersonMinimalApi.ApiCode.Implementations
{
    public class PersonApi : IPersonApi
    {
        public async Task<IResult> GetAllPersons(IPersonRepository personRepository)
        {
            var people = await personRepository.GetAllPeople();
            return TypedResults.Ok(people);
        }

        public async Task<IResult> AddPerson(IPersonRepository personRepository, PersonCreateDTO personCreateDTO)
        {
            await personRepository.AddPerson(personCreateDTO);
            return TypedResults.Ok("Added Person Successfully");
        }

        public async Task<IResult> UpdatePerson(IPersonRepository personRepository, PersonGetDTO personGetDTO)
        {
            await personRepository.UpdatePerson(personGetDTO);
            return Results.Ok("Updated Person Successfully");
        }

        public async Task<IResult> DeletePerson(IPersonRepository personRepository, int id)
        {
            await personRepository.DeletePerson(id);
            return TypedResults.Ok("Deleted Person Successfully");
        }

        public async Task<IResult> GetPersonById(IPersonRepository personRepository, int id)
        {
            var person = await personRepository.GetPersonById(id);
            if (person == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(person);
        }
    }

}
