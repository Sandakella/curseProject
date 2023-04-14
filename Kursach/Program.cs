using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Kursach
{
    internal class Program
    {
        public static List<int> curStr = new List<int>();
        public static List<int> maxStr = new List<int>();
        public static Pair[] EnteredPairs = new Pair[9];

        static void Main(string[] args)
        {
            Console.WriteLine("Курсовая работа");
            Console.WriteLine("Набор неповторяющихся пар: \n(1;2) \n(2;1) \n(4;1) \n(2;6) \n(9;2) \n(3;5) \n(9;1) \n(6;7) \n(8;4)");

            EnteredPairs[0] = new Pair() { first = 1, second = 2 };
            EnteredPairs[1] = new Pair() { first = 2, second = 1 };
            EnteredPairs[2] = new Pair() { first = 4, second = 1 };
            EnteredPairs[3] = new Pair() { first = 2, second = 6 };
            EnteredPairs[4] = new Pair() { first = 9, second = 2 };
            EnteredPairs[5] = new Pair() { first = 3, second = 5 };
            EnteredPairs[6] = new Pair() { first = 9, second = 1 };
            EnteredPairs[7] = new Pair() { first = 6, second = 7 };
            EnteredPairs[8] = new Pair() { first = 8, second = 4 };
            
            var pairs = CopyFrom(EnteredPairs);

            Find2(pairs);
            Console.WriteLine("");
            Console.WriteLine("Результат");
            foreach (var c in maxStr)
            {
                Console.Write(c + " ");
            }
            Console.ReadKey();
        }

        public static Pair[] CopyFrom(Pair[] source) //
        {
            var destination = new Pair[source.Length];
            for(var i = 0; i < source.Length; i++)
            {
                destination[i] = new Pair() { first = source[i].first, second = source[i].second};
            }
            return destination;
        }

        public static void Find2(Pair[] pairs)
        {
            var localPairs = new Pair[pairs.Length];
            for (var i = 0; i < pairs.Length; i++)
            {
                localPairs = CopyFrom(pairs);
                curStr.AddRange(new List<int>{ localPairs[i].first, localPairs[i].second});
                var nextPair = pairs.FirstOrDefault(x => localPairs[i].second == x.first);
                if (nextPair != null)
                {
                    var curPairSecond = pairs[i].second;
                    localPairs = localPairs.Where(x => x.first != localPairs[i].first && x.second != localPairs[i].second).ToArray();
                    if (curStr.Count > maxStr.Count)
                    {
                        maxStr.Clear();
                        maxStr.AddRange(curStr);
                    }
                    Find3(curPairSecond, localPairs);
                }
                curStr.Clear();
            }
        }

        public static void Find3(int prevSecond, Pair[] pairs)
        {
            var nextPair = pairs.FirstOrDefault(x => prevSecond == x.first);
            if (nextPair != null)
            {
                curStr.Add(nextPair.second);
                if (curStr.Count > maxStr.Count)
                {
                    maxStr.Clear();
                    maxStr.AddRange(curStr);
                }
                var nextPairSecond = nextPair.second;
                pairs = pairs.Where(x => x.first != nextPair.first && x.second != nextPair.second).ToArray();
                Find3(nextPairSecond, pairs);
            }
        }

    }

    public class Pair
    {
        public int first { get; set; }
        public int second { get; set; }
    }
}
  
