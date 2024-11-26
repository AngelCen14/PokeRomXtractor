using PokeRomXtractor.Core.Extractors;

namespace PokeRomXtractor;

class Program {
    private readonly string _romPath;
    private readonly string _jsonPath;

    private Program(string romPath, string jsonPath) {
        _romPath = romPath;
        _jsonPath = jsonPath;
    }

    private void RunExtractor() {
        try {
            RomExtractor romExtractor = ExtractorManager.GetRomExtractor(_romPath);
            romExtractor.GeneratePokemonListJson(_jsonPath);
        } catch (Exception e) {
            Console.Error.WriteLine(e.Message);
        }
    }
    
    public static void Main(string[] args) {
        if (args.Length < 1) {
            throw new ArgumentException("Usage: PokeRomXtractor <rom path> (optional)<json path>");
        }

        Program? program = null;
        if (args.Length < 2) program = new Program(args[0],Path.GetFullPath(Path.GetDirectoryName(args[0])!));
        if (args.Length >= 2) program = new Program(args[0], args[1]);
        
        program?.RunExtractor();
    }
}