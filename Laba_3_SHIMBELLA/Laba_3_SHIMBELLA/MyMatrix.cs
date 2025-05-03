using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Laba_3_SHIMBELLA
{
    internal class MyMatrix
    {
        private int[,] _matrix;
        private int rows;
        private int cols;
        
        public int[,] Matrix { get { return _matrix; } }

        public MyMatrix(int[,] matrix)
        {
            _matrix = matrix;
            rows = matrix.GetLength(0);
            cols = matrix.GetLength(1);
        }
        private int[,] CloneMatrix(int[,] matrix)
        {
            int[,] clone = new int[rows, cols];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    clone[i, j] = matrix[i, j];
            return clone;
        }

        private int[,] MinWay(int[,] newMatrix)
        {
            int[,] result = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    List<int> points = new List<int>();
                    for (int k = 0; k < cols; k++)
                    {
                        int point = (_matrix[i, k] == 0 || newMatrix[k, j] == 0) ? 0 : _matrix[i, k] + newMatrix[k, j];
                        if (point != 0)
                            points.Add(point);
                    }                    
                    result[i, j] = (points.Count==0) ? 0 : points.Min();
                }
            }
            return result;
        }
        private int[,] MaxWay(int[,] newMatrix)
        {
            int[,] result = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    List<int> points = new List<int>();
                    for (int k = 0; k < cols; k++)
                    {
                        int point = (_matrix[i, k] == 0 || newMatrix[k, j] == 0) ? 0 : _matrix[i, k] + newMatrix[k, j];
                        if (point != 0)
                            points.Add(point);
                    }
                    result[i, j] = (points.Count == 0) ? 0 : points.Max();
                }
            }
            return result;
        }
        
        public int[,] FindMinWay(int countSteps)
        {
            int[,] result = _matrix;
            for (int i=0; i<countSteps-1; i++)
            {
                result = MinWay(result);
            }
            PrintMatrix(result);
            return result;
        }
        public int[,] FindMaxWay(int countSteps)
        {
            int[,] result = CloneMatrix(_matrix);
            for (int i = 0; i < countSteps-1; i++)
            {
                result = MaxWay(result);
            }
            PrintMatrix(result);
            return result; 
        }
        static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
