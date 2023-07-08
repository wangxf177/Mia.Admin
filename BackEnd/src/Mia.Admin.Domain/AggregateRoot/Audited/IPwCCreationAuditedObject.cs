using System;

namespace Mia.Admin.AggregateRoot.Audited
{
    public interface IMiaCreationAuditedObject
    {
        DateTime C4CreateDate { get; }
        string C4CreateBy { get; }
        string C4CreateById { get; }
    }
}
