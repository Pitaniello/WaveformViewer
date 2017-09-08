using System;
using System.ComponentModel;

namespace WaveformView.Chunks
{
    class Cue : Chunk
    {
        const string m_chunkName = "Cue Cunk";
        readonly string m_ID = "cue ";
        readonly UInt32 m_size;

        public Cue( UInt32 size )
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
