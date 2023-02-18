/**

Palindrome Permutation: Given a string, write a function to check if it is a permutation of a palindrome. A palindrome is a word or phrase that is the same forwards and backwards. A permutation is a rearrangement of letters. The palindrome does not need to be limited to just dictionary words.
SOLUTION
EXAMPLE
Input: Tact Coa
Output: True (permutations: "taco cat'; "atc o eta·; etc.)

Questions:
    charset? If ascii, I can do a bool array, and check for anything that is not 2 (only 1 1).
    does spaces count?
    from the example, it looks like even center doesn't matter, or is it because of the space?


Option 1: bool array
Option 2: Dictionary / Hash Map

*/

IPalindromePermutationResolver engine = new PalindromePermutationResolverWithHashMap();

System.Diagnostics.Debug.Assert(!engine.IsPalindromePermutation("google"));
System.Diagnostics.Debug.Assert(engine.IsPalindromePermutation("elgoogle"));

interface IPalindromePermutationResolver
{
    bool IsPalindromePermutation(string input);
}

class PalindromePermutationResolverWithBoolArray : IPalindromePermutationResolver
{
    // This solution assumes ASCII (7 bits, 128 chars)
    public bool IsPalindromePermutation(string input)
    {
        int[] map = new int[128];
        // Build the map
        for (int i = 0; i < input.Length; i++)
        {
            map[input[i] - 'a']++;
        }

        // Loop through the whole map and identify uneven chars
        int unevenCount = 0;
        for (int i = 0; i < map.Length; i++)
        {
            if (map[i] % 2 != 0)
                unevenCount++;

            if (unevenCount > 1)
                break;
        }

        return unevenCount <= 1;
    }
}

class PalindromePermutationResolverWithHashMap : IPalindromePermutationResolver
{
    public bool IsPalindromePermutation(string input)
    {
        Dictionary<char, int> map = new Dictionary<char, int>();


        // Fill the map
        for (int i = 0; i < input.Length; i++)
        {
            char inputChar = input[i];
            if (map.ContainsKey(inputChar))
            {
                map[inputChar]++;
            }
            else
            {
                map.Add(inputChar, 1);
            }
        }

        // Loop the map finding one uneven (for even strings) or 2 uneven (for uneven strings)
        int unevenChars = 0;
        for (int i = 0; i < map.Count(); i++)
        {
            if (map.ElementAt(i).Value % 2 != 0)
                unevenChars++;
            if (unevenChars == 2 || (unevenChars == 1 && input.Length % 2 == 0))
                return false;
        }
        return true;
    }
}