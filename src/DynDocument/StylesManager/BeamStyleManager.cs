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
    /// Класс для работы с менеджером свойств балок, 
    /// интерфейсом Renga.IBeamStyleManager
    /// </summary>
    public class BeamStyleManager
    {
        public Renga.IBeamStyleManager man;
        /// <summary>
        /// Инициализация класса (получение менеджера свойств) из Проекта
        /// </summary>
        /// <param name="renga_project"></param>
        public BeamStyleManager(DynDocument.Project.Project renga_project)
        {
            this.man = renga_project.project.BeamStyleManager;
        }
        /// <summary>
        /// Получение всех стилей как интерфейсов Renga.IBeamStyle
        /// </summary>
        /// <returns></returns>
        public List<object> GetBeamStyles()
        {
            List<object> styles = new List<object>();
            List<int> ids = this.man.GetIds().OfType<int>().ToList();
            for (int i = 0; i < ids.Count; i++)
            {
                styles.Add(this.man.GetBeamStyle(i));
            }
            return styles;
        }
        /// <summary>
        /// Получение всех идентификаторов (int) стилей балок
        /// </summary>
        /// <returns></returns>
        public List<int> GetIds()
        {
            return this.man.GetIds().OfType<int>().ToList();
        }
        /// <summary>
        /// Получение интерфейса IBeamStyle по его идентификатору
        /// </summary>
        /// <param name="style_id">Численный (int) идентификатор стиля балки</param>
        /// <returns></returns>
        public object GetBeamStyle(int style_id)
        {
            return this.man.GetBeamStyle(style_id);
        }
        /// <summary>
        /// Проверяет, имеется ли стиль с таким идентификатором
        /// </summary>
        /// <param name="style_id">Численный (int) идентификатор стиля балки</param>
        /// <returns></returns>
        public bool Contains(int style_id)
        {
            return this.man.Contains(style_id);
        }
    }
}
