using System;
using System.ComponentModel;

namespace WaveformView.Chunks
{
    class Format : Chunk
    {
        const string m_chunkName = "Format Chunk";
        readonly string m_ID = "fmt ";
        readonly UInt32 m_size;
        readonly UInt16 m_format;
        readonly UInt16 m_channels;
        readonly UInt32 m_sampleRate;
        readonly UInt32 m_byteRate;
        readonly UInt16 m_blockAlign;
        readonly UInt16 m_bitsPerSample;

        public Format( UInt32 size, UInt16 format, UInt16 channels, UInt32 rate, UInt32 byteRate, UInt16 alignment, UInt16 bps )
        {
            m_size = size;
            m_format = format;
            m_channels = channels;
            m_sampleRate = rate;
            m_byteRate = byteRate;
            m_blockAlign = alignment;
            m_bitsPerSample = bps;
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
        [DisplayName( "Size" )]
        public UInt32 Size
        {
            set { }
            get { return m_size; }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName( "Audio Format" )]
        public UInt16 AudioFormat
        {
            set { }
            get { return m_format; }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName( "Channels" )]
        public UInt16 Channels
        {
            set { }
            get { return m_channels; }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName( "Sample Rate" )]
        public UInt32 SamplingRate
        {
            set { }
            get { return m_sampleRate; }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName( "Byte Rate" )]
        public UInt32 ByteRate
        {
            set { }
            get { return m_byteRate; }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName( "Block Alignmment" )]
        public UInt16 Alignment
        {
            set { }
            get { return m_blockAlign; }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName( "Bits Per Sample" )]
        public UInt16 BitsPerSample
        {
            set { }
            get { return m_bitsPerSample; }
        }
    }
}
