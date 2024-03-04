using DataAccess.DTOs;
using DataAccess.Interfaces;

namespace PersonMinimalApi.ApiCode.Interfaces
{
    public interface IPersonApi
    {
        Task<IResult> GetAllPersons(IPersonRepository personRepository);
        Task<IResult> AddPerson(IPersonRepository personRepository, PersonCreateDTO personCreateDTO);
        Task<IResult> UpdatePerson(IPersonRepository personRepository, PersonGetDTO personGetDTO);
        Task<IResult> DeletePerson(IPersonRepository personRepository, int id);
        Task<IResult> GetPersonById(IPersonRepository personRepository, int id);
    }
}
