using PokemonRomExtractor.Core.Extractors.Gen3;
using PokemonRomExtractor.Core.Games;

namespace PokemonRomExtractor.Core.Extractors;

public static class ExtractorManager {
    public static RomExtractor GetRomExtractor(string romPath) {
        byte[] romData = File.ReadAllBytes(romPath);
        Game? romGame = GameChecker.Check(romData);

        Console.WriteLine("Game: "+romGame);
        
        switch (romGame) {
            case Game.Emerald:
            case Game.FireRed:
                return new Gen3Extractor(romData, romGame);
            default:
                throw new Exception("Unsupported Game");
        }
    }
}