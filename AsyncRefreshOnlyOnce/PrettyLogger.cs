using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncRefreshOnlyOnce
{

    public static class PrettyLogger
    {
        public static void Log(string message, ConsoleColor color = ConsoleColor.White)
        {
            int stackDepth = new StackTrace().FrameCount;
            string indentation = new string(' ', stackDepth * 2);
            string logMessage = $"{indentation}{message}";

            Console.ForegroundColor = color;

            Console.WriteLine(logMessage);
            Thread.Sleep(500); // this in order to "animate" the log
            Console.ResetColor();
        }
    }
}