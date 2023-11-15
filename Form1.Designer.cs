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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Program Data");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Program Files");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Program Files (x86)");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Users");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Windows");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Local Disk (C:)", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("This PC", new System.Windows.Forms.TreeNode[] {
            treeNode6});
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(9, 9);
            this.treeView1.Margin = new System.Windows.Forms.Padding(0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node2";
            treeNode1.Tag = "C:\\ProgramData";
            treeNode1.Text = "Program Data";
            treeNode2.Name = "Node3";
            treeNode2.Tag = "C:\\Program Files";
            treeNode2.Text = "Program Files";
            treeNode3.Name = "Node4";
            treeNode3.Tag = "C:\\Program Files (x86)";
            treeNode3.Text = "Program Files (x86)";
            treeNode4.Name = "Node5";
            treeNode4.Tag = "C:\\Users";
            treeNode4.Text = "Users";
            treeNode5.Name = "Node6";
            treeNode5.Tag = "C:\\Windows";
            treeNode5.Text = "Windows";
            treeNode6.Name = "Node1";
            treeNode6.Tag = "C:\\";
            treeNode6.Text = "Local Disk (C:)";
            treeNode7.Name = "Node0";
            treeNode7.Tag = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
            treeNode7.Text = "This PC";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7});
            this.treeView1.Size = new System.Drawing.Size(200, 250);
            this.treeView1.TabIndex = 10;
            this.treeView1.TabStop = false;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 271);
            this.Controls.Add(this.treeView1);
            this.Name = "Form1";
            this.Text = "This PC";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private TreeView treeView1;
    }
}