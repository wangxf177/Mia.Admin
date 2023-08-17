using Volo.Abp.Auditing;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Timing;
using Volo.Abp.Users;

namespace Mia.Admin
{
    /// <summary>
    /// 审计日志字段设置，当使用仓储新增，修改数据的时候会使用
    /// </summary>
    internal class MiaAuditPropertySetter : AuditPropertySetter, IAuditPropertySetter, ITransientDependency
    {
        public MiaAuditPropertySetter(ICurrentUser currentUser, ICurrentTenant currentTenant, IClock clock) : base(currentUser, currentTenant, clock)
        {
        }
    }
}
