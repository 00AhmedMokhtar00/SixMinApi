using Microsoft.EntityFrameworkCore;
using SixMinApi.models;

namespace SixMinApi.Data{
    public class CommandRepo : ICommandRepo
    {
        private readonly AppDbContext _context;

        public CommandRepo(AppDbContext context)
        {
            _context = context;
        }
        async Task ICommandRepo.CreateCommand(Command cmd)
        {
            if(cmd == null){
                throw new ArgumentNullException(nameof(cmd));
            }
            await _context.AddAsync(cmd);
        }

        void ICommandRepo.DeleteCommand(Command cmd)
        {
            if(cmd == null){
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Commands.Remove(cmd);
        }

        async Task<IEnumerable<Command>> ICommandRepo.GetAllCommands()
        {
            return await _context.Commands.ToListAsync();
        }

        async Task<Command?> ICommandRepo.GetCommandById(int id)
        {
            return await _context.Commands.FirstOrDefaultAsync(c => c.Id == id);
        }

        async Task ICommandRepo.SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}