using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSimulation.Interfaces
{
    internal interface ISchedulingStrategy
    {
        void Schedule(List<ITask> Tasks);
        List<ITask> GetAvailableTasks(List<ITask> Tasks, double CurrentTime);
        ITask GetNextTask(List<ITask> Tasks, double CurrentTime);
        void UpdateTasks(List<ITask> Tasks, ITask NextTask, double CurrentTime);
    }
}
