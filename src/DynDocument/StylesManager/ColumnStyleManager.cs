using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;

namespace DynRenga.DynDocument.StylesManager
{
    /// <summary>
    /// Класс для работы с менеджером свойств колонн
    /// </summary>
    public class ColumnStyleManager
    {
        public Renga.IColumnStyleManager man;
        /// <summary>
        /// Получение мененджера свойств колонн из Проекта
        /// </summary>
        /// <param name="renga_project"></param>
        public ColumnStyleManager(DynDocument.Project.Project renga_project)
        {
            this.man = renga_project.project.ColumnStyleManager;
        }
        /// <summary>
        /// Получение всех стилей как интерфейсов IColumnStyle
        /// </summary>
        /// <returns></returns>
        public List<object> GetColumnStyles()
        {
            List<object> styles = new List<object>();
            List<int> ids = this.man.GetIds().OfType<int>().ToList();
            for (int i = 0; i < ids.Count; i++)
            {
                styles.Add(this.man.GetColumnStyle(i));
            }
            return styles;
        }
        /// <summary>
        /// Получение всех идентификаторов стилей колонн
        /// </summary>
        /// <returns></returns>
        public List<int> GetIds()
        {
            return this.man.GetIds().OfType<int>().ToList();
        }
        /// <summary>
        /// Получение интерфейса IColumnStyle по его идентификатору
        /// </summary>
        /// <param name="style_id"></param>
        /// <returns></returns>
        public object GetColumnStyle(int style_id)
        {
            return this.man.GetColumnStyle(style_id);
        }
    }
}
