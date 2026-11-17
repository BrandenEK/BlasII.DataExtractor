using BlasII.CheatConsole.Attributes;
using BlasII.CheatConsole.Commands;

namespace BlasII.DataExtractor;

/// <summary>
/// Handles extracting all kinds of game data
/// </summary>
public class ExtractCommand : ModComplexCommand
{
    private readonly IExtractor _languageExtractor;
    private readonly IExtractor _questExtractor;

    /// <summary>
    /// Creates a new extract command
    /// </summary>
    public ExtractCommand(IExtractor languages, IExtractor quests) : base("extract")
    {
        _languageExtractor = languages;
        _questExtractor = quests;
    }

    [SubCommand]
    private void Languages() => Extract(_languageExtractor);

    [SubCommand]
    private void Quests() => Extract(_questExtractor);

    private void Extract(IExtractor extractor)
    {
        Write($"Extracting {extractor.Name}...");
        extractor.Extract();
        Write($"Finished extracting {extractor.Name}");
    }
}
