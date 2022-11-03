using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;


namespace UCL.Assets.Scripts.Extensions.NaughtyWords
{

    public static partial class NaughtyWordsExtensions
    {
        internal const char ReplacementCharacter = '*';
        internal static readonly char[] TrimChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '!', '$', '@', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+', '`', '~' };
        internal static readonly Regex CleanserRegex = new Regex(@"[^a-zA-Z]", RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase);

        public static bool IsNaughtyWord(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            return EnglishNaughtyWordsSet.Contains(CleanserRegex.Replace(value, string.Empty).ToLowerInvariant());
        }

        public static bool IsThereAnyNaughtyWords(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            var words = value.Split(' ');
            foreach (var word in words)
            {
                if (word.IsNaughtyWord())
                    return true;
            }
            return false;
        }

        public static string ReplaceNaughtyWords(this string value, char replacement = ReplacementCharacter)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return value;
            }

            var words = value.Split(' '); 
            List<string> outWords = new List<string>();
            foreach (var word in words)
            {
                var replacedWord = CleanserRegex.Replace(word, String.Empty);
                outWords.Add(EnglishNaughtyWordsSet.Contains(replacedWord.ToLowerInvariant()) ? new String(replacement, word.Length) : word);
            }
            return string.Join(" ", outWords);
        }
    }
}
