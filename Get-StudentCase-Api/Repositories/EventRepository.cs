using Get_StudentCase.Data;
using Get_StudentCase.Entities;
using Microsoft.EntityFrameworkCore;

namespace Get_StudentCase.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _context;

        public EventRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddEventAsync(Event @event)
        {
            await _context.Events.AddAsync(@event);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}