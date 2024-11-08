using System.Text;
using PokemonRomExtractor.Core.Games;

namespace PokemonRomExtractor.Core;

public static class GameChecker {
    private static readonly Dictionary<Game, GameInfo> GameDictionary = new() {
        // Gen 3
        { Game.Emerald, GameInfo.Emerald },
        { Game.FireRed, GameInfo.FireRed }
    };
    
    // Devuelve que juego es la rom
    public static Game? Check(byte[] romData) {
        foreach (KeyValuePair<Game, GameInfo> keyValuePair in GameDictionary) {
            Game game = keyValuePair.Key;
            GameInfo gameInfo = keyValuePair.Value;
            if (MatchGameCode(romData, gameInfo)) {
                return game;
            }
        }
        return null;
    }

    private static bool MatchGameCode(byte[] romData, GameInfo gameInfo) {
        string gameCode = GetGameCode(romData, gameInfo.Offset, gameInfo.Size);
        return gameCode.Equals(gameInfo.Code);
    }
    
    // Extrae el id del juego de la rom
    private static string GetGameCode(byte[] romData, int offset, int size) {
        byte[] gameCodeBytes = new byte[size];
        Array.Copy(romData, offset, gameCodeBytes, 0, size);
        string gameCode = Encoding.ASCII.GetString(gameCodeBytes);
        return gameCode;
    }
}