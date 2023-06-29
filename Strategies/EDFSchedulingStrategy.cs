using SchedulingSimulation.Enums;
using SchedulingSimulation.Interfaces;
using SchedulingSimulation.Ultilities;
using SchedulingSimulation.Visualizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSimulation.Strategies
{
    internal class EDFSchedulingStrategy : ISchedulingStrategy
    {
        public void Schedule(List<ITask> Tasks)
        {
            double CurrentTime = 0;

            double Hyperperiod = Calculator.Hyperperiod(Tasks);

            while (CurrentTime < Hyperperiod)
            {
                var AvailableTasks = GetAvailableTasks(Tasks, CurrentTime);

                var NextTask = GetNextTask(AvailableTasks, CurrentTime);

                this.UpdateTasks(Tasks, NextTask, CurrentTime);

                

                CurrentTime++;
            }

            GanttChartVisualizer.Show(CurrentTime, Tasks);
        }

        public List<ITask> GetAvailableTasks(List<ITask> Tasks, double CurrentTime)
        {
            return Tasks.Where(t => t.ReleaseTime <= CurrentTime && (t.RemainingTime > 0 || CurrentTime >= t.ReleaseTime + t.Period)).ToList();
        }

        public ITask GetNextTask(List<ITask> AvailableTasks, double CurrentTime)
        {
            return AvailableTasks.OrderBy(t => t.Deadline).First();
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

                        Task.RemainingTime--;

                        if (CurrentTime >= Task.ReleaseTime + Task.Period)
                        {
                            Task.Deadline = CurrentTime + Task.Period;
                            Task.ReleaseTime = CurrentTime;
                            // Reset the remaining time to the execution time
                            Task.RemainingTime = Task.ExecutionTime;
                        }
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
