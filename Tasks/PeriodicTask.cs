using SchedulingSimulation.Enums;
using SchedulingSimulation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSimulation.Tasks
{
    internal class PeriodicTask : ITask, IStateHistory
    {
        public string Name { get; }
        public double ExecutionTime { get; }
        public double Period { get; }

        public double ReleaseTime { get; set; }
        public double Deadline { get; set; }

        public TaskState CurrentState { get; set; }
        public double RemainingTime { get; set; }
        public double SlackTime { get; set; }
        public Queue<TaskState> Histories { get; }

        public PeriodicTask(string Name, double ExecutionTime, double Deadline)
        {
            this.Name = Name;
            this.ReleaseTime = 0;
            this.ExecutionTime = ExecutionTime;
            this.RemainingTime = ExecutionTime;
            this.Deadline = Deadline;
            this.Period = Deadline;

            this.Histories = new Queue<TaskState>();
        }
        public PeriodicTask(string Name, double ReleaseTime, double ExecutionTime, double Deadline)
        {
            this.Name = Name;
            this.ReleaseTime = ReleaseTime;
            this.ExecutionTime = ExecutionTime;
            this.RemainingTime = ExecutionTime;
            this.Deadline = Deadline;
            this.Period = Deadline;

            this.Histories = new Queue<TaskState>();
        }
        public PeriodicTask(string Name, double ReleaseTime, double ExecutionTime, double Deadline, double Period)
        {
            this.Name = Name;
            this.ReleaseTime = ReleaseTime;
            this.ExecutionTime = ExecutionTime;
            this.RemainingTime = ExecutionTime;
            this.Deadline = Deadline;
            this.Period = Period;

            this.Histories = new Queue<TaskState>();
        }

        public void Update(TaskState State) 
        {
            this.CurrentState = State;
            this.Histories.Enqueue(State);
        }
    }
}
