using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TSA.Mongo
{
    public static class Help
    {
        private static Stopwatch _stopwatch;
        public static Stopwatch Stopwatch
        {
            get
            {
                if (_stopwatch == null)
                    _stopwatch = new Stopwatch();
                return _stopwatch;
            }
        }

        public static string FileJson = @"C:\caidtemp\pessoadto.txt";

        public static void Stop(string category = "Testes")
        {
            Stopwatch.Stop();
            var ts = Stopwatch.Elapsed;
            var elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                   ts.Hours, ts.Minutes, ts.Seconds,
                   ts.Milliseconds / 10);
            Debug.WriteLine("Tempo: " + elapsedTime, category);
            System.IO.File.WriteAllText($"C:\\caidtemp\\{Guid.NewGuid().ToString()}.txt", $"Tempo: {elapsedTime} {category}");
        }

        public static void Restart()
        {
            Stopwatch.Restart();
        }
    }
}
