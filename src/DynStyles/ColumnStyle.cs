using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;

namespace DynRenga.DynStyles
{
    /// <summary>
    /// Класс для работы с интерфейсом Renga.IColumnStyle, одиночным стилем колонны
    /// </summary>
    public class ColumnStyle
    {
        public Renga.IColumnStyle column_style;
        /// <summary>
        /// Инициализация класса через интерфейс Renga.IBeamStyle
        /// </summary>
        /// <param name="ColumnStyle_object"></param>
        public ColumnStyle(object ColumnStyle_object)
        {
            this.column_style = ColumnStyle_object as Renga.IColumnStyle;
        }
        /// <summary>
        /// Получение целочисленного идентификатора стиля
        /// </summary>
        /// <returns></returns>
        public int Id()
        {
            return this.column_style.Id;
        }
        /// <summary>
        /// Получение наименования стиля
        /// </summary>
        /// <returns></returns>
        public string Name()
        {
            return this.column_style.Name;
        }
        /// <summary>
        /// Получение интерфейса Renga.IProfile
        /// </summary>
        /// <returns></returns>
        public object Profile()
        {
            return this.column_style.Profile;
        }
    }
}
