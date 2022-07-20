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
    /// Класс для работы с менеджером свойств инженерных систем, 
    /// интерфейсом Renga.ISystemStyleManager
    /// </summary>
    public class SystemStyleManager
    {
        public Renga.ISystemStyleManager man;
        /// <summary>
        /// Получение мененджера свойств инженерных систем из Проекта
        /// </summary>
        /// <param name="renga_project"></param>
        public SystemStyleManager(DynDocument.Project.Project renga_project)
        {
            this.man = renga_project.project.SystemStyleManager;
        }
        /// <summary>
        /// Получение всех стилей как интерфейсов Renga.ISystemStyleManager
        /// </summary>
        /// <returns></returns>
        public List<object> GetSystemStyles()
        {
            List<object> styles = new List<object>();
            List<int> ids = this.man.GetIds().OfType<int>().ToList();
            for (int i = 0; i < ids.Count; i++)
            {
                styles.Add(this.man.GetSystemStyle(i));
            }
            return styles;
        }
        /// <summary>
        /// Получение всех идентификаторов (int) стилей инженерных систем
        /// </summary>
        /// <returns></returns>
        public List<int> GetIds()
        {
            return this.man.GetIds().OfType<int>().ToList();
        }
        /// <summary>
        /// Получение интерфейса IEquipmentStyle по его идентификатору
        /// </summary>
        /// <param name="style_id">Численный (int) идентификатор стиля инженерных систем</param>
        /// <returns></returns>
        public object GetEquipmentStyle(int style_id)
        {
            return this.man.GetSystemStyle(style_id);
        }
        /// <summary>
        /// Проверяет, имеется ли стиль с таким идентификатором
        /// </summary>
        /// <param name="style_id">Численный (int) идентификатор стиля инженерных систем</param>
        /// <returns></returns>
        public bool Contains(int style_id)
        {
            return this.man.Contains(style_id);
        }
    }
}
