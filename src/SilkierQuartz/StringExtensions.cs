using System.Diagnostics.CodeAnalysis;
using System;

namespace SilkierQuartz;

public static class StringExtensions
{
    /// <summary>
    /// Prepends (i.e. to the beginning) the given <paramref name="prependage"/> if it is not already prefixed to the current string.
    /// </summary>
    /// <param name="theString"></param>
    /// <param name="prependage"></param>
    /// <param name="comparisonType">Specify the comparison type, when checking if the <paramref name="prependage"/> already exists.
    /// <para>This does not re-write the case of the characters in the given <paramref name="prependage"/>.</para></param>
    /// <returns></returns>
    public static string PrependIfAbsent([NotNull] this string theString, string prependage,
        StringComparison comparisonType = StringComparison.CurrentCulture)
    {
        if (string.IsNullOrEmpty(theString)) return theString;

        var prependageLength = Math.Min(theString.Length, prependage.Length);
        string preSubstring = theString.Substring(0, prependageLength);

        if (string.IsNullOrEmpty(preSubstring)) {
            return theString;
        }

        if (preSubstring.Contains(prependage, comparisonType)) return theString;

        return prependage + theString;
    }
}