/**
 * URLify: Write a method to replace all spaces in a string with '%20'. You may assume that the string has sufficient space at the end to hold the additional characters, and that you are given the "true" length of the string. (Note: if implementing in Java, please use a character array so that you can perform this operation in place.)
EXAMPLE
Input: "Mr John Smith    ", 13
Output: "Mr%20John%20Smith"

Option 1: create new array to return results. Loop from 0 to n-1.
Option 2: avoid creating new array, replace in place. Need to be looped backwards

Question. Can I find an end space?
*/
IURLifyResolver uRLifyResolver = new URLifyResolver();

System.Diagnostics.Debug.Assert(uRLifyResolver.ReplaceSpaces("Mr John Smith    ".ToCharArray(), 13).SequenceEqual("Mr%20John%20Smith".ToCharArray()));

interface IURLifyResolver
{
	public char[] ReplaceSpaces(char[] input, int stringLength);
}

class URLifyResolver : IURLifyResolver
{
	public char[] ReplaceSpaces(char[] input, int stringLength)
	{
		int writePointer = input.Length - 1;

		for (int readPointer = stringLength - 1; readPointer >= 0; readPointer--)
		{

			if (input[readPointer] == ' ') // space treatment
			{
				input[writePointer] = '0';
				input[writePointer - 1] = '2';
				input[writePointer - 2] = '%';
				writePointer -= 3;
			}
			else // normal treatment
			{
				input[writePointer] = input[readPointer];
				writePointer--;
			}
		}

		return input;
	}
}

