namespace WinFormApp
{
	partial class TreeForm
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
			this.components = new System.ComponentModel.Container();
			this.XmlTreeView = new System.Windows.Forms.TreeView();
			this.contextMenuSave = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.TextBoxPath = new System.Windows.Forms.TextBox();
			this.ButtonOpenFileExplorer = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.contextMenuSave.SuspendLayout();
			this.SuspendLayout();
			// 
			// XmlTreeView
			// 
			this.XmlTreeView.ContextMenuStrip = this.contextMenuSave;
			this.XmlTreeView.Location = new System.Drawing.Point(12, 67);
			this.XmlTreeView.Name = "XmlTreeView";
			this.XmlTreeView.Size = new System.Drawing.Size(936, 438);
			this.XmlTreeView.TabIndex = 0;
			// 
			// contextMenuSave
			// 
			this.contextMenuSave.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem});
			this.contextMenuSave.Name = "contextMenuSave";
			this.contextMenuSave.Size = new System.Drawing.Size(99, 26);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// TextBoxPath
			// 
			this.TextBoxPath.Enabled = false;
			this.TextBoxPath.Location = new System.Drawing.Point(53, 13);
			this.TextBoxPath.Name = "TextBoxPath";
			this.TextBoxPath.Size = new System.Drawing.Size(814, 20);
			this.TextBoxPath.TabIndex = 1;
			// 
			// ButtonOpenFileExplorer
			// 
			this.ButtonOpenFileExplorer.Location = new System.Drawing.Point(873, 10);
			this.ButtonOpenFileExplorer.Name = "ButtonOpenFileExplorer";
			this.ButtonOpenFileExplorer.Size = new System.Drawing.Size(75, 23);
			this.ButtonOpenFileExplorer.TabIndex = 2;
			this.ButtonOpenFileExplorer.Text = "Open";
			this.ButtonOpenFileExplorer.UseVisualStyleBackColor = true;
			this.ButtonOpenFileExplorer.Click += new System.EventHandler(this.ButtonOpenFileExplorer_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Path :";
			// 
			// TreeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(960, 517);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ButtonOpenFileExplorer);
			this.Controls.Add(this.TextBoxPath);
			this.Controls.Add(this.XmlTreeView);
			this.Name = "TreeForm";
			this.Text = "TreeView";
			this.contextMenuSave.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TreeView XmlTreeView;
		private System.Windows.Forms.ContextMenuStrip contextMenuSave;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.TextBox TextBoxPath;
		private System.Windows.Forms.Button ButtonOpenFileExplorer;
		private System.Windows.Forms.Label label1;
	}
}

