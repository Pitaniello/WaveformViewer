using System;
using System.ComponentModel;
using System.Reflection;

namespace WaveformView
{
    public static class AudioFormats
    {
        
    // a more complete list can be found in the windows header file mmreg.h
        public enum Format
        {
            [Description("Unkown Microsoft Format")]
            WAVE_FORMAT_UNKNOWN                 = 0x0000,

            [Description("Microsft ADPCM")]
            WAVE_FORMAT_ADPCM                   = 0x0002,

            [Description("Microsoft IEEE Float")]
            WAVE_FORMAT_IEEE_FLOAT              = 0x0003,

            [Description("Compaq Computer Corp. VSELP")]
            WAVE_FORMAT_VSELP                   = 0x0004,

            [Description("IBM Corporation CVSD")]
            WAVE_FORMAT_IBM_CVSD                = 0x0005,

            [Description("Microsoft ALAW")]
            WAVE_FORMAT_ALAW                    = 0x0006,

            [Description("Microsoft MULAW")] 
            WAVE_FORMAT_MULAW                   = 0x0007,

            [Description("Microsoft DTS")]
            WAVE_FORMAT_DTS                     = 0x0008,

            [Description("OKI ADPCM")]
            WAVE_FORMAT_OKI_ADPCM               = 0x0010,

            [Description("Intel Corporation DVI ADPCM")]
            WAVE_FORMAT_DVI_ADPCM               = 0x0011,

            [Description("Intel Corporation IMA ADPCM")]
            WAVE_FORMAT_IMA_ADPCM               = (WAVE_FORMAT_DVI_ADPCM),

            [Description("Videologic Mediaspace ADPCM")]
            WAVE_FORMAT_MEDIASPACE_ADPCM        = 0x0012,

            [Description("Sierra Semiconductor Corp. ADPCM")]
            WAVE_FORMAT_SIERRA_ADPCM            = 0x0013,

            [Description("Antex Electronics Corporation G723 ADPCM")]
            WAVE_FORMAT_G723_ADPCM              = 0x0014,

            [Description("DSP Solutions, Inc. DigiSTD")]
            WAVE_FORMAT_DIGISTD                 = 0x0015,

            [Description("DSP Solutions, Inc. DigiFIX")]
            WAVE_FORMAT_DIGIFIX                 = 0x0016,

            [Description("Dialogic Corporation OKI ADPCM")]
            WAVE_FORMAT_DIALOGIC_OKI_ADPCM      = 0x0017,

            [Description("Media Vision, Inc. ADPCM")]
            WAVE_FORMAT_MEDIAVISION_ADPCM       = 0x0018,

            [Description("Hewlett-Packard Company CU Codec")]
            WAVE_FORMAT_CU_CODEC                = 0x0019,

            [Description("Yamaha Corporation of America ADPCM")]
            WAVE_FORMAT_YAMAHA_ADPCM            = 0x0020,

            [Description("Speech Compression SONARC")]
            WAVE_FORMAT_SONARC                  = 0x0021,

            [Description("DSP Group, Inc. TrueSpeech")]
            WAVE_FORMAT_DSPGROUP_TRUESPEECH     = 0x0022,

            [Description("Echo Speech Corporation EchoSC1")]
            WAVE_FORMAT_ECHOSC1                 = 0x0023,

            [Description("Virtual Music, Inc. AF36")]
            WAVE_FORMAT_AUDIOFILE_AF36          = 0x0024,

            [Description("Audio Processing Technology APTX")]
            WAVE_FORMAT_APTX                    = 0x0025,

            [Description("Virtual Music, Inc. Audifile AF10")]
            WAVE_FORMAT_AUDIOFILE_AF10          = 0x0026,

            [Description("Aculab plc Prosody 1612")]
            WAVE_FORMAT_PROSODY_1612            = 0x0027,

            [Description("Merging Technologies S.A. LRC")]
            WAVE_FORMAT_LRC                     = 0x0028,

            [Description("Dolby Laboratories AC2")]
            WAVE_FORMAT_DOLBY_AC2               = 0x0030,

            [Description("Microsoft GSM610")]
            WAVE_FORMAT_GSM610                  = 0x0031,
   
            [Description("Microsoft MSNAudio")]
            WAVE_FORMAT_MSNAUDIO                = 0x0032,

            [Description("Antex Electronics Corporation ADPCME")]
            WAVE_FORMAT_ANTEX_ADPCME            = 0x0033,

            [Description("Control Resources Limited VQLPC")]
            WAVE_FORMAT_CONTROL_RES_VQLPC       = 0x0034,

