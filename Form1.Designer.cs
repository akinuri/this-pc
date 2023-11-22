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
            this.LocationsTreeView = new System.Windows.Forms.TreeView();
            this.LocationsLabel = new System.Windows.Forms.Label();
            this.SummaryListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.SummaryLabel = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LocationsTreeView
            // 
            this.LocationsTreeView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LocationsTreeView.Location = new System.Drawing.Point(9, 31);
            this.LocationsTreeView.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.LocationsTreeView.Name = "LocationsTreeView";
            this.LocationsTreeView.Size = new System.Drawing.Size(240, 520);
            this.LocationsTreeView.TabIndex = 10;
            this.LocationsTreeView.TabStop = false;
            this.LocationsTreeView.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeCollapse);
            this.LocationsTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // LocationsLabel
            // 
            this.LocationsLabel.AutoSize = true;
            this.LocationsLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LocationsLabel.Location = new System.Drawing.Point(9, 9);
            this.LocationsLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.LocationsLabel.Name = "LocationsLabel";
            this.LocationsLabel.Size = new System.Drawing.Size(65, 17);
            this.LocationsLabel.TabIndex = 11;
            this.LocationsLabel.Text = "Locations";
            // 
            // SummaryListView
            // 
            this.SummaryListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SummaryListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.SummaryListView.FullRowSelect = true;
            this.SummaryListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.SummaryListView.Location = new System.Drawing.Point(9, 31);
            this.SummaryListView.Margin = new System.Windows.Forms.Padding(0);
            this.SummaryListView.Name = "SummaryListView";
            this.SummaryListView.Size = new System.Drawing.Size(304, 300);
            this.SummaryListView.TabIndex = 13;
            this.SummaryListView.UseCompatibleStateImageBehavior = false;
            this.SummaryListView.View = System.Windows.Forms.View.Details;
            this.SummaryListView.Resize += new System.EventHandler(this.SummaryListView_Resize);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Key";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 200;
            // 
            // SummaryLabel
            // 
            this.SummaryLabel.AutoSize = true;
            this.SummaryLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SummaryLabel.Location = new System.Drawing.Point(9, 10);
            this.SummaryLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.SummaryLabel.Name = "SummaryLabel";
            this.SummaryLabel.Size = new System.Drawing.Size(67, 17);
            this.SummaryLabel.TabIndex = 11;
            this.SummaryLabel.Text = "Summary";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.SummaryListView);
            this.splitContainer1.Panel1.Controls.Add(this.SummaryLabel);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(10);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.LocationsTreeView);
            this.splitContainer1.Panel2.Controls.Add(this.LocationsLabel);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainer1.Size = new System.Drawing.Size(588, 566);
            this.splitContainer1.SplitterDistance = 322;
            this.splitContainer1.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 565);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 604);
            this.MinimumSize = new System.Drawing.Size(604, 604);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "This PC";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Click += new System.EventHandler(this.Form1_Click);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

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