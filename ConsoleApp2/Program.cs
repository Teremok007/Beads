using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArray = new int[] {7, 0, 1, 5, 3, 4, 2, 6};
            foreach (var item in GetMaxSequense(ref intArray))
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();            
            Console.ReadKey();
        }

        public static HashSet<int> GetSeq(ref Dictionary<int,int> beads)
        {
            int currentKey = beads.First().Key;
            int currentValue = beads.First().Value;
            HashSet<int> buf = new HashSet<int>();

            while (buf.Add(currentValue) &&
                  (currentValue != currentKey))
            {
                currentKey = currentValue;
                currentValue = beads[currentValue];
                beads.Remove(currentKey);
            }
            return buf;
        }

        public static int[] GetMaxSequense(ref int[] berds)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < berds.Length; i++)
            {
                dict.Add(i, berds[i]);
            }
            int resLen = 0;
            HashSet<int> maxLenSequense = new HashSet<int>();
            while (dict.Count() > 0)
            {
                HashSet<int> seq = GetSeq(ref dict);
                int len = seq.Count;
                if (len > resLen)
                {
                    resLen = len;
                    maxLenSequense = seq;
                }
            }
            return maxLenSequense.ToArray<int>();
        }
    }
}
