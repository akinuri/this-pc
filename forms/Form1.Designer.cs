namespace this_pc
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LocationsTreeView = new TreeView();
            LocationsLabel = new Label();
            SummaryListView = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            SummaryLabel = new Label();
            splitContainer1 = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // LocationsTreeView
            // 
            LocationsTreeView.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            LocationsTreeView.Location = new Point(9, 31);
            LocationsTreeView.Margin = new Padding(10, 0, 0, 0);
            LocationsTreeView.Name = "LocationsTreeView";
            LocationsTreeView.ShowPlusMinus = false;
            LocationsTreeView.ShowRootLines = false;
            LocationsTreeView.Size = new Size(210, 520);
            LocationsTreeView.TabIndex = 10;
            LocationsTreeView.TabStop = false;
            LocationsTreeView.BeforeCollapse += treeView1_BeforeCollapse;
            LocationsTreeView.NodeMouseDoubleClick += treeView1_NodeMouseDoubleClick;
            LocationsTreeView.MouseDown += LocationsTreeView_MouseDown;
            // 
            // LocationsLabel
            // 
            LocationsLabel.AutoSize = true;
            LocationsLabel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            LocationsLabel.Location = new Point(9, 9);
            LocationsLabel.Margin = new Padding(0, 0, 0, 5);
            LocationsLabel.Name = "LocationsLabel";
            LocationsLabel.Size = new Size(65, 17);
            LocationsLabel.TabIndex = 11;
            LocationsLabel.Text = "Locations";
            // 
            // SummaryListView
            // 
            SummaryListView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SummaryListView.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            SummaryListView.FullRowSelect = true;
            SummaryListView.HeaderStyle = ColumnHeaderStyle.None;
            SummaryListView.Location = new Point(9, 31);
            SummaryListView.Margin = new Padding(0);
            SummaryListView.Name = "SummaryListView";
            SummaryListView.Size = new Size(250, 520);
            SummaryListView.TabIndex = 13;
            SummaryListView.UseCompatibleStateImageBehavior = false;
            SummaryListView.View = View.Details;
            SummaryListView.Resize += SummaryListView_Resize;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Key";
            columnHeader1.Width = 110;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Value";
            columnHeader2.Width = 135;
            // 
            // SummaryLabel
            // 
            SummaryLabel.AutoSize = true;
            SummaryLabel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            SummaryLabel.Location = new Point(9, 10);
            SummaryLabel.Margin = new Padding(0, 0, 0, 5);
            SummaryLabel.Name = "SummaryLabel";
            SummaryLabel.Size = new Size(67, 17);
            SummaryLabel.TabIndex = 11;
            SummaryLabel.Text = "Summary";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Top;
            splitContainer1.FixedPanel = FixedPanel.Panel2;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(SummaryListView);
            splitContainer1.Panel1.Controls.Add(SummaryLabel);
            splitContainer1.Panel1.Padding = new Padding(10);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(LocationsTreeView);
            splitContainer1.Panel2.Controls.Add(LocationsLabel);
            splitContainer1.Panel2.Padding = new Padding(10);
            splitContainer1.Size = new Size(508, 566);
            splitContainer1.SplitterDistance = 272;
            splitContainer1.TabIndex = 14;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(508, 565);
            Controls.Add(splitContainer1);
            MaximizeBox = false;
            MaximumSize = new Size(800, 604);
            MinimumSize = new Size(524, 604);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "This PC";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TreeView LocationsTreeView;
        private Label LocationsLabel;
        private ListView SummaryListView;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Label SummaryLabel;
        private SplitContainer splitContainer1;
    }
}