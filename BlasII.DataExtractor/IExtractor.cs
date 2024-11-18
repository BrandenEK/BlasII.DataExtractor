
namespace BlasII.DataExtractor;

/// <summary>
/// Extracts a type of data
/// </summary>
public interface IExtractor
{
    /// <summary>
    /// The text to use in the extract command
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Performs the extraction
    /// </summary>
    public void Extract();
}
