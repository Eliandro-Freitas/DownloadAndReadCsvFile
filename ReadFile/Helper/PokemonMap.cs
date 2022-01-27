using CsvHelper.Configuration;
using ReadFile.Model;

namespace ReadFile.Helper;

public class PokemonMap : ClassMap<PokemonCsv>
{
    public PokemonMap()
    {
        Map(x => x.Id);
        Map(x => x.Name);
        Map(x => x.Type);
        Map(x => x.Total);
        Map(x => x.HealthPoints);
        Map(x => x.Attack);
        Map(x => x.Defense);
        Map(x => x.SpecialAttack);
        Map(x => x.SpecialDefense);
        Map(x => x.Speed);
        Map(x => x.Generation);
    }
}