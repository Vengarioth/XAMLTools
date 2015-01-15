using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAMLTools.Scanner.Token
{
    class BeginReference : ITokenDefinition
    {
        public DocumentState ActiveDuringState
        {
            get { return DocumentState.InReference; }
        }

        public string Name
        {
            get { return "BeginReference"; }
        }

        public bool MatchOne(char character, ISampler sampler)
        {
            throw new NotImplementedException();
        }
    }
}
