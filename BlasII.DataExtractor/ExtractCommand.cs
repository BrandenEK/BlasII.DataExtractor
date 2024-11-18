using BlasII.CheatConsole;

namespace BlasII.DataExtractor;

/// <summary>
/// Handles extracting all kinds of game data
/// </summary>
public class ExtractCommand : ModCommand
{
    /// <summary>
    /// Creates a new extract command
    /// </summary>
    public ExtractCommand() : base("extract") { }

    /// <summary>
    /// Extracts a certain kind of data
    /// </summary>
    public override void Execute(string[] args)
    {
        Write("Extracting...");
    }
}
