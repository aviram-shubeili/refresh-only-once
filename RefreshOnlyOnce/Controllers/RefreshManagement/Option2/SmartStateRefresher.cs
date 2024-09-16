using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefreshOnlyOnce.Controllers
{
    public class SmartStateRefresher : IStateRefresher
    {
        private int _openRefreshRequests;
        public void RefreshState()
        {
            if(--_openRefreshRequests == 0) {
                PrettyLogger.Log("State was refreshed!", ConsoleColor.Magenta);
            }
        }

        public void NotifyRefreshNeeded() {
            _openRefreshRequests++;
        }
    }
}