using Openlane.CarSaleManager.Application;
using Openlane.CarSaleManager.Domain.Abstractions;

namespace Openlane.CarSaleManager.Infrastructure
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IAggregateRoot
    {
        protected Repository() { }

        protected Repository(CarSalesDbContext dbContext)
            => DbContext = dbContext;

        protected CarSalesDbContext DbContext { get; init; } = default!;

        protected IQueryable<TEntity> All()
            => DbContext.Set<TEntity>();

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            DbContext.Add(entity);

            await DbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            DbContext.Update(entity);

            await DbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
