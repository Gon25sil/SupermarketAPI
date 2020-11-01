using SupermarketAPI.Domain.Persistance;
using SupermarketAPI.Domain.Persistance.Repositories;

namespace SupermarketAPI.Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public void Complete()
        {
            appDbContext.SaveChanges();
        }
    }
}
