namespace WaveformView
{
    partial class ChunkDisplay
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
            this.displayPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // displayPropertyGrid
            // 
            this.displayPropertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.displayPropertyGrid.HelpVisible = false;
            this.displayPropertyGrid.LineColor = System.Drawing.SystemColors.ControlDark;
            this.displayPropertyGrid.Location = new System.Drawing.Point(3, 3);
            this.displayPropertyGrid.Name = "displayPropertyGrid";
            this.displayPropertyGrid.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.displayPropertyGrid.Size = new System.Drawing.Size(144, 144);
            this.displayPropertyGrid.TabIndex = 0;
            this.displayPropertyGrid.ToolbarVisible = false;
            // 
            // ChunkDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.displayPropertyGrid);
            this.Name = "ChunkDisplay";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid displayPropertyGrid;
    }
}
