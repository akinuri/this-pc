using System.Text.RegularExpressions;

public static class Summary
{

    private static string ReplaceSystemVarPlaceHolders(string text)
    {
        Dictionary<string, string> varPropMap = new Dictionary<string, string>
        {
            {"%Manufacturer%",      "Manufacturer"},
            {"%Model%",             "Model"},
            {"%SKU%",               "SystemSKUNumber"},
            {"%ComputerName%",      "Name"},
            {"%User%",              "PrimaryOwnerName"},
            {"%TimeZone%",          "CurrentTimeZone"},
            {"%LogicalProcessors%", "NumberOfLogicalProcessors"},
            {"%SystemType%",        "SystemType"},
            {"%Memory%",            "TotalPhysicalMemory"},
            {"%Workgroup%",         "Workgroup"},
            {"%PCType%",            "PCSystemType"},
        };
        //https://learn.microsoft.com/en-us/dotnet/api/microsoft.powershell.commands.pcsystemtype?view=powershellsdk-1.1.0
        Dictionary<string, string> typeMap = new Dictionary<string, string>
        {
            {"0", "Unspecified"},
            {"1", "Desktop"},
            {"2", "Mobile"},
            {"3", "Workstation"},
            {"4", "EnterpriseServer"},
            {"5", "SOHOServer"},
            {"6", "AppliancePC"},
            {"7", "PerformanceServer"},
            {"8", "Slate"},
            {"9", "Maximum"},
        };
        List<string> usedProps = new List<string>();
        foreach (var item in varPropMap)
        {
            if (text.Contains(item.Key))
            {
                usedProps.Add(item.Value);
            }
        }
        Dictionary<string, string> info = Utilities.QueryWin32("ComputerSystem", usedProps.ToArray());
        foreach (KeyValuePair<string, string> pair in info)
        {
            string var = varPropMap.FirstOrDefault(x => x.Value == pair.Key).Key;
            string value = pair.Value;
            if (var == "%PCType%")
            {
                value = $"{value} ({typeMap[value]})";
            }
            else if (var == "%Memory%")
            {
                float size = long.Parse(value);
                size = size / 1024 / 1024 / 1024;
                value = size.ToString("0.0") + " GB";
            }
            else if (var == "%TimeZone%")
            {
                value = Utilities.GetTimezoneString(int.Parse(value));
            }
            text = text.Replace(var, value);
        }
        return text;
    }

    private static string ReplaceProcessorVarPlaceHolders(string text)
    {
        Dictionary<string, string> varPropMap = new Dictionary<string, string>
        {
            {"%CPUName%",           "Name"},
            {"%CPUDesc%",           "Description"},
            {"%MaxSpeed%",          "MaxClockSpeed"},
            {"%Cores%",             "NumberOfCores"},
            {"%LogicalProcessors%", "NumberOfLogicalProcessors"},
            {"%Threads%",           "ThreadCount"},
            {"%Socket%",            "SocketDesignation"},
            {"%Architecture%",      "AddressWidth"},
        };
        List<string> usedProps = new List<string>();
        foreach (var item in varPropMap)
        {
            if (text.Contains(item.Key))
            {
                usedProps.Add(item.Value);
            }
        }
        Dictionary<string, string> info = Utilities.QueryWin32("Processor", usedProps.ToArray());
        foreach (KeyValuePair<string, string> pair in info)
        {
            string var = varPropMap.FirstOrDefault(x => x.Value == pair.Key).Key;
            string value = pair.Value;
            if (var == "%CPUName%")
            {
                value = value.Replace("(R)", "");
                value = value.Replace("(TM)", "");
            }
            text = text.Replace(var, value);
        }
        return text;
    }

    private static string ReplaceOSVarPlaceHolders(string text)
    {
        Dictionary<string, string> varPropMap = new Dictionary<string, string>
        {
            {"%Caption%",        "Caption"},
            {"%BuildNumber%",    "BuildNumber"},
            {"%OSArchitecture%", "OSArchitecture"},
            {"%InstallDate%",    "InstallDate"},
        };
        List<string> usedProps = new List<string>();
        foreach (var item in varPropMap)
        {
            if (text.Contains(item.Key))
            {
                usedProps.Add(item.Value);
            }
        }
        Dictionary<string, string> info = Utilities.QueryWin32("OperatingSystem", usedProps.ToArray());
        foreach (KeyValuePair<string, string> pair in info)
        {
            string var = varPropMap.FirstOrDefault(x => x.Value == pair.Key).Key;
            string value = pair.Value;
            text = text.Replace(var, value);
        }
        return text;
    }

    private static List<SummaryNode> buildSummaryList(string[]? lines = null)
    {
        lines ??= new string[0];
        List<SummaryNode> summary = new List<SummaryNode>();
        SummaryNode? lastParentNode = null;
        foreach (var line in lines)
        {
            int indentLevel = Utilities.GetIndentLevel(line);
            string[] parts = Regex.Split(line, @", *");
            if (parts.Length == 0) { continue; }
            SummaryNode node = new()
            {
                Name = parts[0].Trim(),
                Value = parts.Length > 1 ? parts[1]?.Trim() : null,
                Level = Utilities.GetIndentLevel(line),
            };
            if (node.Level == 0)
            {
                summary.Add(node);
                lastParentNode = node;
            }
            else
            {
                if (lastParentNode != null)
                {
                    lastParentNode.Children.Add(node);
                }
                else
                {
                    summary.Add(node);
                }
            }
        }
        return summary;
    }

    public static List<SummaryNode> GetSummary()
    {
        string[] lines = Utilities.ReadFileLines(
            "summary.txt",
            text => {
                text = ReplaceSystemVarPlaceHolders(text);
                text = ReplaceProcessorVarPlaceHolders(text);
                text = ReplaceOSVarPlaceHolders(text);
                return text;
            }
        );
        var summary = buildSummaryList(lines);
        return summary;
    }

    public static void PopulateListView(ListView listView)
    {
        List<SummaryNode> summary = GetSummary();
        foreach (SummaryNode node in summary)
        {
            if (node.Level == 0 && node.Children.Count > 0)
            {
                ListViewGroup group = new ListViewGroup(node.Name, HorizontalAlignment.Left);
                listView.Groups.AddRange(new ListViewGroup[] { group });
                foreach (SummaryNode childNode in node.Children)
                {
                    ListViewItem item = new ListViewItem(new string[] {childNode.Name, childNode.Value ?? ""});
                    item.Group = group;
                    listView.Items.Add(item);
                }
            }
            else if (node.Children.Count == 0)
            {
                ListViewItem item = new ListViewItem(new string[] { node.Name, node.Value ?? "" });
                listView.Items.Add(item);
            }
        }
    }

}

public class SummaryNode
{
    public string Name { get; set; }
    public string? Value { get; set; }
    public List<SummaryNode> Children = new List<SummaryNode>();
    public int Level = 0;
}
