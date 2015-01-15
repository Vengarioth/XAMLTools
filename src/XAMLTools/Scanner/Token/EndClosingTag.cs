using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAMLTools.Scanner.Token
{
    class EndClosingTag : ITokenDefinition
    {
        public DocumentState ActiveDuringState
        {
            get { return DocumentState.InClosingElement; }
        }

        public string Name
        {
            get { return "EndClosingTag"; }
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
