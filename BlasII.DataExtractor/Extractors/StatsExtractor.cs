using Il2CppTGK.Game.Components.StatsSystem.Data;
using UnityEngine;
using System.Text;
using System.IO;
using System.Linq;
using BlasII.ModdingAPI.Helpers;

namespace BlasII.DataExtractor.Extractors;

internal class StatsExtractor : IExtractor
{
    public string Name { get; } = "stats";

    public void Extract()
    {
        var sb = new StringBuilder();
        sb.AppendLine();

        AddStats<BonuseableStatID>(sb, "BonuseableStat");
        AddStats<BonuseableValueStatID>(sb, "BonuseableValueStat : BonuseableStat");
        AddStats<ModifiableStatID>(sb, "ModifiableStat : BonuseableStat");
        AddStats<RangeStatID>(sb, "RangeStat : BonuseableStat");
        AddStats<RangeAutoUpgradeStatID>(sb, "RangeAutoUpgradeStat : RangeStat");
        AddStats<MainStatID>(sb, "MainStat");
        AddStats<ValueStatID>(sb, "ValueStat");

        string path = Path.Combine(Main.DataExtractor.FileHandler.ContentFolder, Name, VersionHelper.GameVersion, "stats.txt");
        Directory.CreateDirectory(Path.GetDirectoryName(path));

        File.WriteAllText(path, sb.ToString());
    }

    private void AddStats<T>(StringBuilder sb, string name) where T : BaseStatID
    {
        string line = new string('=', name.Length + 2);

        sb.AppendLine(line);
        sb.AppendLine(" " + name);
        sb.AppendLine(line);
        sb.AppendLine();
        foreach (var stat in Resources.FindObjectsOfTypeAll<T>().OrderBy(x => x.name))
            sb.AppendLine(stat.name.Replace(" ", ""));
        sb.AppendLine();
    }
}
