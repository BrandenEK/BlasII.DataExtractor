using BlasII.ModdingAPI;

namespace BlasII.DataExtractor;

public class DataExtractor : BlasIIMod
{
    internal DataExtractor() : base(ModInfo.MOD_ID, ModInfo.MOD_NAME, ModInfo.MOD_AUTHOR, ModInfo.MOD_VERSION) { }

    protected override void OnInitialize()
    {
        // Perform initialization here
    }
}
