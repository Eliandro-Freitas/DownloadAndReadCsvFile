using CsvHelper;
using CsvHelper.Configuration;
using ReadFile.DTO;
using ReadFile.Helper;
using ReadFile.Model;
using System.Globalization;
using System.Text;

namespace ReadFile.ReadingService;

public class Service
{
    private readonly CultureInfo _cultureInfo = new("pt-BR");
    private IEnumerable<PokemonCsv> _pokemonCsv;
    private IEnumerable<PokemonDTO> _pokemonDTO;
    private readonly CsvReader _csvReader;

    public Service()
    {
    }

    public void Run(Stream stream)
    {
        FetchPokemonCsv(stream);
        ParseToDTO();
    }

    private void ParseToDTO()
        => _pokemonDTO = _pokemonCsv.Select(ParseToDto);

    private static PokemonDTO ParseToDto(PokemonCsv pokemon)
        => PokemonDTO.CreatePokemon(
            int.Parse(pokemon.Id),
            pokemon.Name,
            pokemon.Type,
            int.Parse(pokemon.Attack),
            int.Parse(pokemon.Defense),
            int.Parse(pokemon.SpecialAttack),
            int.Parse(pokemon.Generation));

    private void FetchPokemonCsv(Stream stream)
    {
        var csvConfiguration = GetCsvConfiguration();
        using var csvReader = CsvReader(csvConfiguration, stream);
        _pokemonCsv = csvReader.GetRecords<PokemonCsv>().ToList().Skip(1);
    }

    private static CsvReader CsvReader(CsvConfiguration csvConfiguration, Stream stream)
    {
        var reader = new StreamReader(stream, Encoding.GetEncoding("iso-8859-1"));
        var csvReader = new CsvReader(reader, csvConfiguration);
        csvReader.Context.RegisterClassMap(typeof(PokemonMap));
        return csvReader;
    }

    private CsvConfiguration GetCsvConfiguration()
        => new(_cultureInfo)
        {
            Delimiter = ",",
            HasHeaderRecord = false,
            BadDataFound = null,
            MissingFieldFound = null
        };
}