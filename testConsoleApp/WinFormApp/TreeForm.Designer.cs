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
			this.contextMenuSave.SuspendLayout();
			this.SuspendLayout();
			// 
			// XmlTreeView
			// 
			this.XmlTreeView.ContextMenuStrip = this.contextMenuSave;
			this.XmlTreeView.Location = new System.Drawing.Point(12, 12);
			this.XmlTreeView.Name = "XmlTreeView";
			this.XmlTreeView.Size = new System.Drawing.Size(384, 483);
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
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// TreeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(410, 517);
			this.Controls.Add(this.XmlTreeView);
			this.Name = "TreeForm";
			this.Text = "TreeView";
			this.Load += new System.EventHandler(this.TreeForm_Load);
			this.contextMenuSave.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView XmlTreeView;
		private System.Windows.Forms.ContextMenuStrip contextMenuSave;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
	}
}

