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
    public class PropertyDescription : Other.Technical.ICOM_Tools
    {
        //Для IPropertyDescription
        public Renga.IPropertyDescription prop_descr;
        /// <summary>
        /// Инициализация интерфейса Renga.IPropertyDescription из com-объекта
        /// </summary>
        /// <param name="PropertyDescription_obj"></param>

        public PropertyDescription (object PropertyDescription_obj)
        {
            this.prop_descr = PropertyDescription_obj as Renga.IPropertyDescription;
        }
        /// <summary>
        /// Проверка на null полученного интерфейса
        /// </summary>
        /// <returns></returns>
        public bool CheckIsNotNull()
        {
            if (this.prop_descr == null) return false;
            else return true;
        }
        /// <summary>
        /// Получение наименования определения свойства
        /// </summary>
        /// <returns></returns>
        public string Name  => this.prop_descr.Name;
        /// <summary>
        /// Получение типа определения свойства
        /// </summary>
        /// <returns></returns>
        public object Type => this.prop_descr.Type;
        /// <summary>
        /// Присвоение определению свойства перечня значений 
        /// (только для свойства с типом Enumeration)
        /// </summary>
        /// <param name="enums"></param>
        public void SetEnumerationItems(List<string> enums)
        {
            if (this.prop_descr.Type == Renga.PropertyType.PropertyType_Enumeration) 
                this.prop_descr.SetEnumerationItems(enums.ToArray());
        }
        /// <summary>
        /// Получение из определения свойства перечня значений 
        /// (только для свойства с типом Enumeration)
        /// </summary>
        /// <returns></returns>
        public List<string> GetEnumerationItems()
        {
            if (this.prop_descr.Type == Renga.PropertyType.PropertyType_Enumeration)
                return this.prop_descr.GetEnumerationItems().OfType<string>().ToList();
            else return null;
        }
        //Для PropertyDescription
        public Renga.PropertyDescription prop_descr_new;
        /// <summary>
        /// Создание класса Renga.PropertyDescription (нового определения свойства)
        /// </summary>
        /// <param name="name">Строковое наименование свойства</param>
        /// <param name="prop_type">Тип параметра нового свойства, используйте нод Property.PropertyTypes</param>
        public PropertyDescription(string name, object prop_type)
        {
            this.prop_descr_new = new Renga.PropertyDescription();
            this.prop_descr_new.Name = name;
            this.prop_descr_new.Type = (Renga.PropertyType)prop_type;
        }

        /// <summary>
        /// Инициализация класса Renga.PropertyDescription по его сущности.
        /// Второй параметр ни на что не влияет
        /// </summary>
        /// <param name="PropertyDescription_obj"></param>
        /// <param name="NewProp"></param>
        [dr.IsVisibleInDynamoLibrary(false)] //Зачем он нужен?
        public PropertyDescription(object PropertyDescription_obj, bool PropFromManager = true)
        {
            this.prop_descr_new = (Renga.PropertyDescription)PropertyDescription_obj;
        }
    }
}
