using Mia.Admin.AggregateRoot.Audited;
using System.Collections.Generic;

namespace Mia.Admin.AggregateRoot
{
    public class MiaWorkflowAggregateRoot : MiaAggregateRoot, IMiaWorkflowObject
    {
        public string C4WorkflowState { get; set; } = string.Empty;

        public List<string> C4CurrentWorkflowRole { get; set; } = new List<string>();

        public List<string> C4CurrentWorkflowUser { get; set; } = new List<string>();

        public List<string> C4CurrentWorkflowDoneUser { get; set; } = new List<string>();

        public string C4WorkflowStateDisplayName { get; set; } = string.Empty;

        public string C4WorkflowIsEndState { get; set; } = string.Empty;

        public string WorkflowActionButton { get; set; } = string.Empty;
    }
}
