using System;
using System.ComponentModel;

namespace WaveformView.Chunks
{
    class Format : Chunk
    {
        const string m_chunkName = "Format Chunk";
        
        // Contains the letters "fmt " (0x666d7420 big-endian form).
        readonly string m_ID = "fmt ";
        // 16 for PCM.  This is the size of the rest of the Subchunk which follows this number.
        readonly UInt32 m_size;
        // PCM = 1 (i.e. Linear quantization) Values other than 1 indicate some form of compression.
        readonly UInt16 m_format;
        // Mono = 1, Stereo = 2, etc.
        readonly UInt16 m_channels;
        // 8000, 44100, etc.
        readonly UInt32 m_sampleRate;
        // == SampleRate * NumChannels * BitsPerSample/8
        readonly UInt32 m_byteRate;
        // == NumChannels * BitsPerSample/8 The number of bytes for one sample including
        //  all channels. I wonder what happens when this number isn't an integer?
        readonly UInt16 m_blockAlign;
        // 8 bits = 8, 16 bits = 16, etc.
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

        [CategoryAttribute( m_chunkName )]
        [DisplayName("ID")]
        public string ID
        {
            set { }
            get { return m_ID; }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName("Size")]
        public UInt32 Size
        {
            set { }
            get { return m_size; }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName("Audio Format")]
        public UInt16 AudioFormat
        {
            set { }
            get { return m_format; }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName("Channels")]
        public UInt16 Channels
        {
            set { }
            get { return m_channels; }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName("Sample Rate")]
        public UInt32 SamplingRate
        {
            set { }
            get { return m_sampleRate; }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName("Byte Rate")]
        public UInt32 ByteRate
        {
            set { }
            get { return m_byteRate; }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName("Block Alignmment")]
        public UInt16 Alignment
        {
            set { }
            get { return m_blockAlign; }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName("Bits Per Sample")]
        public UInt16 BitsPerSample
        {
            set { }
            get { return m_bitsPerSample; }
        }
    }
}
