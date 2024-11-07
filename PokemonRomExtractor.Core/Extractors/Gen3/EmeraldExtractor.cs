namespace PokemonRomExtractor.Core.Extractors.Gen3;

public class EmeraldExtractor : BaseExtractor {

    public EmeraldExtractor(string romPath) : base(romPath, 0x3203CC , 411, 28) {
    }
    
    public override Pokemon? ExtractPokemon(uint pokemonIndex) {
        if (pokemonIndex > MaxPokemonIndex) return null;
        
        int offset = (int)(StartOffset + pokemonIndex * PokemonBytesSize);
        return new Pokemon {
            BaseHp = RomData[offset],
            BaseAttack = RomData[offset + 1],
            BaseDefense = RomData[offset + 2],
            BaseSpeed = RomData[offset + 3],
            BaseSpecialAttack = RomData[offset + 4],
            BaseSpecialDefense = RomData[offset + 5],
            Type1 = (Type)RomData[offset + 6],
            Type2 = (Type)RomData[offset + 7],
            CatchRate = RomData[offset + 8],
            BaseExpYield = RomData[offset + 9],
            EffortYield = RomData[offset + 10].ToString(),
            Item1 = RomData[offset + 12].ToString(),
            Item2 = RomData[offset + 14].ToString(),
            Gender = RomData[offset + 16],
            EggCycles = RomData[offset + 17],
            BaseFriendship = RomData[offset + 18],
            LevelUpType = (LevelUpType)RomData[offset + 19],
            EggGroup1 = RomData[offset + 20],
            EggGroup2 = RomData[offset + 21],
            Ability1 = RomData[offset + 22],
            Ability2 = RomData[offset + 23],
            SafariZoneRate = RomData[offset + 24],
            ColorAndFlip = RomData[offset + 25],
            Padding = RomData[offset + 26].ToString()
        };
    }
    
    public override List<Pokemon?> ExtractAllPokemon() {
        List<Pokemon?> pokemons = new List<Pokemon?>();
        for (uint i = 0; i <= MaxPokemonIndex; i++) {
            pokemons.Add(ExtractPokemon(i));
        }
        return pokemons;
    }
}