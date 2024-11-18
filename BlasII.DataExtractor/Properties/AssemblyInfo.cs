using BlasII.DataExtractor;
using MelonLoader;

[assembly: MelonInfo(typeof(BlasII.DataExtractor.Main), ModInfo.MOD_NAME, ModInfo.MOD_VERSION, ModInfo.MOD_AUTHOR)]
[assembly: MelonOptionalDependencies("Modding API", "1.1.0", "Cheat Console", "1.2.0")]
[assembly: MelonPriority(1000)] // Temp until better priority sorting is added
