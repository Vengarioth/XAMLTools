using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAMLTools.Scanner.Token
{
    class EndTag : ITokenDefinition
    {
        public DocumentState ActiveDuringState
        {
            get { return DocumentState.InElement; }
        }

        public string Name
        {
            get { return "EndTag"; }
        }

        public bool MatchOne(char character, ISampler sampler)
        {
            if (character == '>')
            {
                sampler.State = DocumentState.InText;
                System.Diagnostics.Debug.WriteLine(">");
                return true;
            }

            return false;
        }
    }
}
