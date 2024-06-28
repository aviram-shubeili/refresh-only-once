using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncRefreshOnlyOnce.Workflows;

namespace AsyncRefreshOnlyOnce.Controllers
{
    public class ControllerB : IWorkflowsInitiator
    {
        private WorkflowsController _workflowsController;

        public void DoSomethingB()
        {
            PrettyLogger.Log("ControllerB.DoSomethingB...");
            _workflowsController.ExecuteWorkflow("WorkflowB");
        }

        public void Initialize(WorkflowsController workflowsController)
        {
            _workflowsController = workflowsController;
        }
    }
}