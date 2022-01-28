namespace ReadFile.DTO;

internal class PokemonDTO
{
    private PokemonDTO(
        int id,
        string name,
        string type,
        int attack,
        int defense,
        int speed)
    {
        Id = id;
        Name = name;
        Type = type;
        Attack = attack;
        Defense = defense;
        Speed = speed;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string SpecialMove { get; set; }
    public string Type { get; set; }
    public int Health { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int SpecialAttack { get; set; }
    public int SpecialDefense { get; set; }
    public int Speed { get; set; }
    public int Generation { get; set; }

    public static PokemonDTO CreatePokemonDTO(
        int id,
        string name,
        string type,
        int attack,
        int defense,
        int speed,
        int generation)
        => type.ToUpper().Trim() switch
        {
            "FIRE" => CreatePokemon(id, name, type, attack, defense, speed, generation)
                        .SetSpecialAttack(specialAttack: attack + 15)
                        .SetSpecialDefente(specialDefense: defense + 5)
                        .SetSpecialMove(specialMove: "Fire Blast"),

            "WATER" => CreatePokemon(id, name, type, attack, defense, speed, generation)
                        .SetSpecialAttack(specialAttack: attack + 5)
                        .SetSpecialDefente(specialDefense: defense + 15)
                        .SetSpecialMove(specialMove: "Waterfall"),

            "GRASS" => CreatePokemon(id, name, type, attack, defense, speed, generation)
                        .SetSpecialAttack(specialAttack: attack + 10)
                        .SetSpecialDefente(specialDefense: defense + 10)
                        .SetSpecialMove(specialMove: "Giga Drain"),
            _ => CreatePokemon(id, name, type, attack, defense, speed, generation),
        };

    private static PokemonDTO CreatePokemon(
        int id,
        string name,
        string type,
        int attack,
        int defense,
        int speed,
        int generation)
    {
        var pokemon = new PokemonDTO(id, name, type, attack, defense, speed);
        pokemon.SetGeneration(generation);
        return pokemon;
    }

    private PokemonDTO SetSpecialAttack(int specialAttack)
    {
        SpecialAttack = specialAttack;
        return this;
    }

    private PokemonDTO SetSpecialDefente(int specialDefense)
    {
        SpecialDefense = specialDefense;
        return this;
    }

    private PokemonDTO SetSpecialMove(string specialMove)
    {
        SpecialMove = specialMove;
        return this;
    }

    private PokemonDTO SetGeneration(int generation)
    {
        Generation = generation;
        return this;
    }
}