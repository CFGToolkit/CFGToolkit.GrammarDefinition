namespace CFGToolkit.GrammarDefinition.Readers
{
    public interface IReader
    {
        string FormatName { get; }

        Grammar Read(string txt);
    }
}
