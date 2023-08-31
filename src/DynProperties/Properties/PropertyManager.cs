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
    /// Класс для работы с менеджером свойств проекта 
    /// (интерфейсом Renga.IPropertyManager)
    /// </summary>
    public class PropertyManager
    {
        public Renga.IPropertyManager _i;
        /// <summary>
        /// Получение менеджера свойств (интерфейса Renga.IPropertyManager) из данного проекта
        /// </summary>
        /// <param name="renga_project"></param>
        public PropertyManager (DynDocument.Project.Project renga_project)
        {
            this._i = renga_project._i.PropertyManager;
        }
        /// <summary>
        /// Получение общего количества зарегистрированных свойств в Renga (данном проекте)
        /// </summary>
        /// <returns></returns>
        public int PropertyCount => this._i.PropertyCount;

        /// <summary>
        /// Удаление свойства из Renga по его Guid-идентификатору
        /// </summary>
        /// <param name="property_id"></param>
        public void UnregisterProperty(Guid property_id)
        {
            this._i.UnregisterProperty(property_id);
        }
        /// <summary>
        /// Получение Guid-идентиикатора свойства по его внутреннему индексу из коллекции PropertyManager
        /// </summary>
        /// <param name="prop_index"></param>
        /// <returns></returns>
        public Guid GetPropertyId(int prop_index)
        {
            return this._i.GetPropertyId(prop_index);
        }
        /// <summary>
        /// Получение описания свойства (Renga.PropertyDescription) по его Guid-идентификатору
        /// </summary>
        /// <param name="property_id"></param>
        /// <returns></returns>
        [dr.IsVisibleInDynamoLibrary(false)]
        public object GetPropertyDescription (Guid property_id)
        {
            return this._i.GetPropertyDescription(property_id);
        }
        /// <summary>
        /// Получение описания свойства (Renga.IPropertyDescription) по его Guid-идентификатору
        /// </summary>
        /// <param name="property_id"></param>
        /// <returns></returns>
        public PropertyDescription GetPropertyDescription2(Guid property_id)
        {
            return new PropertyDescription(this._i.GetPropertyDescription2(property_id));
        }
        /// <summary>
        /// Проверка, зарегистрировано ли в Renga созданное свойство по его Guid-идентификатору
        /// </summary>
        /// <param name="property_id"></param>
        /// <returns></returns>
        public bool IsPropertyRegistered(Guid property_id)
        {
            return this._i.IsPropertyRegistered(property_id);
        }
        /// <summary>
        /// Ассоциация свойства с данным Guid-идентификатором категории объекта Renga
        /// </summary>
        /// <param name="property_id"></param>
        /// <param name="object_type"></param>
        public void AssignPropertyToType(Guid property_id, object object_type)
        {
            this._i.AssignPropertyToType(property_id, (Guid)object_type);
        }
        /// <summary>
        /// Ассоциация свойства со списком Guid-идентификаторов категорий объекта Renga
        /// </summary>
        /// <param name="property_id"></param>
        /// <param name="object_types"></param>
        public void AssignPropertyToTypes(Guid property_id, List<object> object_types)
        {
            foreach (object object_type in object_types)
            {
                this._i.AssignPropertyToType(property_id, (Guid)object_type);
            }

        }
        /// <summary>
        /// Удаление ассоциации свойства с данным Guid-идентификатором от категории объекта в Renga
        /// </summary>
        /// <param name="property_id"></param>
        /// <param name="object_type"></param>
        public void UnassignPropertyFromType(Guid property_id, object object_type)
        {
            this._i.UnassignPropertyFromType(property_id, (Guid)object_type);
        }
        /// <summary>
        /// Удаление ассоциации свойства с данным Guid-идентификатором от категории объектов в Renga
        /// </summary>
        /// <param name="property_id"></param>
        /// <param name="object_types"></param>
        public void UnassignPropertyFromTypes(Guid property_id, List<object> object_types)
        {
            foreach (object object_type in object_types)
            {
                this._i.UnassignPropertyFromType(property_id, (Guid)object_type);
            }
        }
        /// <summary>
        /// Проверка, назначено ли свойство с данным идентификатором данному типу объектов Renga
        /// </summary>
        /// <param name="property_id">Guid-идентификатор свойства</param>
        /// <param name="object_type">Тип объектов Renga</param>
        /// <returns></returns>
        public bool IsPropertyAssignedToType(Guid property_id, object object_type)
        {
            return this._i.IsPropertyAssignedToType(property_id, (Guid)object_type);
        }
        /// <summary>
        /// Проверка, назначено ли свойство с данным идентификатором каждому объекту из списка объектов Renga
        /// </summary>
        /// <param name="property_id"></param>
        /// <param name="object_types"></param>
        /// <returns></returns>
        public List<bool> IsPropertyAssignedToTypes(Guid property_id, List<Guid> object_types)
        {
            List<bool> bools = new List<bool>();
            foreach (Guid object_type in object_types)
            {
                bools.Add(this._i.IsPropertyAssignedToType(property_id, object_type));
            }
            return bools;
        }
        /// <summary>
        /// Получение наименования свойства по его идентификатору
        /// </summary>
        /// <param name="property_id"></param>
        /// <returns></returns>
        public string GetPropertyName(Guid property_id)
        {
            return this._i.GetPropertyName(property_id);
        }
        /// <summary>
        /// Получение типа свойства (Renga.PropertyTypes) для свойства по его идентификатору
        /// </summary>
        /// <param name="property_id"></param>
        /// <returns></returns>
        public object GetPropertyType(Guid property_id)
        {
            return this._i.GetPropertyType(property_id);
        }
        ///// <summary>
        ///// Регистрация в Renga созданного Renga.PropertyDescription (как класса), 
        ///// см. конструктор с двумя аргументами для нода-класса PropertyDescription
        ///// </summary>
        ///// <param name="property_id"></param>
        ///// <param name="prop_description_new"></param>
        //public void RegisterProperty(Guid property_id, PropertyDescription prop_description_new)
        //{
        //    this._i.RegisterProperty(property_id, prop_description_new.prop_descr_new);
        //}

        /// <summary>
        /// Создание нового свойства () по имени и значению свойства
        /// </summary>
        /// <param name="name"></param>
        /// <param name="property_type"></param>
        /// <returns></returns>
        public PropertyDescription CreatePropertyDescription(string name, object property_type)
        {
            return new PropertyDescription(this._i.CreatePropertyDescription(name, (Renga.PropertyType)property_type));
        }
        /// <summary>
        /// Регистрация созданного Renga.IPropertyDescription в Renga по его Guid
        /// </summary>
        /// <param name="property_id"></param>
        /// <param name="prop_description_existed"></param>
        public void RegisterProperty2(Guid property_id, PropertyDescription prop_description_existed)
        {
            this._i.RegisterProperty2(property_id, prop_description_existed._i);
        }

        //My
        /// <summary>
        /// ПОлучение всех идентификаторов (Guid) свойств проекта
        /// </summary>
        /// <returns></returns>
        public List<Guid> GetAllProperties()
        {
            List<Guid> props = new List<Guid>();
            for (int i = 0; i < this._i.PropertyCount; i++)
            {
                props.Add(this._i.GetPropertyId(i));
            }
            return props;
        }

    }
}
