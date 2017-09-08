using System;
using System.Text;
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

        readonly Dictionary<string, string> m_values = new Dictionary<string, string>();

        public List( UInt32 size, Byte [] data )
        {
            m_chunkSize = size;

            Int32 pos = 0;
            m_type = Encoding.ASCII.GetString( data, pos, 4 );
            pos += 4;

            while ( pos < m_chunkSize )
            {
                string infoType = Encoding.ASCII.GetString( data, pos, 4 );
                pos += 4;
                Int32 infoSize = BitConverter.ToInt32( data, pos );
                pos += 4;

                if ( "adtl" == m_type )
                {
                    //Int32 infoID = BitConverter.ToInt32( data, pos );
                    infoType = BitConverter.ToInt32( data, pos ).ToString();
                    pos += 4;
                    infoSize -= 4;
                }

                string infoValue = Encoding.ASCII.GetString( data, pos, infoSize );
                //InfoString value = new InfoString( infoType, infoValue );
                //m_values.Add( value );
                m_values.Add( infoType, infoValue );

                pos += infoSize;

                if ( infoSize % 2 == 1 )
                {
                    pos += 1;
                }
            }
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

        [CategoryAttribute( m_chunkName )]
        [DisplayName( "Values" )]
        [TypeConverter(typeof( DictionaryConverter ) )]
        public DictionaryPropertyAdapter Values
        {
            set { }
            get { return new DictionaryPropertyAdapter(m_values); }
        }
    }
}
