using MongoDB.Driver;
using Mia.Admin.MongoDB;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Mia.Admin.MongoDb
{
    public class MiaRepository<TEntity> : MongoDbRepository<MiaMongoDbContext, TEntity, string>, IMiaRepository<TEntity> where TEntity : class, IEntity<string>
    {
        public MiaRepository(IMongoDbContextProvider<MiaMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        /// <summary>
        /// 为了兼容历史数据，历史数据中id既有object类型，又有guid字符串，所以这里id定义为string
        /// </summary>
        /// <param name="entity"></param>
        protected override void CheckAndSetId(TEntity entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Id))
            {
                EntityHelper.TrySetId(
                    entity,
                    () => GuidGenerator.Create().ToString("N"),
                    true);
            }
        }

        protected static FilterDefinitionBuilder<TEntity> Filter => Builders<TEntity>.Filter;

        protected static SortDefinitionBuilder<TEntity> Sort => Builders<TEntity>.Sort;

        protected static UpdateDefinitionBuilder<TEntity> Update => Builders<TEntity>.Update;

        protected static ProjectionDefinitionBuilder<TEntity> Projection => Builders<TEntity>.Projection;
    }
}
