using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAMLTools.Scanner
{
    public interface ISampler
    {
        /// <summary>
        /// Gets or Sets the current document state
        /// </summary>
        DocumentState State { get; set; }

        /// <summary>
        /// Advances the position by one.
        /// </summary>
        void Next();

        /// <summary>
        /// Reads the character at the current position. Returns false if the current position is beyond bounds.
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        bool ReadCharacter(out char character);

        /// <summary>
        /// Peeks the character at the next position without advancing the position. Returns false if the next position is beyond bounds.
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        bool PeekAhead(out char character);
    }
}
