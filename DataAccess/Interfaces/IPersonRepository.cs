using DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<PersonGetDTO>> GetAllPeople();
        Task<PersonGetDTO> GetPersonById(int id);
        Task<bool> AddPerson(PersonCreateDTO personCreateDto);
        Task<bool> UpdatePerson(PersonGetDTO personUpdateDto);
        Task<bool> DeletePerson(int id);
    }
}
