using BlasII.ModdingAPI;
using Il2CppI2.Loc;

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
        foreach (string term in source.GetTermsList())
        {
            ModLog.Warn($"{term}: {source.GetTermData(term).Languages[langIdx]}");
        }
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

    private int _current;
    private int _total;
}
