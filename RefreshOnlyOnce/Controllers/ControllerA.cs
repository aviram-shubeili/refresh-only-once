using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RefreshOnlyOnce.Workflows;

namespace RefreshOnlyOnce.Controllers
{
    public class ControllerA : IWorkflowsInitiator
    {
        private WorkflowsController _workflowsController;

        public void DoSomethingA() {
            PrettyLogger.Log("ControllerA.DoSomethingA...");
            _workflowsController.ExecuteWorkflow("WorkflowA");
        }

        public void Initialize(WorkflowsController workflowsController) {
            _workflowsController = workflowsController;
        }
    }
}