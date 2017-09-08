using System;
using System.ComponentModel;

namespace WaveformView.Chunks
{
    class InfoString : Chunk
    {
        const string m_chunkName = "List-Info Chunk";
        readonly string m_ID;
        readonly string m_value;

        public InfoString( string chunkId, string value )
        {
            m_ID = chunkId;
            m_value = value;
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
        [DisplayName( "Value" )]
        public string Size
        {
            set { }
            get { return m_value; }
        }
    }
}