            [Description("DSP Solutions, Inc. DigiReal")]
            WAVE_FORMAT_DIGIREAL                = 0x0035,

            [Description("DSP Solutions, Inc. DigiADPCM")]
            WAVE_FORMAT_DIGIADPCM               = 0x0036,

            [Description("Control Resources Limited CR10")]
            WAVE_FORMAT_CONTROL_RES_CR10        = 0x0037,

            [Description("Natural MicroSystems VBXADPCM")]
            WAVE_FORMAT_NMS_VBXADPCM            = 0x0038,

            [Description("Crystal Semiconductor IMAADPCM")]
            WAVE_FORMAT_CS_IMAADPCM             = 0x0039,

            [Description("Echo Speech Corporation SC3")]
            WAVE_FORMAT_ECHOSC3                 = 0x003A,

            [Description("Rockwell International ADPCM")]
            WAVE_FORMAT_ROCKWELL_ADPCM          = 0x003B,

            [Description("Rockwell International DigiTalk")]
            WAVE_FORMAT_ROCKWELL_DIGITALK       = 0x003C,

            [Description("Xebec Multimedia Solutions Limited")]
            WAVE_FORMAT_XEBEC                   = 0x003D,

            [Description("Antex Electronics Corporation G721 ADPCM")]
            WAVE_FORMAT_G721_ADPCM              = 0x0040,

            [Description("Antex Electronics Corporation G728 CELP")]
            WAVE_FORMAT_G728_CELP               = 0x0041,

            [Description("Microsoft MSG723")]
            WAVE_FORMAT_MSG723                  = 0x0042,

            [Description("Microsoft MPEG")]
            WAVE_FORMAT_MPEG                    = 0x0050,

            [Description("InSoft, Inc. RT24")]
            WAVE_FORMAT_RT24                    = 0x0052,

            [Description("InSoft, Inc. PAC")]
            WAVE_FORMAT_PAC                     = 0x0053,

            [Description("ISO/MPEG Layer3 Format Tag MPEG Layer 3")]
            WAVE_FORMAT_MPEGLAYER3              = 0x0055,

            [Description("Lucent Technologies G723")]
            WAVE_FORMAT_LUCENT_G723             = 0x0059,

            [Description("Cirrus Logic Format")]
            WAVE_FORMAT_CIRRUS                  = 0x0060,

            [Description("ESS Technology ESPCM")]
            WAVE_FORMAT_ESPCM                   = 0x0061,

            [Description("Voxware Inc. Format")]
            WAVE_FORMAT_VOXWARE                 = 0x0062,

            [Description("Canopus, co., Ltd. ATRAC")]
            WAVE_FORMAT_CANOPUS_ATRAC           = 0x0063,

            [Description("APICOM G726 ADPCM")]
            WAVE_FORMAT_G726_ADPCM              = 0x0064,

            [Description("APICOM G722 ADPCM")]
            WAVE_FORMAT_G722_ADPCM              = 0x0065,

            [Description("Microsoft DSAT Display")]
            WAVE_FORMAT_DSAT_DISPLAY            = 0x0067,

            [Description("Voxware Inc. Byte Aligned")]
            WAVE_FORMAT_VOXWARE_BYTE_ALIGNED    = 0x0069,

            [Description("Voxware Inc. AC8")]
            WAVE_FORMAT_VOXWARE_AC8             = 0x0070,

            [Description("Voxware Inc. AC10")]
            WAVE_FORMAT_VOXWARE_AC10            = 0x0071,

            [Description("Voxware Inc. AC16")]
            WAVE_FORMAT_VOXWARE_AC16            = 0x0072,

            [Description("Voxware Inc. AC20")]
            WAVE_FORMAT_VOXWARE_AC20            = 0x0073,

            [Description("Voxware Inc. RT24")]
            WAVE_FORMAT_VOXWARE_RT24            = 0x0074,

            [Description("Voxware Inc. RT29")]
            WAVE_FORMAT_VOXWARE_RT29            = 0x0075,

            [Description("Voxware Inc. Rt29HW")]
            WAVE_FORMAT_VOXWARE_RT29HW          = 0x0076,

            [Description("Voxware Inc. VR12")]
            WAVE_FORMAT_VOXWARE_VR12            = 0x0077,

            [Description("Voxware Inc. VR18")]
            WAVE_FORMAT_VOXWARE_VR18            = 0x0078,

            [Description("Voxware Inc. TQ40")]
            WAVE_FORMAT_VOXWARE_TQ40            = 0x0079,

            [Description("Softsound, Ltd.")]
            WAVE_FORMAT_SOFTSOUND               = 0x0080,

