using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAMLTools.Scanner.Token
{
    class DocumentTextBlock : ITokenDefinition
    {
        public DocumentState ActiveDuringState
        {
            get { return DocumentState.InText; }
        }

        public string Name
        {
            get { return "DocumentTextBlock"; }
        }

        public bool MatchOne(char character, ISampler sampler)
        {
            if (char.IsLetterOrDigit(character))
            {
                string name = character.ToString();
                char nextCharacter;
                while (sampler.PeekAhead(out nextCharacter))
                {
                    if (!char.IsLetterOrDigit(nextCharacter))
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
