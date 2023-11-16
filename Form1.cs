using System.Diagnostics;
using Timer = System.Windows.Forms.Timer;

namespace this_pc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PopulateTreeView(this.treeView1);
        }

        private void PopulateTreeView(TreeView treeView)
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("This PC");
            treeNode1.Tag = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}";

            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Local Disk (C:)");
            treeNode2.Tag = "C:\\";

            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Program Data");
            treeNode3.Tag = "C:\\ProgramData";

            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Program Files");
            treeNode4.Tag = "C:\\Program Files";

            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Program Files (x86)");
            treeNode5.Tag = "C:\\Program Files (x86)";

            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Users");
            treeNode6.Tag = "C:\\Users";

            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Windows");
            treeNode7.Tag = "C:\\Windows";

            treeNode1.Nodes.Add(treeNode2);

            treeNode2.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
                treeNode3,
                treeNode4,
                treeNode5,
                treeNode6,
                treeNode7,
            });

            treeView.Nodes.Add(treeNode1);
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