            [Description("Voxware Inc. TQ60")]
            WAVE_FORMAT_VOXWARE_TQ60            = 0x0081,

            [Description("Microsoft MSRT24")]
            WAVE_FORMAT_MSRT24                  = 0x0082,

            [Description("AT&T Labs, Inc. G729A")]
            WAVE_FORMAT_G729A                   = 0x0083,

            [Description("Motion Pixels MVI MVI2")]
            WAVE_FORMAT_MVI_MVI2                = 0x0084,

            [Description("DataFusion Systems (Pty) (Ltd) G726")]
            WAVE_FORMAT_DF_G726                 = 0x0085,

            [Description("DataFusion Systems (Pty) (Ltd) GSM610")]
            WAVE_FORMAT_DF_GSM610               = 0x0086,

            [Description("Iterated Systems, Inc. Audio")]
            WAVE_FORMAT_ISIAUDIO                = 0x0088,

            [Description("OnLive! Technologies, Inc. Format")]
            WAVE_FORMAT_ONLIVE                  = 0x0089,

            [Description("Siemens Business Communications Sys SBC24")]
            WAVE_FORMAT_SBC24                   = 0x0091,

            [Description("Sonic Foundry AC3 SPDIF")]
            WAVE_FORMAT_DOLBY_AC3_SPDIF         = 0x0092,

            [Description("MediaSonic G723")]
            WAVE_FORMAT_MEDIASONIC_G723         = 0x0093,

            [Description("Aculab plc Prosody 8KBPS")]
            WAVE_FORMAT_PROSODY_8KBPS           = 0x0094,

            [Description("ZyXEL Communications, Inc. ADPCM")]
            WAVE_FORMAT_ZYXEL_ADPCM             = 0x0097,

            [Description("Philips Speech Processing LPCBB")]
            WAVE_FORMAT_PHILIPS_LPCBB           = 0x0098,

            [Description("Studer Professional Audio AG Packed")]
            WAVE_FORMAT_PACKED                  = 0x0099,

            [Description("Malden Electronics Ltd. PhonyTalk")]
            WAVE_FORMAT_MALDEN_PHONYTALK        = 0x00A0,

            [Description("Rhetorex Inc. ADPCM")]
            WAVE_FORMAT_RHETOREX_ADPCM          = 0x0100,

            [Description("BeCubed Software Inc. IRAT")]
            WAVE_FORMAT_IRAT                    = 0x0101,

            [Description("Vivo Software G723")]
            WAVE_FORMAT_VIVO_G723               = 0x0111,

            [Description("Vivo Software Siren")]
            WAVE_FORMAT_VIVO_SIREN              = 0x0112,

            [Description("Digital Equipment Corporation G723")]
            WAVE_FORMAT_DIGITAL_G723            = 0x0123,

            [Description("Sanyo Electric Co., Ltd. LD ADPCM")]
            WAVE_FORMAT_SANYO_LD_ADPCM          = 0x0125,

            [Description("Sipro Lab Telecom Inc. ACEPLNET")]
            WAVE_FORMAT_SIPROLAB_ACEPLNET       = 0x0130,

            [Description("Sipro Lab Telecom Inc. ACELP4800")]
            WAVE_FORMAT_SIPROLAB_ACELP4800      = 0x0131,

            [Description("Sipro Lab Telecom Inc. ACELP8V3")]
            WAVE_FORMAT_SIPROLAB_ACELP8V3       = 0x0132,

            [Description("Sipro Lab Telecom Inc. G729")]
            WAVE_FORMAT_SIPROLAB_G729           = 0x0133,

            [Description("Sipro Lab Telecom Inc. G729A")]
            WAVE_FORMAT_SIPROLAB_G729A          = 0x0134,

            [Description("Sipro Lab Telecom Inc. Kelvin")]
            WAVE_FORMAT_SIPROLAB_KELVIN         = 0x0135,

            [Description("Dictaphone Corporation G726ADPCM")]
            WAVE_FORMAT_G726ADPCM               = 0x0140,

            [Description("Qualcomm, Inc. PureVoice")]
            WAVE_FORMAT_QUALCOMM_PUREVOICE      = 0x0150,

            [Description("Qualcomm, Inc. HalfRate")]
            WAVE_FORMAT_QUALCOMM_HALFRATE       = 0x0151,

            [Description("Ring Zero Systems, Inc. TUBGSM")]
            WAVE_FORMAT_TUBGSM                  = 0x0155,

            [Description("Microsoft MSAudio1")]
            WAVE_FORMAT_MSAUDIO1                = 0x0160,

