﻿namespace CFGToolkit.GrammarDefinition.Structure
{
    public class Literal : ISymbol
    {
        public Literal(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public override string ToString()
        {
            return Value;
        }
    }
}
