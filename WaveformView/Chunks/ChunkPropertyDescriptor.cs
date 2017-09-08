using System;
using System.ComponentModel;

namespace WaveformView.Chunks
{
    public class ChunkPropertyDescriptor : PropertyDescriptor
    {
        ChunkCollection m_collection;

        int m_index = -1;

        public ChunkPropertyDescriptor( ChunkCollection cs, int chunkIdx ) : 
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
}
