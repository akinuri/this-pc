using System.Diagnostics;
using Timer = System.Windows.Forms.Timer;
using TreeNode = System.Windows.Forms.TreeNode;

namespace this_pc
{
    class LocationNodeRecord
    {
        public string Text { get; set; }
        public string Tag { get; set; }
        public List<LocationNodeRecord>? Children { get; set; }
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
            List<LocationNodeRecord> locations = new List<LocationNodeRecord>
            {
                new LocationNodeRecord
                {
                    Text = "This PC",
                    Tag = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}",
                    Children = new List<LocationNodeRecord>
                    {
                        new LocationNodeRecord
                        {
                            Text = "Local Disk (C:)",
                            Tag = "C:\\",
                            Children = new List<LocationNodeRecord> {
                                new LocationNodeRecord
                                {
                                    Text = "Program Data",
                                    Tag = "C:\\ProgramData",
                                },
                                new LocationNodeRecord
                                {
                                    Text = "Program Files",
                                    Tag = "C:\\Program Files",
                                },
                                new LocationNodeRecord
                                {
                                    Text = "Program Files (x86)",
                                    Tag = "C:\\Program Files (x86)",
                                },
                                new LocationNodeRecord
                                {
                                    Text = "Users",
                                    Tag = "C:\\Users",
                                },
                                new LocationNodeRecord
                                {
                                    Text = "Windows",
                                    Tag = "C:\\Windows",
                                },
                            },
                        },
                    },
                },
            };

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