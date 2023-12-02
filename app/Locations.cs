using System.Text.RegularExpressions;

public static class Locations
{

    private static string locationsFilePath = "locations.txt";

    private static string[] readLocationsFile(Func<string, string>? callback = null)
    {
        string[] lines = new string[0];
        if (!File.Exists(locationsFilePath))
        {
            return lines;
        }
        string text = File.ReadAllText(locationsFilePath);
        text = callback?.Invoke(text) ?? text;
        lines = text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        return lines;
    }

    private static string ReplaceVarPlaceHolders(string text)
    {
        IDictionary<string, string?> handledVars = new Dictionary<string, string?>
            {
                {"%ThisPC%",                    "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}"},
                {"%SystemDrive%",               Environment.GetEnvironmentVariable("SystemDrive")},
                {"%ProgramData%",               Environment.GetEnvironmentVariable("ProgramData")},
                {"%ProgramFiles%",              Environment.GetEnvironmentVariable("ProgramFiles")},
                {"%ProgramFiles(x86)%",         Environment.GetEnvironmentVariable("ProgramFiles(x86)")},
                {"%CommonProgramFiles%",        Environment.GetEnvironmentVariable("CommonProgramFiles")},
                {"%CommonProgramFiles(x86)%",   Environment.GetEnvironmentVariable("CommonProgramFiles(x86)")},
                {"%USERNAME%",                  Environment.GetEnvironmentVariable("USERNAME")},
                {"%USERPROFILE%",               Environment.GetEnvironmentVariable("USERPROFILE")},
                {"%LOCALAPPDATA%",              Environment.GetEnvironmentVariable("LOCALAPPDATA")},
                {"%TEMP%",                      Environment.GetEnvironmentVariable("TEMP")},
                {"%TMP%",                       Environment.GetEnvironmentVariable("TEMP")},
                {"%APPDATA%",                   Environment.GetEnvironmentVariable("APPDATA")},
                {"%SystemRoot%",                Environment.GetEnvironmentVariable("SystemRoot")},
            };
        foreach (KeyValuePair<string, string> pair in handledVars)
        {
            text = text.Replace(pair.Key, pair.Value);
        }
        return text;
    }

    private static List<LocationNodeRecord> buildLocationsHierarchy(string[]? lines = null)
    {
        lines ??= new string[0];
        List<LocationNodeRecord> locations = new List<LocationNodeRecord> { };
        List<LocationNodeRecord> parentNodes = new List<LocationNodeRecord>();
        LocationNodeRecord? prevNode = null;
        foreach (var line in lines)
        {
            int indentLevel = Utilities.GetIndentLevel(line);
            string[] parts = Regex.Split(line, @", *");
            LocationNodeRecord locNodeRec = new LocationNodeRecord
            {
                Text = parts[0].Trim(),
                Tag = parts[1].Trim(),
                Level = Utilities.GetIndentLevel(line)
            };
            if (prevNode == null)
            {
                locations.Add(locNodeRec);
            }
            else
            {
                if (locNodeRec.Level > prevNode.Level)
                {
                    parentNodes.Add(prevNode);
                }
                else if (locNodeRec.Level < prevNode.Level)
                {
                    int levelDiff = Math.Abs(locNodeRec.Level - prevNode.Level);
                    parentNodes.RemoveRange(parentNodes.Count - levelDiff, levelDiff);
                }
                if (parentNodes.Count == 0)
                {
                    locations.Add(locNodeRec);
                }
                else
                {
                    var lastParent = parentNodes[parentNodes.Count - 1];
                    lastParent.Children.Add(locNodeRec);
                }
            }
            prevNode = locNodeRec;
        }
        return locations;
    }

    private static List<LocationNodeRecord> GetLocations()
    {
        string[] lines = readLocationsFile(text => ReplaceVarPlaceHolders(text));
        List<LocationNodeRecord> locations = buildLocationsHierarchy(lines);
        return locations;
    }

    public static void PopulateTreeView(TreeView treeView)
    {
        List<LocationNodeRecord> locations = GetLocations();
        foreach (LocationNodeRecord location in locations)
        {
            TreeNode treenode = new TreeNode(location.Text) { Tag = location.Tag };
            treeView.Nodes.Add(treenode);
            if (location.Children != null)
            {
                foreach (LocationNodeRecord child in location.Children)
                {
                    ProcessChildLocations(child, treenode);
                }
            }
        }
    }

    private static void ProcessChildLocations(LocationNodeRecord location, TreeNode parentNode)
    {
        TreeNode treenode = new TreeNode(location.Text) { Tag = location.Tag };
        parentNode.Nodes.Add(treenode);
        if (location.Children != null)
        {
            foreach (LocationNodeRecord child in location.Children)
            {
                ProcessChildLocations(child, treenode);
            }
        }
    }

}

class LocationNodeRecord
{
    public string Text { get; set; }
    public string Tag { get; set; }
    public List<LocationNodeRecord> Children = new List<LocationNodeRecord>();
    public int Level = 0;
}
