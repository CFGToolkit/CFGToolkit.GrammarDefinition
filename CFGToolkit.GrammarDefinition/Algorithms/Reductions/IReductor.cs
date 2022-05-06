using System;

namespace CFGToolkit.GrammarDefinition.Algorithms.Reductions
{
    public interface IReductor
    {
        Grammar Reduct(Grammar input, Func<string, bool> filter = null);
    }
}