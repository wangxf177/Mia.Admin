using System;
using System.Collections.Generic;

namespace Mia.Admin.AggregateRoot.Audited
{
    public interface IMiaModificationAuditedObject
    {
        string C4ModifyById { get; set; }
        string C4ModifyBy { get; set; }
        DateTime C4ModifyDate { get; set; }
        List<C4EditHistory> C4EditHistory { get; set; }
    }
}
