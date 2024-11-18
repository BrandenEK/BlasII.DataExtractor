using MelonLoader;

namespace BlasII.DataExtractor;

internal class Main : MelonMod
{
    public static DataExtractor DataExtractor { get; private set; }

    public override void OnLateInitializeMelon()
    {
        DataExtractor = new DataExtractor();
    }
}