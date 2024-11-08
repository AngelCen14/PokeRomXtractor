using System.Text;
using PokemonRomExtractor.Core.Games;

namespace PokemonRomExtractor.Core;

public static class GameChecker {
    private static readonly Dictionary<Game, GameInfo> GameDictionary = new() {
        // Gen 3
        { Game.Emerald, GameInfo.Emerald },
        { Game.FireRed, GameInfo.FireRed }
    };

    public static Game? Check(byte[] romData) {
        foreach (var (game, info) in GameDictionary) {
            if (MatchGameCode(romData, info)) {
                return game;
            }
        }
        return null;
    }

    private static bool MatchGameCode(byte[] romData, GameInfo info) {
        string gameCode = GetGameCode(romData, info.Offset, info.Size);
        return gameCode == info.Code;
    }

    private static string GetGameCode(byte[] romData, int offset, int size) {
        byte[] gameCodeBytes = new byte[size];
        Array.Copy(romData, offset, gameCodeBytes, 0, size);
        string gameCode = Encoding.ASCII.GetString(gameCodeBytes);
        return gameCode;
    }
}