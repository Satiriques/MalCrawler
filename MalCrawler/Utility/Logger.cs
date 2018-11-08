using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalCrawler.Utility
{
    public static class Logger
    {
        static private int position = 0;
        public static void Log()
        {
            position++;
        }

        public static ProgressBar StartProgressBar(int size)
        {
            Console.WriteLine("||||||||||| 0%");
            return new ProgressBar(size, position++);
        }

        internal static void UpdateProgressBar(ProgressBar bar)
        {
            Console.SetCursorPosition(0, bar.ConsolePosition);
            int numBar = (int)(bar.Pourcentage / 10);
        }

        public static void ClearProgressBar()
        {

        }

    }
}
