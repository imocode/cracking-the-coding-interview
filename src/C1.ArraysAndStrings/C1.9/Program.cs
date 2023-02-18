/*
StringRotation: Assume you have a method i5Sub5tring which checks if one word is 
a substring of another. 

Given two strings, S1 and S2, write code to check if S2 is a rotation of S1 
using only one call to i5Sub5tring (e.g., "waterbottle" is a rotation of" 
erbottlewat").

waterbottle wat-erbottle
erbottlewat erbottle-wat

w aterbottle -> aterbottlew
wa terbottle
wat erbottle
wate rbottle
water bottle
waterb ottle
waterbo ttle
waterbot tle
waterbott le
waterbottl e

Q: is waterbottle rotation of waterbottle?

The first thing that comes to mind is to have a string, doble size of the 
original, duplicating all its content. In this case, the new string would be 
"waterbottlewaterbottle". Then, the isSubstring can be called only one. Time
complexity should be constant, but space is taking twice the size of the string.


*/

using System.Diagnostics;

Debug.Assert(IsStringRotation("waterbottle", "terbottlewa"));
Debug.Assert(!IsStringRotation("waterbottle", "terbottlew"));


static bool IsStringRotation(string s1, string s2) {
    if (s1.Length != s2.Length)
        return false;

    string doubleString = s1 + s1;

    if (doubleString.Contains(s2))
        return true;
    return false;
}
