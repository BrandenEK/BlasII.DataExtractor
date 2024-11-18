using BlasII.ModdingAPI;

namespace BlasII.DataExtractor;

/// <summary>
/// Adds methods of extracting data from different versions of the game
/// </summary>
public class DataExtractor : BlasIIMod
{
    internal DataExtractor() : base(ModInfo.MOD_ID, ModInfo.MOD_NAME, ModInfo.MOD_AUTHOR, ModInfo.MOD_VERSION) { }

    protected override void OnInitialize()
    {
        // Perform initialization here
    }
}
