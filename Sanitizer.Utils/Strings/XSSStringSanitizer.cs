using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Sanitizer.Utils.Strings
{
    public class XSSStringSanitizer : IStringSanitizer
    {
        public List<SanitizePattern> ListPatterns { get; set; }

        public XSSStringSanitizer()
        {
            ListPatterns = new List<SanitizePattern>();
            ListPatterns.Add(new SanitizePattern() { Pattern = "<script>", ReplacePattern = "[script]" });
            ListPatterns.Add(new SanitizePattern() { Pattern = "</script>", ReplacePattern = "[/script]" });
            //ListPatterns.Add(new SanitizePattern() { Pattern = "(https?|ftp|file)://", ReplacePattern = "" });
            //ListPatterns.Add(new SanitizePattern() { Pattern = "(www.)", ReplacePattern = "" });
        }

        public string Sanitize(string value)
        {
            var result = value;
            foreach (var pattern in ListPatterns)
            {
                result = Regex.Replace(result, pattern.Pattern, pattern.ReplacePattern);
            }

            return result;
        }
    }
}
