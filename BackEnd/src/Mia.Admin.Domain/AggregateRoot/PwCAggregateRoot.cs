using Mia.Admin.AggregateRoot.Audited;
using System;
using System.Collections.Generic;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Mia.Admin.AggregateRoot
{
    public abstract class MiaAggregateRoot : AggregateRoot<string>, ISoftDelete, IMiaFullAuditedObject
    {
        /// <summary>
        /// 现有数据是0和1，能够兼容bool类型数据
        /// </summary>
        public bool IsDeleted { get; set; }

        public DateTime C4CreateDate { get; set; }

        public string C4CreateBy { get; set; } = string.Empty;

        public string C4CreateById { get; set; } = string.Empty;

        public string C4ModifyById { get; set; } = string.Empty;
        public string C4ModifyBy { get; set; } = string.Empty;
        public DateTime C4ModifyDate { get; set; }
        public List<C4EditHistory> C4EditHistory { get; set; } = new List<C4EditHistory>();
    }
}
