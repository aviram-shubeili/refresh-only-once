using System;
using AsyncRefreshOnlyOnce.Controllers;
using AsyncRefreshOnlyOnce.Workflows;

namespace AsyncRefreshOnlyOnce {
    class Program {

        private static List<IController> _controllers;
        private static List<WorkflowExecutor> _workflows;
        static void Main(string[] args)
        {            
            _controllers = CreateControllers();
            _workflows = CreateWorkflows();
            var workflowsController = new WorkflowsController(_workflows);
            _controllers.Add(workflowsController);
            InitializeIWorkflowsInitiators(workflowsController);

            Start();
            
        }

        private static void Start()
        {
            _controllers.OfType<ControllerA>().First().DoSomethingA();
        }

        private static void InitializeIWorkflowsInitiators(WorkflowsController workflowsController)
        {
            foreach(var workflowsInitiator in _controllers.OfType<IWorkflowsInitiator>()) {
                workflowsInitiator.Initialize(workflowsController);
            }
        }

        private static List<WorkflowExecutor> CreateWorkflows() {
            return new List<WorkflowExecutor>
            {
                new WorkflowExecutorA2(_controllers),
                new WorkflowExecutorB2(_controllers),
            };
        }
        private static List<IController> CreateControllers()
        {
            var controllers = new List<IController>
            {
                new ControllerA(),
                new ControllerB(),
                new SmartStateRefresher(),
            };
            
            return controllers;
        }
    }
}