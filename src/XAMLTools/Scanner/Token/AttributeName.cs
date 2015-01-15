using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAMLTools.Scanner.Token
{
    class AttributeName : ITokenDefinition
    {
        public DocumentState ActiveDuringState
        {
            get { return DocumentState.InElement; }
        }

        public string Name
        {
            get { return "AttributeName"; }
        }

        public bool MatchOne(char character, ISampler sampler)
        {
            if (char.IsLetter(character))
            {
                string name = character.ToString();
                char nextCharacter;
                while (sampler.PeekAhead(out nextCharacter))
                {
                    //for xaml, also allow : in attribute names and resolve the namespace later
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
