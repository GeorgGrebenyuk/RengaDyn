using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;
using DynRenga.DynGeometry;

namespace DynRenga.DynDocument
{
    /// <summary>
    /// Класс для работы с Уровнями модели проекта (интерфейсов Renga.ILevel)
    /// </summary>
    public class Level
    {
        public Renga.ILevel _i;
        /// <summary>
        /// Получение всех уровней в модели проекта как интерфейсов Renga.IModelObject
        /// </summary>
        /// <param name="renga_model">Класс для представления модели проекта (Project->Model)</param>
        /// <returns></returns>
        public static List<DynRenga.DynObjects.ModelObject> GetLevels (DynDocument.Model renga_model)
        {
            Renga.IModelObjectCollection _i = renga_model._i.GetObjects();
            List<DynObjects.ModelObject> objects_need = new List<DynObjects.ModelObject>();
            foreach (int id in _i.GetIds())
            {
                IModelObject currentObject = _i.GetById(id);

                if (currentObject.ObjectType == Renga.ObjectTypes.Level)
                {
                    objects_need.Add(new DynObjects.ModelObject(currentObject));
                }
            }
            return objects_need;
        }
        /// <summary>
        /// Получение уровня в модели проекта по его идентификатору (актуально для свойства GetLevelObjectInfo)
        /// </summary>
        /// <param name="renga_model">Класс для представления модели проекта (Project->Model)</param>
        /// <param name="level_model_object_id"></param>
        public Level (DynDocument.Model renga_model, int level_model_object_id)
        {
            Renga.IModelObjectCollection _i = renga_model._i.GetObjects();
            foreach (int id in _i.GetIds())
            {
                IModelObject currentObject = _i.GetById(id);

                if (currentObject.ObjectType == Renga.ObjectTypes.Level && currentObject.Id == level_model_object_id)
                {
                    this._i = currentObject as Renga.ILevel;
                    break;
                }
            }
        }
        /// <summary>
        /// Инициация класса черезе интерфейс Renga.IModelObject как интерфейса Renga.ILevel
        /// </summary>
        /// <param name="level_com">Интерфейс Renga.IModelObject</param>
        internal Level (object level_com)
        {
            this._i = level_com as Renga.ILevel;
        }
        /// <summary>
        /// Получение имени уровня
        /// </summary>
        /// <returns></returns>
        public string LevelName => this._i.LevelName;
        /// <summary>
        /// Получение отметки уровня
        /// </summary>
        /// <returns></returns>
        public double Elevation => this._i.Elevation;
        /// <summary>
        /// Получение интерфейса Renga.IPlacement3D
        /// </summary>
        /// <returns></returns>
        public Placement3D Placement => new Placement3D(this._i.Placement);
    }
}
