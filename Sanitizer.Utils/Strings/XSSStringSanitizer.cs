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
            ListPatterns.Add(new SanitizePattern() { Pattern = "<\\s*(script)\\s*>", ReplacePattern = "[script]" });
            ListPatterns.Add(new SanitizePattern() { Pattern = "</script>", ReplacePattern = "[/script]" });
            ListPatterns.Add(new SanitizePattern() { Pattern = "<img src", ReplacePattern = "[img src" });
            ListPatterns.Add(new SanitizePattern() { Pattern = "javascript", ReplacePattern = "[javascript]" });
        }

        public string Sanitize(string value)
        {
            var result = value;
            foreach (var pattern in ListPatterns)
            {
                result = Regex.Replace(result, pattern.Pattern, pattern.ReplacePattern, RegexOptions.IgnoreCase);
            }

            return result;
        }
    }
}
