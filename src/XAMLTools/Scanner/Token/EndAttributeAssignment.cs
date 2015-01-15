using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAMLTools.Scanner.Token
{
    class EndAttributeAssignment : ITokenDefinition
    {
        public DocumentState ActiveDuringState
        {
            get { return DocumentState.InAttributeValue; }
        }

        public string Name
        {
            get { return "EndAttributeAssignment"; }
        }

        public bool MatchOne(char character, ISampler sampler)
        {
            if (character == '"')
            {
                sampler.State = DocumentState.InElement;
                System.Diagnostics.Debug.WriteLine("\"");
                return true;
            }

            return false;
        }
    }
}
