using Get_StudentCase.Entities;

namespace Get_StudentCase.Services
{
    public interface IEventService
    {
        Task<Guid> CreateEventAsync(Event @event);
    }
}