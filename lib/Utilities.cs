
using Microsoft.Management.Infrastructure.Options;
using Microsoft.Management.Infrastructure;
using System.Text.RegularExpressions;

public static class Utilities
{

    public static string[] ReadFileLines(string filepath, Func<string, string>? callback = null)
    {
        string[] lines = new string[0];
        if (!File.Exists(filepath))
        {
            return lines;
        }
        string text = File.ReadAllText(filepath);
        text = callback?.Invoke(text) ?? text;
        lines = text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        return lines;
    }

    public static Dictionary<string, string> QueryWin32(string target, string[]? keys = null)
    {
        keys ??= new string[0];
        Dictionary<string, string> info = new Dictionary<string, string>();
        try
        {
            CimSession cimSession = CimSession.Create(null);
            var query = $"SELECT * FROM Win32_{target}";
            var queryOptions = new CimOperationOptions { Timeout = TimeSpan.FromSeconds(2) };
            var results = cimSession.QueryInstances("root/cimv2", "WQL", query, queryOptions);
            CimInstance? result = null;
            if (results.Any())
            {
                result = results.First();
            }
            if (result != null)
            {
                foreach (var item in result.CimInstanceProperties)
                {
                    string value = item.Value?.ToString() ?? "";
                    var stringArray = item.Value as string[];
                    if (stringArray != null)
                    {
                        value = string.Join(", ", stringArray);
                    }
                    if (keys.Count() == 0 || keys.Contains(item.Name))
                    {
                        info.Add(item.Name, value);
                    }
                }
            }
            cimSession.Dispose();
        }
        catch (Exception ex)
        {
            //Logger.error(ex.Message);
        }
        return info;
    }

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

    public static string GetTimezoneString(int timezoneOffset)
    {
        int hours = Math.Abs(timezoneOffset) / 60;
        int minutes = Math.Abs(timezoneOffset) % 60;
        string sign = (timezoneOffset >= 0) ? "+" : "-";
        return $"{sign}{hours:D2}:{minutes:D2}";
    }

    // so they can be output quickly when debugging
    public static string JoinNumbers(params object[] numbers)
    {
        return string.Join(", ", numbers);
    }

    public static bool WasAnyNodeClicked(TreeNodeCollection nodes, MouseEventArgs e)
    {
        foreach (TreeNode node in nodes)
        {
            if (node.Bounds.Contains(e.Location))
            {
                return true;
            }

            if (node.Nodes.Count > 0 && WasAnyNodeClicked(node.Nodes, e))
            {
                return true;
            }
        }

        return false;
    }

}
