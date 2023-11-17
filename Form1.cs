using System.Diagnostics;
using System.Text.RegularExpressions;
using Timer = System.Windows.Forms.Timer;
using TreeNode = System.Windows.Forms.TreeNode;

namespace this_pc
{
    class LocationNodeRecord
    {
        public string Text { get; set; }
        public string Tag { get; set; }
        public List<LocationNodeRecord> Children = new List<LocationNodeRecord>();
        public int Level = 0;
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PopulateTreeView(treeView1);
        }

        private void PopulateTreeView(TreeView treeView)
        {
            string locationsText = @"
            This PC, ::{20D04FE0-3AEA-1069-A2D8-08002B30309D}
                Local Disk (C:), C:\
                    Program Data, C:\ProgramData
                    Program Files, C:\Program Files,
                    Program Files (x86), C:\Program Files (x86)
                    Users, C:\Users
                    Windows, C:\Windows
            ";
            locationsText = RemoveUnnecessaryIndentation(locationsText);

            string[] lines = Regex.Split(locationsText, @"\r?\n");

            List<LocationNodeRecord> locations = new List<LocationNodeRecord> { };

            List<LocationNodeRecord> parentNodes = new List<LocationNodeRecord>();
            LocationNodeRecord? prevNode = null;

            foreach (var line in lines)
            {
                var indentMatch = Regex.Match(line, @"^ *");
                string indent = indentMatch.Success ? indentMatch.Value : "";
                var indentLevelMatches = Regex.Matches(indent, @" {4}");
                int indentLevel = indentLevelMatches.Count;
                string[] parts = Regex.Split(line, @", *");
                string text = parts[0].Trim();
                string tag = parts[1].Trim();
                LocationNodeRecord locNodeRec = new LocationNodeRecord { Text = text, Tag = tag, Level = indentLevel };
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

        static string RemoveUnnecessaryIndentation(string indentedString)
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

        private void ProcessChildLocations(LocationNodeRecord location, TreeNode parentNode)
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

        private void Form1_Load(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Tick += (s, args) =>
            {
                treeView1.SelectedNode = null;
                timer.Stop();
            };
            timer.Start();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            treeView1.SelectedNode = null;
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Node.Tag != null && e.Node.Tag is string path)
                {
                    System.Diagnostics.Process.Start("explorer.exe", path);
                    Timer timer = new Timer();
                    timer.Interval = 100;
                    timer.Tick += (s, args) =>
                    {
                        treeView1.SelectedNode = null;
                        timer.Stop();
                    };
                    timer.Start();
                }
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            treeView1.SelectedNode = null;
        }

    }
}