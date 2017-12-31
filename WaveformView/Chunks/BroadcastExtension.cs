using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;

namespace WaveformView.Chunks
{
    class BroadcastExtension : Chunk
    {
        // https://tech.ebu.ch/docs/tech/tech3285.pdf
        const string m_chunkName = "Broadcast Extension Chunk";
        const string m_ID = "bext";
        
        readonly UInt32 m_size;

        readonly string m_description;
        readonly string m_originator;
        readonly string m_originatorReference;
        readonly string m_originationDate;
        readonly string m_originationTime;

        readonly UInt32 m_timeReferenceLow;
        readonly UInt32 m_timeReferenceHigh;

        readonly UInt16 m_version;

        readonly string m_umid;

        readonly UInt16 m_loudnessValue;
        readonly UInt16 m_loudnessRange;

        readonly UInt16 m_maxTruePeakLevel;
        readonly UInt16 m_maxMomentaryLoudness;
        readonly UInt16 m_maxShortTermLouadness;

        readonly string m_reserved;

        readonly string m_codingHistory;


        public BroadcastExtension( UInt32 size, Byte [] data )
        {
            m_size = size;

            int pos = 0;

            m_description = Encoding.ASCII.GetString( data, pos, 256 );
            pos += 256;
            m_originator = Encoding.ASCII.GetString( data, pos, 32 );
            pos += 32;
            m_originatorReference = Encoding.ASCII.GetString( data, pos, 32 );
            pos += 32;
            m_originationDate = Encoding.ASCII.GetString( data, pos, 10 );
            pos += 10;
            m_originationTime = Encoding.ASCII.GetString( data, pos, 8 );
            pos += 8;


            m_timeReferenceLow = BitConverter.ToUInt32( data, pos );
            pos += 4;
            m_timeReferenceHigh = BitConverter.ToUInt32( data, pos );
            pos += 4;

            m_version = BitConverter.ToUInt16( data, pos );
            pos += 2;
            
            m_umid = Encoding.ASCII.GetString( data, pos, 64 );
            pos += 64;

            m_loudnessValue = BitConverter.ToUInt16( data, pos );
            pos += 2;
            m_loudnessRange = BitConverter.ToUInt16( data, pos );
            pos += 2;

            m_maxTruePeakLevel = BitConverter.ToUInt16( data, pos );
            pos += 2;
            m_maxMomentaryLoudness = BitConverter.ToUInt16( data, pos );
            pos += 2;
            m_maxShortTermLouadness = BitConverter.ToUInt16( data, pos );
            pos += 2;

            m_reserved = Encoding.ASCII.GetString( data, pos, 180 );
            pos += 180;

            m_codingHistory = Encoding.ASCII.GetString( data, pos, (int)(size - pos) );
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
        [DisplayName( "Description" )]
        public string Description
        {
            get { return m_description; }
            set { }
        }
        [CategoryAttribute( m_chunkName )]
        [DisplayName( "Originator" )]
        public string Originator
        {
            get { return m_originator; }
            set { }
        }
        [CategoryAttribute( m_chunkName )]
        [DisplayName( "Originator Reference" )]
        public string OriginatorReference
        {
            get { return m_originatorReference; }
            set { }
        }
        [CategoryAttribute( m_chunkName )]
        [DisplayName( "Origination Date" )]
        public string OriginationDate
        {
            get { return m_originationDate; }
            set { }
        }
        [CategoryAttribute( m_chunkName )]
        [DisplayName( "Origination Time" )]
        public string OriginationTime
        {
            get { return m_originationTime; }
            set { }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName( "Time Reference Low" )]
        public UInt32 TimeReferenceLow
        {
            get { return m_timeReferenceLow; }
            set { }
        }
        [CategoryAttribute( m_chunkName )]
        [DisplayName( "Time Reference High" )]
        public UInt32 TimeReferenceHigh
        {
            get { return m_timeReferenceHigh; }
            set { }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName( "Version" )]
        public UInt16 Version
        {
            get { return m_version; }
            set { }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName( "UMID" )]
        public string UMID
        {
            get { return m_umid; }
            set { }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName( "Loudness Value" )]
        public UInt16 LoudnessValue
        {
            get { return m_loudnessValue; }
            set { }
        }
        [CategoryAttribute( m_chunkName )]
        [DisplayName( "Loudness Range" )]
        public UInt16 LoudnessRange
        {
            get { return m_loudnessRange; }
            set { }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName( "Max True Peak Level" )]
        public UInt16 MaxTruePeakLevel
        {
            get { return m_maxTruePeakLevel; }
            set { }
        }
        [CategoryAttribute( m_chunkName )]
        [DisplayName( "Max Momentary Loudness" )]
        public UInt16 MaxMomentaryLoudness
        {
            get { return m_maxMomentaryLoudness; }
            set { }
        }
        [CategoryAttribute( m_chunkName )]
        [DisplayName( "Max Short Term Louadness" )]
        public UInt16 MaxShortTermLouadness
        {
            get { return m_maxShortTermLouadness; }
            set { }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName( "Reserved" )]
        public string Reserved
        {
            get { return m_reserved; }
            set { }
        }

        [CategoryAttribute( m_chunkName )]
        [DisplayName( "Coding History" )]
        public string CodingHistory
        {
            get { return m_codingHistory; }
            set { }
        }
    }
}
