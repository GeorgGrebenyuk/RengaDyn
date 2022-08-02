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
    public class ModelObject : Other.Technical.ICOM_Tools
    {
        public Renga.IModelObject obj;
        /// <summary>
        /// Инициация класса из интерфейса Renga.IModelObject
        /// </summary>
        /// <param name="model_object_com"></param>
        public ModelObject (object model_object_com)
        {
            this.obj = model_object_com as Renga.IModelObject;
        }
        /// <summary>
        /// Проверка на null полученного интерфейса
        /// </summary>
        /// <returns></returns>
        public bool CheckIsNotNull()
        {
            if (this.obj == null) return false;
            else return true;
        }
        /// <summary>
        /// Получение типа объекта как Guid
        /// </summary>
        /// <returns></returns>
        public Guid ObjectType()
        {
            return this.obj.ObjectType;
        }
        /// <summary>
        /// Получение целочисленного идентификатора объекта
        /// </summary>
        /// <returns></returns>
        public int Id()
        {
            return this.obj.Id;
        }
        /// <summary>
        /// Получение наименования объекта в Renga
        /// </summary>
        /// <returns></returns>
        public string Name()
        {
            return this.obj.Name;
        }
        /// <summary>
        /// Получение внутреннего идентификатора объекта в Renga как Guid
        /// </summary>
        /// <returns></returns>
        public Guid UniqueId()
        {
            return this.obj.uniqueId;
        }
        /// <summary>
        /// Приведение объекта модели к интерфейсу Renga.IObjectWithMaterial для получения материала, если таковой вообще назначен.
        /// Если не назначен - будет возвращено "-1"
        /// </summary>
        /// <returns></returns>
        public int GetAssotiatedMaterialId()
        {
            Renga.IObjectWithMaterial obj_mat = this.obj as Renga.IObjectWithMaterial;
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
            Renga.IObjectWithLayeredMaterial obj_lay_mat = this.obj as Renga.IObjectWithLayeredMaterial;
            if (obj_lay_mat.HasLayeredMaterial()) return obj_lay_mat.LayeredMaterialId;
            else return -1;
        }
        /// <summary>
        /// Получает строкое наименование метки, ассоциированной с объектом
        /// </summary>
        /// <returns></returns>
        public string GetAssotiatedMark()
        {
            Renga.IObjectWithMark obj_mark = this.obj as Renga.IObjectWithMark;
            return obj_mark.Mark;
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
                { "Properties_IPropertyContainer",this.obj.GetProperties()},
                { "Quantities_IQuantityContainer",this.obj.GetQuantities()},
                { "Parameters_IParameterContainer", this.obj.GetParameters()}
            };

        }
        /// <summary>
        /// Представление объекта модели как объекта уровня и получение информации о нем
        /// </summary>
        /// <returns></returns>
        [dr.MultiReturn(new[] { "LevelId", "VerticalOffset", "PlacementElevation", "ElevationAboveLevel" })]
        public Dictionary<string, object> GetLevelObjectInfo()
        {
            ILevelObject obj = this.obj as ILevelObject;
            return new Dictionary<string, object>
            {
                {"LevelId",obj.LevelId },
                {"VerticalOffset",obj.VerticalOffset },
                {"PlacementElevation",obj.PlacementElevation},
                {"ElevationAboveLevel",obj.ElevationAboveLevel }
            };
        }

    }
}
