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
            Riff riffChunk = new Riff(100, "WAVE");
            ChunkDisplay disp = new ChunkDisplay(riffChunk);
            disp.Size = new Size(panel1.Width - 10, panel1.Height - 10);
            disp.Location = new Point(5, 5);
            disp.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            panel1.Controls.Add(disp);
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
                //int xOffset = 5;
                //int yOffset = 5;
                //string [] files = ( string [] )( e.Data.GetData( DataFormats.FileDrop ) );

                //Console.WriteLine(files[0]);
                //if ( files[0].Contains( ".wav"))
                //{
                //    panel1.Controls.Clear();

                //    List<Chunk> chunks = new List<Chunk>();
                //    ReadChunks(files[0], ref chunks);

                //    foreach (var chunk in chunks)
                //    {
                //        ChunkDisplay disp = new ChunkDisplay(chunk);
                //        disp.Size = new Size(panel1.Width - 10, 100);
                //        disp.Location = new Point(xOffset, yOffset);
                //        panel1.Controls.Add(disp);
                //        yOffset += 100;
                //    }
                //}
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
                out_knownChunks = new List<Chunk>();

                // For the time, only supporting "RIFF" organized files.
                Byte [] mainChunkData = new Byte[12];
                source.Read( mainChunkData, 0, 12 );

                string mainChunkID = Encoding.ASCII.GetString( mainChunkData, 0, 4 );
                UInt32 mainChunkSize = BitConverter.ToUInt32( mainChunkData, 4 );
                string subChunkFormat = Encoding.ASCII.GetString( mainChunkData, 8, 4 );
                if ( "RIFF" != mainChunkID )
                {
                    Console.WriteLine( "Unsupported header format \"" + mainChunkID + "\". Quitting." );
                    return;
                }

                if ( "WAVE" != subChunkFormat )
                {
                    Console.WriteLine( "Unsupported data format \"" + mainChunkID + "\". Quitting." );
                    return;
                }

                Riff riffChunk = new Riff( mainChunkSize, subChunkFormat );
                out_knownChunks.Add(riffChunk);

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
                        out_knownChunks.Add(dataChunk);
                    }
                    else if ( "fmt " == chunkType )
                    {
                        UInt16 format = BitConverter.ToUInt16( chunkData,  0 );
                        UInt16 channels = BitConverter.ToUInt16( chunkData, 2 );
                        UInt32 rate = BitConverter.ToUInt32( chunkData, 4 );
                        UInt32 byteRate = BitConverter.ToUInt32( chunkData, 8 );
                        UInt16 alignment = BitConverter.ToUInt16( chunkData, 12 );
                        UInt16 bps = BitConverter.ToUInt16( chunkData, 14 );

                        if ( 16 < chunkSize )
                        {
                            UInt16 extraDataSize = BitConverter.ToUInt16( chunkData, 16 );
                        }

                        Format formatChunk = new Format( ( UInt32 )( chunkSize ), format, channels, rate, byteRate, alignment, bps );
                        out_knownChunks.Add(formatChunk);
                    }
                    else if ( "cue " == chunkType )
                    {
                        UInt32 cueCount = BitConverter.ToUInt32( chunkData, 0 );
                        
                        Cue cueChunk = new Cue( (UInt32)chunkSize );
                        out_knownChunks.Add(cueChunk);

                        for ( UInt32 i = 0; i < cueCount; ++i )
                        {
                            int offset = (int)(24 * i) + 4;
                            
                            UInt32 cuePointID = BitConverter.ToUInt32( chunkData, offset + 0 );
                            UInt32 playOrderPosition = BitConverter.ToUInt32( chunkData, offset + 4 );
                            string dataChunkID = Encoding.ASCII.GetString( chunkData, offset + 8, 4 );
                            UInt32 chunkStart = BitConverter.ToUInt32( chunkData, offset + 12 );
                            UInt32 blockStart = BitConverter.ToUInt32( chunkData, offset + 16 );
                            UInt32 frameOffset = BitConverter.ToUInt32( chunkData, offset + 20 );
                        }

                    }
                    else if ( "JUNK" == chunkType )
                    {
                        Junk junkChunk = new Junk( (UInt32)chunkSize );
                        out_knownChunks.Add(junkChunk);
                    }
                    else if ( "bext" == chunkType )
                    {
                        /*
                            https://tech.ebu.ch/docs/tech/tech3285.pdf

                            CHAR Description[256]; // get str until null
                            CHAR Originator[32]; // get str until null
                            CHAR OriginatorReference[32]; // get str until null
                            CHAR OriginationDate[10]; // formatted
                            CHAR OriginationTime[8]; // formatted
                            DWORD TimeReferenceLow; // read 2 bytes
                            DWORD TimeReferenceHigh; // read 2 bytes
                            WORD Version; // read 4bytes
                            BYTE UMID_0; // read 64 bytes
                            BYTE UMID_63;
                            WORD LoudnessValue; // read 2 bytes
                            WORD LoudnessRange; // read 2 bytes
                            WORD MaxTruePeakLevel; // read 2 bytes
                            WORD MaxMomentaryLoudness; // read 2 bytes
                            WORD MaxShortTermLoudness; // read 2 bytes
                            BYTE Reserved[180]; // skip 180 char
                            CHAR CodingHistory[]; // read until null
                        */
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

                            InfoString str = new InfoString(infoType, infoValue);
                            out_knownChunks.Add(str);

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
