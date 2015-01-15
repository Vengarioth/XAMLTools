using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAMLTools.Scanner.Token
{
    class EndAndCloseTag : ITokenDefinition
    {
        public DocumentState ActiveDuringState
        {
            get { return DocumentState.InElement; }
        }

        public string Name
        {
            get { return "EndAndCloseTag"; }
        }

        public bool MatchOne(char character, ISampler sampler)
        {
            char nextCharacter;
            if (character == '/' && sampler.PeekAhead(out nextCharacter) && nextCharacter == '>')
            {
                sampler.Next();
                sampler.State = DocumentState.InText;
                System.Diagnostics.Debug.WriteLine("/>");
                return true;
            }

            return false;
        }
    }
}
