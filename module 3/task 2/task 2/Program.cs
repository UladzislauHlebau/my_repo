using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*namespace task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] MyMatrix = new int[2, 2];

            int a = MyMatrix[0, 0] = 23;
            int b = MyMatrix[1, 0] = -5;
            int c = MyMatrix[0, 1] = 17;
            int d = MyMatrix[1, 1] = -35;

            int det = a * d - b * c;

            int[,] NewMatrix = new int[2, 2];

            int e = a = d;
            int b = MyMatrix[1, 0] = -5;
            int c = MyMatrix[0, 1] = 17;
            int d = MyMatrix[1, 1] = -35;
        }
    }
}
*/

/*namespace task_2
{
    class Program
    {
        public int row, col;
        public int[,] p;
 
        public Matrix(int n, int m)
        {
            row = n;
            col = m;
            p = new int[n, m];
        }
 
        public void InitMartix() // Ввод матрицы
        {
 
            for (int i = 0; i < row; i++)
                for (int j = 0; j < row; j++)
                {
 
                   Console.Write("A[{0},{1}] = ", i, j);
                   p[i, j] = Convert.ToInt32(Console.ReadLine());
                }
        }
    }
}*/


// return matrix
namespace inverse
{
    class Matrix
    {
        public int row, col;
        public int[,] p;

        public Matrix(int n, int m)
        {
            row = n;
            col = m;
            p = new int[n, m];
        }

        public void InitMatrix() // matrix creation
        {

            for (int i = 0; i < row; i++)
                for (int j = 0; j < row; j++)
                {

                    Console.Write("A[{0},{1}] = ", i, j);
                    p[i, j] = Convert.ToInt32(Console.ReadLine());
                }
        }


        public double Det2x2()
        {
            double det;
            det = p[0, 0] * p[1, 1] - p[0, 1] * p[1, 0];

            return det;
        } //determinant 2x2

        public void ShowMartix() //matrix displaying
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    Console.Write(p[i, j]);
                    Console.Write("  ");
                }
                Console.WriteLine();
            }
        }
        //minor determinant
        public Matrix Minor(int a, int b)
        {
            int i, j, p, q;
            Matrix MEN = new Matrix(row - 1, col - 1);
            for (j = 0, q = 0; q < MEN.col; j++, q++)
                for (i = 0, p = 0; p < MEN.row; i++, p++)
                {
                    if (i == a) i++;
                    if (j == b) j++;
                    MEN.p[p, q] = this.p[i, j];
                }
            return MEN;
        }

    }

    class Program
    {

        //matrix determinant
        public static double Det(Matrix B)
        {
            int n;
            int signo;
            double det = 0;

            if (B.row != B.col)
            {
                Console.WriteLine("Matrix should be square.");
                return 0;
            }
            else
                if (B.row == 1)
                    return B.p[0, 0];
                else
                    if (B.row == 2)
                        return B.Det2x2();
                    else
                        for (n = 0; n < B.col; n++)
                        { //sign check
                            if ((n & 1) == 0)
                            {
                                signo = 1;
                            }
                            else
                            {
                                signo = -1;
                            }
                            //(n&1)==0 ? (signo=1):(signo=-1);
                            det = det + signo * B.p[0, n] * Det(B.Minor(0, n));
                        }

            return det;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter matrix dimensions:");
            int[,] A = new int[Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine())];
            Matrix m = new Matrix(A.GetLength(0), A.GetLength(0));
            m.InitMatrix();
            Console.WriteLine("Matrix");
            m.ShowMartix();
            double d = Det(m);
            Console.WriteLine();
            Console.Write("Det = ");
            Console.Write(d);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}