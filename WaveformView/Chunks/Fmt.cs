using System;
using System.ComponentModel;

namespace WaveformView
{
    public class Fmt : Chunk
    {
        const string m_chunkName = "fmt ";
        
        // Contains the letters "fmt " (0x666d7420 big-endian form).
        readonly Char [] m_ID = { 'f', 'm', 't', ' ' };
        // 16 for PCM.  This is the size of the rest of the Subchunk which follows this number.
        readonly Int32 m_size;
        // PCM = 1 (i.e. Linear quantization) Values other than 1 indicate some form of compression.
        readonly Int16 m_format;
        // Mono = 1, Stereo = 2, etc.
        readonly Int16 m_channels;
        // 8000, 44100, etc.
        readonly Int32 m_sampleRate;
        // == SampleRate * NumChannels * BitsPerSample/8
        readonly Int32 m_byteRate;
        // == NumChannels * BitsPerSample/8 The number of bytes for one sample including
        //  all channels. I wonder what happens when this number isn't an integer?
        readonly Int16 m_blockAlign;
        // 8 bits = 8, 16 bits = 16, etc.
        readonly Int16 m_bitsPerSample;

        public Fmt( Int32 size, Int16 format, Int16 channels, Int32 rate, Int32 byteRate, Int16 alignment, Int16 bps )
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
        public Char [] ID
        {
            set { }
            get { return m_ID; }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName("Size")]
        public Int32 Size
        {
            set { }
            get { return m_size; }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName("Audio Format")]
        public Int16 Format
        {
            set { }
            get { return m_format; }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName("Channels")]
        public Int16 Channels
        {
            set { }
            get { return m_channels; }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName("Sample Rate")]
        public Int32 SamplingRate
        {
            set { }
            get { return m_sampleRate; }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName("Byte Rate")]
        public Int32 ByteRate
        {
            set { }
            get { return m_byteRate; }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName("Block Alignmment")]
        public Int16 Alignment
        {
            set { }
            get { return m_blockAlign; }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName("Beats Per Second")]
        public Int16 BeatsPerSecond
        {
            set { }
            get { return m_bitsPerSample; }
        }
    }
}
