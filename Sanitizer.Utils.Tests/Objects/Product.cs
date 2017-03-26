using Sanitizer.Utils.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanitizer.Utils.Tests.Objects
{
    internal class Product
    {
        public int ID { get; set; }

        public string Name { get; set; }

        [AntiXSS]
        public string Description { get; set; }
    }
}
