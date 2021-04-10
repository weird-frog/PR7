using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR7_part2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Обеспечьте перенаправление ввода на файл F, а вывода на файл G, и решите следующую задачу: 
             * В файле F хранятся средние температуры за каждый месяц года. 
             * В файле G для каждого месяца сохраните отклонение среднемесячной температуры от среднегодовой.
             * 
             */
            StreamReader inFile = new StreamReader("averageTemp.txt");
            Console.SetIn(inFile);

            // назначение приемника данных, вместо экрана
            StreamWriter outFile = new StreamWriter("G.txt");
            Console.SetOut(outFile);

            double[] arr = Array.ConvertAll(Console.ReadLine().Split(','), Double.Parse);
            double averageYearTemp = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                averageYearTemp += arr[i];
            }
            averageYearTemp /= 12d;
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{Math.Abs(averageYearTemp - arr[i]):f2},");
            }
            // закрытие потоков ввода-вывода
            inFile.Close();
            outFile.Close();
        }
    }
}
