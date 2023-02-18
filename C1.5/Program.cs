/**
 * One Away: There are three types of edits that can be performed on strings: 
 * insert a character, 
 * remove a character, 
 * or replace a character. 
 * 
 * Given two strings, write a function to check if they are one edit (or zero edits) away.
 * EXAMPLE
 * pale, ple-> true //remove
 * pales, pale -> true //add
 * pale, bale -> true //replace
 * pale, bae -> false //replace + remove
 */

System.Diagnostics.Debug.Assert(OneEditAway("pale", "ple"));
System.Diagnostics.Debug.Assert(OneEditAway("pales", "pale"));
System.Diagnostics.Debug.Assert(OneEditAway("pale", "bale"));
System.Diagnostics.Debug.Assert(!OneEditAway("pale", "bae"));
System.Diagnostics.Debug.Assert(OneEditAway("ab", "abc"));
System.Diagnostics.Debug.Assert(OneEditAway("abc", "ab"));
System.Diagnostics.Debug.Assert(!OneEditAway("abc", "bca"));

static bool OneEditAway(string str1, string str2)
{
    if (Math.Abs(str1.Length - str2.Length) > 1)
        return false;


    if (str1.Length == str2.Length) // case replacement
    {
        return OneEditReplace(str1, str2);
    }
    else if (str1.Length > str2.Length)     // addition
    {
        return OneEditInsert(str1, str2);
    }
    else if (str1.Length < str2.Length)
    {
        return OneEditInsert(str2, str1);
    }

    return false;
}

static bool OneEditReplace(string str1, string str2)
{
    bool foundReplaced = false;
    for (int i = 0; i < str1.Length; i++)
    {
        if (str1[i] != str2[i])
        {
            if (foundReplaced)
                return false;

            foundReplaced = true;
        }
    }
    return true;
}

static bool OneEditInsert(string str1, string str2)
{
    int str2Index = 0;
    bool foundAdditionSubstraction = false;

    for (int str1Index = 0; str1Index < str1.Length; str1Index++)
    {
        if (str2.Length == str2Index + 1)
            continue;

        if (str1[str1Index] != str2[str2Index])
        {
            if (foundAdditionSubstraction)
                return false;

            foundAdditionSubstraction = true;
        }
        else
        {
            str2Index++;
        }
    }
    return true;
}
