using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefreshOnlyOnce.Workflows
{
    public abstract class WorkflowExecutor
    {
        public WorkflowExecutor(string identifier) {
            WorkflowIdentifer = identifier;
        }
        
        public string WorkflowIdentifer { get; }
        public abstract void Execute();
    }
}