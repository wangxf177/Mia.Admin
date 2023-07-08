using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Mia.Admin
{
    public interface IMiaRepository<TEntity> : ITransientDependency, IRepository<TEntity, string> where TEntity : class, IEntity<string>
    {
    }
}
