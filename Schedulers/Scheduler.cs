using SchedulingSimulation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSimulation.Schedulers
{
    internal class Scheduler
    {
        private ISchedulingStrategy SchedulingStrategy;

        public Scheduler(ISchedulingStrategy SchedulingStrategy)
        {
            this.SchedulingStrategy = SchedulingStrategy;
        }

        public void SetSchedulingStrategy(ISchedulingStrategy SchedulingStrategy)
        {
            this.SchedulingStrategy = SchedulingStrategy;
        }

        public void Run(List<ITask> Tasks)
        {
            this.SchedulingStrategy.Schedule(Tasks);
        }
    }
}
