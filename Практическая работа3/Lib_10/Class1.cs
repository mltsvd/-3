using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_10
{
    public class Class1
    {
        /// <summary>
        /// Функция для нахождения столбца с наименьшим произведением элементов
        /// </summary>
        /// <param name="matr"-матрица ></param>
        /// <param name="num"- номер столбца></param>
        /// <param name="minproiz"-наименьшее произведение></param>
        public static void Raschet(int[,] matr, out int num,out int minproiz)
        {
            int i, j;
            num = 0;
            minproiz = 1;
            int proiz = 1;
            for (j = 0; j < 1; j++)
            {
                for (i = 0; i < matr.GetLength(0); i++)
                {
                    minproiz = minproiz * matr[i, j];
                }
                num = j + 1;
            }
                for (j = 0; j < matr.GetLength(1); j++)
                
            {
                proiz = 1;
                for (i = 0; i < matr.GetLength(0); i++)
                {
                    proiz=proiz*matr[i, j];
                }
                if (proiz < minproiz)
                {
                    minproiz = proiz;
                    num = j+1;
                }
            }
        }
    }
}
