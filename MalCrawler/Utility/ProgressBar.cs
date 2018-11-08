using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalCrawler.Utility
{
    public class ProgressBar
    {
        public int ConsolePosition { get; }
        public int Size { get; }
        public int Value { get; private set; }
        public double Pourcentage => (double)Value / (double)Size;

        public ProgressBar(int size, int consolePosition)
        {
            Size = size;
            ConsolePosition = consolePosition;
        }

        public void Increment()
        {
            Value++;
            Logger.UpdateProgressBar(this);
        }
    }
}
