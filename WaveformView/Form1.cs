using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using WaveformView.Chunks;


/*
    TODO
        overload char array display so it shows the chars, not the type

        Find a way to set property grids to their natural height

        Separate LIST into its own, better thing

        Make a better way of tellig when I'm fucking done reading a chunk

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
                    List<Chunk> chunks = new List<Chunk>();
                    ReadChunks(files[0], ref chunks);

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

        private void ReadChunks( string in_filename, ref List<Chunk> out_knownChunks )
        {
            using (FileStream source = new FileStream(in_filename, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                Byte [] mainChunkData = new Byte[4];
                source.Read( mainChunkData, 0, 4 );
                string mainChunkID = System.Text.Encoding.ASCII.GetString( mainChunkData, 0, 4 );

                if ( "RIFF" == mainChunkID )
                {
                    ReadChunk_RIFF( source, ref out_knownChunks );
                }
                else if ( "RIFX" == mainChunkID )
                {
                    ReadChunk_RIFX( source, ref out_knownChunks );
                }
                else
                {
                    Console.WriteLine("Unkown main chunk id \"" + mainChunkID + "\". Failed to read.");
                    return;
                }
            }
        }

        private void ReadChunk_RIFX(FileStream in_source, ref List<Chunk> out_knownChunks)
        {
            Console.WriteLine("Let's be honest; I don't know if I'm going to bother with this.");
        }

        private void ReadChunk_RIFF( FileStream in_source, ref List<Chunk> out_knownChunks )
        {   
            Byte [] mainChunkData = new Byte[12];
            in_source.Read( mainChunkData, 0, 12 );

            string mainChunkID = System.Text.Encoding.ASCII.GetString( mainChunkData, 0, 4 );
            UInt32 mainChunkSize = BitConverter.ToUInt32( mainChunkData, 4 );
            string mainChunkFormat = System.Text.Encoding.ASCII.GetString( mainChunkData, 8, 4 );

            Riff riffChunk = new Riff( mainChunkSize, mainChunkFormat );
            out_knownChunks.Add( riffChunk );

            Byte [] chunkHeader = new Byte[8];
            Int32 bytesRead = -4;
            bytesRead += in_source.Read( chunkHeader, 0, 8 );

            while ( bytesRead < mainChunkSize )
            {
                string chunkType = System.Text.Encoding.ASCII.GetString( chunkHeader, 0, 4 );
                Int32 chunkSize = BitConverter.ToInt32( chunkHeader, 4 );

                Byte [] chunkData = new Byte[chunkSize];
                bytesRead += in_source.Read( chunkData, 0, chunkSize );

                // case; ended on odd byte, so reading in one padding byte
                if ( chunkSize % 2 == 1 )
                {
                    Byte [] oddSize = new Byte[1];
                    bytesRead += in_source.Read( chunkData, 0, 1 );
                }

                if ( "data" == chunkType )
                {
                    Data dataChunk = new Data( (UInt32)chunkSize );
                    out_knownChunks.Add( dataChunk );
                }
                else if ( "fmt " == chunkType )
                {
                    UInt16 format = BitConverter.ToUInt16( chunkData,  0 );
                    UInt16 channels = BitConverter.ToUInt16( chunkData, 2 );
                    UInt32 rate = BitConverter.ToUInt32( chunkData, 4 );
                    UInt32 byteRate = BitConverter.ToUInt32( chunkData, 8 );
                    UInt16 alignment = BitConverter.ToUInt16( chunkData, 12 );
                    UInt16 bps = BitConverter.ToUInt16( chunkData, 14 );

                    Format formatChunk = new Format( ( UInt32 )( chunkSize ), format, channels, rate, byteRate, alignment, bps );
                    out_knownChunks.Add( formatChunk );
                }
                else if ( "cue " == chunkType )
                {
                    Cue cueChunk = new Cue( (UInt32)chunkSize );
                    out_knownChunks.Add( cueChunk );
                }
                else if ( "JUNK" == chunkType )
                {
                    Junk junkChunk = new Junk( (UInt32)chunkSize );
                    out_knownChunks.Add( junkChunk );
                }
                else if ( "LIST" == chunkType )
                {
                    ReadChunk_LIST( in_source, ref out_knownChunks );
                }
                else
                {
                    Console.WriteLine( "Ignoring unknown chunk of type " + chunkType + Environment.NewLine );
                }

                bytesRead += in_source.Read( chunkHeader, 0, 8 );
            }
        }

        private void ReadChunk_LIST( FileStream in_source, ref List<Chunk> out_knownChunks )
        {
            Byte [] mainChunkData = new Byte[12];
            in_source.Read( mainChunkData, 0, 12 );

            string mainChunkID = System.Text.Encoding.ASCII.GetString( mainChunkData, 0, 4 );
            UInt32 mainChunkSize = BitConverter.ToUInt32( mainChunkData, 4 );
            string mainChunkFormat = System.Text.Encoding.ASCII.GetString( mainChunkData, 8, 4 );
            
            List listChunk = new List( mainChunkSize, mainChunkFormat );
            out_knownChunks.Add( listChunk );

            Byte [] chunkHeader = new Byte[8];
            Int32 bytesRead = -4;
            bytesRead += in_source.Read( chunkHeader, 0, 8 );

            while ( bytesRead < mainChunkSize )
            {
                string chunkType = System.Text.Encoding.ASCII.GetString( chunkHeader, 0, 4 );
                Int32 chunkSize = BitConverter.ToInt32( chunkHeader, 4 );

                Byte [] chunkData = new Byte[chunkSize];
                bytesRead += in_source.Read( chunkData, 0, chunkSize );
                string chunkValue = System.Text.Encoding.ASCII.GetString( chunkData );

                // case; ended on odd byte, so reading in one padding byte
                if ( chunkSize % 2 == 1 )
                {
                    Byte [] oddSize = new Byte[1];
                    bytesRead += in_source.Read( chunkData, 0, 1 );
                }

                InfoString infoChunk = new InfoString( chunkType, chunkValue );
                out_knownChunks.Add( infoChunk );

                bytesRead += in_source.Read( chunkHeader, 0, 8 );
            }
            
            var cur = in_source.Position;
            in_source.Position = cur - 8;
        }
    }
}
