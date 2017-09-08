using System;
using System.Text;
using System.ComponentModel;
using System.Collections;
using System.Globalization;

namespace WaveformView.Chunks
{
    [TypeConverter(typeof( CueDataConverter ) )]
    public class CueData
    {
        readonly UInt32 m_cuePointID;
        readonly UInt32 m_playOrderPosition;
        readonly string m_dataChunkID;
        readonly UInt32 m_chunkStart;
        readonly UInt32 m_blockStart;
        readonly UInt32 m_frameOffset;

        public CueData( Byte [] data )
        {
            m_cuePointID = BitConverter.ToUInt32( data, 0 );
            m_playOrderPosition = BitConverter.ToUInt32( data, 4 );
            m_dataChunkID = Encoding.ASCII.GetString( data, 8, 4 );
            m_chunkStart = BitConverter.ToUInt32( data, 12 );
            m_blockStart = BitConverter.ToUInt32( data, 16 );
            m_frameOffset = BitConverter.ToUInt32( data,+ 20 );
        }
        
        [Browsable(false)]
        public UInt32 CuePointID
        {
            get { return m_cuePointID; }
            set { }
        }

        [DisplayName( "Play Order Position" )]
        public UInt32 PlayOrderPosition
        {
            get { return m_playOrderPosition; }
            set { }
        }

        [DisplayName( "Data Chunk ID" )]
        public string DataChunkID
        {
            get { return m_dataChunkID; }
            set { }
        }

        [DisplayName( "Chunk Start" )]
        public UInt32 ChunkStart
        {
            get { return m_chunkStart; }
            set { }
        }

        [DisplayName( "Block Start" )]
        public UInt32 BlockStart
        {
            get { return m_blockStart; }
            set { }
        }

        [DisplayName( "Frame Offset" )]
        public UInt32 FrameOffset
        {
            get { return m_frameOffset; }
            set { }
        }
    }

    class CueDataConverter : ExpandableObjectConverter
    {
        public override object ConvertTo( ITypeDescriptorContext contect, CultureInfo culture, object value, Type destType )
        {
            object result = null;

            if ( (destType == typeof( string )) && (value is CueData) )
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




    public class CueDataCollection : CollectionBase, ICustomTypeDescriptor
    {
        public void Add( CueData chunk )
        {
            List.Add( chunk );
        }

        public void Remove( CueData chunk )
        {
            List.Remove( chunk );
        }

        public CueData this[int index]
        {
            set { }
            get { return ( CueData )( List[index] ); }
        }

        public String GetClassName()
        {
            return TypeDescriptor.GetClassName( this, true );
        }

        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes( this, true );
        }

        public String GetComponentName()
        {
            return TypeDescriptor.GetComponentName( this, true );
        }

        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter( this, true );
        }

        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent( this, true );
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty( this, true );
        }

        public object GetEditor( Type editorBaseType )
        {
            return TypeDescriptor.GetEditor( this, editorBaseType, true );
        }

        public EventDescriptorCollection GetEvents( Attribute[] attributes )
        {
            return TypeDescriptor.GetEvents( this, attributes, true );
        }

        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents( this, true );
        }

        public object GetPropertyOwner( PropertyDescriptor pd )
        {
            return this;
        }

        public PropertyDescriptorCollection GetProperties( Attribute [] attributes )
        {
            return GetProperties();
        }

        public PropertyDescriptorCollection GetProperties()
        {
            PropertyDescriptorCollection pds = new PropertyDescriptorCollection( null );

            for ( int chunkIdx = 0; chunkIdx < this.List.Count; chunkIdx++ )
            {
                CueDataCollectionPropertyDescriptor pdc = new CueDataCollectionPropertyDescriptor( this, chunkIdx );
                pds.Add( pdc );
            }

            return pds;
        }
    }

    public class CueDataCollectionPropertyDescriptor : PropertyDescriptor
    {
        CueDataCollection m_collection;

        int m_index = -1;

        public CueDataCollectionPropertyDescriptor( CueDataCollection cds, int chunkIdx ) : 
            base ( "#" + chunkIdx, null )
        {
            m_collection = cds;
            m_index = chunkIdx;
        }

        public override AttributeCollection Attributes
        {
            get { return new AttributeCollection( null ); }
        }

        public override bool CanResetValue( object component )
        {
            return true;
        }

        public override Type ComponentType
        {
            get { return m_collection.GetType(); }
        }

        public override string DisplayName
        {
            get { return m_collection[m_index].CuePointID.ToString(); }
        }

        public override object GetValue( object component )
        {
            return m_collection[m_index];
        }

        public override bool IsReadOnly
        {
            get { return true;  }
        }

        public override string Name
        {
            get { return m_collection[m_index].CuePointID.ToString(); }
        }

        public override Type PropertyType
        {
            get { return m_collection[m_index].GetType(); }
        }

        public override void ResetValue( object component )
        {
        }

        public override bool ShouldSerializeValue( object component )
        {
            return true;
        }

        public override void SetValue( object component, object value )
        {

        }
    }

    class CueDataCollectionConverter : ExpandableObjectConverter
    {
        public override object ConvertTo( ITypeDescriptorContext contect, CultureInfo culture, object value, Type destType )
        {
            object result = null;

            if ( (destType == typeof( string )) && (value is CueDataCollection) )
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
