using Mia.Admin.Enum;
using Mia.Admin.Models;
using Mia.Admin.MongoDB;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Mia.Admin.MongoDb
{
    public class MiaRepository<TEntity> : MongoDbRepository<MiaMongoDbContext, TEntity, Guid>, IMiaRepository<TEntity> where TEntity : class, IEntity<Guid>
    {
        public MiaRepository(IMongoDbContextProvider<MiaMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        #region 扩展的几个方法

        public async Task<PageModel<TEntity>> GetPageAsync(
            Expression<Func<TEntity, bool>> predicate,
            int pageSize,
            int pageIndex,
            Expression<Func<TEntity, object>>? orderField = null,
            OrderType orderType = OrderType.Desc)
        {
            var collection = await GetCollectionAsync();
            orderField ??= c => c.Id;
            var sort = orderType == OrderType.Asc ? Sort.Ascending(orderField) : Sort.Descending(orderField);
            var options = new FindOptions<TEntity>
            {
                Skip = pageSize * (pageIndex - 1),
                Limit = pageSize,
                Sort = sort
            };
            var total = await collection.CountDocumentsAsync(predicate);
            var data = await collection.FindAsync(predicate, options);
            return new PageModel<TEntity>(data.ToList(), (int)total);
        }

        public async Task<PageModel<TProjection>> GetProjectionPageAsync<TProjection>(
            Expression<Func<TEntity, bool>> predicate,
            int pageSize,
            int pageIndex,
            Expression<Func<TEntity, object>>? orderField = null,
            OrderType orderType = OrderType.Desc)
        {
            var collection = await GetCollectionAsync();
            orderField ??= c => c.Id;
            var sort = orderType == OrderType.Asc ? Sort.Ascending(orderField) : Sort.Descending(orderField);
            var options = new FindOptions<TEntity, TProjection>
            {
                Skip = pageSize * (pageIndex - 1),
                Limit = pageSize,
                Sort = sort
            };
            var total = await collection.CountDocumentsAsync(predicate);
            var data = await collection.FindAsync(predicate, options);
            return new PageModel<TProjection>(data.ToList(), (int)total);

        }

        public async Task<List<TProjection>> GetProjectionListAsync<TProjection>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>>? orderField = null,
            OrderType orderType = OrderType.Desc)
        {
            var collection = await GetCollectionAsync();
            orderField ??= c => c.Id;
            var sort = orderType == OrderType.Asc ? Sort.Ascending(orderField) : Sort.Descending(orderField);
            var options = new FindOptions<TEntity, TProjection>
            {
                Sort = sort
            };
            var data = await collection.FindAsync(predicate, options);
            return await data.ToListAsync();
        }

        public async Task<List<TProjection>> GetProjectionListAsync<TProjection>(
            Expression<Func<TEntity, bool>> predicate,
            int pageSize,
            int pageIndex,
            Expression<Func<TEntity, object>>? orderField = null,
            OrderType orderType = OrderType.Desc)
        {
            var collection = await GetCollectionAsync();
            orderField ??= c => c.Id;
            var sort = orderType == OrderType.Asc ? Sort.Ascending(orderField) : Sort.Descending(orderField);
            var options = new FindOptions<TEntity, TProjection>
            {
                Sort = sort,
                Skip = pageSize * (pageIndex - 1),
                Limit = pageSize,
            };
            var data = await collection.FindAsync(predicate, options);
            return await data.ToListAsync();
        }

        public async Task<IEnumerable<Guid>> GetIdsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var collection = await GetCollectionAsync();
            var cursor = collection.Find(predicate);
            return cursor.Project<Ids>(Projection.Include("_id")).ToList().Select(c => c.Id);
        }

        #endregion


        protected static FilterDefinitionBuilder<TEntity> Filter => Builders<TEntity>.Filter;

        protected static SortDefinitionBuilder<TEntity> Sort => Builders<TEntity>.Sort;

        protected static UpdateDefinitionBuilder<TEntity> Update => Builders<TEntity>.Update;

        protected static ProjectionDefinitionBuilder<TEntity> Projection => Builders<TEntity>.Projection;
    }

    public class Ids
    {
        public Guid Id { get; set; }
    }
}
