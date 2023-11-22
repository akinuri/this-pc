﻿using Microsoft.Management.Infrastructure;
using Microsoft.Management.Infrastructure.Options;
using System.Text.RegularExpressions;

public static class Summary
{
    public static string summaryFilePath = "summary.txt";

    private static string[] readSummaryFile(Func<string, string>? callback = null)
    {
        string[] lines = new string[0];
        if (!File.Exists(summaryFilePath))
        {
            return lines;
        }
        string text = File.ReadAllText(summaryFilePath);
        text = callback?.Invoke(text) ?? text;
        lines = text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        return lines;
    }

    private static string ReplaceVarPlaceHolders(string text)
    {
        Dictionary<string, string> varPropMap = new Dictionary<string, string>
        {
            {"%Manufacturer%",  "Manufacturer"},
            {"%Model%",         "Model"},
            {"%SKU%",           "SystemSKUNumber"},
            {"%Name%",          "Name"},
            {"%User%",          "PrimaryOwnerName"},
        };
        List<string> usedProps = new List<string>();
        foreach (var item in varPropMap)
        {
            if (text.Contains(item.Key))
            {
                usedProps.Add(item.Value);
            }
        }
        Dictionary<string, string> info = GetSystemInfo(usedProps.ToArray());
        foreach (KeyValuePair<string, string> pair in info)
        {
            string var = varPropMap.FirstOrDefault(x => x.Value == pair.Key).Key;
            text = text.Replace(var, pair.Value);
        }
        return text;
    }

    public static Dictionary<string, string> GetSystemInfo(string[]? keys = null)
    {
        keys ??= new string[0];
        Dictionary<string, string> info = new Dictionary<string, string>();
        try
        {
            CimSession cimSession = CimSession.Create(null);
            var query = "SELECT * FROM Win32_ComputerSystem";
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
        string[] lines = readSummaryFile(text => ReplaceVarPlaceHolders(text));
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
