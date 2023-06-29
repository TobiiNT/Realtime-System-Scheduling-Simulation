using SchedulingSimulation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSimulation.Ultilities
{
    internal class Calculator
    {
        public static double Utilization(List<ITask> Tasks)
        {
            double Utilization = 0;

            foreach (var Task in Tasks)
            {
                Utilization += (double)Task.ExecutionTime / Task.Period;
            }

            return Utilization;
        }
        public static double Hyperperiod(List<ITask> Tasks)
        {
            double Hyperperiod = 1;

            foreach (var task in Tasks)
            {
                Hyperperiod = LCM(Hyperperiod, task.Period);
            }

            return Hyperperiod;
        }

        private static double LCM(double a, double b)
        {
            return Math.Abs(a * b) / GCD(a, b);
        }

        private static double GCD(double a, double b)
        {
            while (b != 0)
            {
                double temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }
    }
}
