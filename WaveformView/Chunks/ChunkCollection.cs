using System;
using System.Collections;
using System.ComponentModel;

namespace WaveformView.Chunks
{
    public class ChunkCollection : CollectionBase, ICustomTypeDescriptor
    {
        public void Add( Chunk chunk )
        {
            this.List.Add( chunk );
        }

        public void Remove( Chunk chunk )
        {
            this.List.Remove( chunk );
        }

        public Chunk this[int index]
        {
            set { }
            get { return ( Chunk )( this.List[index] ); }
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
                ChunkPropertyDescriptor pdc = new ChunkPropertyDescriptor( this, chunkIdx );
                pds.Add( pdc );
            }

            return pds;
        }
    }
}
