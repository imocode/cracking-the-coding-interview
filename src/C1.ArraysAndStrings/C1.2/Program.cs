using System.Diagnostics;

/**
 * Question in P90
 * Solution in P193
 * Ask: Charset?
 * Ask: Can I use datastructures? -> If can't use Dictionary, then Charset becomes important.
 * Option 1: Loop on string A and store in Dictionary<char, int>, then loop through string B and "undo". 2N => N
 * Option 2: Sort both strings and walk through them. Requires 2 sorts. 2 x N x Log(N) => N* Log(N)
 * 
 * What I didn't ask:
 * case sensitive
 * whitespace is significant
 * 
 * ASCII charset is 7 bit (128 possibilities, which is a-z A-Z 0-9 and some puntuation. 95 are printable and 33 not printable, like CR)
 * ASCII extended is 256 bits, it adds support for accent and other chars for german, french, spanish, etc
 * UTF -> 8 to 32 bits, so 1 to 4 bytes. MANY possibilities, hard to put in an array.
 * 
*/

IPermutationResolver permutator = new PermutationResolverBitArrayWithASCII();

Debug.Assert(permutator.IsPermutation("abc", "cba"));
Debug.Assert(!permutator.IsPermutation("abcd", "abc"));
Debug.Assert(!permutator.IsPermutation("abc", "abd"));

interface IPermutationResolver
{
    bool IsPermutation(string strA, string strB);
}

class PermutationResolverHashMap : IPermutationResolver
{
    public bool IsPermutation(string strA, string strB)
    {
        if (strA.Length != strB.Length)
            return false;

        Dictionary<char, int> map = new Dictionary<char, int>();

        // Load map with strA
        for (int i = 0; i < strA.Length; i++)
        {
            char c = strA[i];
            if (map.ContainsKey(c))
            {
                map[c]++;
            }
            else
            {
                map.Add(c, 1);
            }
        }

        // Undo operation with strB
        for (int i = 0; i < strB.Length; i++)
        {
            char c = strB[i];
            if (!map.ContainsKey(c) || map[c] == 0)
                return false;

            map[c]--;
        }
        return true;
    }
}

class PermutationResolverSortingStrings : IPermutationResolver
{
    public bool IsPermutation(string strA, string strB)
    {
        // Sort both strings and compare them
        return new string(strA.ToCharArray().Order().ToArray()).Equals(new string(strB.ToCharArray().Order().ToArray()));
    }
}

class PermutationResolverBitArrayWithASCII : IPermutationResolver
{
    public bool IsPermutation(string strA, string strB)
    {
        if (strA.Length != strB.Length)
            return false;

        int[] map = new int[128]; //assumption

        for(int i = 0; i < strA.Length; i++)
        {
            map[strA[i]]++;
        }
        for(int i = 0; i< strB.Length; i++)
        {
            if (map[strB[i]] == 0)
                return false;
            map[strB[i]]--;
        }
        return true;
    }
}