using System;
using System.ComponentModel;

namespace WaveformView.Chunks
{
    [TypeConverter(typeof( ChunkConverter ) )]
    public abstract class Chunk
    {
        public Chunk()
        {
        }

        [Browsable( false )]
        public abstract string Name
        {
            get;
            set;
        }
    }
}
