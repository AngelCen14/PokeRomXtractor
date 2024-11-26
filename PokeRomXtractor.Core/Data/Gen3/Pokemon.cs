namespace PokeRomXtractor.Core.Data.Gen3;

[Serializable]
public class Pokemon {
    public string? Name { get; set; }
    public byte Hp { get; set; }
    public byte Attack { get; set; }
    public byte Defense { get; set; }
    public byte Speed { get; set; }
    public byte SpecialAttack { get; set; }
    public byte SpecialDefense { get; set; }
    public PokemonType Type1 { get; set; }
    public PokemonType Type2 { get; set; }
    public byte CatchRate { get; set; }
    public byte BaseExpYield { get; set; }
    public EffortValues? EffortValues { get; set; }
    public Item? Item1 { get; set; }
    public Item? Item2 { get; set; }
    public Gender Gender { get; set; }
    public byte EggCycles { get; set; }
    public byte BaseFriendship { get; set; }
    public LevelUpType LevelUpType { get; set; }
    public EggGroup EggGroup1 { get; set; }
    public EggGroup EggGroup2 { get; set; }
    public string? Ability1 { get; set; }
    public string? Ability2 { get; set; }
    public int SafariZoneRate { get; set; }
    public int ColorAndFlip { get; set; }   
    public ushort Padding { get; set; }
    
    public override string ToString() {
        return $"Pokemon:\n" +
               $"Name: {Name}\n" +
               $"Hp: {Hp}\n" +
               $"Attack: {Attack}\n" +
               $"Defense: {Defense}\n" +
               $"Speed: {Speed}\n" +
               $"Special Attack: {SpecialAttack}\n" +
               $"Special Defense: {SpecialDefense}\n" +
               $"Type 1: {Type1}\n" +
               $"Type 2: {Type2}\n" +
               $"Catch Rate: {CatchRate}\n" +
               $"Base EXP Yield: {BaseExpYield}\n" +
               $"Effort Values: {EffortValues}\n" +
               $"Item 1: {{ Name: {Item1?.Name}, Index Number: {Item1?.IndexNumber} }}\n" +
               $"Item 2: {{ Name: {Item2?.Name}, Index Number: {Item2?.IndexNumber}  }}\n" +
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