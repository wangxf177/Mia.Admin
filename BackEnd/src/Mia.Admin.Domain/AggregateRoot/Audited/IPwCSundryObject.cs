using System.Collections.Generic;

namespace Mia.Admin.AggregateRoot.Audited
{
    public interface IMiaSundryObject
    {
        string ActionButton { get; set; }
        string WorkflowActionButton { get; set; }
        string RequestVerificationToken { get; set; }
        List<string> C4RelevantUsers { get; set; }
    }
}
