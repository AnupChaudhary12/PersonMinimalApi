using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonMinimalApi.Tests.Helpers
{
    public class MockDb:IDbContextFactory<PersonDbContext>
    {
        public PersonDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<PersonDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var dbContext = new PersonDbContext(options);
            dbContext.Database.EnsureCreated();
            return dbContext;
        }
    }
}
