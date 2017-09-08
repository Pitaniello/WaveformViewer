using System;
using System.ComponentModel;

namespace WaveformView.Chunks
{
    class Format : Chunk
    {
        const string m_chunkName = "Format Chunk";
        const string m_ID = "fmt ";

        readonly UInt32 m_size;
        readonly UInt16 m_format;
        readonly UInt16 m_channels;
        readonly UInt32 m_sampleRate;
        readonly UInt32 m_byteRate;
        readonly UInt16 m_blockAlign;
        readonly UInt16 m_bitsPerSample;
        readonly UInt16 m_extraDataSize;

        public Format( UInt32 size, Byte [] data )
        {
            m_size = size;
            m_format= BitConverter.ToUInt16( data, 0 );
            m_channels = BitConverter.ToUInt16( data, 2 );
            m_sampleRate = BitConverter.ToUInt32( data, 4 );
            m_byteRate = BitConverter.ToUInt32( data, 8 );
            m_blockAlign = BitConverter.ToUInt16( data, 12 );
            m_bitsPerSample = BitConverter.ToUInt16( data, 14 );

            if ( 16 < size )
            {
                m_extraDataSize = BitConverter.ToUInt16( data, 16 );
            }
        }

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
            get { return m_ID; }
            set { }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName( "Size" )]
        public UInt32 Size
        {
            get { return m_size; }
            set { }
        }

        [CategoryAttribute(m_chunkName)]
        [DisplayName("Audio Format")]
        public string AudioFormat
        {
            get
            {
                string result = "uknown format: " + m_format;
                if (Enum.IsDefined(typeof(AudioFormats.Format), m_format))
                {
                    result = AudioFormats.GetDescription((AudioFormats.Format)(m_format));
                }
                return result;
            }
            set { }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName( "Channels" )]
        public UInt16 Channels
        {
            get { return m_channels; }
            set { }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName( "Sample Rate" )]
        public UInt32 SamplingRate
        {
            get { return m_sampleRate; }
            set { }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName( "Byte Rate" )]
        public UInt32 ByteRate
        {
            get { return m_byteRate; }
            set { }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName( "Block Alignmment" )]
        public UInt16 Alignment
        {
            get { return m_blockAlign; }
            set { }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName( "Bits Per Sample" )]
        public UInt16 BitsPerSample
        {
            get { return m_bitsPerSample; }
            set { }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName( "Extra Data Size" )]
        public UInt16 ExtraDataSize
        {
            get { return m_extraDataSize; }
            set { }
        }
    }
}
