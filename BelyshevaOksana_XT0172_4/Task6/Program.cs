using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    public class Program
    {
        public static int[] FillArray(int length, Random random)
        {
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = random.Next(-1000, 1000);
            }

            return array;
        }

        public static long[] MeasurementOfTime(int[] array)
        {
            long[] arrayTime = new long[5];
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            SeekPositiveElement.SimpleSeekPositiveElement(array);
            stopwatch.Stop();
            arrayTime[0] = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();

            stopwatch.Start();
            SeekPositiveElement.DelegateSeekPositiveElement(array, SeekPositiveElement.IsPositive);
            stopwatch.Stop();
            arrayTime[1] = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();

            stopwatch.Start();
            SeekPositiveElement.DelegateSeekPositiveElement(array, delegate(int x) { return x > 0; });
            stopwatch.Stop();
            arrayTime[2] = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();

            stopwatch.Start();
            SeekPositiveElement.DelegateSeekPositiveElement(array, (x) => (x > 0));
            stopwatch.Stop();
            arrayTime[3] = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();

            stopwatch.Start();
            SeekPositiveElement.LINQSeekPositiveElement(array);
            stopwatch.Stop();
            arrayTime[4] = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();

            return arrayTime;
        }

        public static void Main(string[] args)
        {
            Random random = new Random();
            int countMeasurement = 100;
            int lengthArray = 100;
            long[] measurement = new long[5];

            for (int i = 0; i < countMeasurement; i++)
            {
                int[] array = FillArray(lengthArray, random);
                long[] oneMeasurement = MeasurementOfTime(array);
                measurement[0] += oneMeasurement[0];
                measurement[1] += oneMeasurement[1];
                measurement[2] += oneMeasurement[2];
                measurement[3] += oneMeasurement[3];
                measurement[4] += oneMeasurement[4];
            }

            using (StreamWriter sw = new StreamWriter("result.txt"))
            {
                sw.WriteLine("SimpleSeekPositive " + ((double)measurement[0] / countMeasurement));
                sw.WriteLine("DelegateSeekPositiveElement " + ((double)measurement[1] / countMeasurement));
                sw.WriteLine("AnonymusSeekPositiveElement " + ((double)measurement[2] / countMeasurement));
                sw.WriteLine("LambdaSeekPositiveElement " + ((double)measurement[3] / countMeasurement));
                sw.WriteLine("LINQSeekPositiveElement " + ((double)measurement[4] / countMeasurement));
            }     
        }
    }
}
