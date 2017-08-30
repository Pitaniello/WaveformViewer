using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WaveformView.Chunks
{
    class List : Chunk
    {
        const string m_chunkName = "List Chunk";

        // Contains the letters "RIFF" in ASCII form (0x52494646 big-endian form).
        readonly string m_chunkID = "LIST";

        // 36 + SubChunk2Size, or more precisely: 
        //  4 + (8 + SubChunk1Size) + (8 + SubChunk2Size) This is the size of the rest of the chunk 
        //  following this number.  This is the size of the entire file in bytes minus 8 bytes for the
        //  two fields not included in this count: ChunkID and ChunkSize.
        readonly UInt32 m_chunkSize;

        // Contains the letters "WAVE" (0x57415645 big-endian form).
        readonly string m_type;

        public List( UInt32 chunkSize, string type )
        {
            m_chunkSize = chunkSize;
            m_type = type;
        }


        [CategoryAttribute( m_chunkName )]
        [DisplayName("Chunk ID")]
        public string ChunkId
        {
            set { }
            get { return m_chunkID; }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName("Chunk Size")]
        public UInt32 ChunkSize
        {
            set { }
            get { return m_chunkSize; }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName("Data Format")]
        public string Type
        {
            set { }
            get { return m_type; }
        }
    }
}
