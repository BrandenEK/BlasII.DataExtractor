using BlasII.ModdingAPI;
using BlasII.ModdingAPI.Helpers;
using Il2CppI2.Loc;
using System.IO;
using System.Text;

namespace BlasII.DataExtractor.Extractors;

internal class LanguageExtractor : IExtractor
{
    public string Name { get; } = "languages";

    public void Extract()
    {
        CalculateTotal();

        int sourceIdx = 0;
        foreach (LanguageSourceData source in LocalizationManager.Sources)
        {
            if (source.GetTermsList().Count == 0)
                continue;

            ExtractSource($"source{sourceIdx}", source);
            sourceIdx++;
        }
    }

    private void ExtractSource(string name, LanguageSourceData source)
    {
        PrintPercentMessage(name);

        foreach (string code in source.GetLanguagesCode())
        {
            ExtractLanguage(name, code, source);
        }
    }

    private void ExtractLanguage(string name, string code, LanguageSourceData source)
    {
        PrintPercentMessage($"{name}/{code}");

        int langIdx = source.GetLanguageIndexFromCode(code);
        var sb = new StringBuilder();

        foreach (string term in source.GetTermsList())
        {
            string value = source.GetTermData(term).Languages[langIdx].Trim().Replace('\n', '@');
            sb.AppendLine($"{term}: {value}");
        }

        SaveToFile(Path.Combine(name, $"{code}.txt"), sb.ToString());
    }

    private void CalculateTotal()
    {
        _current = 0;
        _total = 0;

        foreach (LanguageSourceData source in LocalizationManager.Sources)
        {
            if (source.GetTermsList().Count == 0)
                continue;

            _total += source.GetLanguagesCode().Count + 1;
        }
    }

    private void PrintPercentMessage(string name)
    {
        int percent = (int)((float)++_current / _total * 100);
        ModLog.Info($"[{percent}%] Extracting {name}");
    }

    private void SaveToFile(string path, string contents)
    {
        path = Path.Combine(Main.DataExtractor.FileHandler.ContentFolder, Name, VersionHelper.GameVersion, path);
        Directory.CreateDirectory(Path.GetDirectoryName(path));

        //ModLog.Warn($"Writing extracted data to {path}");
        File.WriteAllText(path, contents);
    }

    private int _current;
    private int _total;
}
