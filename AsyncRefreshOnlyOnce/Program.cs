using System;
using AsyncRefreshOnlyOnce.Controllers;
using AsyncRefreshOnlyOnce.Workflows;

namespace AsyncRefreshOnlyOnce {
    class Program {

        private static List<IController> _controllers;
        private static List<WorkflowExecutor> _workflows;
        static void Main(string[] args)
        {
            while (true) {

            var option = WaitForOptionSelection();
            if(option == "exit") {
                Console.WriteLine("Thank you, Goodbye!");
                return;
            }
            _controllers = CreateControllers();
            if(option == "IssueFlow") {
                _controllers.Add(new StateRefresher());
                _workflows = CreateWorkflowsForIssue();
            } else {
                    _controllers.Add(new SmartStateRefresher());
                    _workflows = CreateWorkflowsForSolution();
            }
            var workflowsController = new WorkflowsController(_workflows);
            _controllers.Add(workflowsController);
            InitializeIWorkflowsInitiators(workflowsController);

            Start();
            
            }
        }

        private static string WaitForOptionSelection()
        {
            var options = new (string option, string displayMessage)[] { ("IssueFlow", "See the flow that represent the problem statement."), ("FixFlow", "See the flow that represent the solution."), ("exit", "Exit")};
            var selected = 0;
            var needClear = false;
            while (true)
            {
                if(needClear) {
                    ClearLastLines(options.Length + 1);
                    Console.CursorVisible = false;
                }
                Console.WriteLine("What flow would you like to run?");
                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine((i == selected ? "[*] " : "[ ] ") + options[i].displayMessage + (i == selected ? "  <----" : ""));
                }
                needClear = true;
                var keyPressed = Console.ReadKey();

                if (keyPressed.Key == ConsoleKey.DownArrow && selected != options.Length - 1)
                {
                    selected++;
                }
                else if (keyPressed.Key == ConsoleKey.UpArrow && selected >= 1)
                {
                    selected--;
                }
                else if (keyPressed.Key == ConsoleKey.Enter)
                {
                    return options[selected].option;
                }
            }
        }

        private static void ClearLastLines(int numberOfLines)
        {
            // Save the current cursor position
            int currentLineCursor = Console.CursorTop;

            // Calculate the starting line position to clear
            int startLine = currentLineCursor - numberOfLines;

            if (startLine < 0)
            {
                startLine = 0; // Ensure we do not go above the top of the console
            }

            // Loop through the number of lines to clear
            for (int i = startLine; i < currentLineCursor; i++)
            {
                // Move the cursor to the start of the line
                Console.SetCursorPosition(0, i);
                // Write empty spaces to clear the line
                Console.Write(new string(' ', Console.WindowWidth));
            }

            // Move the cursor back to the start position
            Console.SetCursorPosition(0, startLine);
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

        private static List<WorkflowExecutor> CreateWorkflowsForIssue() {
            return new List<WorkflowExecutor>
            {
                new WorkflowExecutorA(_controllers),
                new WorkflowExecutorB(_controllers),
            };
        }

        private static List<WorkflowExecutor> CreateWorkflowsForSolution()
        {
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
            };
            
            return controllers;
        }
    }
}