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
    /// Класс для работы с менеджером свойств балок, 
    /// интерфейсом Renga.IBeamStyleManager
    /// </summary>
    public class BeamStyleManager
    {
        public Renga.IBeamStyleManager _i;
        /// <summary>
        /// Инициализация класса (получение менеджера свойств) из Проекта
        /// </summary>
        /// <param name="renga_project"></param>
        public BeamStyleManager(DynDocument.Project.Project renga_project)
        {
            this._i = renga_project._i.BeamStyleManager;
        }
        /// <summary>
        /// Получение всех стилей как интерфейсов Renga.IBeamStyle
        /// </summary>
        /// <returns></returns>
        public List<BeamStyle> GetBeamStyles()
        {
            List<BeamStyle> styles = new List<BeamStyle>();
            List<int> ids = this._i.GetIds().OfType<int>().ToList();
            for (int i = 0; i < ids.Count; i++)
            {
                styles.Add(new BeamStyle(this._i.GetBeamStyle(i)));
            }
            return styles;
        }
        /// <summary>
        /// Получение всех идентификаторов (int) стилей балок
        /// </summary>
        /// <returns></returns>
        public List<int> GetIds()
        {
            return this._i.GetIds().OfType<int>().ToList();
        }
        /// <summary>
        /// Получение интерфейса IBeamStyle по его идентификатору
        /// </summary>
        /// <param name="style_id">Численный (int) идентификатор стиля балки</param>
        /// <returns></returns>
        public BeamStyle GetBeamStyle(int style_id)
        {
            return new BeamStyle( this._i.GetBeamStyle(style_id));
        }
        /// <summary>
        /// Проверяет, имеется ли стиль с таким идентификатором
        /// </summary>
        /// <param name="style_id">Численный (int) идентификатор стиля балки</param>
        /// <returns></returns>
        public bool Contains(int style_id)
        {
            return this._i.Contains(style_id);
        }
    }
}
