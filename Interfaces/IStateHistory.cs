using SchedulingSimulation.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSimulation.Interfaces
{
    internal interface IStateHistory
    {
        public Queue<TaskState> Histories { get; }
    }
}
