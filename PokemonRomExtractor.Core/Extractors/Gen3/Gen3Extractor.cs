using PokemonRomExtractor.Core.Games;
using PokemonRomExtractor.Core.Data.Gen3;

namespace PokemonRomExtractor.Core.Extractors.Gen3;

public class Gen3Extractor : RomExtractor {
    // Se debe restar a los punteros de 4 bytes para obtener el offset de la rom
    private const int PointerDifference = 0x08000000;
    
    private readonly Game? _game;
    
    public Gen3Extractor(byte[] romData, Game? game) : base(romData) {
        _game = game;
        InitGen3CommonData();
        InitGameSpecificData();
        ExtractDataToLists();
    }

    #region Initialization Functions
    private void InitGen3CommonData() {
        NumberOfPokemons = 412;
        NumberOfAbilities = 78;
        PokemonBytesSize = 28;
        ItemBytesSize = 44;
        PokemonNameBytesSize = 11;
        AbilityBytesSize = 13;
    }
    
    private void InitGameSpecificData() {
        switch (_game) {
            case Game.Emerald:
                PokemonDataOffset = 0x3203CC;
                ItemsOffset = 0x5839A0;
                PokemonNamesOffset = 0x3185C8;
                AbilitiesOffset = 0x31B6DB;
                NumberOfItems = 377;
                break;
            case Game.FireRed:
                PokemonDataOffset = 0x254784;
                ItemsOffset = 0x3DB028;
                PokemonNamesOffset = 0x245EE0;
                AbilitiesOffset = 0x24FC40;
                NumberOfItems = 375;
                break;
            default:
                throw new Exception("Only Emerald and Fire Red are supported");
        }
    }
    
    private void ExtractDataToLists() {
        ExtractAllItems();
        ExtracAbilities();
        ExtracPokemonNames();
        ExtractAllPokemon();
    }
    #endregion
    
    #region Overrided Functions
    protected sealed override Pokemon? ExtractPokemon(uint pokemonIndex) {
        if (pokemonIndex >= NumberOfPokemons) return null;
        
        int offset = (int)(PokemonDataOffset + pokemonIndex * PokemonBytesSize);
        return new Pokemon {
            Name = PokemonNames[(int)pokemonIndex], // 1 byte
            BaseHp = RomData[offset], // 1 byte
            BaseAttack = RomData[offset + 1], // 1 byte
            BaseDefense = RomData[offset + 2], // 1 byte
            BaseSpeed = RomData[offset + 3], // 1 byte
            BaseSpecialAttack = RomData[offset + 4], // 1 byte
            BaseSpecialDefense = RomData[offset + 5], // 1 byte
            Type1 = (PokemonType)RomData[offset + 6], // 1 byte
            Type2 = (PokemonType)RomData[offset + 7], // 1 byte
            CatchRate = RomData[offset + 8], // 1 byte
            BaseExpYield = RomData[offset + 9], // 1 byte
            EffortYield = BitConverter.ToUInt16(RomData, offset + 10), // 2 bytes
            Item1 = Items[BitConverter.ToUInt16(RomData, offset + 12)], // 2 bytes
            Item2 = Items[BitConverter.ToUInt16(RomData, offset + 14)], // 2 bytes
            Gender = ParseGender(RomData[offset + 16]), // 1 byte
            EggCycles = RomData[offset + 17], // 1 byte
            BaseFriendship = RomData[offset + 18], // 1 byte
            LevelUpType = (LevelUpType)RomData[offset + 19], // 1 byte
            EggGroup1 = RomData[offset + 20], // 1 byte
            EggGroup2 = RomData[offset + 21], // 1 byte
            Ability1 = Abilities[RomData[offset + 22]], // 1 byte
            Ability2 = Abilities[RomData[offset + 23]], // 1 byte
            SafariZoneRate = RomData[offset + 24], // 1 byte
            ColorAndFlip = RomData[offset + 25], // 1 byte
            Padding = BitConverter.ToUInt16(RomData, offset + 26) // 2 bytes
        };
    }
    
