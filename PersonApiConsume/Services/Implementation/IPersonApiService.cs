using DataAccess.DTOs;
using DataAccess.Models;
using Microsoft.Extensions.Options;
using PersonMinimalApi.ApiCode.Interfaces;

namespace PersonApiConsume.Services.Implementation
{
    public interface IPersonApiService
    {
        Task<List<PersonGetDTO>> GetPersons();
    }
}
