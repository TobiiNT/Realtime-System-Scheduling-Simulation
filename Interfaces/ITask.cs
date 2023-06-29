using SchedulingSimulation.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSimulation.Interfaces
{
    internal interface ITask
    {
        public string Name { get; }
        public double ExecutionTime { get; }
        public double Period { get; }

        public double ReleaseTime { set; get; }
        public double Deadline { set; get; }

        public double RemainingTime { get; set; }
        public double SlackTime { get; set; }
        public TaskState CurrentState { get; set; }

        void Update(TaskState State);
    }
}
