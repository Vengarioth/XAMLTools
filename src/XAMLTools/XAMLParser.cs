using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XAMLTools
{
    class XAMLParser
    {
        private Scanner.Scanner scanner;

        public XAMLParser()
        {
            scanner = new Scanner.Scanner();
        }

        public void Parse(string xaml)
        {
            var sampler = new Scanner.StringSampler(xaml);
            scanner.Scan(sampler);
        }
    }
}
