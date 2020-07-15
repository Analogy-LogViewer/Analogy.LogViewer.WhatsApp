using System.Windows.Forms;

namespace Analogy.LogViewer.WhatsApp
{
    partial class AnalogyColumnsMatcherUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnalogyColumnsMatcherUC));
            this.spltColumns = new System.Windows.Forms.SplitContainer();
            this.lstBAnalogyColumns = new System.Windows.Forms.ListBox();
            this.labelControl9 = new System.Windows.Forms.Label();
            this.splitContainerButtons = new System.Windows.Forms.SplitContainer();
            this.sBtnMoveUp = new System.Windows.Forms.Button();
            this.BtnMoveDown = new System.Windows.Forms.Button();
            this.lstBoxItems = new System.Windows.Forms.ListBox();
            this.labelControl10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spltColumns)).BeginInit();
            this.spltColumns.Panel1.SuspendLayout();
            this.spltColumns.Panel2.SuspendLayout();
            this.spltColumns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerButtons)).BeginInit();
            this.splitContainerButtons.Panel1.SuspendLayout();
            this.splitContainerButtons.Panel2.SuspendLayout();
            this.splitContainerButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // spltColumns
            // 
            this.spltColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltColumns.Location = new System.Drawing.Point(0, 0);
            this.spltColumns.Name = "spltColumns";
            // 
            // spltColumns.Panel1
            // 
            this.spltColumns.Panel1.Controls.Add(this.lstBAnalogyColumns);
            this.spltColumns.Panel1.Controls.Add(this.labelControl9);
            this.spltColumns.Panel1.Controls.Add(this.splitContainerButtons);
            this.spltColumns.Panel1.Text = "Panel1";
            // 
            // spltColumns.Panel2
            // 
            this.spltColumns.Panel2.Controls.Add(this.lstBoxItems);
            this.spltColumns.Panel2.Controls.Add(this.labelControl10);
            this.spltColumns.Panel2.Text = "Panel2";
            this.spltColumns.Size = new System.Drawing.Size(602, 483);
            this.spltColumns.SplitterDistance = 167;
            this.spltColumns.TabIndex = 10;
            // 
            // lstBAnalogyColumns
            // 
            this.lstBAnalogyColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBAnalogyColumns.ItemHeight = 16;
            this.lstBAnalogyColumns.Items.AddRange(new object[] {
            "Date",
            "Text",
            "Source",
            "Module",
            "MethodName",
            "FileName",
            "User",
            "LineNumber",
            "ProcessID",
            "Thread",
            "Level",
            "Class",
            "Category",
            "ID",
            "__ignore__",
            "__ignore__",
            "__ignore__",
            "__ignore__",
            "__ignore__",
            "__ignore__",
            "__ignore__"});
            this.lstBAnalogyColumns.Location = new System.Drawing.Point(47, 16);
            this.lstBAnalogyColumns.Name = "lstBAnalogyColumns";
            this.lstBAnalogyColumns.Size = new System.Drawing.Size(120, 467);
            this.lstBAnalogyColumns.TabIndex = 0;
            this.lstBAnalogyColumns.SelectedIndexChanged += new System.EventHandler(this.lstBAnalogyColumns_SelectedIndexChanged);
            // 
            // labelControl9
            // 
            this.labelControl9.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl9.Location = new System.Drawing.Point(47, 0);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(120, 16);
            this.labelControl9.TabIndex = 7;
            this.labelControl9.Text = "Log message Columns";
            // 
            // splitContainerButtons
            // 
            this.splitContainerButtons.Dock = System.Windows.Forms.DockStyle.Left;
            this.splitContainerButtons.Location = new System.Drawing.Point(0, 0);
            this.splitContainerButtons.Name = "splitContainerButtons";
            this.splitContainerButtons.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerButtons.Panel1
            // 
            this.splitContainerButtons.Panel1.Controls.Add(this.sBtnMoveUp);
            this.splitContainerButtons.Panel1.Text = "Panel1";
            // 
            // splitContainerButtons.Panel2
            // 
            this.splitContainerButtons.Panel2.Controls.Add(this.BtnMoveDown);
            this.splitContainerButtons.Panel2.Text = "Panel2";
            this.splitContainerButtons.Size = new System.Drawing.Size(47, 483);
            this.splitContainerButtons.SplitterDistance = 238;
            this.splitContainerButtons.TabIndex = 1;
            // 
            // sBtnMoveUp
            // 
            this.sBtnMoveUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sBtnMoveUp.Image = ((System.Drawing.Image)(resources.GetObject("sBtnMoveUp.Image")));
            this.sBtnMoveUp.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.sBtnMoveUp.Location = new System.Drawing.Point(0, 0);
            this.sBtnMoveUp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sBtnMoveUp.Name = "sBtnMoveUp";
            this.sBtnMoveUp.Size = new System.Drawing.Size(47, 238);
            this.sBtnMoveUp.TabIndex = 2;
            this.sBtnMoveUp.Text = "Up";
            this.sBtnMoveUp.Click += new System.EventHandler(this.BtnMoveUp_Click);
            // 
            // BtnMoveDown
            // 
            this.BtnMoveDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnMoveDown.Image = ((System.Drawing.Image)(resources.GetObject("BtnMoveDown.Image")));
            this.BtnMoveDown.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnMoveDown.Location = new System.Drawing.Point(0, 0);
            this.BtnMoveDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnMoveDown.Name = "BtnMoveDown";
            this.BtnMoveDown.Size = new System.Drawing.Size(47, 241);
            this.BtnMoveDown.TabIndex = 3;
            this.BtnMoveDown.Text = "Down";
            this.BtnMoveDown.Click += new System.EventHandler(this.BtnMoveDown_Click);
            // 
            // lstBoxItems
            // 
            this.lstBoxItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBoxItems.ItemHeight = 16;
            this.lstBoxItems.Location = new System.Drawing.Point(0, 16);
            this.lstBoxItems.Name = "lstBoxItems";
            this.lstBoxItems.Size = new System.Drawing.Size(431, 467);
            this.lstBoxItems.TabIndex = 2;
            // 
            // labelControl10
            // 
            this.labelControl10.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl10.Location = new System.Drawing.Point(0, 0);
            this.labelControl10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(431, 16);
            this.labelControl10.TabIndex = 8;
            this.labelControl10.Text = "Parsed columns.";
            // 
            // AnalogyColumnsMatcherUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spltColumns);
            this.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.Name = "AnalogyColumnsMatcherUC";
            this.Size = new System.Drawing.Size(602, 483);
            this.spltColumns.Panel1.ResumeLayout(false);
            this.spltColumns.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltColumns)).EndInit();
            this.spltColumns.ResumeLayout(false);
            this.splitContainerButtons.Panel1.ResumeLayout(false);
            this.splitContainerButtons.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerButtons)).EndInit();
            this.splitContainerButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer spltColumns;
        private ListBox lstBAnalogyColumns;
        private Label labelControl9;
        private SplitContainer splitContainerButtons;
        private Button sBtnMoveUp;
        private Button BtnMoveDown;
        private ListBox lstBoxItems;
        private Label labelControl10;
    }
}
