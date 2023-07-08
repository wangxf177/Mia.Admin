using Mia.Admin.Messages;
using Mia.Admin.MongoDb;
using Mia.Admin.MongoDB;
using Volo.Abp.MongoDB;

namespace Mia.Admin.Repositories
{
    public class CommentRepository : AdminRepository<Comment>, ICommentRepository
    {
        public CommentRepository(IMongoDbContextProvider<AdminMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
