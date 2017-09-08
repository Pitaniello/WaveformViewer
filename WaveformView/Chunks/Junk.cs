using System;
using System.ComponentModel;

namespace WaveformView.Chunks
{
    class Junk : Chunk
    {
        const string m_chunkName = "Junk Chunk";
        const string m_ID = "JUNK";

        readonly UInt32 m_size;

        public Junk( UInt32 size, Byte [] data )
        {
            m_size = size;
        }

        public override string Name
        {
            get { return m_chunkName; }
            set { }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName( "Chunk ID" )]
        public string ChunkId
        {
            set { }
            get { return m_ID; }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName( "Chunk Size" )]
        public UInt32 Size
        {
            set { }
            get { return m_size; }
        }
    }
}
