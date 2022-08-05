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
    public class PropertyManager : Other.Technical.ICOM_Tools
    {
        public Renga.IPropertyManager prop_manager;
        /// <summary>
        /// Получение менеджера свойств (интерфейса Renga.IPropertyManager) из данного проекта
        /// </summary>
        /// <param name="renga_project"></param>
        public PropertyManager (DynDocument.Project.Project renga_project)
        {
            this.prop_manager = renga_project.project.PropertyManager;
        }
        /// <summary>
        /// Проверка на null полученного интерфейса
        /// </summary>
        /// <returns></returns>
        public bool CheckIsNotNull()
        {
            if (this.prop_manager== null) return false;
            else return true;
        }
        /// <summary>
        /// Получение общего количества зарегистрированных свойств в Renga (данном проекте)
        /// </summary>
        /// <returns></returns>
        public int PropertyCount => this.prop_manager.PropertyCount;

        /// <summary>
        /// Удаление свойства из Renga по его Guid-идентификатору
        /// </summary>
        /// <param name="property_id"></param>
        public void UnregisterProperty(Guid property_id)
        {
            this.prop_manager.UnregisterProperty(property_id);
        }
        /// <summary>
        /// Получение Guid-идентиикатора свойства по его внутреннему индексу из коллекции PropertyManager
        /// </summary>
        /// <param name="prop_index"></param>
        /// <returns></returns>
        public Guid GetPropertyId(int prop_index)
        {
            return this.prop_manager.GetPropertyId(prop_index);
        }
        /// <summary>
        /// Получение описания свойства (Renga.PropertyDescription) по его Guid-идентификатору
        /// </summary>
        /// <param name="property_id"></param>
        /// <returns></returns>
        [dr.IsVisibleInDynamoLibrary(false)]
        public object GetPropertyDescription (Guid property_id)
        {
            return this.prop_manager.GetPropertyDescription(property_id);
        }
        /// <summary>
        /// Получение описания свойства (Renga.IPropertyDescription) по его Guid-идентификатору
        /// </summary>
        /// <param name="property_id"></param>
        /// <returns></returns>
        public object GetPropertyDescription2(Guid property_id)
        {
            return this.prop_manager.GetPropertyDescription2(property_id);
        }
        /// <summary>
        /// Проверка, зарегистрировано ли в Renga созданное свойство по его Guid-идентификатору
        /// </summary>
        /// <param name="property_id"></param>
        /// <returns></returns>
        public bool IsPropertyRegistered(Guid property_id)
        {
            return this.prop_manager.IsPropertyRegistered(property_id);
        }
        /// <summary>
        /// Ассоциация свойства с данным Guid-идентификаторов категории объекта Renga
        /// </summary>
        /// <param name="property_id"></param>
        /// <param name="object_type"></param>
        public void AssignPropertyToType(Guid property_id, object object_type)
        {
            this.prop_manager.AssignPropertyToType(property_id, (Guid)object_type);
        }
        /// <summary>
        /// Удаление ассоциации свойства с данным Guid-идентификатором от категории объекта в Renga
        /// </summary>
        /// <param name="property_id"></param>
        /// <param name="object_type"></param>
        public void UnassignPropertyFromType(Guid property_id, object object_type)
        {
            this.prop_manager.UnassignPropertyFromType(property_id, (Guid)object_type);
        }
        /// <summary>
        /// Проверка, назначено ли свойство с данным идентификатором данному типу объектов Renga
        /// </summary>
        /// <param name="property_id">Guid-идентификатор свойства</param>
        /// <param name="object_type">Тип объектов Renga</param>
        /// <returns></returns>
        public bool IsPropertyAssignedToType(Guid property_id, object object_type)
        {
            return this.prop_manager.IsPropertyAssignedToType(property_id, (Guid)object_type);
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
                bools.Add(this.prop_manager.IsPropertyAssignedToType(property_id, object_type));
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
            return this.prop_manager.GetPropertyName(property_id);
        }
        /// <summary>
        /// Получение типа свойства (Renga.PropertyTypes) для свойства по его идентификатору
        /// </summary>
        /// <param name="property_id"></param>
        /// <returns></returns>
        public object GetPropertyType(Guid property_id)
        {
            return this.prop_manager.GetPropertyType(property_id);
        }
        /// <summary>
        /// Регистрация в Renga созданного Renga.PropertyDescription (как класса), 
        /// см. конструктор с двумя аргументами для нода-класса PropertyDescription
        /// </summary>
        /// <param name="property_id"></param>
        /// <param name="prop_description_new"></param>
        public void RegisterProperty(Guid property_id, PropertyDescription prop_description_new)
        {
            this.prop_manager.RegisterProperty(property_id, prop_description_new.prop_descr_new);
        }

        /// <summary>
        /// Создание интерфейса Renga.IPropertyDescription по имени и значению свойства
        /// </summary>
        /// <param name="name"></param>
        /// <param name="property_type"></param>
        /// <returns></returns>
        public object CreatePropertyDescription(string name, object property_type)
        {
            return this.prop_manager.CreatePropertyDescription(name, (Renga.PropertyType)property_type);
        }
        /// <summary>
        /// Регистрация созданного Renga.IPropertyDescription в Renga по его Guid
        /// </summary>
        /// <param name="property_id"></param>
        /// <param name="prop_description_existed"></param>
        public void RegisterProperty2(Guid property_id, PropertyDescription prop_description_existed)
        {
            this.prop_manager.RegisterProperty2(property_id, prop_description_existed.prop_descr);
        }

        //My
        /// <summary>
        /// ПОлучение всех идентификаторов (Guid) свойств проекта
        /// </summary>
        /// <returns></returns>
        public List<Guid> GetAllProperties()
        {
            List<Guid> props = new List<Guid>();
            for (int i = 0; i < this.prop_manager.PropertyCount; i++)
            {
                props.Add(this.prop_manager.GetPropertyId(i));
            }
            return props;
        }

    }
}
