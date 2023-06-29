using SchedulingSimulation.Enums;
using SchedulingSimulation.Interfaces;
using SchedulingSimulation.Visualizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSimulation.Strategies
{
    internal class LSTSchedulingStrategy : ISchedulingStrategy
    {
        public void Schedule(List<ITask> Tasks)
        {
            double CurrentTime = 0;

            while (Tasks.Any(t => t.RemainingTime > 0))
            {
                var AvailableTasks = GetAvailableTasks(Tasks, CurrentTime);

                var NextTask = GetNextTask(AvailableTasks, CurrentTime);

                this.UpdateTasks(Tasks, NextTask, CurrentTime);

                NextTask.RemainingTime--;

                CurrentTime++;
            }

            GanttChartVisualizer.Show(CurrentTime, Tasks);
        }

        public List<ITask> GetAvailableTasks(List<ITask> Tasks, double CurrentTime)
        {
            return Tasks.Where(t => t.ReleaseTime <= CurrentTime && t.RemainingTime > 0).ToList();
        }

        public ITask GetNextTask(List<ITask> AvailableTasks, double CurrentTime)
        {
            foreach (var Task in AvailableTasks)
            {
                Task.SlackTime = Task.Deadline - CurrentTime - Task.RemainingTime;
            }

            return AvailableTasks.OrderBy(t => t.SlackTime).First();
        }

        
        public void UpdateTasks(List<ITask> Tasks, ITask NextTask, double CurrentTime)
        {
            foreach (var Task in Tasks)
            {
                if (Task.RemainingTime > 0)
                {
                    if (Task == NextTask)
                    {
                        Task.Update(TaskState.Executing);
                    }
                    else
                    {
                        if (Task.RemainingTime < Task.ExecutionTime)
                        {
                            Task.Update(TaskState.Suspending);
                        }
                        else
                        {
                            Task.Update(TaskState.Waiting);
                        }
                    }
                }
                else
                {
                    if (Task.CurrentState != TaskState.Finished && CurrentTime > Task.Deadline)
                    {
                        Task.Update(TaskState.MissedDeadline);
                    }
                    else
                    {
                        Task.Update(TaskState.Finished);
                    }
                }
            }
        }
    }
}
