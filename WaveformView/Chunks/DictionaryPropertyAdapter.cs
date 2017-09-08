using System;
using System.ComponentModel;
using System.Collections;
using System.Globalization;

namespace WaveformView.Chunks
{
    class DictionaryPropertyAdapter : ICustomTypeDescriptor
    {
        IDictionary m_dictionary;
        
        public DictionaryPropertyAdapter( IDictionary d )
        {
            m_dictionary = d;
        }

        public string GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        public string GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return m_dictionary;
        }

        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            return null;
        }

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
        {
            return ((ICustomTypeDescriptor)this).GetProperties(new Attribute[0]);
        }

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            ArrayList properties = new ArrayList();
            foreach (DictionaryEntry e in m_dictionary)
            {
                properties.Add(new DictionaryPropertyDescriptor(m_dictionary, e.Key));
            }

            PropertyDescriptor[] props = (PropertyDescriptor[])properties.ToArray(typeof(PropertyDescriptor));

            return new PropertyDescriptorCollection(props);
        }
    }

    class DictionaryPropertyDescriptor : PropertyDescriptor
    {
        IDictionary m_dictionary;
        object m_key;

        internal DictionaryPropertyDescriptor(IDictionary d, object key) 
            : base(key.ToString(), null)
        {
            m_dictionary = d;
            m_key = key;
        }

        public override Type PropertyType
        {
            get { return m_dictionary[m_key].GetType(); }
        }

        public override void SetValue(object component, object value)
        {
            m_dictionary[m_key] = value;
        }

        public override object GetValue(object component)
        {
            return m_dictionary[m_key];
        }

        public override bool IsReadOnly
        {
            get { return false; }
        }

        public override Type ComponentType
        {
            get { return null; }
        }

        public override bool CanResetValue(object component)
        {
            return false;
        }

        public override void ResetValue(object component)
        {
        }

        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
    }

    class DictionaryConverter : ExpandableObjectConverter
    {
        public override object ConvertTo( ITypeDescriptorContext contect, CultureInfo culture, object value, Type destType )
        {
            object result = null;

            if ( (destType == typeof( string )) && (value is DictionaryPropertyAdapter) )
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
