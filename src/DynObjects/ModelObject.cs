using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;


namespace DynRenga.DynObjects
{
    /// <summary>
    /// Класс для работы с объектом модели Renga.IModelObject
    /// </summary>
    public class ModelObject
    {
        public Renga.IModelObject _i;
        /// <summary>
        /// Инициация класса из интерфейса Renga.IModelObject
        /// </summary>
        /// <param name="model_object_com"></param>
        internal ModelObject (object model_object_com)
        {
            this._i = model_object_com as Renga.IModelObject;
        }
        /// <summary>
        /// Получение типа объекта как Guid
        /// </summary>
        /// <returns></returns>
        public Guid ObjectType => this._i.ObjectType;
        /// <summary>
        /// Получение целочисленного идентификатора объекта
        /// </summary>
        /// <returns></returns>
        public int Id => this._i.Id;
        /// <summary>
        /// Получение наименования объекта в Renga
        /// </summary>
        /// <returns></returns>
        public string Name => this._i.Name;
        /// <summary>
        /// Получение внутреннего идентификатора объекта в Renga как Guid
        /// </summary>
        /// <returns></returns>
        public Guid UniqueId => this._i.UniqueId;
        /// <summary>
        /// Приведение объекта модели к интерфейсу Renga.IObjectWithMaterial для получения материала, если таковой вообще назначен.
        /// Если не назначен - будет возвращено "-1"
        /// </summary>
        /// <returns></returns>
        public int GetAssotiatedMaterialId()
        {
            Renga.IObjectWithMaterial obj_mat = this._i as Renga.IObjectWithMaterial;
            if (obj_mat.HasMaterial()) return obj_mat.MaterialId;
            else return -1;
        }
        /// <summary>
        /// Получает ассоциированный с объектом набор слоев LayeredMaterial 
        /// (только в случае если это объект типа Крыша, Стена или Перекрытие
        /// </summary>
        /// <returns></returns>
        public int GetAssotiatedLayerMaterialId()
        {
            Renga.IObjectWithLayeredMaterial obj_lay_mat = this._i as Renga.IObjectWithLayeredMaterial;
            if (obj_lay_mat.HasLayeredMaterial()) return obj_lay_mat.LayeredMaterialId;
            else return -1;
        }
        /// <summary>
        /// Получает строкое наименование метки, ассоциированной с объектом
        /// </summary>
        /// <returns>Если марка отсутствует, то возвращается пустая строка. В противном случае - марка.</returns>
        public string GetAssotiatedMark()
        {
            Renga.IObjectWithMark obj_mark = this._i as Renga.IObjectWithMark;
            if (obj_mark == null) return "";
            else return obj_mark.Mark;
        }
        /// <summary>
        /// Получение свойств объекта - собственных свойств, количества и параметров 
        /// </summary>
        /// <returns>Словарь со свойствами</returns>
        [dr.MultiReturn(new[] { "Properties_IPropertyContainer", 
            "Quantities_IQuantityContainer", "Parameters_IParameterContainer" })]
        public Dictionary<string, object> GetObjectsData()
        {
            return new Dictionary<string, object>
            {
                { "Properties_IPropertyContainer", new DynProperties.Properties.PropertyContainer (this._i.GetProperties())},
                { "Quantities_IQuantityContainer", new DynProperties.Quantities.QuantityContainer(this._i.GetQuantities())},
                { "Parameters_IParameterContainer", new DynProperties.Parameters.ParameterContainer (this._i.GetParameters())}
            };

        }

    }
}