            [Description("Creative Labs, Inc. ADPCM")]
            WAVE_FORMAT_CREATIVE_ADPCM          = 0x0200,

            [Description("Creative Labs, Inc. FastSpeech8")]
            WAVE_FORMAT_CREATIVE_FASTSPEECH8    = 0x0202,

            [Description("Creative Labs, Inc. FastSpeech10")]
            WAVE_FORMAT_CREATIVE_FASTSPEECH10   = 0x0203,

            [Description("UHER informatic GmbH ADPCM")]
            WAVE_FORMAT_UHER_ADPCM              = 0x0210,

            [Description("Quarterdeck Corporation QuarterDeck")]
            WAVE_FORMAT_QUARTERDECK             = 0x0220,

            [Description("I-link Worldwide VC")]
            WAVE_FORMAT_ILINK_VC                = 0x0230,

            [Description("Aureal Semiconductor Raw Sport")]
            WAVE_FORMAT_RAW_SPORT               = 0x0240,

            [Description("Interactive Products, Inc. HSX")]
            WAVE_FORMAT_IPI_HSX                 = 0x0250,

            [Description("Interactive Products, Inc. RPELP")]
            WAVE_FORMAT_IPI_RPELP               = 0x0251,

            [Description("Consistent Software CS2")]
            WAVE_FORMAT_CS2                     = 0x0260,

            [Description("Sony Corp. SCX")]
            WAVE_FORMAT_SONY_SCX                = 0x0270,

            [Description("Fujitsu Corp. Towns Sound")]
            WAVE_FORMAT_FM_TOWNS_SND            = 0x0300,

            [Description("Brooktree Corporation BTV Digital")]
            WAVE_FORMAT_BTV_DIGITAL             = 0x0400,

            [Description("QDesign Corporation Music")]
            WAVE_FORMAT_QDESIGN_MUSIC           = 0x0450,

            [Description("AT&T Labs, Inc. VME VMPCM")]
            WAVE_FORMAT_VME_VMPCM               = 0x0680,

            [Description("AT&T Labs, Inc. TPC")]
            WAVE_FORMAT_TPC                     = 0x0681,

            [Description("Ing C. Olivetti & C., S.p.A. OLIGSM")]
            WAVE_FORMAT_OLIGSM                  = 0x1000,

            [Description("Ing C. Olivetti & C., S.p.A. OLIADPCM")]
            WAVE_FORMAT_OLIADPCM                = 0x1001,

            [Description("Ing C. Olivetti & C., S.p.A. OLICELP")]
            WAVE_FORMAT_OLICELP                 = 0x1002,

            [Description("Ing C. Olivetti & C., S.p.A. OLISBC")]
            WAVE_FORMAT_OLISBC                  = 0x1003,

            [Description("Ing C. Olivetti & C., S.p.A. OLIOPR")]
            WAVE_FORMAT_OLIOPR                  = 0x1004,

            [Description("Lernout & Hauspie codec")]
            WAVE_FORMAT_LH_CODEC                = 0x1100,

            [Description("Norris Communications, Inc. Format")]
            WAVE_FORMAT_NORRIS                  = 0x1400,

            [Description("AT&T Labs, Inc. Soundspace MusiCompress")]
            WAVE_FORMAT_SOUNDSPACE_MUSICOMPRESS = 0x1500,

            [Description("FAST Multimedia AG DVM")]
            WAVE_FORMAT_DVM                     = 0x2000,

            [Description("flac.sourceforge.net FLAC")]
            WAVE_FORMAT_FLAC                    = 0xF1AC,

            [Description("Microsoft Extensible Format")]
            WAVE_FORMAT_EXTENSIBLE              = 0xFFFE,

            [Description("New format, still in development")]
            WAVE_FORMAT_DEVELOPMENT             = 0xFFFF
        }

        public static string GetDescription<T>(this T enumValue) where T : struct
        {
            Type type = enumValue.GetType();

            if ( type.IsEnum == false )
            {
                throw new ArgumentException( "Enumeration value must be of Enum type", "enumValue" );
            }

            string returnVal = enumValue.ToString();

            MemberInfo[] memberInfo = type.GetMember( enumValue.ToString() );
            if ( (memberInfo != null) && (memberInfo.Length > 0) )
            {
                Attribute attribute = memberInfo[0].GetCustomAttribute( typeof( DescriptionAttribute ), false) ;
                if ( (attribute != null) )
                {
                    returnVal = ( ( DescriptionAttribute )attribute ).Description;
                }
            }

            return returnVal;
        }
    }
}
