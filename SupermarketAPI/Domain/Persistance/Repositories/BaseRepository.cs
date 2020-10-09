using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketAPI.Domain.Persistance.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext context;

        protected BaseRepository(AppDbContext context)
        {
            this.context = context;
        }
    }
}
