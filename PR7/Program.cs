using System;
using System.IO;

namespace PR7
{
    class Program
    {
        static void Main()
        {
            //Занести в файл 10 действительных чисел. Напечатать в конце файла сумму компонентов данного файла
            try
            {
                BinaryWriter fout = new BinaryWriter(new FileStream("binary.dat", FileMode.Create));
                Random random = new Random();
                double d = 0, sum = 0;

                int i = 1;
                for (; i < 11; i++)
                {
                    d = Math.Round(random.NextDouble() * 100 - 50, 2); 
                    fout.Write(d);
                }

                fout.Close();

                FileStream f = new FileStream("binary.dat", FileMode.Open);
                BinaryReader fin = new BinaryReader(f);

                try
                {
                    while (true)
                    {
                        d = fin.ReadDouble();
                        sum += d;
                    }
                }
                catch (EndOfStreamException e) { }

                fin.Close();
                f.Close();

                fin = new BinaryReader(new FileStream("binary.dat", FileMode.Open));
                for (int j = 0; j < 10; j++)
                {
                    d = fin.ReadDouble();
                    Console.Write(d + " ");
                }

                Console.WriteLine("\nSum = " + sum);

                fin.Close();
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error end: " + e.Message);
                Console.ReadKey();
                return;
            }
        }
    }
}