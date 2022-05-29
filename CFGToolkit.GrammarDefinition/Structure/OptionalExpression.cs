namespace CFGToolkit.GrammarDefinition.Structure
{
    public class OptionalExpression : ISymbol
    {
        public Alternatives Inside { get; set; }

        public override string ToString()
        {
            return "[" + Inside + "]";
        }
    }
}
