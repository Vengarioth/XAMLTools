using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAMLTools.Scanner
{
    interface ITokenDefinition
    {
        DocumentState ActiveDuringState { get; }
        string Name { get; }
        bool MatchOne(char character, ISampler sampler);
    }
}
