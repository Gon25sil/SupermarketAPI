using SupermarketAPI.Domain.Persistance;

namespace SupermarketAPI.Persistance.Repositories
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
