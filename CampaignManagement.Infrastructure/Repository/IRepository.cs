using System;
using System.Linq;
using System.Threading.Tasks;

namespace CampaignManagement.Domain.SeedWork
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetById(Guid id);
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(Guid id);
        Task Delete(TEntity entity);
        Task SaveChangesAsync();
    }
}