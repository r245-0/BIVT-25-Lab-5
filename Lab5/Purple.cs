using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;


            // code here
            answer = new int[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    answer[j] += matrix[i, j] < 0 ? 1 : 0;
                }
            }

            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int min = matrix[i, 0];
                int min_j = 0;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        min_j = j;
                    }
                }

                for (int j = min_j; j >= 1; j--)
                {
                    matrix[i, j] = matrix[i, j - 1];
                }

                matrix[i, 0] = min;

            }
            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            answer = new int[rows, cols + 1];

            for (int i = 0; i < rows; i++)
            {
                int max = matrix[i, 0];
                int maxIdx = 0;
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxIdx = j;
                    }
                }

                for (int j = 0; j <= maxIdx; j++)
                    answer[i, j] = matrix[i, j];
                answer[i, maxIdx + 1] = max;
                for (int j = maxIdx + 1; j < cols; j++)
                    answer[i, j + 1] = matrix[i, j];
            }
            // end

            return answer;
        }

        public void Task4(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                int max = matrix[i, 0];
                int maxIdx = 0;
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxIdx = j;
                    }
                }

                int sum = 0;
                int count = 0;
                for (int j = maxIdx + 1; j < cols; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }

                if (count > 0)
                {
                    int avg = sum / count;
                    for (int j = 0; j < maxIdx; j++)
                    {
                        if (matrix[i, j] < 0)
                            matrix[i, j] = avg;
                    }
                }
            }
            // end

        }

        public void Task5(int[,] matrix, int k)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (k < 0 || k >= cols) return;

            int[] maxs = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                int max = matrix[i, 0];
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > max)
                        max = matrix[i, j];
                }
                maxs[i] = max;
            }

            for (int i = 0; i < rows; i++)
            {
                matrix[i, k] = maxs[rows - 1 - i];
            }
            // end

        }


        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (array.Length != cols) return;

            for (int j = 0; j < cols; j++)
            {
                int max = matrix[0, j];
                int maxIdx = 0;
                for (int i = 1; i < rows; i++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxIdx = i;
                    }
                }

                if (array[j] > max)
                    matrix[maxIdx, j] = array[j];
            }
            // end

        }

        public void Task7(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows - 1; i++)
            {
                for (int k = 0; k < rows - 1 - i; k++)
                {
                    int min1 = matrix[k, 0];
                    int min2 = matrix[k + 1, 0];
                    for (int j = 1; j < cols; j++)
                    {
                        if (matrix[k, j] < min1) min1 = matrix[k, j];
                        if (matrix[k + 1, j] < min2) min2 = matrix[k + 1, j];
                    }

                    if (min1 < min2)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            int temp = matrix[k, j];
                            matrix[k, j] = matrix[k + 1, j];
                            matrix[k + 1, j] = temp;
                        }
                    }
                }
            }
            // end

        }

        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int n = matrix.GetLength(0);
            if (n != matrix.GetLength(1)) return answer;

            answer = new int[2 * n - 1];

            for (int d = 0; d < 2 * n - 1; d++)
            {
                int sum = 0;
                if (d < n)
                {
                    int i = n - 1 - d;
                    int j = 0;
                    while (i < n && j < n)
                    {
                        sum += matrix[i, j];
                        i++;
                        j++;
                    }
                }
                else
                {
                    int i = 0;
                    int j = d - n + 1;
                    while (i < n && j < n)
                    {
                        sum += matrix[i, j];
                        i++;
                        j++;
                    }
                }
                answer[d] = sum;
            }
            // end

            return answer;
        }

        public void Task9(int[,] matrix, int k)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows != cols || k < 0 || k >= rows) return;

            int maxAbs = Math.Abs(matrix[0, 0]);
            int maxI = 0, maxJ = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (Math.Abs(matrix[i, j]) > maxAbs)
                    {
                        maxAbs = Math.Abs(matrix[i, j]);
                        maxI = i;
                        maxJ = j;
                    }
                }
            }

            if (maxI != k)
            {
                int dir = maxI < k ? 1 : -1;
                while (maxI != k)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        int temp = matrix[maxI, j];
                        matrix[maxI, j] = matrix[maxI + dir, j];
                        matrix[maxI + dir, j] = temp;
                    }
                    maxI += dir;
                }
            }

            if (maxJ != k)
            {
                int dir = maxJ < k ? 1 : -1;
                while (maxJ != k)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        int temp = matrix[i, maxJ];
                        matrix[i, maxJ] = matrix[i, maxJ + dir];
                        matrix[i, maxJ + dir] = temp;
                    }
                    maxJ += dir;
                }
            }
            // end

        }

        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            int rowsA = A.GetLength(0);
            int colsA = A.GetLength(1);
            int rowsB = B.GetLength(0);
            int colsB = B.GetLength(1);

            if (colsA != rowsB) return answer;

            answer = new int[rowsA, colsB];

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < colsA; k++)
                        sum += A[i, k] * B[k, j];
                    answer[i, j] = sum;
                }
            }
            // end

            return answer;
        }

        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            answer = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int count = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 0)
                        count++;
                }

                answer[i] = new int[count];
                int idx = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 0)
                        answer[i][idx++] = matrix[i, j];
                }
            }
            // end

            return answer;
        }

        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;

            // code here
            int total = 0;
            for (int i = 0; i < array.Length; i++)
                total += array[i].Length;

            int n = (int)Math.Ceiling(Math.Sqrt(total));
            answer = new int[n, n];

            int row = 0, col = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    answer[row, col] = array[i][j];
                    col++;
                    if (col == n)
                    {
                        col = 0;
                        row++;
                    }
                }
            }
            // end

            return answer;
        }
    }

}