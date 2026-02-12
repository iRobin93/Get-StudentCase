using Get_StudentCase.Entities;
using Get_StudentCase.Repositories;

namespace Get_StudentCase.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _repository;

        public EventService(IEventRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> CreateEventAsync(Event @event)
        {
            if (@event.StudentId == Guid.Empty)
            {
                @event.StudentId = Guid.NewGuid();
            }

            await _repository.AddEventAsync(@event);
            await _repository.SaveChangesAsync();

            return @event.StudentId;
        }
    }
}