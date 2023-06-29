using SchedulingSimulation.Interfaces;
using SchedulingSimulation.Schedulers;
using SchedulingSimulation.Strategies;
using SchedulingSimulation.Tasks;
using SchedulingSimulation.Ultilities;
using System.Runtime.InteropServices;
using System.Text;

namespace SchedulingSimulation
{
    internal class Program
    {
        [DllImport("kernel32.dll")]
        static extern bool SetConsoleOutputCP(uint wCodePageID);
        static void Main(string[] args)
        {
            SetConsoleOutputCP(65001);
            Console.OutputEncoding = Encoding.UTF8;

            RunWithEDF();

            //RunWithLST();

            Console.ReadKey();
        }

        public static void RunWithEDF()
        {
            List<ITask> Tasks = new List<ITask>
            {
                new PeriodicTask("A", 0, 1, 2),
                new PeriodicTask("B", 0, 1, 4),
                new PeriodicTask("C", 0, 1.5, 6)
            };
            Console.WriteLine($"=> Utilization: {Calculator.Utilization(Tasks)}");
            Console.WriteLine($"=> Hyperperiod: {Calculator.Hyperperiod(Tasks)}");

            Scheduler Scheduler = new Scheduler(new EDFSchedulingStrategy());
            Scheduler.Run(Tasks);

            Console.WriteLine();
        }

        public static void RunWithLST()
        {
            List<ITask> Tasks = new List<ITask>
            {
                new PeriodicTask("A", 0, 6, 20),
                new PeriodicTask("B", 0, 2, 5),
                new PeriodicTask("C", 0, 4, 9),
                new PeriodicTask("D", 3, 2, 5)
            };
            Console.WriteLine($"=> Utilization: {Calculator.Utilization(Tasks)}");
            Console.WriteLine($"=> Hyperperiod: {Calculator.Hyperperiod(Tasks)}");

            Scheduler Scheduler = new Scheduler(new LSTSchedulingStrategy());
            Scheduler.Run(Tasks);

            Console.WriteLine();
        }
    }
}