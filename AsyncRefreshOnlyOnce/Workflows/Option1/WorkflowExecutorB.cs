using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncRefreshOnlyOnce.Controllers;

namespace AsyncRefreshOnlyOnce.Workflows
{
    public class WorkflowExecutorB : WorkflowExecutor
    {
        public List<IController> _controllers { get; }

        public WorkflowExecutorB(List<IController> controllers)
        : base("WorkflowB") {
            _controllers = controllers;
        }

        public override void Execute()
        {
            PrettyLogger.Log("Start WorkflowB");

            //DoSomething...
            RefreshState();
            PrettyLogger.Log("Finish WorkflowB");

        }


        private void RefreshState()
        {
            var refresher = _controllers.OfType<IStateRefresher>().First();
            refresher.RefreshState();
        }
    }
}