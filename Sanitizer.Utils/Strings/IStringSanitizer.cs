using System.Collections.Generic;

namespace Sanitizer.Utils.Strings
{
    public interface IStringSanitizer
    {
        List<SanitizePattern> ListPatterns { get; set; }

        string Sanitize(string value);
    }
}
