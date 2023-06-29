using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSimulation.Enums
{
    internal enum TaskState
    {
        None,
        Waiting,
        Executing,
        Suspending,
        MissedDeadline,
        Finished
    }
}
