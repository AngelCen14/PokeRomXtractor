namespace PokemonRomExtractor.Core.Extractors;

public abstract class BaseExtractor {
    protected readonly int StartOffset;
    protected readonly int MaxPokemonIndex;
    protected readonly int PokemonBytesSize;
    protected readonly byte[] RomData;

    protected BaseExtractor(string romPath, int startOffset, int maxPokemonIndex, int pokemonBytesSize) {
        StartOffset = startOffset;
        MaxPokemonIndex = maxPokemonIndex;
        RomData = File.ReadAllBytes(romPath);
        PokemonBytesSize = pokemonBytesSize;
    }
    
    public abstract Pokemon? ExtractPokemon(uint pokemonIndex);
    public abstract List<Pokemon?> ExtractAllPokemon();
}