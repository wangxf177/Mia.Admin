using Mia.Admin.Messages;
using Mia.Admin.MongoDb;
using Mia.Admin.MongoDB;
using Volo.Abp.MongoDB;

namespace Mia.Admin.Repositories
{
    public class CommentRepository : MiaRepository<Comment>, ICommentRepository
    {
        public CommentRepository(IMongoDbContextProvider<MiaMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
