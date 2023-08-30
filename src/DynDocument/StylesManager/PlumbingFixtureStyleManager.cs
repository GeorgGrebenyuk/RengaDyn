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
    /// Класс для работы с менеджером свойств сантехнического оборудования, 
    /// интерфейсом Renga.IPlumbingFixtureStyleManager
    /// </summary>
    public class PlumbingFixtureStyleManager
    {
        public Renga.IPlumbingFixtureStyleManager _i;
        /// <summary>
        /// Инициализация класса (получение менеджера свойств) из Проекта
        /// </summary>
        /// <param name="renga_project"></param>
        public PlumbingFixtureStyleManager(DynDocument.Project.Project renga_project)
        {
            this._i = renga_project._i.PlumbingFixtureStyleManager;
        }
        /// <summary>
        /// Получение всех стилей как интерфейсов Renga.IPlumbingFixtureStyle
        /// </summary>
        /// <returns></returns>
        public List<PlumbingFixtureStyle> GetPlumbingFixtureStyles()
        {
            List<PlumbingFixtureStyle> styles = new List<PlumbingFixtureStyle>();
            List<int> ids = this._i.GetIds().OfType<int>().ToList();
            for (int i = 0; i < ids.Count; i++)
            {
                styles.Add(new PlumbingFixtureStyle(this._i.GetPlumbingFixtureStyle(i)));
            }
            return styles;
        }
        /// <summary>
        /// Получение всех идентификаторов (int) стилей сантехнического оборудования
        /// </summary>
        /// <returns></returns>
        public List<int> GetIds()
        {
            return this._i.GetIds().OfType<int>().ToList();
        }
        /// <summary>
        /// Получение интерфейса IPlumbingFixtureStyle по его идентификатору
        /// </summary>
        /// <param name="style_id">Численный (int) идентификатор стиля сантехнического оборудованиия</param>
        /// <returns></returns>
        public PlumbingFixtureStyle GetEquipmentStyle(int style_id)
        {
            return new PlumbingFixtureStyle(this._i.GetPlumbingFixtureStyle(style_id));
        }
        /// <summary>
        /// Проверяет, имеется ли стиль с таким идентификатором
        /// </summary>
        /// <param name="style_id">Численный (int) идентификатор стиля сантехнического оборудованиия</param>
        /// <returns></returns>
        public bool Contains(int style_id)
        {
            return this._i.Contains(style_id);
        }
    }
}
