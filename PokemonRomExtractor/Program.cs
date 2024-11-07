using PokemonRomExtractor.Core;
using PokemonRomExtractor.Core.Extractors;
using PokemonRomExtractor.Core.Extractors.Gen3;

namespace PokemonRomExtractor;

class Program {
    public static void Main() {
        string romPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\roms\pokemon_emerald.gba"));
        BaseExtractor extractor = new EmeraldExtractor(romPath);
        List<Pokemon?> pokemons = extractor.ExtractAllPokemon();
        pokemons.ForEach(p => Console.WriteLine(p+"\n"));
    }
}