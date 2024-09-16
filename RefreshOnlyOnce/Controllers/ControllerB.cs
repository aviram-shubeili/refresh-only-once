using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RefreshOnlyOnce.Workflows;

namespace RefreshOnlyOnce.Controllers
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