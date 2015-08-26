using System;
using AntAlgorithm.Algorithm;
using AntAlgorithm.Graph;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var standartAlgoritmBuilder = new StandartAlgoritmBuilder();
            var alg = standartAlgoritmBuilder.GetAlgorithm(0.5,0.5, 100,20);
            var d = new double[6,6];
            d[0, 0] = -1;
            d[0, 1] = 43; 
            d[0, 2] = 39;
            d[0, 3] = 38;
            d[0, 4] = 22;
            d[0, 5] = 9;

            d[1, 0] = 72;
            d[1, 1] = -1;
            d[1, 2] = 65;
            d[1, 3] = 57;
            d[1, 4] = 52;
            d[1, 5] = 70;

            d[2, 0] = 13;
            d[2, 1] = 14;
            d[2, 2] = -1;
            d[2, 3] = 73;
            d[2, 4] = 59;
            d[2, 5] = 39;

            d[3, 0] = 81;
            d[3, 1] = 87;
            d[3, 2] = 86;
            d[3, 3] = -1;
            d[3, 4] = 22;
            d[3, 5] = 17;

            d[4, 0] = 89;
            d[4, 1] = 33;
            d[4, 2] = 65;
            d[4, 3] = 15;
            d[4, 4] = -1;
            d[4, 5] = 8;

            d[5, 0] = 80;
            d[5, 1] = 30;
            d[5, 2] = 10;
            d[5, 3] = 30;
            d[5, 4] = 18;
            d[5, 5] = -1;
            var result = alg.Calculate(new Graph(d));
            Console.ReadLine();
        }
    }
}
