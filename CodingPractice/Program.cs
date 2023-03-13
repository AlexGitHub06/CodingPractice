using System;
using System.Xml.Schema;

namespace CodingPractice // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main()
        {
            //Console.WriteLine(BinaryGap(1041));
            int[] A = new int[] { 9,3,9,3,9,7,9};
            int[] B = CyclicRotation(A, 3);
            //Console.WriteLine(string.Join(',', B));
            Console.WriteLine(OddOccurances(A));
            //Console.WriteLine(FrogJump(10, 85, 30));
            //Console.WriteLine(PermMissingElim(A));
            //Console.WriteLine(TapeEquilibrium(A));
        }

        static int BinaryGap(int num)
        {
            string binary = Convert.ToString(num, 2);
            int n = 0;
            int maxN = 0;
            foreach (char i in binary)
            {
                if (i == '0') { n++; }
                else if (i == '1')
                {
                    if (n > maxN) { maxN = n; }
                    n = 0;
                }
            }

            return maxN;
        }

        static int[] CyclicRotation(int[] A, int K)
        {
            int[] array = new int[A.Length];
            for (int i = 0; i < A.Length; i++)
            {
                int index = (i + K) % A.Length;
                array[index] = A[i];
            }

            return array;
        }

        static int OddOccurances(int[] A)
        {
            Dictionary<int, int> dic = new();
            foreach (int i in A)
            { 
                if (!dic.ContainsKey(i)) { dic[i] = 1; }
                else { dic[i]++; }
            }

            foreach(int key in dic.Keys)
            {
                if (dic[key] % 2 == 1) { return key; }
            }
            return 0;
        }

        static int FrogJump(int X, int Y, int D)
        {
            int dif = Y - X;
            return (int)Math.Ceiling((double)dif / D);
        }

        static int PermMissingElim(int[] A)
        {
            long max = A.Length + 1;
            long total = max*(max + 1) / 2;
            return (int)total - A.Sum(); //manually in codility
        }

        static int TapeEquilibrium(int[] A)
        {
            int pre = 0;
            int post = A.Sum();
            int dif = 0;
            int minDif = 2000;

            for (int i = 0; i < A.Length-1; i++)
            {
                pre += A[i];
                post -= A[i];
                dif = Math.Abs(post - pre);
                if (dif < minDif) { minDif = dif; }
            }

            return minDif;
        }
    }
}