using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;
using DynRenga.DynStyles;

namespace DynRenga.DynDocument.StylesManager
{
    /// <summary>
    /// Класс для работы с менеджером свойств колонн, 
    /// интерфейсом Renga.IColumnStyleManager
    /// </summary>
    public class ColumnStyleManager
    {
        public Renga.IColumnStyleManager _i;
        /// <summary>
        /// Инициализация класса (получение менеджера свойств) из Проекта
        /// </summary>
        /// <param name="renga_project"></param>
        public ColumnStyleManager(DynDocument.Project.Project renga_project)
        {
            this._i = renga_project._i.ColumnStyleManager;
        }
        /// <summary>
        /// Получение всех стилей как интерфейсов Renga.IColumnStyle
        /// </summary>
        /// <returns></returns>
        public List<ColumnStyle> GetColumnStyles()
        {
            List<ColumnStyle> styles = new List<ColumnStyle>();
            List<int> ids = this._i.GetIds().OfType<int>().ToList();
            for (int i = 0; i < ids.Count; i++)
            {
                styles.Add(new ColumnStyle(this._i.GetColumnStyle(i)));
            }
            return styles;
        }
        /// <summary>
        /// Получение всех идентификаторов (int) стилей колонн
        /// </summary>
        /// <returns></returns>
        public List<int> GetIds()
        {
            return this._i.GetIds().OfType<int>().ToList();
        }
        /// <summary>
        /// Получение интерфейса IColumnStyle по его идентификатору
        /// </summary>
        /// <param name="style_id">Численный (int) идентификатор стиля колонны</param>
        /// <returns></returns>
        public ColumnStyle GetColumnStyle(int style_id)
        {
            return new ColumnStyle(this._i.GetColumnStyle(style_id));
        }
        /// <summary>
        /// Проверяет, имеется ли стиль с таким идентификатором
        /// </summary>
        /// <param name="style_id">Численный (int) идентификатор стиля колонны</param>
        /// <returns></returns>
        public bool Contains (int style_id)
        {
            return this._i.Contains(style_id);
        }
    }
}
