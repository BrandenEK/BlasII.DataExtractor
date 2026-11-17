using BlasII.ModdingAPI.Helpers;
using Il2CppTGK.Framework.Quest;
using Il2CppTGK.Game;
using System.IO;
using System.Text;

namespace BlasII.DataExtractor.Extractors;

internal class QuestExtractor : IExtractor
{
    public string Name { get; } = "quests";

    public void Extract()
    {
        var sb = new StringBuilder();

        foreach (var quest in CoreCache.Quest.quests.Values)
        {
            sb.AppendLine(StringifyVariable(quest, quest.currentStatus));

            foreach (var variable in quest.vars.Values)
            {
                sb.AppendLine(StringifyVariable(quest, variable));
            }

            sb.AppendLine();
        }

        SaveToFile("data.txt", sb.ToString());
    }

    private string StringifyVariable(QuestDataInternal quest, QuestVariable variable)
    {
        string enums = variable.variableType == QuestVariable.VariableTypes.Enum && variable.enumElementsList != null
            ? string.Join('/', variable.enumElementsList.ToArray())
            : string.Empty;

        return $"{quest.Name},{variable.id},{variable.description},{variable.variableType},{enums}";
    }

    private void SaveToFile(string path, string contents)
    {
        path = Path.Combine(Main.DataExtractor.FileHandler.ContentFolder, Name, VersionHelper.GameVersion, path);
        Directory.CreateDirectory(Path.GetDirectoryName(path));

        File.WriteAllText(path, contents);
    }
}
