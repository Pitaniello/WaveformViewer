using System;
using System.ComponentModel;

namespace WaveformView
{
    class Riff : Chunk
    {
        const string m_chunkName = "RIFF";

        // Contains the letters "RIFF" in ASCII form (0x52494646 big-endian form).
        readonly Char [] m_chunkID = { 'R', 'I', 'F', 'F' };

        // 36 + SubChunk2Size, or more precisely: 
        //  4 + (8 + SubChunk1Size) + (8 + SubChunk2Size) This is the size of the rest of the chunk 
        //  following this number.  This is the size of the entire file in bytes minus 8 bytes for the
        //  two fields not included in this count: ChunkID and ChunkSize.
        readonly Int32 m_chunkSize;

        // Contains the letters "WAVE" (0x57415645 big-endian form).
        readonly Char[] m_format = { 'W', 'A', 'V', 'E' };


        public Riff( Int32 chunkSize )
        {
            m_chunkSize = chunkSize;
        }


        [CategoryAttribute( m_chunkName )]
        [DisplayName("Chunk ID")]
        public Char [] ChunkId
        {
            set { }
            get { return m_chunkID; }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName("Chunk Size")]
        public Int32 ChunkSize
        {
            set { }
            get { return m_chunkSize; }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName("Data Format")]
        public Char [] Format
        {
            set { }
            get { return m_format; }
        }
    }
}
