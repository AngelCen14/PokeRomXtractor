namespace PokemonRomExtractor.Core.Games;

public record GameInfo(string Code, int Offset, int Size) {
    #region Gen3
    private const string EmeraldCode = "POKEMON EMERBPEE";
    private const string FireRedCode = "POKEMON FIREBPRE";
    private const int Gen3CodeOffset = 0xA0;
    private const int Gen3CodeSize = 16;
    
    public static readonly GameInfo Emerald = new(EmeraldCode, Gen3CodeOffset, Gen3CodeSize);
    public static readonly GameInfo FireRed = new(FireRedCode, Gen3CodeOffset, Gen3CodeSize);
    #endregion
};

