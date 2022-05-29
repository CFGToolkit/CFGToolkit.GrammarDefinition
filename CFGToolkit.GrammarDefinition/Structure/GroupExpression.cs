namespace CFGToolkit.GrammarDefinition.Structure
{
    public class GroupExpression : ISymbol
    {
        public Alternatives Inside { get; set; }

        public override string ToString()
        {
            return "{" + Inside + "}";
        }
    }
}
