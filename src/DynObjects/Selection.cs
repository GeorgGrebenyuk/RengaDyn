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
    /// Операции с выборкой объектов
    /// </summary>
    public class Selection
    {
        private Selection() { }
        /// <summary>
        /// Получение списка объектов (интерфейс Renga.IModelObject) из модели проекта
        /// </summary>
        /// <returns>Список объектов (интерфейсов Renga.IModelObject)</returns>
        public static List<object> GetModelObjects(DynDocument.Model renga_model)
        {
            List<object> model_objects = new List<object>();
            Renga.IModelObjectCollection collection = renga_model.model.GetObjects();
            for (int i = 0; i < collection.Count; i++)
            {
                model_objects.Add(collection.GetByIndex(i));
            }
            return model_objects;
        }
        /// <summary>
        /// Получение объекта Renga.IModelObject через его идентификатор (актуально для нодов Exported3DObject)
        /// </summary>
        /// <param name="model_object_id">int идентификатор объекта модели</param>
        /// <returns></returns>
        public static object GetModelObjectById (DynDocument.Model renga_model, int model_object_id)
        {
            Renga.IModelObjectCollection collection = renga_model.model.GetObjects();
            return collection.GetById(model_object_id);
        }
        /// <summary>
        /// Получение списка объектов (интерфейс Renga.IModelObject) из модели проекта определенного типа
        /// </summary>
        /// <param name="model_com">Интерфейс Renga.IModel из нодов Project</param>
        /// <param name="object_type">Guid типа объектов, см. нод GynObjects.General</param>
        /// <returns>Список объектов (интерфейсов Renga.IModelObject)</returns>
        public static List<object> GetObjectsByType(DynDocument.Model renga_model, Guid object_type)
        {
            Renga.IModelObjectCollection collection = renga_model.model.GetObjects();
            List<object> objects_need = new List<object>();
            foreach (int id in collection.GetIds())
            {
                IModelObject currentObject = collection.GetById(id);

                if (currentObject.ObjectType == object_type)
                {
                    objects_need.Add(currentObject);
                }
            }
            return objects_need;
        }
        /// <summary>
        /// Получение списка объектов (интерфейс Renga.IModelObject) из модели проекта на поределенном уровне
        /// </summary>
        /// <param name="model_com">Интерфейс Renga.IModel из нодов Project</param>
        /// <param name="com_ILevel">Интерфейс Renga.Level</param>
        /// <returns></returns>
        public static List<object> GetObjectsByLevel (DynDocument.Model renga_model, object com_ILevel)
        {
            Renga.IModelObjectCollection collection = renga_model.model.GetObjects();
            IModelObject level = com_ILevel as IModelObject;
            List<object> objects_need = new List<object>();
            foreach (int id in collection.GetIds())
            {
                IModelObject currentObject = collection.GetById(id);
                ILevelObject lvl_obj = currentObject as ILevelObject;

                if (lvl_obj!= null && lvl_obj.LevelId == level.Id)
                {
                    objects_need.Add(currentObject);
                }
            }
            return objects_need;
        }


    }
}
