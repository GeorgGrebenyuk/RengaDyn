using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;

namespace DynRenga.DynDocument.Views
{
    /// <summary>
    /// Класс для работы с Видом модели (отображение объектов)
    /// </summary>
    public class ModelView
    {
        public Renga.IModelView _i;
        internal ModelView(object view_object)
        {
            this._i = view_object as Renga.IModelView;
        }
        //functions
        /// <summary>
        /// Изменение видимости объектов.
        /// </summary>
        /// <param name="object_ids">Список int-идентификаторов объектов модели</param>
        /// <param name="visiable">True для видимости, False для скрытия</param>
        public void SetObjectsVisibility(List<int> object_ids, bool visiable)
        {
            this._i.SetObjectsVisibility(object_ids.ToArray(), visiable);
        }
        /// <summary>
        /// Проверка, является ли данный объекти видимым в модели
        /// </summary>
        /// <param name="object_id"></param>
        /// <returns></returns>
        public bool IsObjectVisible(int object_id)
        {
            return this._i.IsObjectVisible(object_id);
        }
        /// <summary>
        /// Включение видимости объектов
        /// </summary>
        /// <param name="object_ids">Список int-идентификаторов объектов модели</param>
        public void ShowObjects(List<int> object_ids)
        {
            this._i.ShowObjects(object_ids.ToArray());
        }
        /// <summary>
        /// Устаналивает стиль отображения для данного списка объектов
        /// </summary>
        /// <param name="object_ids"></param>
        /// <param name="VisualStyle"></param>
        public void SetObjectsVisualStyle (List<int> object_ids, object VisualStyle)
        {
            this._i.SetObjectsVisualStyle(object_ids.ToArray(), (Renga.VisualStyle)VisualStyle);
        }
        /// <summary>
        /// Получение текущего визуального стиля отображения объекта как числа (Renga.VisualStyle)
        /// </summary>
        /// <param name="object_id"></param>
        /// <returns></returns>
        public object GetObjectVisualStyle(int object_id)
        {
            return this._i.GetObjectVisualStyle(object_id);
        }
        /// <summary>
        ///  Получение текущего визуального стиля отображения объекта как строки
        /// </summary>
        /// <param name="VisualStyle"></param>
        /// <returns></returns>
        public string GetObjectVisualStyleAsString(object VisualStyle)
        {
            return VisualStyles().Where(a => a.Value == VisualStyle).First().Key;
        }
        /// <summary>
        /// Все стили визуального отображения
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string,object> VisualStyles()
        {
            return new Dictionary<string, object>()
            {
                {"Undefined visual",Renga.VisualStyle.VisualStyle_Undefined },
                {"Wireframe visual",Renga.VisualStyle.VisualStyle_Wireframe },
                {"Monochrome visual",Renga.VisualStyle.VisualStyle_Monochrome },
                {"Colored visual",Renga.VisualStyle.VisualStyle_Color },
                {"Textured visual",Renga.VisualStyle.VisualStyle_Textured }
            };
        }

    }
}
