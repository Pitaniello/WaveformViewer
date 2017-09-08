using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using WaveformView.Chunks;

namespace WaveformView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                if ( e.Data.GetDataPresent( DataFormats.FileDrop ) )
                {
                    e.Effect = DragDropEffects.Copy;
                }
            }
            catch ( Exception ex )
            {
                MessageBox.Show( ex.ToString(), "Error!", MessageBoxButtons.OK );
                Application.Exit();
            }
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] files = (string[])(e.Data.GetData(DataFormats.FileDrop));

                if ( files[0].Contains( ".wav"))
                {
                    panel1.Controls.Clear();
                    Riff riffChunk = null;

                    using ( FileStream source = new FileStream( files[0], FileMode.Open, FileAccess.Read, FileShare.Read ) )
                    {
                        Byte [] data = new byte[source.Length];
                        source.Read(data, 0, (int)source.Length);
                        riffChunk = ChunkFactory.CreateChunk( "RIFF", ( UInt32 )( source.Length ), data ) as Riff;
                    }

                    if ( riffChunk != null )
                    {
                        ChunkDisplay disp = new ChunkDisplay(riffChunk);
                        disp.Size = new Size(panel1.Width - 10, panel1.Height - 10);
                        disp.Location = new Point(5, 5);
                        panel1.Controls.Add(disp);
                    }
                }
                else
                {
                    string ext = Path.GetExtension( files[0] );
                    MessageBox.Show( "Unsupported file format \"" + ext + "\". Currently, only \".wav\" is supported.",
                        "Warning!",
                        MessageBoxButtons.OK );
                }
            }
            catch ( Exception ex )
            {
                MessageBox.Show( ex.ToString(), "Error!", MessageBoxButtons.OK );
                Application.Exit();
            }
        }
    }
}
