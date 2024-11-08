using PokeRomXtractor.Core.Extractors.Gen3;
using PokeRomXtractor.Core.Games;

namespace PokeRomXtractor.Core.Extractors;

public static class ExtractorManager {
    public static RomExtractor GetRomExtractor(string romPath) {
        Console.WriteLine("Analyzing rom...");
        byte[] romData = File.ReadAllBytes(romPath);
        Game? romGame = GameChecker.Check(romData);
        Console.WriteLine($"Loaded game: {romGame}");
        
        switch (romGame) {
            case Game.Emerald:
            case Game.FireRed:
                return new Gen3Extractor(romData, romGame);
            default:
                throw new Exception("Unsupported Game");
        }
    }
}