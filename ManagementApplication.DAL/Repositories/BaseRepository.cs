using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.DAL.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly ManagementApplicationDbContext _context;
        protected BaseRepository(ManagementApplicationDbContext context)
        {
            _context = context;
        }
    }
}
