using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Mia.Admin.AggregateRoot;
using Mia.Admin.Messages;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Mia.Admin.MongoDB;

[ConnectionStringName("Default")]
public class AdminMongoDbContext : AbpMongoDbContext
{
    public IMongoCollection<Comment> Comments => Collection<Comment>();


    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        AggregateRootCreateModel(modelBuilder);
    }


    #region AggregateRoot

    public IMongoCollection<MiaAggregateRoot> MiaAggregateRoots => Collection<MiaAggregateRoot>();
    public IMongoCollection<MiaFullAggregateRoot> MiaFullAggregateRoots => Collection<MiaFullAggregateRoot>();
    public IMongoCollection<MiaWorkflowAggregateRoot> MiaWorkflowAggregateRoots => Collection<MiaWorkflowAggregateRoot>();

    private static void AggregateRootCreateModel(IMongoModelBuilder modelBuilder)
    {
        BsonClassMap.RegisterClassMap<MiaAggregateRoot>(classMap =>
        {
            classMap.MapMember(entity => entity.C4CreateBy).SetElementName("C4-CreateBy");
        });

        modelBuilder.Entity<MiaAggregateRoot>(builder =>
        {
            builder.BsonMap.MapMember(entity => entity.C4CreateById).SetElementName("C4-CreateById");
            builder.BsonMap.MapMember(entity => entity.C4CreateBy).SetElementName("C4-CreateBy");
            builder.BsonMap.MapMember(entity => entity.C4CreateDate).SetElementName("C4-CreateDate");
            builder.BsonMap.MapMember(entity => entity.C4ModifyById).SetElementName("C4-ModifyById");
            builder.BsonMap.MapMember(entity => entity.C4ModifyBy).SetElementName("C4-ModifyBy");
            builder.BsonMap.MapMember(entity => entity.C4ModifyDate).SetElementName("C4-ModifyDate");
            builder.BsonMap.MapMember(entity => entity.C4EditHistory).SetElementName("C4-EditHistory");
        });

        modelBuilder.Entity<MiaWorkflowAggregateRoot>(builder =>
        {
            builder.BsonMap.MapMember(entity => entity.C4WorkflowState).SetElementName("C4-WorkflowState");
            builder.BsonMap.MapMember(entity => entity.C4CurrentWorkflowRole).SetElementName("C4-CurrentWorkflowRole");
            builder.BsonMap.MapMember(entity => entity.C4CurrentWorkflowUser).SetElementName("C4-CurrentWorkflowUser");
            builder.BsonMap.MapMember(entity => entity.C4CurrentWorkflowDoneUser).SetElementName("C4-CurrentWorkflowDoneUser");
            builder.BsonMap.MapMember(entity => entity.C4WorkflowStateDisplayName).SetElementName("C4-WorkflowStateDisplayName");
            builder.BsonMap.MapMember(entity => entity.C4WorkflowIsEndState).SetElementName("C4-WorkflowIsEndState");
            builder.BsonMap.MapMember(entity => entity.WorkflowActionButton).SetElementName("_workflowActionButton");
        });

        modelBuilder.Entity<MiaFullAggregateRoot>(builder =>
        {
            builder.BsonMap.MapMember(entity => entity.ActionButton).SetElementName("_actionButton");
            builder.BsonMap.MapMember(entity => entity.RequestVerificationToken).SetElementName("__RequestVerificationToken");
            builder.BsonMap.MapMember(entity => entity.C4RelevantUsers).SetElementName("C4-RelevantUsers");
        });
    }

    #endregion
}
