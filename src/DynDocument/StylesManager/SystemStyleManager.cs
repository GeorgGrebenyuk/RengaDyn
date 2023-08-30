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
    /// Класс для работы с менеджером свойств инженерных систем, 
    /// интерфейсом Renga.ISystemStyleManager
    /// </summary>
    public class SystemStyleManager
    {
        public Renga.ISystemStyleManager _i;
        /// <summary>
        /// Инициализация класса (получение менеджера свойств) из Проекта
        /// </summary>
        /// <param name="renga_project"></param>
        public SystemStyleManager(DynDocument.Project.Project renga_project)
        {
            this._i = renga_project._i.SystemStyleManager;
        }
        /// <summary>
        /// Получение всех стилей как интерфейсов Renga.ISystemStyleManager
        /// </summary>
        /// <returns></returns>
        public List<SystemStyle> GetSystemStyles()
        {
            List<SystemStyle> styles = new List<SystemStyle>();
            List<int> ids = this._i.GetIds().OfType<int>().ToList();
            for (int i = 0; i < ids.Count; i++)
            {
                styles.Add(new SystemStyle(this._i.GetSystemStyle(i)));
            }
            return styles;
        }
        /// <summary>
        /// Получение всех идентификаторов (int) стилей инженерных систем
        /// </summary>
        /// <returns></returns>
        public List<int> GetIds()
        {
            return this._i.GetIds().OfType<int>().ToList();
        }
        /// <summary>
        /// Получение интерфейса IEquipmentStyle по его идентификатору
        /// </summary>
        /// <param name="style_id">Численный (int) идентификатор стиля инженерных систем</param>
        /// <returns></returns>
        public SystemStyle GetEquipmentStyle(int style_id)
        {
            return new SystemStyle(this._i.GetSystemStyle(style_id));
        }
        /// <summary>
        /// Проверяет, имеется ли стиль с таким идентификатором
        /// </summary>
        /// <param name="style_id">Численный (int) идентификатор стиля инженерных систем</param>
        /// <returns></returns>
        public bool Contains(int style_id)
        {
            return this._i.Contains(style_id);
        }
    }
}
