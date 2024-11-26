namespace PokeRomXtractor.Core.Data.Gen3;

/*
https://bulbapedia.bulbagarden.net/wiki/Pokémon_species_data_structure_(Generation_III)
The following values correspond to the different growth rates a Pokémon can have:

Value	Growth	        Lv100 Exp
0	    Medium Fast	    1,000,000
1	    Erratic	        600,000
2	    Fluctuating	    1,640,000
3	    Medium Slow	    1,059,860
4	    Fast	        800,000
5	    Slow	        1,250,000
*/

public enum LevelUpType {
    MediumFast = 0,
    Erratic = 1,
    Fluctuating = 2,
    MediumSlow = 3,
    Fast = 4,
    Slow = 5
}