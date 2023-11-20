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
            this.SuspendLayout();
            // 
            // LocationsTreeView
            // 
            this.LocationsTreeView.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LocationsTreeView.Location = new System.Drawing.Point(9, 34);
            this.LocationsTreeView.Margin = new System.Windows.Forms.Padding(0);
            this.LocationsTreeView.Name = "LocationsTreeView";
            this.LocationsTreeView.Size = new System.Drawing.Size(240, 570);
            this.LocationsTreeView.TabIndex = 10;
            this.LocationsTreeView.TabStop = false;
            this.LocationsTreeView.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeCollapse);
            this.LocationsTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // LocationsLabel
            // 
            this.LocationsLabel.AutoSize = true;
            this.LocationsLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LocationsLabel.Location = new System.Drawing.Point(9, 9);
            this.LocationsLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.LocationsLabel.Name = "LocationsLabel";
            this.LocationsLabel.Size = new System.Drawing.Size(73, 20);
            this.LocationsLabel.TabIndex = 11;
            this.LocationsLabel.Text = "Locations";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 626);
            this.Controls.Add(this.LocationsLabel);
            this.Controls.Add(this.LocationsTreeView);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "This PC";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Click += new System.EventHandler(this.Form1_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TreeView LocationsTreeView;
        private Label LocationsLabel;
    }
}