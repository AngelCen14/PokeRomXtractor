using PokeRomXtractor.Core.Data.Gen3;

namespace PokeRomXtractor.Core.Extractors;

public abstract class RomExtractor {
    // Offsets
    protected int PokemonDataOffset;
    protected int ItemsOffset;
    protected int PokemonNamesOffset;
    protected int AbilitiesOffset;
    
    // Max number of data
    protected int NumberOfPokemons;
    protected int NumberOfItems;
    protected int NumberOfAbilities;
    
    // Data structures size
    protected int PokemonBytesSize;
    protected int ItemBytesSize;
    protected int PokemonNameBytesSize;
    protected int AbilityBytesSize;
    
    protected readonly byte[] RomData;
    
    public List<Item> Items { get; private set; }
    public List<string> Abilities { get; private set; }
    public List<string> PokemonNames { get; private set; }
    public List<Pokemon?> PokemonList { get; private set; }

    protected RomExtractor(byte[] romData) {
        RomData = romData;
        Items = [];
        Abilities = [];
        PokemonNames = [];
        PokemonList = [];
    }
    
    protected abstract Pokemon? ExtractPokemon(uint pokemonIndex);
    protected abstract void ExtractAllPokemon();
    protected abstract void ExtractAllItems();
    protected abstract void ExtracAbilities();
    protected abstract void ExtracPokemonNames();

    public abstract void GeneratePokemonListJson(string path);
}