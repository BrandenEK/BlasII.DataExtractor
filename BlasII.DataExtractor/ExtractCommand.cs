using BlasII.CheatConsole;
using BlasII.CheatConsole.Attributes;
using BlasII.CheatConsole.Commands;
using BlasII.DataExtractor.Extractors;
using System.Linq;

namespace BlasII.DataExtractor;

/// <summary>
/// Handles extracting all kinds of game data
/// </summary>
public class ExtractCommand : ModSimpleCommand
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

    [MainCommand]
    private void Execute(string data)
    {
        IExtractor extractor = _extractors.FirstOrDefault(x => x.Name == data);
        if (extractor == null)
        {
            WriteFailure($"{data} is not a valid extraction type");
            return;
        }

        Write($"Extracting {data}...");
        extractor.Extract();
    }
}
