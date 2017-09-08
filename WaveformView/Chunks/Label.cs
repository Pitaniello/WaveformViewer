using System;
using System.ComponentModel;

namespace WaveformView.Chunks
{
    // An entry in an array containing an a label or name which is associated with the cue points from the "cue " tag in order to provide names for the markers.
    class Label : Chunk
    {
        const string m_chunkName = "Label";
        public override string Name
        {
            get { return m_chunkName; }
            set { }
        }
    }
}
