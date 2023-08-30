using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;
using DynRenga.Other;

namespace DynRenga.DynProperties.Properties
{
    /// <summary>
    /// Класс для работы с контейнером свойств (Renga.IPropertyContainer)
    /// </summary>
    public class PropertyContainer
    {
        public Renga.IPropertyContainer _i;
        /// <summary>
        /// Инициация класса из интерфейса Renga.IPropertyContainer
        /// </summary>
        /// <param name="PropertyContainer_obj"></param>
        internal PropertyContainer (object PropertyContainer_obj)
        {
            this._i = PropertyContainer_obj as Renga.IPropertyContainer;
        }
        /// <summary>
        /// Проверка, содержит ли набор свойств свойство с данным идентификаторов в форме Guid
        /// </summary>
        /// <param name="prop_id"></param>
        /// <returns></returns>
        public bool Contains(Guid prop_id)
        {
            return this._i.Contains(prop_id);
        }
        /// <summary>
        /// Проверка, содержит ли набор свойств свойство с данным идентификаторов в форме строки
        /// </summary>
        /// <param name="prop_id"></param>
        /// <returns></returns>
        public bool ContainsS (string prop_id)
        {
            return this._i.ContainsS(prop_id);
        }
        /// <summary>
        /// Получение списка идентификаторов свойств в форме Guid'ов (Renga.IGuidCollection)
        /// </summary>
        /// <returns></returns>
        public GuidCollection GetIds => new GuidCollection( this._i.GetIds());
        /// <summary>
        /// Получение одиночного свойства (Renga.IProperty) по идентификатору в форме Guid
        /// </summary>
        /// <param name="prop_id"></param>
        /// <returns></returns>
        public Property Get(Guid prop_id)
        {
            return new Property(this._i.Get(prop_id));
        }
        /// <summary>
        /// Получение одиночного свойства (Renga.IProperty) по идентификатору в форме строки
        /// </summary>
        /// <param name="prop_id"></param>
        /// <returns></returns>
        public Property GetS(string prop_id)
        {
            return new Property(this._i.GetS(prop_id));
        }
        /// <summary>
        /// Получение списка свойств Renga.IProperty
        /// </summary>
        /// <returns></returns>
        public List<Property> GetAllProperties()
        {
            List<Property> props = new List<Property>();
            Renga.IGuidCollection _i = this._i.GetIds();
            for (int i = 0; i < _i.Count; i++)
            {
                props.Add(new Property(this._i.Get(_i.Get(i))));
            }
            return props;
        }
    }
}
