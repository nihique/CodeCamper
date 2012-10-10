using System.Linq;
using CodeCamper.Model;

namespace CodeCamper.Data.Contracts
{
    public interface IPersonsRepository : IRepository<Person>
    {
        IQueryable<Speaker> GetSpeakers();
    }
}
