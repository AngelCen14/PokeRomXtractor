using PokemonRomExtractor.Core.Extractors;

namespace PokemonRomExtractor;

class Program {
    public static void Main() {
        string romPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\roms\pokemon_emerald.gba"));
        try {
            RomExtractor romExtractor = ExtractorManager.GetRomExtractor(romPath);
        
            /*List<Pokemon?> pokemons = extractor.ExtractAllPokemon();
            pokemons.ForEach(p => Console.WriteLine(p+"\n"));*/
        
            /*Console.WriteLine("--- Abilities ---");
            romExtractor.Abilities.ForEach(Console.WriteLine);
        
            Console.WriteLine("\n--- Items ---");
            romExtractor.Items.ForEach(Console.WriteLine);*/
            
            Console.WriteLine(romExtractor.PokemonList[400]);
        } catch (Exception e) {
            Console.Error.WriteLine(e.Message);
        }
    }
}