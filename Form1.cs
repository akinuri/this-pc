using System.Diagnostics;
using Timer = System.Windows.Forms.Timer;

namespace this_pc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Summary.PopulateListView(SummaryListView);
            Locations.PopulateTreeView(LocationsTreeView);
            LocationsTreeView.ExpandAll();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            LocationsTreeView.SelectedNode = null;
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Node.Tag != null && e.Node.Tag is string path)
                {
                    Process.Start("explorer.exe", path);
                }
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            LocationsTreeView.SelectedNode = null;
        }

        private void treeView1_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void SummaryListView_Resize(object sender, EventArgs e)
        {
            ResizeSecondColumn();
        }

        private void ResizeSecondColumn()
        {
            int vrScrollWidth = SummaryListView.Width - SummaryListView.ClientRectangle.Width;
            int firstColumnDefaultWidth = 100;
            int secondColumnDefaultWidth = 200 - vrScrollWidth;
            int availableWidth = SummaryListView.Width - 4 - vrScrollWidth - firstColumnDefaultWidth;
            int secondColumnWidth = Math.Max(availableWidth, secondColumnDefaultWidth);
            SummaryListView.Columns[1].Width = secondColumnWidth;
        }
    }
}