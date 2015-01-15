using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAMLTools.Scanner
{
    class StringSampler : ISampler
    {
        public DocumentState State { get; set; }

        private string content;
        private int position = 0;

        public StringSampler(string content)
        {
            this.content = content;
        }

        public void Next()
        {
            position++;
        }

        public bool ReadCharacter(out char character)
        {
            if (position >= content.Length)
            {
                character = Char.MinValue;
                return false;
            }

            character = content[position];
            return true;
        }

        public bool PeekAhead(out char character)
        {
            var nextPosition = position + 1;
            if (nextPosition >= content.Length)
            {
                character = Char.MinValue;
                return false;
            }

            character = content[nextPosition];
            return true;
        }
    }
}
