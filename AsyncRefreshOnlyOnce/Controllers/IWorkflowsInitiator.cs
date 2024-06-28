using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncRefreshOnlyOnce.Workflows;

namespace AsyncRefreshOnlyOnce.Controllers
{
    public interface IWorkflowsInitiator : IController
    {
        public void Initialize(WorkflowsController workflowsController);
    }
}