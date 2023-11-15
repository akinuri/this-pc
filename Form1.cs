using System.Diagnostics;
using Timer = System.Windows.Forms.Timer;

namespace this_pc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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