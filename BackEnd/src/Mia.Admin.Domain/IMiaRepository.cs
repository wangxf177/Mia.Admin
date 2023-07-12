using Mia.Admin.Enum;
using Mia.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Mia.Admin
{
    public interface IMiaRepository<TEntity> : ITransientDependency, IRepository<TEntity, Guid> where TEntity : class, IEntity<Guid>
    {
        #region 扩展的几个方法

        Task<PageModel<TEntity>> GetPageAsync(
            Expression<Func<TEntity, bool>> predicate,
            int pageSize,
            int pageIndex,
            Expression<Func<TEntity, object>>? orderField = null,
            OrderType orderType = OrderType.Desc);

        Task<PageModel<TProjection>> GetProjectionPageAsync<TProjection>(
            Expression<Func<TEntity, bool>> predicate,
            int pageSize,
            int pageIndex,
            Expression<Func<TEntity, object>>? orderField = null,
            OrderType orderType = OrderType.Desc);

        Task<List<TProjection>> GetProjectionListAsync<TProjection>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>>? orderField = null,
            OrderType orderType = OrderType.Desc);

        Task<List<TProjection>> GetProjectionListAsync<TProjection>(
            Expression<Func<TEntity, bool>> predicate,
            int pageSize,
            int pageIndex,
            Expression<Func<TEntity, object>>? orderField = null,
            OrderType orderType = OrderType.Desc);

        Task<IEnumerable<Guid>> GetIdsAsync(Expression<Func<TEntity, bool>> predicate);

        #endregion
    }
}
