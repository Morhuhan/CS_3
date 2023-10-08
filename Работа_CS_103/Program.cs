using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Работа_CS_103
{
    internal class Program
    {

        interface StringIndexer
        {
            string this[int m] { get; set; }
        }

        class Stringer : StringIndexer
        {
            private string[] ss;

            public Stringer(int n)
            {
                ss = new string[n];
            }

            // Альтернативная индексация
            //public string GetItem(int m)
            //{
            //    return ss[m];
            //}

            //public void SetItem(int m, string newVal)
            //{
            //    ss[m] = newVal;
            //}

            public string this[int m]
            {
                get { return ss[m]; }
                set { ss[m] = value; }
            }
        }

        interface MatrixIndexer
        {
            int this[int m, int n] { get; set; }
        }

        class Matrix : MatrixIndexer
        {
            private int[,] data;

            public Matrix(int rows, int columns)
            {
                if (rows <= 0 || columns <= 0)
                {
                    throw new ArgumentException("Размеры матрицы должны быть положительными числами.");
                }

                data = new int[rows, columns];
            }

            public int this[int row, int column]
            {
                get
                {
                    CheckIndexValidity(row, column);
                    return data[row, column];
                }
                set
                {
                    CheckIndexValidity(row, column);
                    data[row, column] = value;
                }
            }

            private void CheckIndexValidity(int row, int column)
            {
                // GetLength кол-во элементов в заданном измерении массива
                if (row < 0 || row >= data.GetLength(0) || column < 0 || column >= data.GetLength(1))
                {
                    throw new IndexOutOfRangeException("Индексы выходят за пределы матрицы.");
                }
            }
        }



        static void Main(string[] args)
        {
            //Stringer s = new Stringer(2);

            ////s.SetItem(0, "Ann");
            ////s.SetItem(1, "Ann");
            ////Console.WriteLine(s.GetItem(0));
            ////Console.WriteLine(s.GetItem(1));

            //s[0] = "John";
            //Console.WriteLine(s[0]);

            Matrix m = new Matrix(4, 4);

            m[0,1] = 1;
            m[0,2] = 2;
            m[0,3] = 3;
            //m[0,4] = 4;

            Console.WriteLine(m[0, 1]);
            Console.WriteLine(m[0, 2]);
            Console.WriteLine(m[0, 3]);
        }
    }
}
