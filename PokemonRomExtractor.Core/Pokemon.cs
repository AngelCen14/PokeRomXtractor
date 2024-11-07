namespace PokemonRomExtractor.Core;

public class Pokemon {
    public int BaseHp { get; set; }
    public int BaseAttack { get; set; }
    public int BaseDefense { get; set; }
    public int BaseSpeed { get; set; }
    public int BaseSpecialAttack { get; set; }
    public int BaseSpecialDefense { get; set; }
    public Type Type1 { get; set; }
    public Type Type2 { get; set; }
    public int CatchRate { get; set; }
    public int BaseExpYield { get; set; }
    public string EffortYield { get; set; }
    public string Item1 { get; set; }
    public string Item2 { get; set; }
    public int Gender { get; set; }
    public int EggCycles { get; set; }
    public int BaseFriendship { get; set; }
    public LevelUpType LevelUpType { get; set; }
    public int EggGroup1 { get; set; }
    public int EggGroup2 { get; set; }
    public int Ability1 { get; set; }
    public int Ability2 { get; set; }
    public int SafariZoneRate { get; set; }
    public int ColorAndFlip { get; set; }   
    public string Padding { get; set; }
    
    public override string ToString() {
        return $"Pokemon:\n" +
               $"Base HP: {BaseHp}\n" +
               $"Base Attack: {BaseAttack}\n" +
               $"Base Defense: {BaseDefense}\n" +
               $"Base Speed: {BaseSpeed}\n" +
               $"Base Special Attack: {BaseSpecialAttack}\n" +
               $"Base Special Defense: {BaseSpecialDefense}\n" +
               $"Type 1: {Type1}\n" +
               $"Type 2: {Type2}\n" +
               $"Catch Rate: {CatchRate}\n" +
               $"Base EXP Yield: {BaseExpYield}\n" +
               $"Effort Yield: {EffortYield}\n" +
               $"Item 1: {Item1}\n" +
               $"Item 2: {Item2}\n" +
               $"Gender: {Gender}\n" +
               $"Egg Cycles: {EggCycles}\n" +
               $"Base Friendship: {BaseFriendship}\n" +
               $"Level Up Type: {LevelUpType}\n" +
               $"Egg Group 1: {EggGroup1}\n" +
               $"Egg Group 2: {EggGroup2}\n" +
               $"Ability 1: {Ability1}\n" +
               $"Ability 2: {Ability2}\n" +
               $"Safari Zone Rate: {SafariZoneRate}\n" +
               $"Color and Flip: {ColorAndFlip}\n" +
               $"Padding: {Padding}";
    }
}