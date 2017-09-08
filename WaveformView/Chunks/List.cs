using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WaveformView.Chunks
{
    class List : Chunk
    {
        const string m_chunkName = "List Chunk";
        readonly string m_chunkID = "LIST";
        readonly UInt32 m_chunkSize;
        readonly string m_type;

        public List( UInt32 chunkSize, string type )
        {
            m_chunkSize = chunkSize;
            m_type = type;
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
            get { return m_chunkID; }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName( "Chunk Size" )]
        public UInt32 ChunkSize
        {
            set { }
            get { return m_chunkSize; }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName( "Data Format" )]
        public string Type
        {
            set { }
            get { return m_type; }
        }
    }
}
