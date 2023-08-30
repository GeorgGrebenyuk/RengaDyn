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
    /// Класс для работы с менеджером свойств оборудования, 
    /// интерфейсом Renga.IEquipmentStyleManager
    /// </summary>
    public class EquipmentStyleManager
    {
        public Renga.IEquipmentStyleManager _i;
        /// <summary>
        /// Инициализация класса (получение менеджера свойств) из Проекта
        /// </summary>
        /// <param name="renga_project"></param>
        public EquipmentStyleManager(DynDocument.Project.Project renga_project)
        {
            this._i = renga_project._i.EquipmentStyleManager;
        }
        /// <summary>
        /// Получение всех стилей как интерфейсов Renga.IEquipmentStyle
        /// </summary>
        /// <returns></returns>
        public List<EquipmentStyle> GetEquipmentStyles()
        {
            List<EquipmentStyle> styles = new List<EquipmentStyle>();
            List<int> ids = this._i.GetIds().OfType<int>().ToList();
            for (int i = 0; i < ids.Count; i++)
            {
                styles.Add(new EquipmentStyle(this._i.GetEquipmentStyle(i)));
            }
            return styles;
        }
        /// <summary>
        /// Получение всех идентификаторов (int) стилей оборудования
        /// </summary>
        /// <returns></returns>
        public List<int> GetIds()
        {
            return this._i.GetIds().OfType<int>().ToList();
        }
        /// <summary>
        /// Получение интерфейса IEquipmentStyle по его идентификатору
        /// </summary>
        /// <param name="style_id">Численный (int) идентификатор стиля оборудования</param>
        /// <returns></returns>
        public EquipmentStyle GetEquipmentStyle(int style_id)
        {
            return new EquipmentStyle(this._i.GetEquipmentStyle(style_id));
        }
        /// <summary>
        /// Проверяет, имеется ли стиль с таким идентификатором
        /// </summary>
        /// <param name="style_id">Численный (int) идентификатор стиля оборудования</param>
        /// <returns></returns>
        public bool Contains(int style_id)
        {
            return this._i.Contains(style_id);
        }
    }
}
