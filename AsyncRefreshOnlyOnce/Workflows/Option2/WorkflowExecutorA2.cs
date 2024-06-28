using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncRefreshOnlyOnce.Controllers;

namespace AsyncRefreshOnlyOnce.Workflows
{
    public class WorkflowExecutorA2 : WorkflowExecutor
    {
        public List<IController> _controllers { get; }

        public WorkflowExecutorA2(List<IController> controllers)
        : base("WorkflowA")
        {
            _controllers = controllers;
        }

        public override void Execute()
        {
            PrettyLogger.Log("Start WorkflowA2");
            NotifyRefreshNeeded();
            DoSomethingB();
            RefreshState();
            PrettyLogger.Log("Finish WorkflowA2");
        }

        private void NotifyRefreshNeeded()
        {
            var refresher = _controllers.OfType<SmartStateRefresher>().First();
            refresher.NotifyRefreshNeeded();
        }

        private void DoSomethingB()
        {
            var controllerA = _controllers.OfType<ControllerB>().First();
            controllerA.DoSomethingB();
        }

        private void RefreshState()
        {
            var refresher = _controllers.OfType<IStateRefresher>().First();
            refresher.RefreshState();
        }

    }
}