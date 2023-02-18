using System.Collections.Generic;
using System.Diagnostics;

/**
 *  Is Unique: Implement an algorithm to determine if a string has all unique characters.
What if you cannot use additional data structures?
Page 90
*/

namespace C1
{

    interface IIsUniqueResolver
    {
        bool IsUnique(string input);
    }
    /*
    * Options:
    * 1. Nested for loops, N^2
    * 2. Using a hash set of char, N
    * 3. Using a bit vector
    * 4. Using 
    */
    class IsUniqueResolverWithHashSet : IIsUniqueResolver
    {
        public bool IsUnique(string input)
        {
            HashSet<char> charSet = new HashSet<char>();
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (charSet.Contains(c))
                    return false;
                charSet.Add(c);
            }
            return true;
        }
    }
    class IsUniqueResolverWithNestedForLoops : IIsUniqueResolver
    {
        public bool IsUnique(string input)
        {
            for (int i = 0; i < input.Length - 1; i++)
            {
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[i] == input[j])
                        return false;
                }
            }
            return true;
        }
    }
    class IsUniqueResolverWithBitArray : IIsUniqueResolver
    {
        public bool IsUnique(string input)
        {
            bool[] bitArray = new bool[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                byte currentByte = (byte)(input[i] - 'a');

                if (bitArray[currentByte])
                    return false;
                bitArray[currentByte] = true;
            }
            return true;
        }
    }
    class IsUniqueResolverWithByte : IIsUniqueResolver
    {
        public bool IsUnique(string input)
        {
            int checker = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int currentByte = input[i] - 'a';
                int shiftedByte = 1 << currentByte;

                System.Console.WriteLine($"{input[i]}");
                System.Console.WriteLine($"Integer: {currentByte}");
                System.Console.WriteLine($"Binary : {System.Convert.ToString(shiftedByte, 2)}");
                System.Console.WriteLine($"Checker: {System.Convert.ToString(checker, 2)}");

                if ((checker & shiftedByte) > 0)
                    return false;

                checker |= shiftedByte;

                System.Console.WriteLine();
            }
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IIsUniqueResolver resolver = new IsUniqueResolverWithByte();
            Debug.Assert(resolver.IsUnique("omar"));
            Debug.Assert(!resolver.IsUnique("omarm"));
            Debug.Assert(resolver.IsUnique("abcdefghijklmnopqrstuvwxyz"));
        }
    }
}


