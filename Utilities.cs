
using System.Text.RegularExpressions;

public static class Utilities
{

    public static string RemoveUnnecessaryIndentation(string indentedString)
    {
        var match = Regex.Match(indentedString, @"^[ ]+", RegexOptions.Multiline);
        int commonIndentationLength = match.Success ? match.Value.Length : 0;
        string[] lines = Regex.Split(indentedString, @"\r?\n");
        var processedLines = new List<string>();
        foreach (var line in lines)
        {
            if (line.Trim().Length > 0)
            {
                var _line = line;
                if (_line.Length >= commonIndentationLength)
                {
                    _line = line.Substring(commonIndentationLength);
                }
                _line = _line.TrimEnd();
                processedLines.Add(_line);
            }
        }
        return string.Join(Environment.NewLine, processedLines);
    }

    public static int GetIndentLevel(string line, string indentString = "    ")
    {
        var indentMatch = Regex.Match(line, @"^ *");
        string indent = indentMatch.Success ? indentMatch.Value : "";
        var indentLevelMatches = Regex.Matches(indent, indentString);
        int level = indentLevelMatches.Count;
        return level;
    }

}
