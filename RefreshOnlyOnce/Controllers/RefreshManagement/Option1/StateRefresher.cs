using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefreshOnlyOnce.Controllers
{
    public class StateRefresher : IStateRefresher
    {
        public void RefreshState()
        {
            {
                PrettyLogger.Log("State was refreshed!", ConsoleColor.Magenta);
            }
        }

    }
}