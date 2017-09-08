using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WaveformView.Chunks
{
    class Riff : Chunk
    {
        const string m_chunkName = "Riff Chunk";

        readonly string m_chunkID = "RIFF";
        readonly UInt32 m_chunkSize;
        readonly string m_format;


        readonly ChunkCollection m_chunkCollection = new ChunkCollection();

        public Riff( UInt32 chunkSize, string format )
        {
            m_chunkSize = chunkSize;
            m_format = format;

            Data dataCHunk = new Data(500);
            Junk blah = new Junk(30);
            Cue foo = new Cue(1);

            m_chunkCollection.Add(dataCHunk);
            m_chunkCollection.Add(blah);
            m_chunkCollection.Add(foo);
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
        public string Format
        {
            set { }
            get { return m_format; }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName( "Contained Chunks" )]
        [TypeConverter(typeof( ChunkCollectionConverter ) )]
        public ChunkCollection ChunkCollections
        {
            set { }
            get { return m_chunkCollection; }
        }

    }
}
