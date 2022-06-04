using CFGToolkit.GrammarDefinition.Structure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CFGToolkit.GrammarDefinition.Algorithms.Reductions
{
    public class PrefixReductor : IReductor
    {
        public Grammar Reduct(Grammar input, Func<string, bool> filter = null)
        {
            var result = input.Clone();
            var productions = input.Productions.Keys.Where(k => filter == null || filter(k)).OrderBy(key => key).ToArray();

            for (var i = 0; i < productions.Length; i++)
            {
                var productionName = productions[i];
                var production = result.Productions[productionName];

                if (production.Alternatives.Count > 1 && production.Alternatives.Any(alt => alt.Count >= 2))
                {
                    var prefixes = new List<string>();
                    foreach (var alternative in production.Alternatives)
                    {
                        prefixes.Add(alternative.FirstOrDefault()?.ToString() ?? "null");
                    }
                    bool hasSamePrefix = prefixes.Distinct().Count() == 1;

                    if (hasSamePrefix)
                    {
                        var prefixProduction = new Production() { Name = new ProductionIdentifier(productionName + "_prefix"), Tags = new Dictionary<string, string>(production.Tags) };
                        prefixProduction.Alternatives = new Alternatives(new Expression(production.Alternatives[0].First()));
                        result.Add(prefixProduction);

                        var restProduction = new Production() { Name = new ProductionIdentifier(productionName + "_rest"), Tags = new Dictionary<string, string>(production.Tags) };
                        restProduction.Alternatives = new Alternatives();
                        foreach (var alt in production.Alternatives)
                        {
                            var newAlt = alt.Skip(1).ToList();
                            if (newAlt.Count == 0)
                            {
                                newAlt.Add(new Empty());
                            }

                            restProduction.Alternatives.Add(new Expression(newAlt));
                        }
                        result.Add(restProduction);

                        production.Alternatives = new Alternatives(new Expression(new ProductionIdentifier(productionName + "_prefix"), new ProductionIdentifier(productionName + "_rest")));
                    }
                }
            }

            return result;
        }
    }
}
