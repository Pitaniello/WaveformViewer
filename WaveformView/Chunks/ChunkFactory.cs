using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveformView.Chunks
{
    static public class ChunkFactory
    {
        static public Chunk CreateChunk( string name, UInt32 size, Byte [] data )
        {
            Chunk result = null;

            switch( name )
            {
                case "RIFF":
                    result = new Riff( size, data );
                    break;
                    
                case "LIST":
                    result = new List( size, data );
                    break;

                case "JUNK":
                    result = new Junk( size, data );
                    break;

                case "fmt ":
                    result = new Format( size, data );
                    break;

                case "data":
                    result = new Data( size, data );
                    break;
                    
                case "cue ":
                    result = new Cue( size, data );
                    break;

                case "bext":
                    result = new BroadcastExtension( size, data );
                    break;

                default:
                    Console.WriteLine( "Unkown chunk type " + name + "." );
                    break;
            }

            return result;
        }
    }
}
