namespace PokeRomXtractor.Core.Data.Gen3;

public class Pokemon {
    public string Name { get; set; }
    public byte BaseHp { get; set; }
    public byte BaseAttack { get; set; }
    public byte BaseDefense { get; set; }
    public byte BaseSpeed { get; set; }
    public byte BaseSpecialAttack { get; set; }
    public byte BaseSpecialDefense { get; set; }
    public PokemonType Type1 { get; set; }
    public PokemonType Type2 { get; set; }
    public byte CatchRate { get; set; }
    public byte BaseExpYield { get; set; }
    public ushort EffortYield { get; set; }
    public Item Item1 { get; set; }
    public Item Item2 { get; set; }
    public Gender Gender { get; set; }
    public byte EggCycles { get; set; }
    public byte BaseFriendship { get; set; }
    public LevelUpType LevelUpType { get; set; }
    public byte EggGroup1 { get; set; }
    public byte EggGroup2 { get; set; }
    public string Ability1 { get; set; }
    public string Ability2 { get; set; }
    public int SafariZoneRate { get; set; }
    public int ColorAndFlip { get; set; }   
    public ushort Padding { get; set; }
    
    public override string ToString() {
        return $"Pokemon:\n" +
               $"Name: {Name}\n" +
               $"Base Hp: {BaseHp}\n" +
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
               $"Item 1: {{ Name: {Item1.Name}, Index Number: {Item1.IndexNumber} }}\n" +
               $"Item 2: {{ Name: {Item2.Name}, Index Number: {Item2.IndexNumber}  }}\n" +
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