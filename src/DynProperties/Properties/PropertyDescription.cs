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
    /// <summary>
    /// Класс для работы с интерфейсом Renga.IPropertyDescription и классом Renga.PropertyDescription
    /// </summary>
    public class PropertyDescription
    {
        //Для IPropertyDescription
        public Renga.IPropertyDescription _i;
        /// <summary>
        /// Инициализация интерфейса Renga.IPropertyDescription из com-объекта
        /// </summary>
        /// <param name="PropertyDescription_obj"></param>

        internal PropertyDescription (object PropertyDescription_obj)
        {
            this._i = PropertyDescription_obj as Renga.IPropertyDescription;
        }
        internal PropertyDescription (Renga.IPropertyDescription IPropertyDescription)
        {
            this._i = IPropertyDescription;
        }
        /// <summary>
        /// Получение наименования определения свойства
        /// </summary>
        /// <returns></returns>
        public string Name  => this._i.Name;
        /// <summary>
        /// Получение типа определения свойства
        /// </summary>
        /// <returns></returns>
        public object Type => this._i.Type;
        /// <summary>
        /// Присвоение определению свойства перечня значений 
        /// (только для свойства с типом Enumeration)
        /// </summary>
        /// <param name="enums"></param>
        public void SetEnumerationItems(List<string> enums)
        {
            if (this._i.Type == Renga.PropertyType.PropertyType_Enumeration) 
                this._i.SetEnumerationItems(enums.ToArray());
        }
        /// <summary>
        /// Получение из определения свойства перечня значений 
        /// (только для свойства с типом Enumeration)
        /// </summary>
        /// <returns></returns>
        public List<string> GetEnumerationItems()
        {
            if (this._i.Type == Renga.PropertyType.PropertyType_Enumeration)
                return this._i.GetEnumerationItems().OfType<string>().ToList();
            else return null;
        }
        //Для PropertyDescription
        //public Renga.PropertyDescription prop_descr_new;
        ///// <summary>
        ///// Создание класса Renga.PropertyDescription (нового определения свойства)
        ///// </summary>
        ///// <param name="name">Строковое наименование свойства</param>
        ///// <param name="prop_type">Тип параметра нового свойства, используйте нод Property.PropertyTypes</param>
        //public PropertyDescription(string name, object prop_type)
        //{
        //    this.prop_descr_new = new Renga.PropertyDescription();
        //    this.prop_descr_new.Name = name;
        //    this.prop_descr_new.Type = (Renga.PropertyType)prop_type;
        //}

        //[dr.IsVisibleInDynamoLibrary(false)] //Зачем он нужен?
        //internal PropertyDescription(object PropertyDescription_obj, bool PropFromManager = true)
        //{
        //    this.prop_descr_new = (Renga.PropertyDescription)PropertyDescription_obj;
        //}
    }
}
