using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;


namespace DynRenga.DynDocument
{
    /// <summary>
    /// Класс для работы с Уровнями модели проекта (интерфейсов Renga.ILevel)
    /// </summary>
    public class Level : Other.Technical.ICOM_Tools
    {
        public Renga.ILevel level;
        /// <summary>
        /// Получение всех увроней в модели проекта как интерфейсов Renga.IModelObject
        /// </summary>
        /// <param name="renga_model">Класс для представления модели проекта (Project->Model)</param>
        /// <returns></returns>
        public static List<object> GetLevels (DynDocument.Model renga_model)
        {
            Renga.IModelObjectCollection collection = renga_model.model.GetObjects();
            List<object> objects_need = new List<object>();
            foreach (int id in collection.GetIds())
            {
                IModelObject currentObject = collection.GetById(id);

                if (currentObject.ObjectType == Renga.ObjectTypes.Level)
                {
                    objects_need.Add(currentObject);
                }
            }
            return objects_need;
        }
        /// <summary>
        /// Проверка на null полученного интерфейса
        /// </summary>
        /// <returns></returns>
        public bool CheckIsNotNull()
        {
            if (this.level== null) return false;
            else return true;
        }
        /// <summary>
        /// Получение уровня в модели проекта по его идентификатору (актуально для свойства GetLevelObjectInfo)
        /// </summary>
        /// <param name="renga_model">Класс для представления модели проекта (Project->Model)</param>
        /// <param name="level_model_object_id"></param>
        public Level (DynDocument.Model renga_model, int level_model_object_id)
        {
            Renga.IModelObjectCollection collection = renga_model.model.GetObjects();
            foreach (int id in collection.GetIds())
            {
                IModelObject currentObject = collection.GetById(id);

                if (currentObject.ObjectType == Renga.ObjectTypes.Level && currentObject.Id == level_model_object_id)
                {
                    this.level = currentObject as Renga.ILevel;
                    break;
                }
            }
        }
        /// <summary>
        /// Инициация класса черезе интерфейс Renga.IModelObject как интерфейса Renga.ILevel
        /// </summary>
        /// <param name="level_com">Интерфейс Renga.IModelObject</param>
        public Level (object level_com)
        {
            this.level = level_com as Renga.ILevel;
        }
        /// <summary>
        /// Получение имени уровня
        /// </summary>
        /// <returns></returns>
        public string LevelName => this.level.LevelName;
        /// <summary>
        /// Получение отметки уровня
        /// </summary>
        /// <returns></returns>
        public double Elevation => this.level.Elevation;
        /// <summary>
        /// Получение интерфейса Renga.IPlacement3D
        /// </summary>
        /// <returns></returns>
        public object Placement => this.level.Placement;
    }
}
