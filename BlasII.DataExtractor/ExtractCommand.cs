using BlasII.CheatConsole.Attributes;
using BlasII.CheatConsole.Commands;

namespace BlasII.DataExtractor;

/// <summary>
/// Handles extracting all kinds of game data
/// </summary>
public class ExtractCommand : ModComplexCommand
{
    private readonly IExtractor _languageExtractor;

    /// <summary>
    /// Creates a new extract command
    /// </summary>
    public ExtractCommand(IExtractor languages) : base("extract")
    {
        _languageExtractor = languages;
    }

    [SubCommand]
    private void Languages() => Extract(_languageExtractor);

    private void Extract(IExtractor extractor)
    {
        Write($"Extracting {extractor.Name}...");
        extractor.Extract();
    }
}
