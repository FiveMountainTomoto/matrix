using System;

namespace Matrix
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            double[,] _m1 = new double[,]
            {
                {1,2,3 },
                {2,3,4 },
                {3,4,5 }
            };
            double[,] _m2 = new double[,]
            {
                {1,1,4 },
                {5,1,4 },
                {1,9,1 }
            };
            double[,] _m3 = new double[,]
            {
                {1, 1},
                {4,5 },
                {1,4 }
            };
            double[,] _m4 = new double[,]
            {
                {1,9,1 ,9},
                {8,1,0 ,0},
            };
            Matrix m1 = new Matrix(_m1);
            Matrix m2 = new Matrix(_m2);
            Matrix m3 = new Matrix(_m3);
            Matrix m4 = new Matrix(_m4);
            Console.WriteLine("m1,m2,m3,m4");
            PrintMatrix(m1);
            PrintMatrix(m2);
            PrintMatrix(m3);
            PrintMatrix(m4);
            Console.WriteLine("m1+m2");
            PrintMatrix(m1 + m2);
            Console.WriteLine("m1-m2");
            PrintMatrix(m1 - m2);
            Console.WriteLine("m3*m4");
            PrintMatrix(m3 * m4);
            Console.WriteLine("m4^T");
            PrintMatrix(m4.Transpose());
            Console.WriteLine("m2+m3");
            try
            {
                PrintMatrix(m2 + m3);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("m1*m4");
            try
            {
                PrintMatrix(m1 * m4);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
        private static void PrintMatrix(Matrix m)
        {
            for (int i = 0; i < m.RowsCount; i++)
            {
                for (int j = 0; j < m.ColumnsCount; j++)
                {
                    Console.Write(m[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
