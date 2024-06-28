using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncRefreshOnlyOnce.Controllers;

namespace AsyncRefreshOnlyOnce.Workflows
{
    public class WorkflowExecutorB2 : WorkflowExecutor
    {
        public List<IController> _controllers { get; }

        public WorkflowExecutorB2(List<IController> controllers)
        : base("WorkflowB")
        {
            _controllers = controllers;
        }

        public override void Execute()
        {
            PrettyLogger.Log("Start WorkflowB2");
            NotifyRefreshNeeded();
            //DoSomething...
            RefreshState();
            PrettyLogger.Log("Finish WorkflowB2");

        }


        private void NotifyRefreshNeeded() {
            var refresher = _controllers.OfType<SmartStateRefresher>().First();
            refresher.NotifyRefreshNeeded();
        }
        private void RefreshState()
        {
            var refresher = _controllers.OfType<IStateRefresher>().First();
            refresher.RefreshState();
        }
    }
}