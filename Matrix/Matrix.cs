using System;
using System.Collections;

namespace Matrix
{
    public class Matrix : IEnumerable
    {
        private double[,] _arr;
        #region 索引器、行列属性
        public int RowsCount => _arr.GetLength(0);
        public int ColumnsCount => _arr.GetLength(1);
        public double this[int row, int col]
        {
            get => _arr[row, col];
            set => _arr[row, col] = value;
        }
        #endregion
        #region 构造函数
        public Matrix(int row, int col) => _arr = new double[row, col];
        public Matrix(double[,] arr) => _arr = arr;
        #endregion
        #region 实现IEnumerable接口
        public IEnumerator GetEnumerator() => _arr.GetEnumerator();
        #endregion
        #region 矩阵加减乘运算、转置
        public Matrix Multiply(Matrix other)
        {
            if (ColumnsCount != other.RowsCount) throw new ArgumentException($"矩阵的列数 {ColumnsCount} 不等于另一矩阵的行数 {other.RowsCount}");
            Matrix result = new Matrix(RowsCount, other.ColumnsCount);
            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < other.ColumnsCount; j++)
                {
                    for (int e = 0; e < ColumnsCount; e++)
                    {
                        result[i, j] += this[i, e] * other[e, j];
                    }
                }
            }
            return result;
        }
        public Matrix Add(Matrix other)
        {
            if (RowsCount != other.RowsCount || ColumnsCount != other.ColumnsCount) throw new ArgumentException($"矩阵的行列数 {RowsCount},{ColumnsCount} 不等于另一矩阵的行列数 {other.RowsCount},{other.ColumnsCount}");
            Matrix result = new Matrix(RowsCount, ColumnsCount);
            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    result[i, j] = this[i, j] + other[i, j];
                }
            }
            return result;
        }
        public Matrix Transpose()
        {
            Matrix result = new Matrix(ColumnsCount, RowsCount);
            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    result[j, i] = this[i, j];
                }
            }
            return result;
        }
        public static Matrix operator -(Matrix m)
        {
            Matrix result = new Matrix(m.RowsCount, m.ColumnsCount);
            for (int i = 0; i < m.RowsCount; i++)
            {
                for (int j = 0; j < m.ColumnsCount; j++)
                {
                    result[i, j] = -m[i, j];
                }
            }
            return result;
        }
        public static Matrix operator -(Matrix m1, Matrix m2) => m1.Add(-m2);
        public static Matrix operator +(Matrix m1, Matrix m2) => m1.Add(m2);
        public static Matrix operator *(Matrix m1, Matrix m2) => m1.Multiply(m2);
        #endregion
    }
}
