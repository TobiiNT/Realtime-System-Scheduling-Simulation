using SchedulingSimulation.Interfaces;
using SchedulingSimulation.Enums;

namespace SchedulingSimulation.Visualizers
{
    internal class GanttChartVisualizer
    {
        public static void Show(double MaximumTime, List<ITask> Tasks)
        {
            // Top border
            Console.WriteLine(" " + new string('―', (int)MaximumTime * 3 + 4));

            // Time labels
            Console.Write("|   ");
            for (int Time = 0; Time < MaximumTime; Time += 1)
            {
                Console.Write($"{Time,-3}");
            }
            Console.WriteLine(" |");

            foreach (var Task in Tasks)
            {
                if (Task is IStateHistory TaskWithChart)
                {
                    Console.Write("| ");
                    Console.Write($"{Task.Name} ");
                    while (TaskWithChart.Histories.Count > 0)
                    {
                        var State = TaskWithChart.Histories.Dequeue();

                        Console.Write(GetTaskStateString(State));
                    }
                    Console.WriteLine(" |");
                }
            }

            // Bottom border
            Console.WriteLine(" " + new string('―', (int)MaximumTime * 3 + 4));
        }

        private static string GetTaskStateString(TaskState State)
        {
            char StateChar = ' ';
            switch (State)
            {
                case TaskState.Waiting:
                    StateChar = ' ';
                    break;
                case TaskState.Executing:
                    StateChar = '\u25A0';
                    break;
                case TaskState.Suspending:
                    StateChar = 'x';
                    break;
                case TaskState.MissedDeadline:
                    StateChar = '!';
                    break;
                
            }
            return new string(StateChar, 3);
        }
    }
}
