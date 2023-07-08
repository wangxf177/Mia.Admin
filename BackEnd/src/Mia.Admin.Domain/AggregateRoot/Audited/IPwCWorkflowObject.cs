using System.Collections.Generic;

namespace Mia.Admin.AggregateRoot.Audited
{
    public interface IMiaWorkflowObject
    {
        string C4WorkflowState { get; }
        List<string> C4CurrentWorkflowRole { get; }
        List<string> C4CurrentWorkflowUser { get; }
        List<string> C4CurrentWorkflowDoneUser { get; }
        string C4WorkflowStateDisplayName { get; }
        string C4WorkflowIsEndState { get; }
        string WorkflowActionButton { get; }
    }
}
