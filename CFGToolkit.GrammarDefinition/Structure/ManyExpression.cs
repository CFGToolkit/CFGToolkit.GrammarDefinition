namespace CFGToolkit.GrammarDefinition.Structure
{
    public class ManyExpression : ISymbol
    {
        public Alternatives Inside { get; set; }

        public bool AtLeastOnce { get; set; } = false;

        public override string ToString()
        {
            return "{" + Inside + "}";
        }
    }
}
