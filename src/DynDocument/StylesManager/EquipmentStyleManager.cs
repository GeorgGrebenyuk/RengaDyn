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
    /// Класс для работы с менеджером свойств оборудования, 
    /// интерфейсом Renga.IEquipmentStyleManager
    /// </summary>
    public class EquipmentStyleManager
    {
        public Renga.IEquipmentStyleManager man;
        /// <summary>
        /// Получение мененджера свойств балок из Проекта
        /// </summary>
        /// <param name="renga_project"></param>
        public EquipmentStyleManager(DynDocument.Project.Project renga_project)
        {
            this.man = renga_project.project.EquipmentStyleManager;
        }
        /// <summary>
        /// Получение всех стилей как интерфейсов Renga.IEquipmentStyle
        /// </summary>
        /// <returns></returns>
        public List<object> GetEquipmentStyles()
        {
            List<object> styles = new List<object>();
            List<int> ids = this.man.GetIds().OfType<int>().ToList();
            for (int i = 0; i < ids.Count; i++)
            {
                styles.Add(this.man.GetEquipmentStyle(i));
            }
            return styles;
        }
        /// <summary>
        /// Получение всех идентификаторов (int) стилей оборудования
        /// </summary>
        /// <returns></returns>
        public List<int> GetIds()
        {
            return this.man.GetIds().OfType<int>().ToList();
        }
        /// <summary>
        /// Получение интерфейса IEquipmentStyle по его идентификатору
        /// </summary>
        /// <param name="style_id">Численный (int) идентификатор стиля оборудования</param>
        /// <returns></returns>
        public object GetEquipmentStyle(int style_id)
        {
            return this.man.GetEquipmentStyle(style_id);
        }
        /// <summary>
        /// Проверяет, имеется ли стиль с таким идентификатором
        /// </summary>
        /// <param name="style_id">Численный (int) идентификатор стиля оборудования</param>
        /// <returns></returns>
        public bool Contains(int style_id)
        {
            return this.man.Contains(style_id);
        }
    }
}
