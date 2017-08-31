using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using WaveformView.Chunks;
using System.Text;

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
            using ( FileStream source = new FileStream( in_filename, FileMode.Open, FileAccess.Read, FileShare.Read ) )
            {
                // For the time, only supporting "RIFF" organized files.
                Byte [] mainChunkData = new Byte[12];
                source.Read( mainChunkData, 0, 12 );

                string mainChunkID = Encoding.ASCII.GetString( mainChunkData, 0, 4 );
                UInt32 mainChunkSize = BitConverter.ToUInt32( mainChunkData, 4 );
                string subChunkFormat = Encoding.ASCII.GetString( mainChunkData, 8, 4 );
                if ( "RIFF" != mainChunkID )
                {
                    Console.WriteLine( "Unsupported header format \"" + mainChunkID + "\". Quitting read." );
                    return;
                }

                if ( "WAVE" != subChunkFormat )
                {
                    Console.WriteLine( "Unsupported data format \"" + mainChunkID + "\". Quitting read." );
                    return;
                }

                Int32 bytesRead = 0;
                Int32 readThisTime = 0;

                Byte [] subChunkHeader = new Byte[8];
                readThisTime = source.Read( subChunkHeader, 0, 8 );
                bytesRead += readThisTime;

                while ( (readThisTime != 0) && (bytesRead < mainChunkSize) )
                {
                    string chunkType = Encoding.ASCII.GetString( subChunkHeader, 0, 4 );
                    Int32 chunkSize = BitConverter.ToInt32( subChunkHeader, 4 );

                    Byte [] chunkData = new Byte[chunkSize];
                    readThisTime = source.Read( chunkData, 0, chunkSize );
                    bytesRead += readThisTime;

                    if ( chunkSize % 2 == 1 )
                    {
                        Byte [] oddSize = new Byte[1];
                        readThisTime = source.Read( oddSize, 0, 1 );
                        bytesRead += readThisTime;
                    }

                    if ( readThisTime == 0 )
                    {
                        break;
                    }

                    if ( "data" == chunkType )
                    {
                        Data dataChunk = new Data( (UInt32)chunkSize );
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
                    }
                    else if ( "cue " == chunkType )
                    {
                        Cue cueChunk = new Cue( (UInt32)chunkSize );
                    }
                    else if ( "JUNK" == chunkType )
                    {
                        Junk junkChunk = new Junk( (UInt32)chunkSize );
                    }
                    else if ( "LIST" == chunkType )
                    {
                        Int32 converted = 0;

                        string listType = Encoding.ASCII.GetString( chunkData, 0, 4 );
                        converted += 4;

                        while ( converted < chunkSize )
                        {
                            string infoType = Encoding.ASCII.GetString( chunkData, converted, 4 );
                            converted += 4;
                            Int32 infoSize = BitConverter.ToInt32( chunkData, converted );
                            converted += 4;

                            if ( "adtl" == listType )
                            {
                                Int32 infoID = BitConverter.ToInt32( chunkData, converted );
                                converted += 4;
                                infoSize -= 4;
                            }

                            string infoValue = Encoding.ASCII.GetString( chunkData, converted, infoSize );
                            converted += infoSize;

                            if ( infoSize % 2 == 1 )
                            {
                                converted += 1;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine( "Ignoring unknown chunk of type " + chunkType + Environment.NewLine );
                    }

                    readThisTime = source.Read( subChunkHeader, 0, 8 );
                    bytesRead += readThisTime; 
                }
            }
        }
    }
}
