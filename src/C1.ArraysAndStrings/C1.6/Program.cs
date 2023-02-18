/*
 * String Compression: Implement a method to perform basic string compression using the counts of repeated characters. 
 * For example, the string aabcccccaaa would become a2blc5a3. 
 * 
 * If the "compressed" string would not become smaller than the original string, your method should return the original string. 
 * 
 * You can assume the string has only uppercase and lowercase letters (a - z).
 * 
 * Question: how does upper and lower count? equal or separated? aA could be a1A1 or a2
 * Assuming is a2
 * 
 * aabcccccaaa
 * a2b1c5a3
 * 
 * originalLength = 11
 * currentLeng = 0 to 8
 * currentChar = 'a'
 * currentCount = 3
 * result = 'a2b1c5a3'
 * 
 * when it changes and when it ends, write down to final string
 * compare on each loop with the originalLength
 * 
 */

using System.Text;

System.Diagnostics.Debug.Assert(CompressString("aabcccccaaa") == "a2b1c5a3");
System.Diagnostics.Debug.Assert(CompressString("abcd") == "abcd");
System.Diagnostics.Debug.Assert(CompressString("aAaAaAb") == "a6b1");

static string CompressString(string input)
{
    int originalLength = input.Length;
    StringBuilder result = new StringBuilder();
    int currentCount = 1;
    input = input.ToLower();

    for (int i = 1; i < input.Length; i++)
    {
        if (input[i] == input[i - 1])
        {
            currentCount++;
        }
        else
        {
            result.Append(input[i - 1] + currentCount.ToString());
            currentCount = 1;
        }

        if (result.Length >= originalLength)
        {
            return input;
        }
    }
    result.Append(input[input.Length - 1] + currentCount.ToString());

    return result.ToString();
}