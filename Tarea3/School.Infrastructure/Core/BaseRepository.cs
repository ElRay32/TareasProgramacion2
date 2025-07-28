using School.Infrastructure.Context;

namespace School.Infrastructure.Core
{
    public abstract class BaseRepository
    {
        protected readonly SchoolContext _context;
        protected BaseRepository(SchoolContext context)
        {
            _context = context;
        }
    }
}
