using System.Text;

namespace PokemonRomExtractor.Core.Extractors.Gen3;

public class TextDecoder
{
    private const char HGM = '♂';
    private const char HGF = '♀';
    public const byte TerminatorByte = 0xFF;
    private const char Terminator = (char)TerminatorByte;
    
    private static ReadOnlySpan<char> G3_EN =>
    [
        ' ',  'À',  'Á',  'Â', 'Ç',  'È',  'É',  'Ê',  'Ë',  'Ì', 'こ', 'Î',  'Ï',  'Ò',  'Ó',  'Ô',  // 0
        'Œ',  'Ù',  'Ú',  'Û', 'Ñ',  'ß',  'à',  'á',  'ね', 'ç',  'è', 'é',  'ê',  'ë',  'ì',  'ま',  // 1
        'î',  'ï',  'ò',  'ó', 'ô',  'œ',  'ù',  'ú',  'û',  'ñ',  'º', 'ª',  '⑩', '&',  '+',  'あ', // 2
        'ぃ', 'ぅ', 'ぇ', 'ぉ', 'ゃ', '=',  ';', 'が', 'ぎ', 'ぐ', 'げ', 'ご', 'ざ', 'じ', 'ず', 'ぜ', // 3
        'ぞ', 'だ', 'ぢ', 'づ', 'で', 'ど', 'ば', 'び', 'ぶ', 'べ', 'ぼ', 'ぱ', 'ぴ', 'ぷ', 'ぺ', 'ぽ',  // 4
        'っ', '¿',  '¡',  '⒆', '⒇', 'オ', 'カ', 'キ', 'ク', 'ケ', 'Í',  '%', '(', ')', 'セ', 'ソ', // 5
        'タ', 'チ', 'ツ', 'テ', 'ト', 'ナ', 'ニ', 'ヌ', 'â',  'ノ', 'ハ', 'ヒ', 'フ', 'ヘ', 'ホ', 'í',  // 6
        'ミ', 'ム', 'メ', 'モ', 'ヤ', 'ユ', 'ヨ', 'ラ', 'リ', '↑', '↓', '←', '＋', 'ヲ', 'ン', 'ァ', // 7
        'ィ', 'ゥ', 'ェ', 'ォ', '⒅', '<', '>', 'ガ', 'ギ', 'グ', 'ゲ', 'ゴ', 'ザ', 'ジ', 'ズ', 'ゼ', // 8
        'ゾ', 'ダ', 'ヂ', 'ヅ', 'デ', 'ド', 'バ', 'ビ', 'ブ', 'ベ', 'ボ', 'パ', 'ピ', 'プ', 'ペ', 'ポ', // 9
        'ッ', '0',  '1',  '2', '3',  '4',  '5',  '6',  '7',  '8',  '9',  '!', '?',  '.',  '-',  '･',// A
        '⑬',  '“',  '”', '‘', '\'', HGM,  HGF,  '$',  ',',  '⑧',  '/',  'A', 'B',  'C',  'D',  'E', // B
        'F',  'G',  'H',  'I', 'J',  'K',  'L',  'M',  'N',  'O',  'P',  'Q', 'R',  'S',  'T',  'U', // C
        'V',  'W',  'X',  'Y', 'Z',  'a',  'b',  'c',  'd',  'e',  'f',  'g', 'h',  'i',  'j',  'k', // D
        'l',  'm',  'n',  'o', 'p',  'q',  'r',  's',  't',  'u',  'v',  'w', 'x',  'y',  'z',  '►', // E
        ':',  'Ä',  'Ö',  'Ü', 'ä',  'ö',  'ü',                                                      // F

        // Make the total length 256 so that any byte access is always within the array
        Terminator, Terminator, Terminator, Terminator, Terminator, Terminator, Terminator, Terminator, Terminator,
    ];
    
    void decode(uint pokemonIndex, byte[] RomData)
    {
        // El offset donde comienzan los nombres de los Pokémon es 0x3185C8
        // Los nombres tienen un máximo de 10 caracteres (11 bytes incluyendo el byte de terminación 0x00).
        int nameOffset = 0x3185C8 + (int)(pokemonIndex * 11);  // 10 caracteres + 1 byte de terminación.

        // Crear un array para almacenar los bytes del nombre (máximo 11 bytes).
        byte[] nameBytes = new byte[11];

        // Leer hasta 10 caracteres o hasta el byte 0x00 (fin de la cadena).
        for (int i = 0; i < 10; i++) {
            byte currentByte = RomData[nameOffset + i];
            if (currentByte == 0x00) {
                break;  // Terminamos la lectura al encontrar el byte 0x00
            }
            nameBytes[i] = currentByte;  // Guardamos el byte en el array
        }

        // Aseguramos que el byte de terminación 0x00 esté presente al final
        nameBytes[10] = 0x00;
        
        // Crear un StringBuilder para construir el nombre
        StringBuilder pokemonName = new StringBuilder();

        // Iterar sobre cada byte en el array y convertirlo
        foreach (byte b in nameBytes) {
            if (b == TerminatorByte) {
                break;  // Terminamos al encontrar un byte 0x00
            }

            // Añadir el carácter correspondiente a la cadena
            pokemonName.Append(G3_EN[b]);
        }
        

        Console.WriteLine(pokemonName.ToString());
    }
}