using CFGToolkit.ParserCombinator;
using System.Linq;

namespace CFGToolkit.GrammarDefinition.Readers.W3CEBNF
{
    public class Reader : IReader
    {
        public string FormatName => "W3CEBNF";

        public Grammar Read(string txt)
        {
            var grammars = Parsers.Grammar.Parse(txt);
            return grammars.FirstOrDefault();
        }
    }
}
