using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAMLTools.Scanner.Token
{
    class BeginTag : ITokenDefinition
    {
        public DocumentState ActiveDuringState
        {
            get { return DocumentState.InText; }
        }

        public string Name
        {
            get { return "BeginTag"; }
        }

        public bool MatchOne(char character, ISampler sampler)
        {
            char nextCharacter;
            if (character == '<' && sampler.PeekAhead(out nextCharacter) && char.IsLetter(nextCharacter))
            {
                string name = nextCharacter.ToString();

                sampler.Next();
                while (sampler.PeekAhead(out nextCharacter))
                {
                    if (!char.IsLetterOrDigit(nextCharacter) && nextCharacter != ':')
                        break;

                    name += nextCharacter.ToString();
                    sampler.Next();
                }

                sampler.State = DocumentState.InElement;
                System.Diagnostics.Debug.WriteLine("<" + name);
                return true;
            }

            return false;
        }
    }
}