    protected sealed override void ExtractAllPokemon() {
        for (uint i = 0; i < NumberOfPokemons; i++) {
            PokemonList.Add(ExtractPokemon(i));
        }
    }
    
    protected sealed override void ExtractAllItems() {
        int currentOffset = ItemsOffset;
        for (int i = 0; i < NumberOfItems; i++) {
            Item item = new Item {
                Name = Gen3TextDecoder.Decode(RomData[currentOffset..(currentOffset + 14)]), // 14 bytes
                IndexNumber = BitConverter.ToUInt16(RomData, currentOffset + 14),  // 2 bytes
                Price = BitConverter.ToUInt16(RomData, currentOffset + 16),  // 2 bytes
                HoldEffect = RomData[currentOffset + 18], // 1 byte
                Parameter = RomData[currentOffset + 19], // 1 byte
                Description = GetItemDescription(BitConverter.ToUInt32(RomData, currentOffset + 20)), // 4 bytes
                MysteryValue1 = RomData[currentOffset + 24], // 1 byte
                MysteryValue2 = RomData[currentOffset + 25], // 1 byte
                Pocket = ParsePocket(RomData[currentOffset + 26]), // 1 byte
                Type = (ItemType)RomData[currentOffset + 27], // 1 byte
                PointerToFieldUsageCode = BitConverter.ToUInt32(RomData, currentOffset + 28) - PointerDifference, // 4 bytes
                BattleUsage = (ItemBattleUsage)BitConverter.ToUInt32(RomData, currentOffset + 32), // 4 bytes
                PointerToBattledUsageCode = BitConverter.ToUInt32(RomData, currentOffset + 36) - PointerDifference, // 4 bytes
                ExtraParameter = BitConverter.ToUInt32(RomData, currentOffset + 40) // 4 bytes
            };
            Items.Add(item);
            currentOffset += ItemBytesSize;
        }
    }

    protected sealed override void ExtracAbilities() {
        int currentOffset = AbilitiesOffset;
        for (int i = 0; i < NumberOfAbilities; i++) {
            string abilityName = Gen3TextDecoder.Decode(RomData[currentOffset..(currentOffset + 13)]);
            Abilities.Add(abilityName);
            currentOffset += AbilityBytesSize;
        }
    }
    
    protected sealed override void ExtracPokemonNames() {
        int currentOffset = PokemonNamesOffset;
        for (int i = 0; i < NumberOfPokemons; i++) {
            string abilityName = Gen3TextDecoder.Decode(RomData[currentOffset..(currentOffset + 11)]);
            PokemonNames.Add(abilityName);
            currentOffset += PokemonNameBytesSize;
        }
    }

    public override void GeneratePokemonJson(string path, string fileName) {
        throw new NotImplementedException();
    }
    #endregion

    #region Private Functions
    private Gender ParseGender(byte byteValue) {
        if (byteValue is > 0 and < 254) {
            return Gender.Mixed;
        }
        return (Gender)byteValue;
    }

    private string GetItemDescription(uint descriptionPointer) {
        int offset = (int)descriptionPointer - PointerDifference;
        return Gen3TextDecoder.DecodeFromOffset(offset, RomData);
    }

    private Gen3Pokcet ParsePocket(int pocket) {
        switch (pocket) {
            case 2:
                if (_game is Game.Emerald or Game.Ruby or Game.Saphire){
                    return Gen3Pokcet.PokeBalls;
                }
                return (Gen3Pokcet)pocket;
            case 3:
                if (_game is Game.Emerald or Game.Ruby or Game.Saphire){
                    return Gen3Pokcet.TmsAndHms;
                }
                return (Gen3Pokcet)pocket;
            case 5:
                if (_game is Game.Emerald or Game.Ruby or Game.Saphire){
                    return Gen3Pokcet.KeyItems;
                }
                return (Gen3Pokcet)pocket;
            default:
                return (Gen3Pokcet)pocket;
        }
    }
    #endregion
}