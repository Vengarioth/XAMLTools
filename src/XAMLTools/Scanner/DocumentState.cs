using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAMLTools.Scanner
{
    public enum DocumentState
    {
        InText,
        InElement,
        InClosingElement,
        InAttributeValue,
        InReference
    }
}
