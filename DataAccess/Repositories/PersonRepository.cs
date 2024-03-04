using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<PersonRepository> _logger;
        public PersonRepository(PersonDbContext context, IMapper mapper, ILogger<PersonRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> AddPerson(PersonCreateDTO personCreateDto)
        {
            try
            {
                Person newPerson = _mapper.Map<Person>(personCreateDto);
                _context.People.Add(newPerson);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error in Adding Person");
                return false;
            }
        }

        public async Task<bool> DeletePerson(int id)
        {
            try
            {
                var personToDelete = await _context.People.FindAsync(id);
                if (personToDelete == null)
                {
                    return false;
                }
                _context.People.Remove(personToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Deleting Person");
                return false;
            }
            
        }

        public async Task<IEnumerable<PersonGetDTO>> GetAllPeople()
        {
            try
            {
                var people = await _context.People.ToListAsync();
                if (people == null)
                {
                    return null;
                }
                return _mapper.Map<IEnumerable<PersonGetDTO>>(people);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Getting All People");
                return null;
            }
        }

        public async Task<PersonGetDTO> GetPersonById(int id)
        {
            try
            {
                var person = await _context.People.FirstOrDefaultAsync(p => p.Id == id);
                if (person == null)
                {
                    return null;
                }
                return _mapper.Map<PersonGetDTO>(person);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Getting Person by Id");
                return null;
            }
        }

        public async Task<bool> UpdatePerson(PersonGetDTO personUpdateDto)
        {
            try
            {
                Person person = _mapper.Map<Person>(personUpdateDto);
                _context.Entry(person).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Updating Person");
                return false;
            }
        }
    }
}
