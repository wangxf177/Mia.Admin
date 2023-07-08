using Mia.Admin.AggregateRoot.Audited;
using Mia.Admin.Extensions;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Timing;
using Volo.Abp.Users;

namespace Mia.Admin.MongoDb
{
    /// <summary>
    /// 审计日志字段设置，当使用仓储新增，修改数据的时候会使用
    /// </summary>
    internal class AdminAuditPropertySetter : AuditPropertySetter, IAuditPropertySetter, ITransientDependency
    {
        public AdminAuditPropertySetter(ICurrentUser currentUser, ICurrentTenant currentTenant, IClock clock) : base(currentUser, currentTenant, clock)
        {
        }

        protected override void SetCreationTime(object targetObject)
        {
            if (targetObject is IMiaCreationAuditedObject MiaAudited
                && MiaAudited.C4CreateDate == default)
            {
                ObjectHelper.TrySetProperty(MiaAudited, x => x.C4CreateDate, () => Clock.Now);
            }
        }

        protected override void SetCreatorId(object targetObject)
        {
            var currentUserId = CurrentUser.GetUserId();
            if (targetObject is IMiaCreationAuditedObject MiaAudited
                && !string.IsNullOrWhiteSpace(currentUserId)
                && string.IsNullOrWhiteSpace(MiaAudited.C4CreateById))
            {
                ObjectHelper.TrySetProperty(MiaAudited, x => x.C4CreateById, () => currentUserId);
                ObjectHelper.TrySetProperty(MiaAudited, x => x.C4CreateBy, () => CurrentUser.UserName);
            }
        }

        protected override void SetLastModificationTime(object targetObject)
        {
            if (targetObject is IMiaModificationAuditedObject MiaAudited)
            {
                ObjectHelper.TrySetProperty(MiaAudited, x => x.C4ModifyDate, () => Clock.Now);
            }
        }

        protected override void SetLastModifierId(object targetObject)
        {
            var currentUserId = CurrentUser.GetUserId();
            if (targetObject is IMiaModificationAuditedObject MiaAudit
                && !string.IsNullOrWhiteSpace(currentUserId))
            {
                ObjectHelper.TrySetProperty(MiaAudit, x => x.C4ModifyById, () => currentUserId);
                ObjectHelper.TrySetProperty(MiaAudit, x => x.C4ModifyBy, () => CurrentUser.UserName);
                MiaAudit.C4EditHistory.Add(new C4EditHistory
                {

                });
            }
        }
    }
}
