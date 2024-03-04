using DataAccess.DTOs;
using DataAccess.Interfaces;
using PersonMinimalApi.ApiCode.Implementations;
using PersonMinimalApi.ApiCode.Interfaces;


namespace PersonMinimalApi.Extensions
{
    public static class MapApis
    {
  
        public static void MapApi(this WebApplication app, IPersonApi personApi)
        {
            
            app.MapGet("api/PersonYes", () =>
            {
                return "Yes I am Person";
            });
            var person = app.MapGroup("/api/Person")
                .WithTags("Person Api");

            person.MapGet("GetAllPerson", personApi.GetAllPersons);
            person.MapPost("AddPerson", personApi.AddPerson);
            person.MapPut("UpdatePerson", personApi.UpdatePerson);
            person.MapDelete("DeletePerson/{id}", personApi.DeletePerson);
            person.MapGet("GetPersonById/{id}", personApi.GetPersonById);

            //person.MapPost("AddPerson", async (IPersonRepository personRepository, PersonCreateDTO personCreateDTO) =>
            //{
            //    await personRepository.AddPerson(personCreateDTO);
            //    return TypedResults.Ok("Added Person Succesfully");
            //});

            /*
            static async Task<IResult> GetAllPersons(IPersonRepository personRepository)
            {
                var people = await personRepository.GetAllPeople();
                return TypedResults.Ok(people);
            }

            static async Task<IResult> AddPerson(IPersonRepository personRepository, PersonCreateDTO personCreateDTO)
            {
                await personRepository.AddPerson(personCreateDTO);
                return TypedResults.Ok("Added Person Succesfully");
            }

            static async Task<IResult> UpdatePerson(IPersonRepository personRepository, PersonGetDTO personGetDTO)
            {
                await personRepository.UpdatePerson(personGetDTO);
                return Results.Ok("Updated Person Succesfully");
            }

            static async Task<IResult> DeletePerson(IPersonRepository personRepository, int id)
            {
                await personRepository.DeletePerson(id);
                return TypedResults.Ok("Deleted Person Succesfully");
            }
            static async Task<IResult> GetPersonById(IPersonRepository personRepository, int id)
            {
                var person = await personRepository.GetPersonById(id);
                if (person == null)
                {
                    return TypedResults.NotFound();
                }
                return TypedResults.Ok(person);
            }
            */
        }
        // we can also use like this for grouping the endpoints
        public static RouteGroupBuilder PersonTestEndpoints(this RouteGroupBuilder personApiGroup)
        {
            personApiGroup.MapGet("api/PersonYes2", () =>
            {
                return "Yes I am Person 2";
            });

            return personApiGroup;
        }
    }
}
