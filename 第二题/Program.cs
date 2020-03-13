using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Form form1 = new Form();
            //form1.clock1.StartClock(20);
        }
    }

    public delegate void ClockHandler(object sender, ClockEventArgs args);
    public class ClockEventArgs
    { public int AlarmTime { set; get; } }

    public class Clock
    {
        public event ClockHandler Tick;
        public event ClockHandler Alarm;


        public void StartClock(int alarmtime)
        {
            ClockEventArgs args = new ClockEventArgs() { AlarmTime = alarmtime };
            int inittime = 0;

            while (true)
            {
                Tick(this, args);

                inittime++;
                if (inittime == args.AlarmTime)
                    Alarm(this, args);
                    Thread.Sleep(1000);
            }
        }
    }

    public class Form
    {
        public Clock clock1 = new Clock();
        public Form()
        {
            clock1.Tick += new ClockHandler(Clk_Tick);
            clock1.Alarm += Clk_Alarm;
        }
        void Clk_Tick(object sender, ClockEventArgs args)
        {
            Console.WriteLine("Tick");
        }
        void Clk_Alarm(object sender, ClockEventArgs args)
        {
            Console.WriteLine("Alarm!!!");
        }
    }
}
