namespace PokeRomXtractor.Core.Data.Gen3;

public class Item {
    public string Name { get; set; }
    public ushort IndexNumber { get; set; }
    public ushort Price { get; set; }
    public byte HoldEffect { get; set; }
    public byte Parameter { get; set; }
    public string Description { get; set; }
    public byte MysteryValue1 { get; set; }
    public byte MysteryValue2 { get; set; }
    public Gen3Pokcet Pocket { get; set; }
    public ItemType Type { get; set; }
    public uint PointerToFieldUsageCode { get; set; }
    public ItemBattleUsage BattleUsage { get; set; }
    public uint PointerToBattledUsageCode { get; set; }
    public uint ExtraParameter { get; set; }
    
    public override string ToString() {
        return $"Item:\n" +
               $"Name: {Name}\n" +
               $"Index Number: {IndexNumber}\n" +
               $"Price: {Price}\n" +
               $"Hold Effect: {HoldEffect}\n" +
               $"Parameter: {Parameter}\n" +
               $"Description: {Description}\n" +
               $"Mystery Value 1: {MysteryValue1}\n" +
               $"Mystery Value 2: {MysteryValue2}\n" +
               $"Pocket: {Pocket}\n" +
               $"Type: {Type}\n" +
               $"Pointer to Field Usage Code: {PointerToFieldUsageCode}\n" +
               $"Battle Usage: {BattleUsage}\n" +
               $"Pointer to Battle Usage Code: {PointerToBattledUsageCode}\n" +
               $"Extra Parameter: {ExtraParameter}";
    }

}