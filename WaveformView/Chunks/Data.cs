using System;
using System.ComponentModel;

namespace WaveformView
{
    class Data : Chunk
    {
        const string m_chunkName = "data";
        
        // Contains the letters "data" (0x64617461 big-endian form).
        readonly Char [] m_ID = { 'd', 'a', 't', 'a' };
        // == NumSamples * NumChannels * BitsPerSample/8 This is the number of bytes in the data.
        //  You can also think of this as the size of the read of the subchunk following this 
        //  number.
        readonly Int32 m_size;

        public Data( Int32 size )
        {
            m_size = size;
        }

        [CategoryAttribute( "foo" )]
        [DisplayName("ID")]
        public Char [] ID
        {
            set { }
            get { return m_ID; }
        }

        [CategoryAttribute( "bar" )]
        [DisplayName("Size")]
        public Int32 Size
        {
            set { }
            get { return m_size; }
        }
    }
}
