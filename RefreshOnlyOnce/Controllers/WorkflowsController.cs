using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RefreshOnlyOnce.Workflows;

namespace RefreshOnlyOnce.Controllers
{
    public class WorkflowsController : IController
    {
        private readonly List<WorkflowExecutor> _workflowExecutors;
        public WorkflowsController(List<WorkflowExecutor> workflowExecutors) {
            _workflowExecutors = workflowExecutors;
        }

        public void ExecuteWorkflow(string workflowId) {
            _workflowExecutors.Find(we => we.WorkflowIdentifer == workflowId)?.Execute();
        }
    }
}