using System;
using System.Text;
using System.ComponentModel;

namespace WaveformView.Chunks
{
    class Cue : Chunk
    {
        const string m_chunkName = "Cue Cunk";
        const string m_ID = "cue ";

        readonly UInt32 m_size;
        readonly CueDataCollection m_cues = new CueDataCollection();

        public Cue( UInt32 size, Byte [] data )
        {
            m_size = size;

            UInt32 cueCount = BitConverter.ToUInt32( data, 0 );

            for ( UInt32 i = 0; i < cueCount; ++i )
            {
                int offset = (int)(24 * i) + 4;

                Byte[] cueChunk = new Byte[24];

                Array.Copy( data, offset, cueChunk, 0, 24 );
                CueData newData = new CueData( cueChunk );
                m_cues.Add( newData );
            }
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

        
        [CategoryAttribute( m_chunkName )]
        [DisplayName( "Cues" )]
        [TypeConverter(typeof( CueDataCollectionConverter ) )]
        public CueDataCollection Cues
        {
            set { }
            get { return m_cues; }
        }
    }
}
