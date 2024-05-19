namespace Risko
{
    partial class FormMainDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Logs");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Run Dates");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("ExchangeRates", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Reports", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Columns");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Indexes");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Foreign Keys");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Default & Check Constraints");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Tables");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Routines");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Locks");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("DB Design", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11});
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.treeViewMain = new System.Windows.Forms.TreeView();
            this.buttonDbDocumentation = new System.Windows.Forms.Button();
            this.buttonLinks = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.listViewMain = new System.Windows.Forms.ListView();
            this.richTextBoxSQL = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1206, 692);
            this.splitContainer1.SplitterDistance = 155;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.splitContainer3.Panel1.Controls.Add(this.treeViewMain);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.Color.SlateGray;
            this.splitContainer3.Panel2.Controls.Add(this.buttonDbDocumentation);
            this.splitContainer3.Panel2.Controls.Add(this.buttonLinks);
            this.splitContainer3.Size = new System.Drawing.Size(155, 692);
            this.splitContainer3.SplitterDistance = 227;
            this.splitContainer3.SplitterWidth = 6;
            this.splitContainer3.TabIndex = 0;
            // 
            // treeViewMain
            // 
            this.treeViewMain.BackColor = System.Drawing.Color.LightSlateGray;
            this.treeViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewMain.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.treeViewMain.Location = new System.Drawing.Point(0, 0);
            this.treeViewMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.treeViewMain.Name = "treeViewMain";
            treeNode1.Name = "Logs";
            treeNode1.Tag = "000007001";
            treeNode1.Text = "Logs";
            treeNode2.Name = "Run Dates";
            treeNode2.Tag = "000007002";
            treeNode2.Text = "Run Dates";
            treeNode3.Name = "ExchangeRates";
            treeNode3.Tag = "000007";
            treeNode3.Text = "ExchangeRates";
            treeNode4.Name = "NodeRiskAvert";
            treeNode4.Tag = "000";
            treeNode4.Text = "Reports";
            treeNode5.Name = "Columns";
            treeNode5.Tag = "002001";
            treeNode5.Text = "Columns";
            treeNode6.Name = "Indexes";
            treeNode6.Tag = "002002";
            treeNode6.Text = "Indexes";
            treeNode7.Name = "Foreign Keys";
            treeNode7.Tag = "002003";
            treeNode7.Text = "Foreign Keys";
            treeNode8.Name = "Default & Check Constraints";
            treeNode8.Tag = "002004";
            treeNode8.Text = "Default & Check Constraints";
            treeNode9.Name = "Tables";
            treeNode9.Tag = "002005";
            treeNode9.Text = "Tables";
            treeNode10.Name = "Routines";
            treeNode10.Tag = "002006";
            treeNode10.Text = "Routines";
            treeNode11.ForeColor = System.Drawing.Color.Red;
            treeNode11.Name = "Locks";
            treeNode11.Tag = "002007";
            treeNode11.Text = "Locks";
            treeNode12.Name = "NodeDBDesign";
            treeNode12.Tag = "002";
            treeNode12.Text = "DB Design";
            this.treeViewMain.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode12});
            this.treeViewMain.Size = new System.Drawing.Size(155, 227);
            this.treeViewMain.TabIndex = 0;
            this.treeViewMain.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewMain_AfterSelect);
            this.treeViewMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeViewMain_MouseDoubleClick);
            // 
            // buttonDbDocumentation
            // 
            this.buttonDbDocumentation.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonDbDocumentation.Location = new System.Drawing.Point(0, 34);
            this.buttonDbDocumentation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonDbDocumentation.Name = "buttonDbDocumentation";
            this.buttonDbDocumentation.Size = new System.Drawing.Size(155, 34);
            this.buttonDbDocumentation.TabIndex = 10;
            this.buttonDbDocumentation.Text = "API";
            this.buttonDbDocumentation.UseVisualStyleBackColor = true;
            this.buttonDbDocumentation.Click += new System.EventHandler(this.buttonDbDocumentation_Click);
            // 
            // buttonLinks
            // 
            this.buttonLinks.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonLinks.Location = new System.Drawing.Point(0, 0);
            this.buttonLinks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonLinks.Name = "buttonLinks";
            this.buttonLinks.Size = new System.Drawing.Size(155, 34);
            this.buttonLinks.TabIndex = 1;
            this.buttonLinks.Text = "Usefull Links";
            this.buttonLinks.UseVisualStyleBackColor = true;
            this.buttonLinks.Click += new System.EventHandler(this.buttonLinks_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.listViewMain);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.LightSlateGray;
            this.splitContainer2.Panel2.Controls.Add(this.richTextBoxSQL);
            this.splitContainer2.Size = new System.Drawing.Size(1045, 692);
            this.splitContainer2.SplitterDistance = 429;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 0;
            // 
            // listViewMain
            // 
            this.listViewMain.BackColor = System.Drawing.SystemColors.ControlLight;
            this.listViewMain.HideSelection = false;
            this.listViewMain.Location = new System.Drawing.Point(18, 14);
            this.listViewMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listViewMain.Name = "listViewMain";
            this.listViewMain.Size = new System.Drawing.Size(408, 290);
            this.listViewMain.TabIndex = 0;
            this.listViewMain.UseCompatibleStateImageBehavior = false;
            this.listViewMain.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewMain_ColumnClick);
            this.listViewMain.SelectedIndexChanged += new System.EventHandler(this.listViewMain_SelectedIndexChanged);
            this.listViewMain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewMain_KeyDown);
            this.listViewMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewMain_MouseDoubleClick);
            // 
            // richTextBoxSQL
            // 
            this.richTextBoxSQL.BackColor = System.Drawing.Color.SlateGray;
            this.richTextBoxSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxSQL.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.richTextBoxSQL.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxSQL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBoxSQL.Name = "richTextBoxSQL";
            this.richTextBoxSQL.Size = new System.Drawing.Size(1045, 257);
            this.richTextBoxSQL.TabIndex = 0;
            this.richTextBoxSQL.Text = "";
            // 
            // FormMainDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 692);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMainDialog";
            this.ShowIcon = false;
            this.Text = "Main Dialog";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMainDialog_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView listViewMain;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TreeView treeViewMain;
        private System.Windows.Forms.RichTextBox richTextBoxSQL;
        private System.Windows.Forms.Button buttonLinks;
        private System.Windows.Forms.Button buttonDbDocumentation;
    }
}