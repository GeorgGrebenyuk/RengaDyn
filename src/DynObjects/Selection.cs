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
    /// Методы выборки объектов модели
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
            Renga.IModelObjectCollection _i = renga_model._i.GetObjects();
            for (int i = 0; i < _i.Count; i++)
            {
                model_objects.Add(_i.GetByIndex(i));
            }
            return model_objects;
        }
        /// <summary>
        /// Получение интерфейса Renga.IModelObject через его идентификатор (актуально для нодов Exported3DObject)
        /// </summary>
        /// <param name="model_object_id">int идентификатор объекта модели</param>
        /// <returns></returns>
        public static object GetModelObjectById (DynDocument.Model renga_model, int model_object_id)
        {
            Renga.IModelObjectCollection _i = renga_model._i.GetObjects();
            return _i.GetById(model_object_id);
        }
        /// <summary>
        /// Выборка объектов модели (Renga::IModelObject) по типу (Guid)
        /// </summary>
        /// <param name="object_type">Guid типа объектов, см. нод GynObjects.General</param>
        /// <returns>Список объектов (интерфейсов Renga.IModelObject)</returns>
        public static List<object> GetObjectsByType(DynDocument.Model renga_model, Guid object_type)
        {
            Renga.IModelObjectCollection _i = renga_model._i.GetObjects();
            List<object> objects_need = new List<object>();
            foreach (int id in _i.GetIds())
            {
                IModelObject currentObject = _i.GetById(id);

                if (currentObject.ObjectType == object_type)
                {
                    objects_need.Add(currentObject);
                }
            }
            return objects_need;
        }
        /// <summary>
        /// Выборка объектов модели (Renga::IModelObject) по принадлежности к уровню (Renga::IModelObject)
        /// </summary>
        /// <param name="com_ILevel">Интерфейс Renga.Level</param>
        /// <returns></returns>
        public static List<object> GetObjectsByLevel (DynDocument.Model renga_model, object com_ILevel)
        {
            Renga.IModelObjectCollection _i = renga_model._i.GetObjects();
            IModelObject _IModelObject = com_ILevel as IModelObject;
            List<object> objects_need = new List<object>();
            foreach (int id in _i.GetIds())
            {
                IModelObject currentObject = _i.GetById(id);
                ILevelObject lvl_obj = currentObject as ILevelObject;

                if (lvl_obj!= null && lvl_obj.LevelId == _IModelObject.Id)
                {
                    objects_need.Add(currentObject);
                }
            }
            return objects_need;
        }
        /// <summary>
        /// Получает выделенные пользователем идентификаторы (int) объектов модели Renga.
        /// Работает с новым выделенением только при смене с true-false-true
        /// </summary>
        /// <param name="renga_application"></param>
        /// <param name="run_again"></param>
        /// <returns></returns>
        public static List<int> GetSelectedObjectsIdByUser(DynDocument.Application renga_application, bool run_again = false)
        {
            if (run_again == false) return null;
            else
            {
                var selection = renga_application._i.Selection;
                if (selection == null) return null;
                else return selection.GetSelectedObjects().OfType<int>().ToList();
            }

        }
        /// <summary>
        /// Выделение в модели Renga объектов по списку их идентификаторов
        /// </summary>
        /// <param name="renga_application"></param>
        /// <param name="model_objects_ids">Список с int-идентификаторами объектов модели</param>
        public static void SelectObjectsInModelByIds (DynDocument.Application renga_application, List<int> model_objects_ids)
        {
            var selection = renga_application._i.Selection;
            if (model_objects_ids.Any()) selection.SetSelectedObjects(model_objects_ids.ToArray());
        }

    }
}
