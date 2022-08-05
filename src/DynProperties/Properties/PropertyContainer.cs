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
    /// Класс для работы с контейнером свойств (Renga.IPropertyContainer)
    /// </summary>
    public class PropertyContainer : Other.Technical.ICOM_Tools
    {
        public Renga.IPropertyContainer prop_cont;
        /// <summary>
        /// Инициация класса из интерфейса Renga.IPropertyContainer
        /// </summary>
        /// <param name="PropertyContainer_obj"></param>
        public PropertyContainer (object PropertyContainer_obj)
        {
            this.prop_cont = PropertyContainer_obj as Renga.IPropertyContainer;
        }
        /// <summary>
        /// Проверка на null полученного интерфейса
        /// </summary>
        /// <returns></returns>
        public bool CheckIsNotNull()
        {
            if (this.prop_cont == null) return false;
            else return true;
        }
        /// <summary>
        /// Проверка, содержит ли набор свойств свойство с данным идентификаторов в форме Guid
        /// </summary>
        /// <param name="prop_id"></param>
        /// <returns></returns>
        public bool Contains(Guid prop_id)
        {
            return this.prop_cont.Contains(prop_id);
        }
        /// <summary>
        /// Проверка, содержит ли набор свойств свойство с данным идентификаторов в форме строки
        /// </summary>
        /// <param name="prop_id"></param>
        /// <returns></returns>
        public bool ContainsS (string prop_id)
        {
            return this.prop_cont.ContainsS(prop_id);
        }
        /// <summary>
        /// Получение списка идентификаторов свойств в форме Guid'ов (Renga.IGuidCollection)
        /// </summary>
        /// <returns></returns>
        public object GetIds => this.prop_cont.GetIds();
        /// <summary>
        /// Получение одиночного свойства (Renga.IProperty) по идентификатору в форме Guid
        /// </summary>
        /// <param name="prop_id"></param>
        /// <returns></returns>
        public object Get(Guid prop_id)
        {
            return this.prop_cont.Get(prop_id);
        }
        /// <summary>
        /// Получение одиночного свойства (Renga.IProperty) по идентификатору в форме строки
        /// </summary>
        /// <param name="prop_id"></param>
        /// <returns></returns>
        public object GetS(string prop_id)
        {
            return this.prop_cont.GetS(prop_id);
        }
        /// <summary>
        /// Получение списка свойств Renga.IProperty
        /// </summary>
        /// <returns></returns>
        public List<object> GetAllProperties()
        {
            List<object> props = new List<object>();
            Renga.IGuidCollection collection = this.prop_cont.GetIds();
            for (int i = 0; i < collection.Count; i++)
            {
                props.Add(this.prop_cont.Get(collection.Get(i)));
            }
            return props;
        }
    }
}
