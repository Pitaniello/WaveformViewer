using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Drawing;


/*
    TODO
        overload char array display so it shows the chars, not the type

        Find a way to set property grids to their natural height

        Consider reviewing chunk org:
            Type - Main - Sub - Chunk Data
        set up new chunks
            LIST	INFO	INAM	The name of the file (or "project").
            LIST	INFO	ISBJ	The subject.
            LIST	INFO	IART	The artist who created this.
            LIST	INFO	ICMT	A text comment.
            LIST	INFO	IKEY	The keywords for the project or file.
            LIST	INFO	ISFT	The software used to create the file.
            LIST	INFO	IENG	The engineer.
            LIST	INFO	ITCH	The technician.
            LIST	INFO	ICRD	The creation date.
            LIST	INFO	GENR	Genre of content.
            LIST	INFO	ICOP	The copyright information.

        Implement drag and drop

        parse wave headers

        tabs

        wave view window

        data window

*/

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
                int xOffset = 10;
                int yOffset = 10;
                string [] files = ( string [] )( e.Data.GetData( DataFormats.FileDrop ) );

                Console.WriteLine(files[0]);
                if ( files[0].Contains( ".wav"))
                {
                    List<Chunk> chunks;
                    ReadChunks(files[0], out chunks);

                    foreach ( var chunk in chunks )
                    {
                        ChunkDisplay disp = new ChunkDisplay(chunk);
                        disp.Size = new Size( panel1.Width - 20, 100 );
                        disp.Location = new Point( xOffset, yOffset );
                        panel1.Controls.Add(disp);
                        yOffset += 100;
                    }
                }
            }
            catch ( Exception ex )
            {
                Console.WriteLine( ex );
            }
        }

        const string riffHeader = "RIFF";
        const string dataHeader = "data";
        const string formatHeader = "fmt ";
        const string listHeader = "LIST";

        private bool ReadChunks( string in_filename, out List<Chunk> out_knownChunks )
        {
            bool result = true;
            out_knownChunks = new List<Chunk>();

            using ( FileStream source = new FileStream( in_filename, FileMode.Open, FileAccess.Read, FileShare.Read ) )
            {
                // RIFF
                Byte [] riffData = new Byte[12];
                UInt32 bytesRead = ( UInt32 )( source.Read( riffData, 0, 12 ) );
                UInt32 dataSize = BitConverter.ToUInt32( riffData, 4 );
                Riff riffChunk = new Riff( dataSize );
                out_knownChunks.Add( riffChunk );

                // All subsequent things
                Byte [] chunkHeader = new Byte[8];
                bool finishedReadingChunks = false;
                bytesRead += ( UInt32 )( source.Read( chunkHeader, 0, 8 ) );

                while ( !finishedReadingChunks )
                {
                    string chunkType = System.Text.Encoding.ASCII.GetString( chunkHeader, 0, 4 );
                    Int32 chunkSize = BitConverter.ToInt32( chunkHeader, 4 );

                    if ( dataHeader == chunkType )
                    {
                        Byte [] chunkData = new Byte[chunkSize];
                        
                        Data dataChunk = new Data( (UInt32)chunkSize );
                        out_knownChunks.Add( dataChunk );

                        // read audio data here

                        finishedReadingChunks = true;
                    }
                    else if ( formatHeader == chunkType )
                    {
                        Byte [] chunkData = new Byte[chunkSize];
                        bytesRead += ( UInt32 )( source.Read( chunkData, 0, chunkSize ) );

                        UInt16 format = BitConverter.ToUInt16( chunkData,  0 );
                        UInt16 channels = BitConverter.ToUInt16( chunkData, 2 );
                        UInt32 rate = BitConverter.ToUInt32( chunkData, 4 );
                        UInt32 byteRate = BitConverter.ToUInt32( chunkData, 8 );
                        UInt16 alignment = BitConverter.ToUInt16( chunkData, 12 );
                        UInt16 bps = BitConverter.ToUInt16( chunkData, 14 );

                        Format formatChunk = new Format( ( UInt32 )( chunkSize ), format, channels, rate, byteRate, alignment, bps );
                        out_knownChunks.Add( formatChunk );
                    }
                    else
                    {
                        Console.WriteLine( "Ignoring unknown chunk of type " + chunkType + Environment.NewLine );
                        bytesRead += (UInt32)chunkSize;
                        source.Seek( ( long )( bytesRead ), SeekOrigin.Begin );
                    }

                    
                    bytesRead += ( UInt32 )( source.Read( chunkHeader, 0, 8 ) );
                }

            }

            return result;
        }
    }
}
