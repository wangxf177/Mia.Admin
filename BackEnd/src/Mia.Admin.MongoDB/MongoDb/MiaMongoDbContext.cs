using Mia.Admin.Messages;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Mia.Admin.MongoDB;

[ConnectionStringName("Mia")]
public class MiaMongoDbContext : AbpMongoDbContext
{
    public IMongoCollection<Comment> Comments => Collection<Comment>();


    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        
    }
}
