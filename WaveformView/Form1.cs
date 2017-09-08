using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using WaveformView.Chunks;
using System.Text;
using System.ComponentModel;
using System.Collections;

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
                Console.WriteLine( ex );
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
                        riffChunk = ChunkFactory.CreateChunk("RIFF", (uint)source.Length, data) as Riff;
                    }

                    if ( riffChunk != null )
                    {
                        ChunkDisplay disp = new ChunkDisplay(riffChunk);
                        disp.Size = new Size(panel1.Width - 10, panel1.Height - 10);
                        disp.Location = new Point(5, 5);
                        panel1.Controls.Add(disp);
                    }
                }
            }
            catch ( Exception ex )
            {
                Console.WriteLine( ex );
            }
        }

        private void ReadChunks( string in_filename, ref List<Chunk> out_knownChunks )
        {

        }
    }
}
