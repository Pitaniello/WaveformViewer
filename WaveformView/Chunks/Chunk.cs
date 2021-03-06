﻿using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;

namespace WaveformView.Chunks
{
    [TypeConverter(typeof( ChunkConverter ) )]
    public abstract class Chunk
    {
        public Chunk()
        {
        }

        [Browsable( false )]
        public abstract string Name
        {
            get;
            set;
        }
    }

    class ChunkConverter : ExpandableObjectConverter
    {
        public override object ConvertTo( ITypeDescriptorContext contect, CultureInfo culture, object value, Type destType )
        {
            object result = null;

            if ( (destType == typeof( string )) && (value is Chunk) )
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



    public class ChunkCollection : CollectionBase, ICustomTypeDescriptor
    {
        public void Add( Chunk chunk )
        {
            List.Add( chunk );
        }

        public void Remove( Chunk chunk )
        {
            List.Remove( chunk );
        }

        public Chunk this[int index]
        {
            set { }
            get { return ( Chunk )( List[index] ); }
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
                ChunkCollectionPropertyDescriptor pdc = new ChunkCollectionPropertyDescriptor( this, chunkIdx );
                pds.Add( pdc );
            }

            return pds;
        }
    }

    public class ChunkCollectionPropertyDescriptor : PropertyDescriptor
    {
        ChunkCollection m_collection;

        int m_index = -1;

        public ChunkCollectionPropertyDescriptor( ChunkCollection cs, int chunkIdx ) : 
            base ( "#" + chunkIdx, null )
        {
            m_collection = cs;
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
            get { return m_collection[m_index].Name; }
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
            get { return m_collection[m_index].Name; }
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
