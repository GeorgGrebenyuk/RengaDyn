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
    /// Класс для работы с менеджером свойств сантехнического оборудования, 
    /// интерфейсом Renga.IPlumbingFixtureStyleManager
    /// </summary>
    public class PlumbingFixtureStyleManager : Other.Technical.ICOM_Tools
    {
        public Renga.IPlumbingFixtureStyleManager man;
        /// <summary>
        /// Инициализация класса (получение менеджера свойств) из Проекта
        /// </summary>
        /// <param name="renga_project"></param>
        public PlumbingFixtureStyleManager(DynDocument.Project.Project renga_project)
        {
            this.man = renga_project.project.PlumbingFixtureStyleManager;
        }
        /// <summary>
        /// Проверка на null полученного интерфейса
        /// </summary>
        /// <returns></returns>
        public bool CheckIsNotNull()
        {
            if (this.man == null) return false;
            else return true;
        }
        /// <summary>
        /// Получение всех стилей как интерфейсов Renga.IPlumbingFixtureStyle
        /// </summary>
        /// <returns></returns>
        public List<object> GetPlumbingFixtureStyles()
        {
            List<object> styles = new List<object>();
            List<int> ids = this.man.GetIds().OfType<int>().ToList();
            for (int i = 0; i < ids.Count; i++)
            {
                styles.Add(this.man.GetPlumbingFixtureStyle(i));
            }
            return styles;
        }
        /// <summary>
        /// Получение всех идентификаторов (int) стилей сантехнического оборудования
        /// </summary>
        /// <returns></returns>
        public List<int> GetIds()
        {
            return this.man.GetIds().OfType<int>().ToList();
        }
        /// <summary>
        /// Получение интерфейса IPlumbingFixtureStyle по его идентификатору
        /// </summary>
        /// <param name="style_id">Численный (int) идентификатор стиля сантехнического оборудованиия</param>
        /// <returns></returns>
        public object GetEquipmentStyle(int style_id)
        {
            return this.man.GetPlumbingFixtureStyle(style_id);
        }
        /// <summary>
        /// Проверяет, имеется ли стиль с таким идентификатором
        /// </summary>
        /// <param name="style_id">Численный (int) идентификатор стиля сантехнического оборудованиия</param>
        /// <returns></returns>
        public bool Contains(int style_id)
        {
            return this.man.Contains(style_id);
        }
    }
}
