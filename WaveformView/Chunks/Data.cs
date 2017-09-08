using System;
using System.ComponentModel;

namespace WaveformView.Chunks
{
    class Data : Chunk
    {
        const string m_chunkName = "Data Chunk";
        const string m_ID = "data";

        readonly UInt32 m_size;

        public Data( UInt32 size, Byte [] data )
        {
            m_size = size;
        }

        public override string Name
        {
            get { return m_chunkName; }
            set { }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName( "ID" )]
        public string ID
        {
            get { return m_ID; }
            set { }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName( "Size" )]
        public UInt32 Size
        {
            get { return m_size; }
            set { }
        }
    }
}
