using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Globalization;

namespace WaveformView
{
    public partial class ChunkDisplay : UserControl
    {
        public ChunkDisplay( Chunk chunk )
        {
            if ( chunk != null )
            {
                InitializeComponent();
                this.displayPropertyGrid.SelectedObject = chunk as object;
            }
            else
            {
                throw new Exception("Failed to initial new Chunk Display, as the constructor was handed an invalid chunk reference.");
            }
        }
    }
}
