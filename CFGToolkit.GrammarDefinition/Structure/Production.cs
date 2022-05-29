using System.Collections.Generic;
using System.Linq;

namespace CFGToolkit.GrammarDefinition.Structure
{
    public class Production : IStatement
    {
        public ProductionIdentifier Name { get; set; }

        public Alternatives Alternatives { get; set; } = new Alternatives();

        public Dictionary<string, string> Tags { get; set; } = new Dictionary<string, string>();

        public override string ToString()
        {
            return (Name?.Value ?? "null") + " ::=  " + Alternatives.ToString();
        }

        public Production Clone()
        {
            return new Production() { Name = Name, Tags = new Dictionary<string, string>(Tags), Alternatives = new Alternatives(Alternatives.Select(exp => exp.Clone())) };
        }
    }
}
