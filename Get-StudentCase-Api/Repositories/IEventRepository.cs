using Get_StudentCase.Entities;

namespace Get_StudentCase.Repositories
{
    public interface IEventRepository
    {
        Task AddEventAsync(Event @event);
        Task SaveChangesAsync();
    }
}