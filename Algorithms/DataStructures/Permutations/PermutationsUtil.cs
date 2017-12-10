using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures.Permutations
{
    public static class PermutationsUtil
    {
        public static List<int> GetRandomPermutation(int length)
        {
            var random = new Random();
            List<int> identity = GetIdentity(length);

            List<int> permutation = new List<int>();
            while (identity.Any())
            {
                int randomIndex = random.Next(identity.Count);
                permutation.Add(identity[randomIndex]);
                identity.RemoveAt(randomIndex);
            }

            return permutation;
        }

        public static List<int> GetIdentity(int length)
        {
            List<int> identity = new List<int>();
            for (int i = 0; i < length; i++)
                identity.Add(i);

            return identity;
        }
    }
}
