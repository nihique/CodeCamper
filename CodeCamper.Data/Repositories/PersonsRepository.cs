using System.Data.Entity;
using System.Linq;
using CodeCamper.Data.Contracts;
using CodeCamper.Model;

namespace CodeCamper.Data.Repositories
{
    public class PersonsRepository : EFRepository<Person>, IPersonsRepository
    {
        public PersonsRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<Speaker> GetSpeakers()
        {
            return Context
                .Set<Session>()
                .Select(session => session.Speaker)
                .Distinct()
                .Select(person => new Speaker
                    {
                        Id = person.Id,
                        FirstName = person.FirstName,
                        LastName = person.LastName,
                        ImageSource = person.ImageSource,
                    });
        }
    }
}
