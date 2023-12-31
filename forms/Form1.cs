using System.Diagnostics;

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

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Node.Bounds.Contains(e.Location))
                {
                    if (e.Node.Tag != null && e.Node.Tag is string path)
                    {
                        Process.Start("explorer.exe", path);
                    }
                }
            }
        }

        private void treeView1_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void SummaryListView_Resize(object sender, EventArgs e)
        {
            ResizeSummaryColumns();
        }

        private void ResizeSummaryColumns()
        {
            int summaryWidth = 250;
            int vrScrollBarWidth = SummaryListView.Width - SummaryListView.ClientRectangle.Width;
            int firstColDefWidth = 110;

            float firstColWidthRatio = (float)firstColDefWidth / summaryWidth;

            int unknownWidthOffset = 4; // borders?
            int availableWidth = SummaryListView.Width - unknownWidthOffset - vrScrollBarWidth;

            float summaryWidthRatio = (float)summaryWidth / SummaryListView.Width;

            float firstColNewWidth = firstColWidthRatio * availableWidth;
            float firstColWidthDiff = firstColNewWidth - firstColDefWidth;
            float firstColWidthDiffReduced = firstColWidthDiff * summaryWidthRatio * 0.5f;
            firstColNewWidth = firstColDefWidth + firstColWidthDiffReduced;
            int secondColNewWidth = availableWidth - (int)firstColNewWidth;

            SummaryListView.Columns[0].Width = (int)firstColNewWidth;
            SummaryListView.Columns[1].Width = secondColNewWidth;
        }

        private void LocationsTreeView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!Utilities.WasAnyNodeClicked(LocationsTreeView.Nodes, e))
                {
                    LocationsTreeView.SelectedNode = null;
                }
            }
        }

    }
}