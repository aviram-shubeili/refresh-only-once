using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncRefreshOnlyOnce.Controllers;

namespace AsyncRefreshOnlyOnce.Workflows
{
    public class WorkflowExecutorA : WorkflowExecutor
    {
        public List<IController> _controllers { get; }

        public WorkflowExecutorA(List<IController> controllers)
        : base("WorkflowA") {
            _controllers = controllers;
        }

        public override void Execute()
        {
            PrettyLogger.Log("Start WorkflowA");
            DoSomethingB();
            RefreshState();
            PrettyLogger.Log("Finish WorkflowA");
        }

        private void DoSomethingB()
        {
            var controllerA = _controllers.OfType<ControllerB>().First();
            controllerA.DoSomethingB();
        }

        private void RefreshState() {
            var refresher = _controllers.OfType<IStateRefresher>().First();
            refresher.RefreshState();
        }

    }
}