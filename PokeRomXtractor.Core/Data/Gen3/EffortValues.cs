namespace PokeRomXtractor.Core.Data.Gen3;

public class EffortValues {
    public byte Hp { get; set; }
    public byte Attack { get; set; }
    public byte Defense { get; set; }
    public byte Speed { get; set; }
    public byte SpecialAttack { get; set; }
    public byte SpecialDefense { get; set; }
    
    public override string ToString() {
        return $"Effort Values:\n" +
               $"Hp: {Hp}\n" +
               $"Attack: {Attack}\n" +
               $"Defense: {Defense}\n" +
               $"Speed: {Speed}\n" +
               $"Special Attack: {SpecialAttack}\n" +
               $"Special Defense: {SpecialDefense}\n";
    }
}