using NUnit.Framework;
using Sanitizer.Utils.Objects;

namespace Sanitizer.Utils.Tests.Objects
{
    [TestFixture]
    public class XSSObjectSanitizerTests
    {
        [TestCase]
        public void Test_Sanitize_PropertyDescriptionContainsScript_DescriptionIsSanitized()
        {
            var product = new Product() { ID = 1, Name = "Product1", Description = "<script>you are being attacked</script>" };
            var sanitizer = new XSSObjectSanitizer<Product>();

            var result = sanitizer.Sanitize(product);

            Assert.AreEqual(result.Description, "[script]you are being attacked[/script]");
        }
    }
}
