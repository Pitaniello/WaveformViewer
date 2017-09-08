using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveformView.Chunks
{
    class BroadcastExtension
    {
                            /*
                        https://tech.ebu.ch/docs/tech/tech3285.pdf

                        CHAR Description[256]; // get str until null
                        CHAR Originator[32]; // get str until null
                        CHAR OriginatorReference[32]; // get str until null
                        CHAR OriginationDate[10]; // formatted
                        CHAR OriginationTime[8]; // formatted
                        DWORD TimeReferenceLow; // read 2 bytes
                        DWORD TimeReferenceHigh; // read 2 bytes
                        WORD Version; // read 4bytes
                        BYTE UMID_0; // read 64 bytes
                        BYTE UMID_63;
                        WORD LoudnessValue; // read 2 bytes
                        WORD LoudnessRange; // read 2 bytes
                        WORD MaxTruePeakLevel; // read 2 bytes
                        WORD MaxMomentaryLoudness; // read 2 bytes
                        WORD MaxShortTermLoudness; // read 2 bytes
                        BYTE Reserved[180]; // skip 180 char
                        CHAR CodingHistory[]; // read until null
                    */
    }
}
