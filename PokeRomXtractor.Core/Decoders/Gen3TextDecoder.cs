﻿using System.Text;

namespace PokeRomXtractor.Core.Decoders;

public static class Gen3TextDecoder {
    private const char MaleChar = '♂';
    private const char FemaleChar = '♀';
    private const byte TerminatorByte = 0xFF;
    private const byte LineJumpByte = 0xFE;
    private const char Terminator = (char)TerminatorByte;
    
    private static ReadOnlySpan<char> Gen3Charset =>
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
        '⑬',  '“',  '”', '‘', '\'', MaleChar,  FemaleChar,  '$',  ',',  '⑧',  '/',  'A', 'B',  'C',  'D',  'E', // B
        'F',  'G',  'H',  'I', 'J',  'K',  'L',  'M',  'N',  'O',  'P',  'Q', 'R',  'S',  'T',  'U', // C
        'V',  'W',  'X',  'Y', 'Z',  'a',  'b',  'c',  'd',  'e',  'f',  'g', 'h',  'i',  'j',  'k', // D
        'l',  'm',  'n',  'o', 'p',  'q',  'r',  's',  't',  'u',  'v',  'w', 'x',  'y',  'z',  '►', // E
        ':',  'Ä',  'Ö',  'Ü', 'ä',  'ö',  'ü',                                                     // F

        // Make the total length 256 so that any byte access is always within the array
        Terminator, Terminator, Terminator, Terminator, Terminator, Terminator, Terminator, Terminator, Terminator,
    ];
    
   // Decodifica los textos del juego a partir de los bytes correspondientes al texto
   public static string Decode(byte[] encodedText) {
        StringBuilder decodedText = new StringBuilder();
        foreach (byte b in encodedText) {
            if (b >= Gen3Charset.Length) break;
            if (b == TerminatorByte) {
                break;  
            }
            decodedText.Append(b == LineJumpByte ? '\n' : Gen3Charset[b]);
        }
        return decodedText.ToString();
   }
   
   // Decodifica los textos del juego a partir un offset, hasta que encuntre un terminador de cadena
   public static string DecodeFromOffset(int offset, byte[] romData) {
       StringBuilder decodedText = new StringBuilder();
       for (int i = offset; romData[i] != TerminatorByte; i++) {
           if (romData[i] >= Gen3Charset.Length) break;
           decodedText.Append(romData[i] == LineJumpByte ? '\n' : Gen3Charset[romData[i]]);
       }
       return decodedText.ToString();
   }
}