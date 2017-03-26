using Sanitizer.Utils.Strings;
using System.Linq;

namespace Sanitizer.Utils.Objects
{
    public class XSSObjectSanitizer<T> where T : class
    {
        public IStringSanitizer Sanitizer { get; set; }

        public XSSObjectSanitizer()
        {
            Sanitizer = new XSSStringSanitizer();
        }

        public T Sanitize(T entity)
        {
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                if (property.GetCustomAttributes(typeof(AntiXSS), false).Any())
                {
                    var value = property.GetValue(entity).ToString();
                    var sanitizedValue = Sanitizer.Sanitize(value);

                    property.SetValue(entity, sanitizedValue);
                }
            }

            return entity;
        }
    }
}
