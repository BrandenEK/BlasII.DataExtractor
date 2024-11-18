using BlasII.CheatConsole;
using BlasII.DataExtractor.Extractors;
using System.Linq;

namespace BlasII.DataExtractor;

/// <summary>
/// Handles extracting all kinds of game data
/// </summary>
public class ExtractCommand : ModCommand
{
    private readonly IExtractor[] _extractors;

    /// <summary>
    /// Creates a new extract command
    /// </summary>
    public ExtractCommand() : base("extract")
    {
        _extractors =
        [
            new LanguageExtractor()
        ];
    }

    /// <summary>
    /// Extracts a certain kind of data
    /// </summary>
    public override void Execute(string[] args)
    {
        IExtractor extractor = _extractors.FirstOrDefault(x => x.Name == args[0]);
        if (extractor == null)
        {
            WriteFailure($"{args[0]} is not a valid extraction type");
            return;
        }

        Write($"Extracting {args[0]}...");
        extractor.Extract();
    }
}
