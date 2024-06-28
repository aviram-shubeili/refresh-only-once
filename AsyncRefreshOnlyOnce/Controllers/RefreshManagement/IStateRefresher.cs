using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncRefreshOnlyOnce.Controllers
{
    public interface IStateRefresher : IController
    {
        void RefreshState();
    }
}