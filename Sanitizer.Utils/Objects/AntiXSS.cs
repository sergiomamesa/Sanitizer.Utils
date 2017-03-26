using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanitizer.Utils.Objects
{
    [AttributeUsage(AttributeTargets.Property)]
    public class AntiXSS : Attribute
    {

    }
}
