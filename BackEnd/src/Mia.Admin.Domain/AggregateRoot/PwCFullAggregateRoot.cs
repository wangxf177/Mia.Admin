using Mia.Admin.AggregateRoot.Audited;
using System.Collections.Generic;

namespace Mia.Admin.AggregateRoot
{
    public abstract class MiaFullAggregateRoot : MiaWorkflowAggregateRoot, IMiaSundryObject
    {
        public string ActionButton { get; set; } = string.Empty;
        public string RequestVerificationToken { get; set; } = string.Empty;
        public List<string> C4RelevantUsers { get; set; } = new List<string>();
    }
}
