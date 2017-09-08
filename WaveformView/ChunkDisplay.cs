using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Globalization;
using WaveformView.Chunks;

namespace WaveformView
{
    public partial class ChunkDisplay : UserControl
    {
        public ChunkDisplay( Chunk chunk )
        {
            if ( chunk != null )
            {
                InitializeComponent();
                
                Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);

                displayPropertyGrid.PropertySort = PropertySort.NoSort;
                displayPropertyGrid.SelectedObject = chunk as object;
            }
            else
            {
                throw new Exception("Failed to initial new Chunk Display, as the constructor was handed an invalid chunk reference.");
            }
        }
    }
}
