using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAMLTools.Scanner
{
    class Scanner
    {
        public void Scan(ISampler sampler)
        {
            sampler.State = DocumentState.InText;

            ITokenDefinition[] tokenDefinitions = new ITokenDefinition[] {
                //all tag beginnings and endings
                new Token.BeginClosingTag(),
                new Token.EndClosingTag(),
                new Token.BeginTag(),
                new Token.EndAndCloseTag(),
                new Token.EndTag(),
                new Token.ClosingTagName(),

                //element attributes
                new Token.AttributeName(),
                new Token.BeginAttributeAssignment(),
                new Token.EndAttributeAssignment(),
                new Token.AttributeValueTextBlock(),

                //document text
                new Token.DocumentTextBlock()
            };


            char character;
            while(sampler.ReadCharacter(out character))
            {
                for (int i = 0; i < tokenDefinitions.Length; i++)
                {
                    if (sampler.State == tokenDefinitions[i].ActiveDuringState && tokenDefinitions[i].MatchOne(character, sampler))
                    {
                        break;
                    }
                }

                sampler.Next();



                /*
                switch (sampler.State)
                {
                    case DocumentState.InText:
                        if (character == '<')
                        {
                            char nextCharacter;
                            if (sampler.PeekAhead(out nextCharacter) && nextCharacter == '/')
                            {
                                sampler.Next();
                                sampler.State = DocumentState.InElementClosing;
                                Debug.WriteLine("</");
                            }
                            else
                            {
                                sampler.State = DocumentState.InElement;
                                Debug.WriteLine("<");
                            }
                        }
                        else if (char.IsLetterOrDigit(character))
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

                            Debug.WriteLine(name);
                        }
                        break;




                    case DocumentState.InElement:
                        if (character == '/')
                        {
                            char nextCharacter;
                            if (sampler.PeekAhead(out nextCharacter) && nextCharacter == '>')
                            {
                                sampler.Next();
                                sampler.State = DocumentState.InText;
                                Debug.WriteLine("/>");
                            }
                        }
                        else if (character == '=')
                        {
                            Debug.WriteLine("=");
                        }
                        else if (character == '"')
                        {
                            sampler.State = DocumentState.InAttributeValue;
                            Debug.WriteLine("\"");
                        }
                        else if (character == '>')
                        {
                            sampler.State = DocumentState.InText;
                            Debug.WriteLine(">");
                        }
                        else if (char.IsLetterOrDigit(character))
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

                            Debug.WriteLine(name);
                        }
                        break;




                    case DocumentState.InElementClosing:
                        if (character == '>')
                        {
                            sampler.State = DocumentState.InText;
                            Debug.WriteLine(">");
                        }
                        else if (char.IsLetterOrDigit(character))
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

                            Debug.WriteLine(name);
                        }
                        break;
                */
            }

        }
    }
}
