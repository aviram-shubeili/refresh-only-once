using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RefreshOnlyOnce.Workflows;

namespace RefreshOnlyOnce.Controllers
{
    public interface IWorkflowsInitiator : IController
    {
        public void Initialize(WorkflowsController workflowsController);
    }
}