using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAMLTools.Scanner.Token
{
    class ClosingTagName : ITokenDefinition
    {
        public DocumentState ActiveDuringState
        {
            get { return DocumentState.InClosingElement; }
        }

        public string Name
        {
            get { return "ClosingTagName"; }
        }

        public bool MatchOne(char character, ISampler sampler)
        {
            if (char.IsLetter(character))
            {
                string name = character.ToString();
                char nextCharacter;
                while (sampler.PeekAhead(out nextCharacter))
                {
                    if (!char.IsLetterOrDigit(nextCharacter) && nextCharacter != ':')
                        break;

                    name += nextCharacter.ToString();
                    sampler.Next();
                }

                System.Diagnostics.Debug.WriteLine(name);
                return true;
            }

            return false;
        }
    }
}
