using System.Text;

namespace PokemonRomExtractor.Core.Extractors.Gen3;

public static class Gen3TextDecoder {
    private const char HGM = '♂';
    private const char HGF = '♀';
    private const byte TerminatorByte = 0xFF;
    private const byte LineJumpByte = 0xFE;
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
        ':',  'Ä',  'Ö',  'Ü', 'ä',  'ö',  'ü',                                                     // F

        // Make the total length 256 so that any byte access is always within the array
        Terminator, Terminator, Terminator, Terminator, Terminator, Terminator, Terminator, Terminator, Terminator,
    ];
    
   public static string Decode(byte[] encodedText) {
        StringBuilder decodedText = new StringBuilder();

        foreach (byte b in encodedText) {
            if (b >= G3_EN.Length) break;
            if (b == TerminatorByte) {
                break;  
            }
            decodedText.Append(b == LineJumpByte ? '\n' : G3_EN[b]);
        }

        return decodedText.ToString();
   }
   
   public static string DecodeFromOffset(int offset, byte[] romData) {
       StringBuilder decodedText = new StringBuilder();
       for (int i = offset; romData[i] != TerminatorByte; i++) {
           if (romData[i] >= G3_EN.Length) break;
           decodedText.Append(romData[i] == LineJumpByte ? '\n' : G3_EN[romData[i]]);
       }
       return decodedText.ToString();
   }
}