using System.Threading.Tasks;

namespace NetDevPL.Features.Events
{
    public interface IEventProvider
    {
        Task<Event[]> GetEventsAsync();
    }
}
