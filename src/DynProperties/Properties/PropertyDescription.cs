using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;


namespace DynRenga.DynProperties.Properties
{
    public class PropertyDescription
    {
        //Для IPropertyDescription
        public Renga.IPropertyDescription prop_descr;
        
        public PropertyDescription (object PropertyDescription_obj)
        {
            this.prop_descr = PropertyDescription_obj as Renga.IPropertyDescription;
        }
        public string Name ()
        {
            return this.prop_descr.Name;
        }
        public object Type()
        {
            return this.prop_descr.Type;
        }
        public void SetEnumerationItems(List<string> enums)
        {
            if (this.prop_descr.Type == Renga.PropertyType.PropertyType_Enumeration) 
                this.prop_descr.SetEnumerationItems(enums.ToArray());
        }
        public List<string> GetEnumerationItems()
        {
            if (this.prop_descr.Type == Renga.PropertyType.PropertyType_Enumeration)
                return this.prop_descr.GetEnumerationItems().OfType<string>().ToList();
            else return null;
        }
        //Для PropertyDescription
        public Renga.PropertyDescription prop_descr_new;
        public PropertyDescription(string name, object prop_type)
        {
            this.prop_descr_new = new Renga.PropertyDescription();
            this.prop_descr_new.Name = name;
            this.prop_descr_new.Type = (Renga.PropertyType)prop_type;
        }
        public PropertyDescription(object PropertyDescription_obj, bool NewProp = true)
        {
            this.prop_descr_new = (Renga.PropertyDescription)PropertyDescription_obj;
        }
    }
}
