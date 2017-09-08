using System;
using System.ComponentModel;
using System.Globalization;

namespace WaveformView.Chunks
{
    class ChunkCollectionConverter : ExpandableObjectConverter
    {
        public override object ConvertTo( ITypeDescriptorContext contect, CultureInfo culture, object value, Type destType )
        {
            object result = null;

            if ( (destType == typeof( string )) && (value is ChunkCollection) )
            {
                result = "";
            }
            else
            {
                result = base.ConvertTo( contect, culture, value, destType );
            }

            return result;
        }
    }
}
